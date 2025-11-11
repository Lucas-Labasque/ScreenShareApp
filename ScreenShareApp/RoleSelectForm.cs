using System;
using System.Windows.Forms;

namespace ScreenShareApp
{
    public partial class RoleSelectForm : Form
    {
        public string SelectedRole { get; private set; } = "";

        public RoleSelectForm()
        {
            InitializeComponent();
        }

        private void btnLucas_Click(object sender, EventArgs e)
        {
            SelectedRole = "HOST";
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnValentin_Click(object sender, EventArgs e)
        {
            SelectedRole = "VIEWER";
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
