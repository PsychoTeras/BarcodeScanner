using System.Windows.Forms;

namespace BarcodeScanner.Controls
{
    public class BorderedComboBox : ComboBox
    {
        public BorderedComboBox()
        {
            FlatStyle = FlatStyle.Flat;
        }

        protected override void WndProc(ref Message m)
        {
            if (DesignMode || !DrawingHelper.WndProcTextBoxControl(this, m, true))
            {
                base.WndProc(ref m);
            }
        }
    }
}
