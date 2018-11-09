using System.Drawing;

namespace BarcodeDriver.API
{
    public interface IBarcodeDriver
    {
        string Name { get; }

        string SupportFormats { get; }

        string Recognize(Bitmap bitmap);
    }
}
