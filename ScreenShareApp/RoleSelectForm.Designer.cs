namespace ScreenShareApp
{
    partial class RoleSelectForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Button btnLucas;
        private Button btnValentin;
        private Label lblTitle;


        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {

            btnLucas = new Button();
            btnValentin = new Button();
            lblTitle = new Label();
            SuspendLayout();

            // Titre
            lblTitle.Text = "Qui êtes-vous ?";
            lblTitle.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Height = 60;
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // Bouton Lucas
            btnLucas.Text = "👨 Lucas (partager)";
            btnLucas.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnLucas.BackColor = Color.DodgerBlue;
            btnLucas.ForeColor = Color.White;
            btnLucas.Size = new Size(200, 50);
            btnLucas.Location = new Point(50, 100);
            btnLucas.Click += btnLucas_Click;

            // Bouton Valentin
            btnValentin.Text = "👀 Valentin (voir)";
            btnValentin.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnValentin.BackColor = Color.FromArgb(80, 80, 120);
            btnValentin.ForeColor = Color.White;
            btnValentin.Size = new Size(200, 50);
            btnValentin.Location = new Point(270, 100);
            btnValentin.Click += btnValentin_Click;

            // Fenêtre
            BackColor = Color.FromArgb(25, 25, 35);
            ClientSize = new Size(520, 200);
            Controls.Add(lblTitle);
            Controls.Add(btnLucas);
            Controls.Add(btnValentin);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Text = "Sélection du rôle";
            ResumeLayout(false);


            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "RoleSelectForm";
        }

        #endregion
    }
}