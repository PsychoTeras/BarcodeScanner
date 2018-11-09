using System;
using System.Windows.Forms;

namespace BarcodeScanner.Forms
{
    public partial class frmLogin : Form
    {
        public string Result { get; private set; }

        public frmLogin()
        {
            InitializeComponent();
            tbUserName.Select();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string userName = tbUserName.Text;
            if (string.IsNullOrWhiteSpace(userName))
            {
                MessageBox.Show("User name is empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Result = userName.Trim();
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    DialogResult = DialogResult.Cancel;
                    break;
                case Keys.Enter:
                    btnOk_Click(btnOk, e);
                    break;
            }
        }
    }
}
