using System;
using System.Windows.Forms;

namespace ScreenShareApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            using (var roleForm = new RoleSelectForm())
            {
                if (roleForm.ShowDialog() == DialogResult.OK)
                {
                    string role = roleForm.SelectedRole;
                    Application.Run(new Form1(role));
                }
            }
        }
    }
}
