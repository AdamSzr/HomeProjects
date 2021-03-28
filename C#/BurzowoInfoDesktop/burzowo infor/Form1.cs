using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace burzowo_infor
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            this.refresh();
        }
        private void refresh()
        {
            DateTime localDate = DateTime.Now;
            int nextmin = (localDate.Minute + 2) % 60;
            if (localDate.Minute>nextmin)
            {
                this.Refresh();
            }
        }

        private void load_image(object sender,EventArgs e)
        {
            System.Net.WebClient web = new System.Net.WebClient();
            byte[] img = web.DownloadData("https://burzowo.info/maps/poland.png");
            this.pictureBox1.Image = byteArrayToImage(img);
            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
         
        }


        private System.Drawing.Image byteArrayToImage(byte[] bytesArr)
        {
            System.IO.MemoryStream memstr = new System.IO.MemoryStream(bytesArr);
            System.Drawing.Image img = System.Drawing.Image.FromStream(memstr);
            return img;
        }


    }
}
