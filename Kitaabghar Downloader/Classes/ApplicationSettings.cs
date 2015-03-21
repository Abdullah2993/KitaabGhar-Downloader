using System.Windows.Forms;
using KitaabgharDownloader.Properties;

namespace KitaabgharDownloader
{
    public static class ApplicationSettings
    {
        public static bool MinimizeToTray
        {
            get { return Settings.Default.MinimizeToTray; }
            set { Settings.Default.MinimizeToTray = value; }
        }

        public static bool CreatePdf
        {
            get { return Settings.Default.CreatePdf; }
            set { Settings.Default.CreatePdf = value; }
        }

        public static bool DeleteImages
        {
            get { return Settings.Default.DeleteImages; }
            set { Settings.Default.DeleteImages = value; }
        }

        public static string DownloadLocation
        {
            get
            {
                if (string.IsNullOrEmpty(Settings.Default.DownloadLocation))
                {
                    DownloadLocation = Application.StartupPath;
                }
                return Settings.Default.DownloadLocation;
            }
            set { Settings.Default.DownloadLocation = value; }
        }

        public static int Timeout
        {
            get { return Settings.Default.Timeout; }
            set { Settings.Default.Timeout = value; }
        }

        public static int Retries
        {
            get { return Settings.Default.Retries; }
            set { Settings.Default.Retries = value; }
        }

        public static bool OpenPdf
        {
            get { return Settings.Default.OpenPdf; }
            set { Settings.Default.OpenPdf = value; }
        }

        public static bool DoNothing
        {
            get { return Settings.Default.DoNothing; }
            set { Settings.Default.DoNothing = value; }
        }

        public static bool Notify
        {
            get { return Settings.Default.Notify; }
            set { Settings.Default.Notify = value; }
        }

        public static bool Close
        {
            get { return Settings.Default.Close; }
            set { Settings.Default.Close = value; }
        }

        public static bool Resume
        {
            get { return Settings.Default.Resume; }
            set { Settings.Default.Resume = value; }
        }

        public static bool Smart
        {
            get { return Settings.Default.Smart; }
            set { Settings.Default.Smart = value; }
        }
    }
}