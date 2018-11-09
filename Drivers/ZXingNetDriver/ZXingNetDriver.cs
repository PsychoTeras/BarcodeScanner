using BarcodeDriver.API;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using ZXing;
using ZXing.Common;

namespace ZXingNetDriver
{
    public class ZXingNetDriver : IBarcodeDriver
    {
        private BarcodeReader _reader = new BarcodeReader
        {
            AutoRotate = true,
            Options = new DecodingOptions {TryHarder = true, PossibleFormats = new List<BarcodeFormat>
            {
                BarcodeFormat.AZTEC,
                BarcodeFormat.QR_CODE
            }}
        };

        public string Name
        {
            get { return "ZXing.Net based driver"; }
        }

        public string SupportFormats { get; }

        public ZXingNetDriver()
        {
            SupportFormats = _reader.Options.PossibleFormats.Count > 1
                ? _reader.Options.PossibleFormats.OrderBy(i => i).Select(i => i.ToString()).Aggregate((i, j) => i + ", " + j)
                : _reader.Options.PossibleFormats.FirstOrDefault().ToString();
        }

        public string Recognize(Bitmap bitmap)
        {
            Result result = _reader.Decode(bitmap);
            return !string.IsNullOrWhiteSpace(result?.Text) ? result.Text.Trim() : null;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
