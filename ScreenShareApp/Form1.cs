using System.Net.Sockets;
using System.Diagnostics;
using SkiaSharp;
using System.Diagnostics;
using System.Data;


namespace ScreenShareApp
{
    public partial class Form1 : Form
    {
        private string _role;


        TcpClient? clientLucas;
        TcpClient? clientValentin;
        NetworkStream? streamLucas;
        NetworkStream? streamValentin;

        bool isSharingLucas = false;
        bool isSharingValentin = false;

        Thread? threadSendLucas;
        Thread? threadReceiveValentin;

        public Form1(string role)
        {
            InitializeComponent();
            _role = role;
        }

        #region load
        private void Form1_Load(object sender, EventArgs e)
        {
            if (_role == "HOST")
            {
                lblStatusLucas.Text = "Vous êtes Lucas (partage)";
                btnShareLucas.Enabled = true;
                btnShareValentin.Enabled = false;
            }
            else
            {
                lblStatusValentin.Text = "Vous êtes Valentin (visionnage)";
                btnShareLucas.Enabled = false;
                btnShareValentin.Enabled = true;
            }

            BringUiToFront();

            // reposition dynamique à chaque redimensionnement
            this.Resize += (s, ev) => BringUiToFront();

            // Hover effets
            btnShareLucas.MouseEnter += (s, ev) => btnShareLucas.BackColor = Color.FromArgb(60, 160, 255);
            btnShareLucas.MouseLeave += (s, ev) => btnShareLucas.BackColor = Color.FromArgb(30, 144, 255);

            btnShareValentin.MouseEnter += (s, ev) => btnShareValentin.BackColor = Color.FromArgb(80, 80, 120);
            btnShareValentin.MouseLeave += (s, ev) => btnShareValentin.BackColor = Color.FromArgb(60, 60, 85);
        }

        private void BringUiToFront()
        {
            // reposition dynamique
            picLucas.Location = new Point(ClientSize.Width - picLucas.Width - 40, ClientSize.Height - picLucas.Height - 140);
            panelLucas.Location = new Point(20, ClientSize.Height - panelLucas.Height - 20);
            panelValentin.Location = new Point(ClientSize.Width - panelValentin.Width - 20, ClientSize.Height - panelValentin.Height - 20);

            picValentin.SendToBack();

            // Les autres au-dessus
            picLucas.BringToFront();
            panelLucas.BringToFront();
            panelValentin.BringToFront();

            // Repositionne bien les boutons
            panelLucas.Location = new Point(20, ClientSize.Height - panelLucas.Height - 20);
            panelValentin.Location = new Point(ClientSize.Width - panelValentin.Width - 20, ClientSize.Height - panelValentin.Height - 20);
        }
        #endregion


        // 🎥 === PARTAGE ÉCRAN LUCAS ===
        private void btnShareLucas_Click(object sender, EventArgs e)
        {
            if (isSharingLucas)
            {
                isSharingLucas = false;
                threadSendLucas?.Join(500);
                lblStatusLucas.Text = "⏸️ Partage arrêté.";

                return;
            }

            try
            {
                clientLucas = new TcpClient("127.0.0.1", 5555);
                streamLucas = clientLucas.GetStream();
                clientLucas.NoDelay = true;

                using (var writer = new StreamWriter(streamLucas, leaveOpen: true))
                {
                    streamLucas.Write(System.Text.Encoding.ASCII.GetBytes("HOST"));
                    streamLucas.Flush();
                }

                isSharingLucas = true;
                lblStatusLucas.Text = "📡 Partage en cours...";

                threadSendLucas = new Thread(SendScreenLoopLucas);
                threadSendLucas.IsBackground = true;
                threadSendLucas.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }

        private void SendScreenLoopLucas()
        {
            try
            {
                if (clientLucas == null || !clientLucas.Connected)
                {
                    lblStatusLucas.Invoke(() => lblStatusLucas.Text = "❌ Serveur déconnecté.");
                    return;
                }

                using var writer = new BinaryWriter(streamLucas);
                clientLucas.NoDelay = true;

                byte[]? lastFrame = null;
                Stopwatch sw = new Stopwatch();

                while (isSharingLucas)
                {
                    if (!clientLucas.Connected)
                    {
                        lblStatusLucas.Invoke(() => lblStatusLucas.Text = "⚠️ Connexion perdue.");
                        break;
                    }

                    sw.Restart();

                    using (Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height))
                    {
                        using (Graphics g = Graphics.FromImage(bmp))
                            g.CopyFromScreen(0, 0, 0, 0, bmp.Size);

                        using (Bitmap resized = new Bitmap(bmp, new Size(1280, 720)))
                        {
                            using (var skBmp = BitmapToSKBitmap(resized))
                            using (var skImage = SKImage.FromBitmap(skBmp))
                            using (var ms = new MemoryStream())
                            {
                                // 🔹 Compression WebP fluide
                                using (var data = skImage.Encode(SKEncodedImageFormat.Webp, 60))
                                    data.SaveTo(ms);

                                byte[] buffer = ms.ToArray();

                                // 🔹 Vérification frame identique
                                if (lastFrame != null && buffer.SequenceEqual(lastFrame))
                                {
                                    Thread.Sleep(40);
                                    continue;
                                }
                                lastFrame = buffer;

                                // 🔹 Prévisualisation locale
                                picLucas.Invoke(() =>
                                {
                                    picLucas.Image?.Dispose();
                                    picLucas.Image = new Bitmap(resized);
                                });

                                try
                                {
                                    writer.Write(buffer.Length);
                                    writer.Write(buffer);
                                    writer.Flush();
                                }
                                catch (IOException)
                                {
                                    lblStatusLucas.Invoke(() => lblStatusLucas.Text = "⚠️ Déconnexion détectée.");
                                    break;
                                }
                            }
                        }
                    }

                    sw.Stop();
                    Thread.Sleep(Math.Max(10, 33 - (int)sw.ElapsedMilliseconds)); // ~30 FPS
                }

                writer.Close();
                streamLucas.Close();
                clientLucas.Close();
                lblStatusLucas.Invoke(() => lblStatusLucas.Text = "⏸️ Partage terminé.");
            }
            catch (Exception ex)
            {
                lblStatusLucas.Invoke(() => lblStatusLucas.Text = $"⚠️ Erreur envoi : {ex.Message}");
            }
        }




        // 👁️ === AFFICHAGE ÉCRAN VALENTIN ===
        private void btnShareValentin_Click(object sender, EventArgs e)
        {
            if (isSharingValentin)
            {
                isSharingValentin = false;
                threadReceiveValentin?.Join(500);
                lblStatusValentin.Text = "⏸️ Arrêt de la réception.";
                return;
            }

            try
            {
                clientValentin = new TcpClient("127.0.0.1", 5555);
                streamValentin = clientValentin.GetStream();
                clientValentin.NoDelay = true;


                using (var writer = new StreamWriter(streamValentin, leaveOpen: true))
                {
                    streamValentin.Write(System.Text.Encoding.ASCII.GetBytes("VIEW"));
                    streamValentin.Flush();

                }

                isSharingValentin = true;
                lblStatusValentin.Text = "👁️ Réception en cours...";

                threadReceiveValentin = new Thread(ReceiveLoopValentin);
                threadReceiveValentin.IsBackground = true;
                threadReceiveValentin.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }

        private void ReceiveLoopValentin()
        {
            try
            {
                BinaryReader reader = new BinaryReader(streamValentin);
                clientValentin.NoDelay = true;

                while (isSharingValentin)
                {
                    int length;
                    try { length = reader.ReadInt32(); }
                    catch { break; }

                    byte[] data = reader.ReadBytes(length);
                    if (data.Length == 0) break;

                    using (var ms = new MemoryStream(data))
                    using (var skData = SKData.Create(ms))
                    using (var skImage = SKImage.FromEncodedData(skData))
                    using (var bitmap = SKBitmap.FromImage(skImage))
                    {
                        using (var img = SKImage.FromBitmap(bitmap))
                        using (var encoded = img.Encode(SKEncodedImageFormat.Png, 100))
                        using (var outStream = new MemoryStream(encoded.ToArray()))
                        {
                            Image frame = Image.FromStream(outStream);
                            picValentin.Invoke(() =>
                            {
                                picValentin.Image?.Dispose();
                                picValentin.Image = new Bitmap(frame);
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblStatusValentin.Invoke(() => lblStatusValentin.Text = "⚠️ Erreur réception : " + ex.Message);
            }
        }

        private SKBitmap BitmapToSKBitmap(Bitmap bmp)
        {
            var skBmp = new SKBitmap(bmp.Width, bmp.Height, SKColorType.Bgra8888, SKAlphaType.Premul);
            var data = skBmp.PeekPixels();

            var bmpData = bmp.LockBits(
                new Rectangle(0, 0, bmp.Width, bmp.Height),
                System.Drawing.Imaging.ImageLockMode.ReadOnly,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            unsafe
            {
                Buffer.MemoryCopy(
                    (void*)bmpData.Scan0,
                    (void*)data.GetPixels(),
                    data.RowBytes * bmp.Height,
                    bmpData.Stride * bmp.Height);
            }

            bmp.UnlockBits(bmpData);
            return skBmp;
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            string ip = txtIp.Text.Trim();
            int port = (int)numPort.Value;

            try
            {
                lblStatusValentin.Text = "⏳ Connexion en cours...";
                btnConnect.Enabled = false;

                await Task.Run(() =>
                {
                    clientValentin = new TcpClient(ip, port);
                    streamValentin = clientValentin.GetStream();

                    using (var writer = new StreamWriter(streamValentin, leaveOpen: true))
                    {
                        writer.WriteLine("VIEWER");
                        writer.Flush();
                    }
                });

                lblStatusValentin.Text = $"✅ Connecté à {ip}:{port}";
                lblStatusValentin.ForeColor = Color.LightGreen;

                isSharingValentin = true;

                threadReceiveValentin = new Thread(ReceiveLoopValentin)
                {
                    IsBackground = true
                };
                threadReceiveValentin.Start();
            }
            catch (Exception ex)
            {
                lblStatusValentin.Text = "❌ Connexion échouée";
                lblStatusValentin.ForeColor = Color.IndianRed;

                MessageBox.Show(
                    $"Impossible de se connecter à {ip}:{port}\n\nDétail : {ex.Message}",
                    "Erreur de connexion",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                btnConnect.Enabled = true;
            }
        }


    }
}
