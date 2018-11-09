using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace BarcodeScanner.Controls
{
    public class BarcodeRenderer : Control
    {

#region Private fields

        private Graphics _buffer;
        private Bitmap _bufferBitmap;
        private Graphics _controlGraphics;
        private Bitmap _currentFrame;
        private Bitmap _lastRenderedFrame;

        private int[] _fpsCounterData;
        private int _fpsCounterArrIdx;
        private int _fpsCounterArrCnt;
        private Brush _fpsFontBrush;
        private DateTime _lastFrameRenderTime;

        private volatile bool _repainting;
        private object _syncPaint = new object();

#endregion

#region Properties

        #region Hidden

        [DefaultValue(null), Browsable(false)]
        public new string Text { get; set; }

        [Browsable(false)]
        public new bool TabStop { get; set; }

        [Browsable(false)]
        public new int TabIndex { get; set; }

        [Browsable(false)]
        public new Padding Padding
        {
            get { return base.Padding; }
            set
            {
                base.Padding = value;
            }
        }

        [Browsable(false)]
        public new Image BackgroundImage { get; set; }

        [Browsable(false)]
        public new ImageLayout BackgroundImageLayout { get; set; }

        [Browsable(false)]
        public new bool AutoSize { get; set; }

        #endregion

        private new bool DesignMode
        {
            get { return base.DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime; }
        }

#endregion

#region Ctor

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle &= 0x02000000;
                return cp;
            }
        }

        public BarcodeRenderer()
        {
            if (!DesignMode)
            {
                SetStyle(ControlStyles.Opaque, true);
                SetStyle(ControlStyles.Selectable, false);

                InitializeEnvironment();
            }
        }

#endregion

#region Renderer

        private void DestroyGraphics()
        {
            if (_bufferBitmap != null)
            {
                _buffer.Dispose();
                _bufferBitmap.Dispose();
                _controlGraphics.Dispose();
                _lastRenderedFrame = null;
                _bufferBitmap = null;
            }
        }

        private void InitializeGraphics()
        {
            if (Width != 0 && Height != 0)
            {
                _bufferBitmap = new Bitmap(Width, Height);

                _buffer = Graphics.FromImage(_bufferBitmap);
                _buffer.CompositingQuality = CompositingQuality.HighSpeed;
                _buffer.InterpolationMode = InterpolationMode.Low;
                _buffer.SmoothingMode = SmoothingMode.HighSpeed;

                _controlGraphics = Graphics.FromHwnd(Handle);
                _controlGraphics.CompositingQuality = CompositingQuality.HighSpeed;
                _controlGraphics.InterpolationMode = InterpolationMode.Low;
                _controlGraphics.SmoothingMode = SmoothingMode.HighSpeed;
            }
        }

        private void DrawBackground()
        {
            _buffer.FillRectangle(Brushes.Black, ClientRectangle);
        }

        private void DrawFrame()
        {
            if (_currentFrame == null) return;

            SizeF newFrameSize = new SizeF(_currentFrame.Size);
            PointF newFramePos = new PointF();

            float ratio;
            if (_currentFrame.Width - ClientSize.Width >= _currentFrame.Height - ClientSize.Height)
            {
                ratio = (float) _currentFrame.Width / ClientSize.Width;
                newFrameSize = new SizeF(ClientSize.Width, _currentFrame.Height / ratio);
                newFramePos = new PointF(0, (ClientSize.Height - newFrameSize.Height) / 2f);
            }
            else
            {
                ratio = (float)_currentFrame.Height / ClientSize.Height;
                newFrameSize = new SizeF(_currentFrame.Width / ratio, ClientSize.Height);
                newFramePos = new PointF((ClientSize.Width - newFrameSize.Width) / 2f, 0);
            }

            _buffer.DrawImage(_currentFrame, newFramePos.X, newFramePos.Y, newFrameSize.Width, newFrameSize.Height);
        }

        private void DrawFps()
        {
            int sum = _fpsCounterData.Sum();
            int avg = sum != 0 ? sum / _fpsCounterArrCnt : 0;
            int curFps = avg != 0 ? (int)Math.Ceiling(1000f / avg) : 0;
            string fps = string.Format("{0} FPS", curFps);
            _buffer.DrawString(fps, Font, _fpsFontBrush, 10, 10);
        }

        private void Repaint()
        {
            if (_repainting) return;

            lock (_syncPaint)
            {
                bool canvasResized = _bufferBitmap == null || _bufferBitmap.Width != Width || _bufferBitmap.Height != Height;

                if (_repainting || 
                    _lastRenderedFrame != null && _lastRenderedFrame == _currentFrame && !canvasResized) return;

                _repainting = true;

                _lastRenderedFrame = _currentFrame;

                if (canvasResized)
                {
                    DestroyGraphics();
                    InitializeGraphics();
                }

                if (_bufferBitmap != null)
                {
                    DrawBackground();
                    DrawFrame();
                    DrawFps();
                    _controlGraphics.DrawImage(_bufferBitmap, ClientRectangle, ClientRectangle, GraphicsUnit.Pixel);
                }

                _repainting = false;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (!DesignMode)
            {
                Repaint();
            }
            else
            {
                base.OnPaint(e);
            }
        }

#endregion

#region Class methods

        private void InitializeEnvironment()
        {
            _fpsCounterData = new int[10];
            _fpsFontBrush = new SolidBrush(Color.White);
        }

        public void Render(Bitmap bitmap)
        {
            lock (_syncPaint)
            {
                if (_lastFrameRenderTime != default(DateTime))
                {
                    _fpsCounterArrCnt = Math.Min(_fpsCounterArrCnt + 1, _fpsCounterData.Length);
                    _fpsCounterArrIdx = _fpsCounterArrIdx < _fpsCounterData.Length - 1
                        ? _fpsCounterArrIdx + 1
                        : 0;
                    _fpsCounterData[_fpsCounterArrIdx] =  (int)DateTime.UtcNow.Subtract(_lastFrameRenderTime).TotalMilliseconds;
                }

                _lastFrameRenderTime = DateTime.UtcNow;

                _currentFrame?.Dispose();
                _currentFrame = (Bitmap) bitmap.Clone();
                Invalidate(false);
            }
        }

#endregion

    }
}
