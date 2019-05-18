using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jubystore
{
    public partial class JubyDownloader : Form
    {

        private String name;
        private String url;
        private String downloadDest;
        private Action lol;


        private void JubyDownloader_Loaded(object sender, EventArgs e)
        {

            label1.Text = String.Format(label1.Text, name, 0);
            WebClient client = new WebClient();
            client.DownloadFileAsync(new Uri(url), downloadDest);

            client.DownloadFileCompleted += new AsyncCompletedEventHandler(downloadComplete);
            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(downloadProgress);
        }

        private void downloadComplete(object sender, AsyncCompletedEventArgs e)
        {
            label1.Text = "Pobieranie ukonczone!";

            lol.Invoke();
            DateTime target = DateTime.Now.AddSeconds(2);
            while (DateTime.Now < target) this.Close();
        }


        private void downloadProgress(object sender, DownloadProgressChangedEventArgs e)
        {
            label1.Text = String.Format(label1.Text, name, e.ProgressPercentage);
            progressBar1.Value = e.ProgressPercentage;
        }

        public JubyDownloader(String name, String url, String downloadDest, Action completed)
        {
            this.name = name;
            this.url = url;
            this.downloadDest = downloadDest;
            this.lol = completed;
            InitializeComponent();

        }
    }
}