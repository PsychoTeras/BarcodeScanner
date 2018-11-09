using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace BarcodeScanner.Core.WebCam
{
    public sealed class WebCams : IDisposable
    {

#region Delegates

        public delegate void WebCamFrameEventHandler(IWebCam sender, Bitmap bitmap);

#endregion

#region Private fields

        private WebCam[] _webCams;
        private Dictionary<IWebCam, VideoCaptureDevice> _capturingCams;

        private object _objSync;
	    private bool _disposed;

#endregion

#region Ctor

        public WebCams()
        {
            _objSync = new object();

            RefreshDevices();
        }

#endregion

#region Class methods

        private void AssertDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(nameof(WebCams));
            }
        }

        public void RefreshDevices()
        {
            StopAll();

            lock (_objSync)
            {
                _webCams = new FilterInfoCollection(FilterCategory.VideoInputDevice).
                    OfType<FilterInfo>().
                    Select(fi =>
                    {
                        VideoCaptureDevice vdc = new VideoCaptureDevice(fi.MonikerString);
                        IEnumerable<FrameSize> frameSizes = vdc.VideoCapabilities.Select(vc => new FrameSize(vc.FrameSize));
                        return new WebCam(this, fi.Name, fi.MonikerString, frameSizes.ToArray());
                    }).
                    ToArray();
                _capturingCams = new Dictionary<IWebCam, VideoCaptureDevice>();
            }
        }

        public IEnumerable<IWebCam> EnumerateDevices()
        {
            lock (_objSync)
            {
                AssertDisposed();
                return _webCams;
            }
        }

        public bool IsStarted(IWebCam webCam)
        {
            VideoCaptureDevice vdc;
            return webCam != null && _capturingCams.TryGetValue(webCam, out vdc) && vdc.IsRunning;
        }

        public bool Start(IWebCam webCam, WebCamFrameEventHandler newFrameCallback)
        {
            lock (_objSync)
            {
                AssertDisposed();

                VideoCaptureDevice vcd;
                if (webCam == null || _capturingCams.TryGetValue(webCam, out vcd)) return false;

                vcd = new VideoCaptureDevice(((WebCam)webCam).CamId);
                vcd.NewFrame += (sender, args) => 
                {
                    newFrameCallback?.Invoke(webCam, args.Frame);
                };
                vcd.VideoResolution = vcd.VideoCapabilities.FirstOrDefault(vc => webCam.FrameSize.Equals(vc.FrameSize));
                vcd.Start();

                _capturingCams.Add(webCam, vcd);

                return true;
            }
        }

        private bool InternalStop(IWebCam webCam)
        {
            VideoCaptureDevice vcd;
            if (webCam == null || !_capturingCams.TryGetValue(webCam, out vcd)) return false;

            if (vcd.IsRunning)
            {
                vcd.SignalToStop();
                vcd.WaitForStop();
            }

            return true;
        }

        public bool Stop(IWebCam webCam)
        {
            lock (_objSync)
            {
                AssertDisposed();

                if (InternalStop(webCam))
                {
                    _capturingCams.Remove(webCam);
                    return true;
                }

                return false;
            }
        }

        public bool StopAll()
        {
            lock (_objSync)
            {
                AssertDisposed();

                bool someoneStopped = false;
                if (_capturingCams != null)
                {
                    Array.ForEach(_capturingCams.Keys.ToArray(), o => someoneStopped |= InternalStop(o));
                    _capturingCams = new Dictionary<IWebCam, VideoCaptureDevice>();
                }

                return someoneStopped;
            }
        }

        public bool SetFrameSize(IWebCam webCam, FrameSize size)
        {
            lock (_objSync)
            {
                AssertDisposed();

                if (webCam == null) return false;

                ((WebCam) webCam).FrameSize = size;

                VideoCaptureDevice vcd;
                if (_capturingCams.TryGetValue(webCam, out vcd))
                {
                    vcd.VideoResolution = vcd.VideoCapabilities.FirstOrDefault(vc => size.Equals(vc.FrameSize));
                }

                return true;
            }
        }

#endregion

#region IDisposable

        private void FreeResources()
        {
            foreach (VideoCaptureDevice vcd in _capturingCams.Values)
            {
                if (vcd.IsRunning)
                {
                    vcd.SignalToStop();
                }
            }
        }

        public void Dispose()
        {
            lock (_objSync)
            {
                if (_disposed) return;
                _disposed = true;
            }

            FreeResources();
            GC.SuppressFinalize(this);
        }

        ~WebCams()
        {
            FreeResources();
        }

#endregion

    }
}
