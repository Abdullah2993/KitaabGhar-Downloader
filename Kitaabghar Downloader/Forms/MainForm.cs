using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using KitaabgharDownloader.Forms;
using sharpPDF;

namespace KitaabgharDownloader
{
    public partial class MainForm : Form
    {
        private Novel _novel;
        private volatile bool _running;

        public MainForm()
        {
            InitializeComponent();
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            LogMessage("Started.");
            if (Environment.GetCommandLineArgs().Length == 2)
            {
                linkText.Text = Environment.GetCommandLineArgs()[1];
            }

            var updateThreaded = new Thread(() =>
                {
                    try
                    {
                        using (var webclient = new WebClient())
                        {
                            var source = webclient.DownloadString(string.Format("http://app-update-system.appspot.com/kgd.php?ver={0}",
                                                                   Application.ProductVersion));
                            if (source == "1")
                            {
                                Invoke(new MethodInvoker(ShowUpdateMessage));
                            }
                        }
                    }
                    catch (Exception)
                    {
                    }
                });
            updateThreaded.Start();
        }

        private void ShowUpdateMessage()
        {
            MessageBox.Show("A new version is available for download.", "Update Availabe", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (!_running)
            {
                if (!string.IsNullOrEmpty(linkText.Text.Trim()))
                {
                    linkText.Text = linkText.Text.StartsWith("http://", StringComparison.InvariantCultureIgnoreCase)
                                        ? linkText.Text
                                        : "http://" + linkText;

                    if (KitaabGhar.IsValidLink(linkText.Text.Trim()))
                    {
                        if (logList.Items.Count > 0)
                        {
                            logList.Items.Clear();
                        }
                        progress.Value = 0;
                        LogMessage("Link: " + linkText.Text);
                        LogMessage("Gathering information.");
                        if (ApplicationSettings.Smart)
                        {
                            LogMessage("Smart identification is on so this may take a while.");
                        }
                        statusText.Text = "Running...";
                        Application.DoEvents();
                        _running = true;
                        var mainThread = new Thread(Main) {IsBackground = true};
                        mainThread.Start(linkText.Text);
                    }
                    else
                    {
                        LogMessage("Invalid download link.");
                        statusText.Text = "Please enter the link to the novel";
                    }
                }
                else
                {
                    LogMessage("Link missing.");
                    statusText.Text = "Please enter the link to the novel";
                }
            }
            else
            {
                statusText.Text = "Application is already running.";
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            if (_running)
            {
                _running = false;
                LogMessage("Stoped.");
                statusText.Text = "Stoped.";
            }
            else
            {
                statusText.Text = "Application in not running.";
            }
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            using (var settingsForm = new SettingsForm())
            {
                if (settingsForm.ShowDialog() == DialogResult.OK)
                {
                    statusText.Text = "Settings Changed!";
                }
            }
        }

        private void linkText_KeyDown(object sender, KeyEventArgs e)
        {
            if (_running || e.KeyCode != Keys.Enter)
                return;

            e.SuppressKeyPress = true;
            Application.DoEvents();
            startButton.PerformClick();
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Minimized)
                return;

            Hide();
            trayIcon.Visible = true;
        }

        private void trayIcon_DoubleClick(object sender, EventArgs e)
        {
            trayIcon.Visible = false;
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_running)
            {
                _running = false;
            }
        }

        private void Main(object link)
        {
            try
            {
                _novel = KitaabGhar.GetNovelInformation(link.ToString());
                LogMessage("Information collected.");
                LogMessage(string.Format("Total pages: {0} ({1} - {2})", _novel.TotalPages,
                                         _novel.FirstIndex, _novel.LastIndex));

            }
            catch (Exception ex)
            {
                LogMessage("Error: " + ex.Message);
                statusText.Text = "Unable to get the required information. Please try again.";
                _running = false;
                return;
            }

            var directory = Path.Combine(ApplicationSettings.DownloadLocation, _novel.Name);
            var imageFormat = Path.Combine(directory, "{0}.gif");
            Directory.CreateDirectory(directory);
            for (var i = _novel.FirstIndex; i <= _novel.LastIndex; i++)
            {
                statusText.Text = "Downloading page: " + i;

                var r = 0;
                Retry:
                if (!_running)
                {
                    return;
                }
                try
                {
                    if (r <= ApplicationSettings.Retries)
                    {
                        if (!(ApplicationSettings.Resume && File.Exists(string.Format(imageFormat, i))))
                        {
                            var tempImage = Http.DownloadImage(_novel.GetImageLink(i), _novel.GetRefLink(i),
                                                               _novel.NewFormat);
                            tempImage.Save(string.Format(imageFormat, i));
                            tempImage.Dispose();
                        }
                        if (!_running)
                        {
                            return;
                        }
                        Progress((int) ((double) ((i - _novel.FirstIndex)*100)/_novel.TotalPages));
                    }
                    else
                    {
                        LogMessage("Unable to download within the provided number of retries.");
                    }
                }
                catch
                    (Exception
                        ex)
                {
                    LogMessage("Unable to download page: " + i);
                    LogMessage("Trying to download page" + i + " again.");
                    LogMessage("Error: " + ex.Message);
                    r++;
                    goto Retry;
                }
            }
            LogMessage("Download complete.");
            if (ApplicationSettings.CreatePdf)
            {
                LogMessage("Creating PDF file.");
                try
                {
                    using (var pdfFile = new pdfDocument(_novel.Name, "Abdullah Saleem"))
                    {
                        for (var i = _novel.FirstIndex; i <= _novel.LastIndex; i++)
                        {
                            var file = string.Format(imageFormat, i);
                            statusText.Text = "Processing page: " + i;
                            if (File.Exists(file))
                            {
                                try
                                {
                                    using (var image = Image.FromFile(file))
                                    {
                                        pdfFile.addImageReference(file, i.ToString(CultureInfo.InvariantCulture));
                                        var tempPage = pdfFile.addPage(image.Height, image.Width);
                                        tempPage.addImage(
                                            pdfFile.getImageReference(i.ToString(CultureInfo.InvariantCulture)), 0, 0);
                                    }
                                    statusText.Text = "Page " + i + " added.";
                                }
                                catch (Exception)
                                {
                                    LogMessage("Page number " + i + "missing.");
                                }
                            }
                            else
                            {
                                LogMessage("Page number " + i + "missing.");
                            }
                        }
                        pdfFile.createPDF(Path.Combine(directory, _novel.Name + ".pdf"));
                        statusText.Text = "PDF Created!";
                        if (ApplicationSettings.OpenPdf)
                        {
                            Process.Start(Path.Combine(directory, _novel.Name + ".pdf"));
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogMessage("Error occured while creating the PDF.");
                    LogMessage("Error: " + ex.Message);
                }
            }
            if (ApplicationSettings.DeleteImages)
            {
                LogMessage("Deleting images.");
                statusText.Text = "Deleting images.";
                for (var i = _novel.FirstIndex; i <= _novel.LastIndex; i++)
                {
                    if (File.Exists(string.Format(imageFormat, i)))
                    {
                        try
                        {
                            File.Delete(string.Format(imageFormat, i));
                        }
                        catch (Exception ex)
                        {
                            LogMessage("Error occured while deleting images.");
                            LogMessage("Error: " + ex.Message);
                        }
                    }
                }
            }
            statusText.Text = "Completed.";
            Invoke(new MethodInvoker(DownloadCompeted));
        }

        private void LogMessage(string message)
        {
            if (logList.InvokeRequired)
            {
                logList.BeginInvoke(new Action<string>(LogMessage), message);
            }
            else
            {
                logList.Items.Add(string.Format("[{0}] {1}", DateTime.Now.ToShortTimeString(), message));
                logList.TopIndex = logList.Items.Count - 1;
            }
        }

        private void Progress(int percentage)
        {
            progress.BeginInvoke(new Action(() => { progress.Value = percentage; }));
        }

        private void DownloadCompeted()
        {
            if (ApplicationSettings.Notify)
            {
                if (WindowState == FormWindowState.Minimized)
                {
                    trayIcon.BalloonTipText = _novel.Name + " is downloaded.";
                    trayIcon.ShowBalloonTip(2000);
                }
                else
                {
                    MessageBox.Show(_novel.Name + " is downloaded.", "Download Complted", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
            }
            else if (ApplicationSettings.Close)
            {
                Close();
            }
        }

        private void infoButton_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Coded By: Abdullah Saleem\r\nhttps://www.facebook.com/abdullah2993", "About",
                           // MessageBoxButtons.OK, MessageBoxIcon.Information);
            using (var aboutForm=new AboutForm())
            {
                aboutForm.ShowDialog();
            }
        }
    }
}