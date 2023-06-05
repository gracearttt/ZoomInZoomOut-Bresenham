using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZoomInZoomOut_Bresenham
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Image ZoomPicture(Image img, Size size)
        {
            Bitmap bm = new Bitmap(img, Convert.ToInt32(img.Width * size.Width),
                Convert.ToInt32(img.Height * size.Height));
            Graphics gpu = Graphics.FromImage(bm);
            gpu.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            return bm;
        }

        PictureBox org;

        private void Form1_Load(object sender, EventArgs e)
        {
            trackBar1.Minimum = 1;
            trackBar1.Maximum = 6;
            trackBar1.SmallChange = 1;
            trackBar1.LargeChange = 1;
            trackBar1.UseWaitCursor = false;

            this.DoubleBuffered = true;
            //org = new PictureBox();
            //org.Image = pictureBox1.Image;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (trackBar1.Value != 0)
            {
                pictureBox1.Image = null;
                pictureBox1.Image = ZoomPicture(org.Image, new Size(trackBar1.Value, trackBar1.Value));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog();
            if (od.ShowDialog() == DialogResult.OK)
            {
                org = new PictureBox();
                org.Load(od.FileName);
                pictureBox1.Load(od.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();  // form2 göster diyoruz
            this.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();  // form2 göster diyoruz
            this.Hide();
        }
    }
}
