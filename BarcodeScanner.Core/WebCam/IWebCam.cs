using System.Collections.Generic;

namespace BarcodeScanner.Core.WebCam
{
    public interface IWebCam
    {
        string Name { get; }

        FrameSize FrameSize { get; }

        bool IsStarted { get; }

        bool Start(WebCams.WebCamFrameEventHandler newFrameCallback);

        bool Stop();

        IEnumerable<FrameSize> EnumerateFrameSizes();

        bool SetFrameSize(FrameSize size);
    }
}
