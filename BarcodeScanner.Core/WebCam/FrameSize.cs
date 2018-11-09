using System.Drawing;

namespace BarcodeScanner.Core.WebCam
{
    public struct FrameSize
    {
        public int Width;
        public int Height;

        public bool Empty
        {
            get { return Width == 0 && Height == 0; }
        }

        public FrameSize(Size size)
        {
            Width = size.Width;
            Height = size.Height;
        }

        public FrameSize(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public bool Equals(Size size)
        {
            return size.Width == Width && size.Height == Height;
        }

        public override string ToString()
        {
            return string.Format("{0} x {1}", Width, Height);
        }
    }
}
