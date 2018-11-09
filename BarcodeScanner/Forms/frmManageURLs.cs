using System;
using System.Linq;
using System.Windows.Forms;

namespace BarcodeScanner.Forms
{
    public partial class frmManageURLs : Form
    {

#region Properties

        public string[] Result { get; private set; }

#endregion

#region Ctor

        public frmManageURLs()
        {
            InitializeComponent();
        }

#endregion

#region Class methods

        public bool Execute(string urls)
        {
            tbURLs.Text = urls ?? string.Empty;
            btnOk.Select();
            return ShowDialog() == DialogResult.OK;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Result = tbURLs.Text.Trim().
                Split(new [] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries).
                Select(s => s.Trim()).
                ToArray();
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void frmManageURLs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
            }
        }

#endregion

    }
}
