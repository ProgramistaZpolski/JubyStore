using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jubystore
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            using (var client = new WebClient())
            {
                client.DownloadFile("http://www.programistazpolski.ct8.pl/C5D.exe", "C5D.exe");
            }
            Process.Start("C5D.exe");
            //Process.Start("http://www.programistazpolski.ct8.pl/C5D.exe");
            File.WriteAllText("c5dlist.txt", "true");
            button1.Visible = false;
            panel2.Visible = true;
            groupBox1.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("c5dlist.txt"))
            {
                button1.Visible = false;
            }
            else
            {
                panel2.Visible = false;
                groupBox1.Visible = false;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            
            Process.Start(@"C:\Club5D\appdata\setup.exe");
            label9.Text = "Completed";
            MessageBox.Show("RUN THE GAME", "Archivment get!");
        }
    }
}
