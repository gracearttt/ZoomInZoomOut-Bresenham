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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        Bitmap image;
        Bitmap image2;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files(*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG" +
            "|All files(*.*)|*.*";
            dialog.CheckFileExists = true;
            dialog.Multiselect = false;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                image = new Bitmap(dialog.FileName);
                image2 = new Bitmap(dialog.FileName);
                pictureBox2.Image = (Image)image2;
                pictureBox1.Image = (Image)image;
            }
                if (pictureBox1.Image == null) return;

            

            int x0 = 0;
            int y0 = 0;
            int x1 = pictureBox1.Image.Width - 1;
            int y1 = pictureBox1.Image.Height - 1;

            cizgi(x0, y0, x1, y1);

            int x2 = pictureBox1.Image.Width - 1;
            int y2 = 0;
            int x3 = 0;
            int y3 = pictureBox1.Image.Height - 1;

            cizgi(x2, y2, x3, y3);

            

        }

        private void cizgi(int x0, int y0, int x1, int y1)
        {
            Bitmap image = (Bitmap)pictureBox1.Image;

            int deltax = Math.Abs(x1 - x0);
            int deltay = Math.Abs(y1 - y0);
            int xstep = x0 < x1 ? 1 : -1;
            int ystep = y0 < y1 ? 1 : -1;
            int error = deltax - deltay;

            int lineWidth = 5; // Çizgi kalınlığı
            Color lineColor = Color.Red; // Çizgi rengi

            while (true)
            {
                for (int i = -lineWidth / 2; i <= lineWidth / 2; i++)
                {
                    for (int j = -lineWidth / 2; j <= lineWidth / 2; j++)
                    {
                        int pixelX = x0 + i;
                        int pixelY = y0 + j;

                        if (pixelX >= 0 && pixelX < image.Width && pixelY >= 0 && pixelY < image.Height)
                            image.SetPixel(pixelX, pixelY, lineColor);
                    }
                }

                if (x0 == x1 && y0 == y1)
                    break;

                int error2 = error * 2;
                if (error2 > -deltay)
                {
                    error -= deltay;
                    x0 += xstep;
                }
                if (error2 < deltax)
                {
                    error += deltax;
                    y0 += ystep;
                }
            }

              pictureBox1.Refresh();
        }

        


        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show(); 
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();  // form2 göster diyoruz
            this.Hide();
        }
    }
    }

