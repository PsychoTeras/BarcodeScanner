using BarcodeDriver.API;
using BarcodeScanner.Core.BarcodeDriver;
using BarcodeScanner.Core.WebAPI;
using BarcodeScanner.Core.WebCam;
using IPCLogger.Core.Common;
using IPCLogger.Core.Loggers.LFactory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarcodeScanner.Forms
{
    public partial class frmMain : Form
    {

#region Private fields

        private WebCams _webCams;
        private bool _isScanning;
        private string _lastScannedBarcode;

        private IBarcodeDriver _barcodeDriver;
        private Bitmap _currentBarcodeImage;
        private volatile bool _isBarcodeScanned;
        private AutoResetEvent _reTimeToScanBarcode = new AutoResetEvent(false);

        private string _selectedEndpointURL;

        private bool _initializing = true;

#endregion

#region Properties

        public string CurrentUser { get; private set; }

        public IWebCam SelectedCamera
        {
            get { return cbCamera.SelectedItem as IWebCam; }
        }

        public FrameSize? SelectedFrameSize
        {
            get { return cbCameraFrameSizes.SelectedItem as FrameSize?; }
        }

#endregion

#region Ctor

        public frmMain()
        {
            InitializeComponent();

            DoLogin();
        }

#endregion

#region Class methods

        private void WriteLog(string message, bool isSubMessage = false, bool newLine = true)
        {
            Invoke(new Action(() => 
            {
                LFactory.Instance.WriteLine(LogEvent.Info, message);

                if (isSubMessage)
                {
                    message = string.Format("  - {0}", message);
                }
                tbLogs.AppendText(string.Format("{0}{1}",
                    newLine && tbLogs.Text.Length > 0 ? Environment.NewLine : string.Empty,
                    message));
                tbLogs.SelectionStart = tbLogs.Text.Length;
                tbLogs.ScrollToCaret();
            }));
        }

        private void WriteLog(string message, Exception ex)
        {
            Invoke(new Action(() =>
            {
                LFactory.Instance.WriteLine(LogEvent.Error, ex, message);

                message = string.Format("ERROR: {0}. {1}", message, ex.Message);
                tbLogs.AppendText(string.Format("{0}{1}",
                    tbLogs.Text.Length > 0 ? Environment.NewLine : string.Empty,
                    message));
                tbLogs.SelectionStart = tbLogs.Text.Length;
                tbLogs.ScrollToCaret();
            }));
        }

        private void DoLogin()
        {
            using (frmLogin form = new frmLogin())
            {
                if (form.ShowDialog() != DialogResult.OK)
                {
                    Process.GetCurrentProcess().Kill();
                }

                CurrentUser = form.Result;
                Text = string.Format("{0}, {1}", Text, CurrentUser);

                LFactory.Instance.WriteLine(LogEvent.Debug, "".PadRight(75, '='));
                LFactory.Instance.WriteLine(LogEvent.Info, string.Format("User '{0}' was logged in", CurrentUser));
            }
        }

        private bool InitializeDevices()
        {
            try
            {
                WriteLog("Initialize barcode drivers... ");
                BarcodeDriverFactory driverFactory = new BarcodeDriverFactory();
                driverFactory.LoadDrivers(Properties.Settings.Default.Drivers.OfType<string>().ToArray(), (s, ex) =>
                {
                    WriteLog(string.Format("Failed to load driver library '{0}'", s), ex);
                });

                cbBarcodeDriver.DataSource = driverFactory.Drivers;

                if (driverFactory.Drivers.Count > 0)
                {
                    WriteLog(driverFactory.Drivers.Count + " camera(s) found:", false, false);

                    foreach (IBarcodeDriver driver in driverFactory.Drivers)
                    {
                        WriteLog(driver.Name, true);
                    }
                }
                else
                {
                    WriteLog("no barcode drivers loaded", false, false);
                    return false;
                }

                WriteLog("Prepare camera... ");
                IEnumerable<IWebCam> devices = (_webCams = new WebCams()).EnumerateDevices();
                cbCamera.DataSource = devices;

                if (cbCamera.Items.Count > 0)
                {
                    WriteLog(cbCamera.Items.Count + " camera(s) found:", false, false);
                    foreach (IWebCam webCam in devices)
                    {
                        WriteLog(webCam.Name, true);
                    }

                    return true;
                }

                WriteLog(" no camera detected", false, false);
            }
            catch (Exception ex)
            {
                WriteLog("Failed to initialize devices", ex);
            }

            return false;
        }

        private void LoadSettings(string userName = "default")
        {
            try
            {
                WriteLog(string.Format("Load settings for user '{0}'... ", userName));

                cbCamera.SelectedIndex = 0;
                cbEndpointURLs.SelectedIndex = 0;

                WriteLog("done", false, false);
            }
            catch (Exception ex)
            {
                WriteLog("Failed to load user settings", ex);
            }
        }

        private void ApplySetting()
        {
            bool isScanning = _isScanning;
            StopScanning();
            StopCamera();
            ApplyCameraSettings();
            StartCamera();
            if (isScanning)
            {
                StartScanning();
            }
        }

        private void ApplyCameraSettings()
        {
            try
            {
                FrameSize? frameSize = SelectedFrameSize;
                if (frameSize.HasValue)
                {
                    SelectedCamera.SetFrameSize(frameSize.Value);
                    WriteLog("New camera settings applied:");
                    WriteLog(string.Format("camera: {0}", SelectedCamera), true);
                    WriteLog(string.Format("frame size: {0}", SelectedFrameSize), true);
                }
                else
                {
                    string msg = SelectedCamera == null
                        ? "camera is not selected"
                        : "frame size is not selected";
                    WriteLog(string.Format("Can't apply camera settings: {0}", msg));
                }
            }
            catch (Exception ex)
            {
                WriteLog("Failed to apply camera settings", ex);
            }
            finally
            {
                UpdateUIControls();
            }
        }

        private async void SendBarcodeToServer(string scannedBarcode)
        {
            if (!string.IsNullOrEmpty(scannedBarcode) && !string.IsNullOrEmpty(_selectedEndpointURL))
            {
                try
                {
                    AztecCodeREST rest = new AztecCodeREST(_selectedEndpointURL);
                    string response = await rest.PostAztecCodeRequestAsync(CurrentUser, scannedBarcode);
                    WriteLog(string.Format("Server response: '{0}'", response));
                }
                catch (Exception ex)
                {
                    WriteLog("Failed sent barcode to server", ex);
                }
            }
        }

        private void BarcodeScanProc()
        {
            while (Thread.CurrentThread.IsAlive)
            {
                _reTimeToScanBarcode.WaitOne();

                if (_isScanning)
                {
                    using (_currentBarcodeImage)
                    {
                        string scannedBarcode = TryScanBarcode(_currentBarcodeImage);
                        SendBarcodeToServer(scannedBarcode);
                    }
                }

                _isBarcodeScanned = true;
            }
        }

        private string TryScanBarcode(Bitmap bitmap)
        {
            try
            {
                string scannedBarcode = _barcodeDriver?.Recognize(bitmap);
                if (!string.IsNullOrWhiteSpace(scannedBarcode) && _lastScannedBarcode != scannedBarcode)
                {
                    WriteLog(string.Format("Barcode was recognized: '{0}'", scannedBarcode));
                    return _lastScannedBarcode = scannedBarcode;
                }
            }
            catch (Exception ex)
            {
                WriteLog("Failed to scan barcode", ex);
                StopScanning();
            }

            return null;
        }

        private void StartCamera()
        {
            try
            {
                if (SelectedCamera != null && SelectedCamera.Start((sender, bitmap) =>
                {
                    barcodeRenderer.Render(bitmap);
                    if (_isScanning && _isBarcodeScanned)
                    {
                        _isBarcodeScanned = false;
                        _currentBarcodeImage = (Bitmap)bitmap.Clone();
                        _reTimeToScanBarcode.Set();
                    }
                }))
                {
                    WriteLog(string.Format("Camera '{0}' was started", SelectedCamera));
                }
            }
            catch (Exception ex)
            {
                WriteLog("Failed to start camera", ex);
            }
            finally
            {
                UpdateUIControls();
            }
        }

        private void StopCamera()
        {
            try
            {
                if (_webCams.StopAll())
                {
                    WriteLog("Camera was stopped");
                }
            }
            catch (Exception ex)
            {
                WriteLog("Failed to stop camera", ex);
            }
            finally
            {
                UpdateUIControls();
            }
        }

        private void StartScanning()
        {
            if (_isScanning) return;

            try
            {
                BackColor = Color.LemonChiffon;
                WriteLog("Scanning was started");
                _isBarcodeScanned = _isScanning = true;
            }
            catch (Exception ex)
            {
                WriteLog("Failed to start scanning", ex);
            }
            finally
            {
                UpdateUIControls();
            }
        }

        private void StopScanning()
        {
            if (!_isScanning) return;

            try
            {
                BackColor = Color.White;
                _lastScannedBarcode = null;
                _isScanning = false;
                WriteLog("Scanning was stopped");
            }
            catch (Exception ex)
            {
                WriteLog("Failed to stop scanning", ex);
            }
            finally
            {
                UpdateUIControls();
            }
        }

        private void ManageEndpointURLs()
        {
            try
            {
                bool isScanning = _isScanning;
                StopScanning();

                string data = cbEndpointURLs.Items.Count > 1
                    ? cbEndpointURLs.Items.OfType<string>().Aggregate((i, j) => i + Environment.NewLine + j)
                    : cbEndpointURLs.Items.OfType<string>().FirstOrDefault() ?? string.Empty;
                using (frmManageURLs form = new frmManageURLs())
                {
                    if (!form.Execute(data))
                    {
                        if (isScanning)
                        {
                            StartScanning();
                        }
                        return;
                    }

                    string oldUrl = _selectedEndpointURL?.ToLower();
                    cbEndpointURLs.DataSource = form.Result;

                    string existingUrl = form.Result.FirstOrDefault(s => s.ToLower() == oldUrl);
                    if (existingUrl != null)
                    {
                        cbEndpointURLs.SelectedItem = existingUrl;
                        if (isScanning)
                        {
                            StartScanning();
                        }
                    }
                    else if (isScanning)
                    {
                        WriteLog("WARNING: please select desired endpoint URL and restart scanning");
                    }

                    WriteLog("Endpoint URLs were changed");
                }
            }
            catch (Exception ex)
            {
                WriteLog("Failed to edit endpoint URLs", ex);
            }
        }

#endregion

#region Form controls event handlers

        private void UpdateUIControls()
        {
            btnStart.Enabled = SelectedCamera != null && !_isScanning;
            btnStop.Enabled = SelectedCamera != null && _isScanning;
        }

        private void FrmMainLoad(object sender, EventArgs e)
        {
            try
            {
                if (InitializeDevices())
                {
                    LoadSettings();

                    _initializing = false;

                    ApplySetting();

                    Task.Factory.StartNew(BarcodeScanProc, TaskCreationOptions.LongRunning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Critical error occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Process.GetCurrentProcess().Kill();
            }
        }

        private void FrmMainActivated(object sender, EventArgs e)
        {
            tbLogs.SelectionStart = tbLogs.Text.Length;
            tbLogs.ScrollToCaret();
        }

        private void FrmMainFormClosing(object sender, FormClosingEventArgs e)
        {
            StopScanning();
            StopCamera();
            _webCams.Dispose();
        }

        private void BtnSettingsClick(object sender, EventArgs e)
        {
            tcMain.SelectedIndex = 1;
        }

        private void CbBarcodeDriverSelectedIndexChanged(object sender, EventArgs e)
        {
            _barcodeDriver = cbBarcodeDriver.SelectedItem as IBarcodeDriver;
            tbDriverFormats.Text = _barcodeDriver?.SupportFormats ?? string.Empty;
            if (!_initializing)
            {
                ApplySetting();
            }
        }

        private void CbCameraSelectedIndexChanged(object sender, EventArgs e)
        {
            cbCameraFrameSizes.DataSource = SelectedCamera.EnumerateFrameSizes();
            cbCameraFrameSizes.SelectedItem = SelectedCamera.FrameSize;
        }

        private void CbCameraFrameSizesSelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_initializing)
            {
                ApplySetting();
            }
        }

        private void BtnStartClick(object sender, EventArgs e)
        {
            StartScanning();
        }

        private void BtnStopClick(object sender, EventArgs e)
        {
            StopScanning();
        }

        private void CbEndpointURLsButtonClick(object sender, EventArgs e)
        {
            ManageEndpointURLs();
        }

        private void cbEndpointURLs_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedEndpointURL = cbEndpointURLs.SelectedItem?.ToString();
        }

#endregion

    }
}
