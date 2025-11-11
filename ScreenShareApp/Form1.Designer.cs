namespace ScreenShareApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTitle = new Label();
            picValentin = new PictureBox();
            panelLucas = new Panel();
            btnShareLucas = new Button();
            lblStatusLucas = new Label();
            panelValentin = new Panel();
            btnShareValentin = new Button();
            lblStatusValentin = new Label();
            picLucas = new PictureBox();
            txtIp = new TextBox();
            numPort = new NumericUpDown();
            btnConnect = new Button();
            ((System.ComponentModel.ISupportInitialize)picValentin).BeginInit();
            panelLucas.SuspendLayout();
            panelValentin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLucas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPort).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            lblTitle.ForeColor = Color.LightSkyBlue;
            lblTitle.Location = new Point(10, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Padding = new Padding(10, 15, 10, 15);
            lblTitle.Size = new Size(201, 55);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "🎥 Partage d’écran";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // picValentin
            // 
            picValentin.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            picValentin.BackColor = Color.FromArgb(30, 30, 45);
            picValentin.BorderStyle = BorderStyle.FixedSingle;
            picValentin.Location = new Point(14, 106);
            picValentin.Name = "picValentin";
            picValentin.Size = new Size(1253, 581);
            picValentin.SizeMode = PictureBoxSizeMode.StretchImage;
            picValentin.TabIndex = 0;
            picValentin.TabStop = false;
            // 
            // panelLucas
            // 
            panelLucas.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            panelLucas.BackColor = Color.FromArgb(25, 25, 35);
            panelLucas.Controls.Add(btnShareLucas);
            panelLucas.Controls.Add(lblStatusLucas);
            panelLucas.Location = new Point(13, 716);
            panelLucas.Name = "panelLucas";
            panelLucas.Size = new Size(350, 90);
            panelLucas.TabIndex = 2;
            // 
            // btnShareLucas
            // 
            btnShareLucas.BackColor = Color.FromArgb(30, 144, 255);
            btnShareLucas.FlatStyle = FlatStyle.Flat;
            btnShareLucas.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnShareLucas.ForeColor = Color.White;
            btnShareLucas.Location = new Point(20, 10);
            btnShareLucas.Name = "btnShareLucas";
            btnShareLucas.Size = new Size(230, 40);
            btnShareLucas.TabIndex = 0;
            btnShareLucas.Text = "Partager écran (Lucas)";
            btnShareLucas.UseVisualStyleBackColor = false;
            btnShareLucas.Click += btnShareLucas_ClickAsync;
            // 
            // lblStatusLucas
            // 
            lblStatusLucas.AutoSize = true;
            lblStatusLucas.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblStatusLucas.ForeColor = Color.Gray;
            lblStatusLucas.Location = new Point(25, 55);
            lblStatusLucas.Name = "lblStatusLucas";
            lblStatusLucas.Size = new Size(85, 15);
            lblStatusLucas.TabIndex = 1;
            lblStatusLucas.Text = "⏸️ En attente...";
            // 
            // panelValentin
            // 
            panelValentin.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            panelValentin.BackColor = Color.FromArgb(25, 25, 35);
            panelValentin.Controls.Add(btnShareValentin);
            panelValentin.Controls.Add(lblStatusValentin);
            panelValentin.Location = new Point(917, 716);
            panelValentin.Name = "panelValentin";
            panelValentin.Size = new Size(350, 90);
            panelValentin.TabIndex = 3;
            // 
            // btnShareValentin
            // 
            btnShareValentin.BackColor = Color.FromArgb(60, 60, 85);
            btnShareValentin.FlatStyle = FlatStyle.Flat;
            btnShareValentin.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnShareValentin.ForeColor = Color.White;
            btnShareValentin.Location = new Point(20, 10);
            btnShareValentin.Name = "btnShareValentin";
            btnShareValentin.Size = new Size(230, 40);
            btnShareValentin.TabIndex = 0;
            btnShareValentin.Text = "Partager écran (Valentin)";
            btnShareValentin.UseVisualStyleBackColor = false;
            btnShareValentin.Click += btnShareValentin_ClickAsync;
            // 
            // lblStatusValentin
            // 
            lblStatusValentin.AutoSize = true;
            lblStatusValentin.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblStatusValentin.ForeColor = Color.Gray;
            lblStatusValentin.Location = new Point(25, 55);
            lblStatusValentin.Name = "lblStatusValentin";
            lblStatusValentin.Size = new Size(85, 15);
            lblStatusValentin.TabIndex = 1;
            lblStatusValentin.Text = "⏸️ En attente...";
            // 
            // picLucas
            // 
            picLucas.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            picLucas.BackColor = Color.FromArgb(40, 40, 60);
            picLucas.BorderStyle = BorderStyle.FixedSingle;
            picLucas.Location = new Point(937, 492);
            picLucas.Name = "picLucas";
            picLucas.Size = new Size(320, 180);
            picLucas.SizeMode = PictureBoxSizeMode.StretchImage;
            picLucas.TabIndex = 1;
            picLucas.TabStop = false;
            // 
            // txtIp
            // 
            txtIp.ForeColor = Color.Black;
            txtIp.Location = new Point(40, 70);
            txtIp.Name = "txtIp";
            txtIp.PlaceholderText = "Adresse IP (ex: 192.168.1.42)";
            txtIp.Size = new Size(180, 25);
            txtIp.TabIndex = 4;
            txtIp.Text = "127.0.0.1";
            // 
            // numPort
            // 
            numPort.Location = new Point(210, 20);
            numPort.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            numPort.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numPort.Name = "numPort";
            numPort.Size = new Size(80, 25);
            numPort.TabIndex = 5;
            numPort.Value = new decimal(new int[] { 5555, 0, 0, 0 });
            // 
            // btnConnect
            // 
            btnConnect.BackColor = Color.FromArgb(60, 60, 85);
            btnConnect.FlatStyle = FlatStyle.Flat;
            btnConnect.ForeColor = Color.White;
            btnConnect.Location = new Point(300, 20);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(120, 30);
            btnConnect.TabIndex = 6;
            btnConnect.Text = "Se connecter";
            btnConnect.UseVisualStyleBackColor = false;
            btnConnect.Click += btnConnect_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 20, 30);
            ClientSize = new Size(1280, 819);
            Controls.Add(panelValentin);
            Controls.Add(panelLucas);
            Controls.Add(picLucas);
            Controls.Add(picValentin);
            Controls.Add(lblTitle);
            Controls.Add(txtIp);
            Controls.Add(numPort);
            Controls.Add(btnConnect);
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 10F);
            ForeColor = Color.WhiteSmoke;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            Padding = new Padding(10);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "🔗 ScreenShare - Client";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)picValentin).EndInit();
            panelLucas.ResumeLayout(false);
            panelLucas.PerformLayout();
            panelValentin.ResumeLayout(false);
            panelValentin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLucas).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPort).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private PictureBox picValentin;
        private Panel panelLucas;
        private Panel panelValentin;
        private Button btnShareLucas;
        private Button btnShareValentin;
        private Label lblStatusLucas;
        private Label lblStatusValentin;
        private PictureBox picLucas;
        private TextBox txtIp;
        private NumericUpDown numPort;
        private Button btnConnect;
    }
}
