using System.Collections.Generic;
using System.Linq;

namespace BarcodeScanner.Core.WebCam
{
    internal class WebCam : IWebCam
    {

#region Private fields

        private WebCams _host;

        private FrameSize[] _frameSizes;

#endregion

#region Properties


        public string Name { get; }

        public string CamId { get; }

        public FrameSize FrameSize { get; internal set; }

        public bool IsStarted
        {
            get { return _host.IsStarted(this); }
        }

#endregion

#region Ctor

        public WebCam(WebCams host, string name, string camId, FrameSize[] frameSizes)
        {
            _host = host;
            Name = name;
            CamId = camId;
            _frameSizes = frameSizes;
            FrameSize defaultFrameRes = _frameSizes.FirstOrDefault(f => f.Height == 240 && f.Width == 320);
            FrameSize = defaultFrameRes.Empty ? _frameSizes.FirstOrDefault() : defaultFrameRes;
        }

#endregion

#region Class methods

        public bool Start(WebCams.WebCamFrameEventHandler newFrameCallback)
        {
            return _host.Start(this, newFrameCallback);
        }

        public bool Stop()
        {
            return _host.Stop(this);
        }

        public bool SetFrameSize(FrameSize size)
        {
            return _host.SetFrameSize(this, size);
        }

        public IEnumerable<FrameSize> EnumerateFrameSizes()
        {
            return _frameSizes;
        }

        public override string ToString()
        {
            return Name;
        }

#endregion

    }
}
