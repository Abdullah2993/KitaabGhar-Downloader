using System;
using System.Windows.Forms;
using KitaabgharDownloader.Properties;

namespace KitaabgharDownloader
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            trayCheck.Checked = ApplicationSettings.MinimizeToTray;
            pdfCheck.Checked = ApplicationSettings.CreatePdf;
            deleteCheck.Checked = ApplicationSettings.DeleteImages;
            locationText.Text = ApplicationSettings.DownloadLocation;
            retriesNumber.Value = ApplicationSettings.Retries;
            timeoutNumber.Value = ApplicationSettings.Timeout;
            openPdfCheck.Checked = ApplicationSettings.OpenPdf;
            nothingOption.Checked = ApplicationSettings.DoNothing;
            notifyOption.Checked = ApplicationSettings.Notify;
            closeOption.Checked = ApplicationSettings.Close;
            resumeCheck.Checked = ApplicationSettings.Resume;
            smartCheck.Checked = ApplicationSettings.Smart;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            ApplicationSettings.MinimizeToTray = trayCheck.Checked;
            ApplicationSettings.CreatePdf = pdfCheck.Checked;
            ApplicationSettings.DeleteImages = deleteCheck.Checked;
            ApplicationSettings.DownloadLocation = locationText.Text;
            ApplicationSettings.Retries = (int) retriesNumber.Value;
            ApplicationSettings.Timeout = (int) timeoutNumber.Value;
            ApplicationSettings.OpenPdf = openPdfCheck.Checked;
            ApplicationSettings.DoNothing = nothingOption.Checked;
            ApplicationSettings.Notify = notifyOption.Checked;
            ApplicationSettings.Close = closeOption.Checked;
            ApplicationSettings.Resume = resumeCheck.Checked;
            ApplicationSettings.Smart = smartCheck.Checked;
            Settings.Default.Save();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog {ShowNewFolderButton = true})
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    locationText.Text = folderDialog.SelectedPath;
                }
            }
        }

        private void smartCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (smartCheck.Checked)
                return;

            if (MessageBox.Show("You will not able to download the latest novels.\r\nDo you want to continue?",
                                "Support", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                smartCheck.Checked = true;
            }
        }
    }
}