using System;
using System.Drawing;
using System.Security.AccessControl;
using System.Windows.Forms;
using System.Xml.Resolvers;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.AxHost;

namespace lab2
{
    public partial class MainForm : Form
    {
        public Color bkgrnd;
        public int yn, xn, yk, xk;
        Bitmap bitmap;
        Color currentBorderColor = Color.Black;
        Color fill_color;
        public MainForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (CDA_radio.Checked)
            {
                yn = e.Y;
                xn = e.X;

            }

            if (NO_simetrik.Checked)
            {
                yn = e.Y;
                xn = e.X;

            }

            if (CDA_THICC_button.Checked)
            {
                yn = e.Y;
                xn = e.X;
            }

            if (Fill_radio.Checked)
            {

                bitmap = pictureBox1.Image as Bitmap;
                yn = e.Y;
                xn = e.X;
                FloodFill(xn, yn);
                pictureBox1.Image = bitmap;
                pictureBox1.Refresh();

            }


        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {

            if (CDA_radio.Checked)
            {
                int index, nodesNumber;
                double NextX, NextY, dx, dy;
                Pen new_Pen = new Pen(currentBorderColor, 1);
                Graphics drawer = Graphics.FromHwnd(pictureBox1.Handle);

                xk = e.X;
                yk = e.Y;
                dx = xk - xn;
                dy = yk - yn;
                nodesNumber = 200;
                NextX = xn;
                NextY = yn;
                for (int i = 1; i < nodesNumber; i++)
                {
                    Bitmap_pixel_set((int)NextX, (int)NextY, 2);
                    NextX = NextX + dx / nodesNumber;
                    NextY = NextY + dy / nodesNumber;
                }
                pictureBox1.Image = bitmap;
                pictureBox1.Refresh();
            }

            if (CDA_THICC_button.Checked)
            {
                int index, nodesNumber;
                double NextX, NextY, dx, dy;
                Pen new_Pen = new Pen(currentBorderColor, 1);
                Graphics drawer = Graphics.FromHwnd(pictureBox1.Handle);

                xk = e.X;
                yk = e.Y;
                dx = xk - xn;
                dy = yk - yn;
                nodesNumber = 200;
                NextX = xn;
                NextY = yn;
                for (int i = 1; i < nodesNumber; i++)
                {
                    Bitmap_pixel_set((int)NextX, (int)NextY, 3);
                    NextX = NextX + dx / nodesNumber;
                    NextY = NextY + dy / nodesNumber;
                }
                pictureBox1.Image = bitmap;
                pictureBox1.Refresh();
            }

            if (NO_simetrik.Checked)
            {
                double index, numberNodes;
                double xOutput, yOutput, dx, dy;

                /*int xn = StartX;
                int yn = StartY;
                int xk = EndX;
                int yk = EndY;*/

                xk = e.X;
                yk = e.Y;
                dx = xk - xn;
                dy = yk - yn;
                numberNodes = Math.Max(Math.Abs(dx), Math.Abs(dy));
                xOutput = xn;
                yOutput = yn;

                for (index = 1; index <= numberNodes; index++)
                {
                    bitmap.SetPixel((int)xOutput, (int)yOutput, currentBorderColor);
                    xOutput = xOutput + dx / (double)numberNodes;
                    yOutput = yOutput + dy / (double)numberNodes;
                }
            }
        }
        private void Bitmap_pixel_set(int x, int y, int range)
        {
            for (int i = 0; i < range; i++)
            {
                bitmap.SetPixel(x + i, y, currentBorderColor);
                bitmap.SetPixel(x + i, y + i, currentBorderColor);
                bitmap.SetPixel(x + i, y - i, currentBorderColor);
                bitmap.SetPixel(x - i, y + i, currentBorderColor);
                bitmap.SetPixel(x - i, y - i, currentBorderColor);
                bitmap.SetPixel(x - i, y, currentBorderColor);
                bitmap.SetPixel(x, y + i, currentBorderColor);
                bitmap.SetPixel(x, y - i, currentBorderColor);

            }

        }
        private void Clear_button_Click(object sender, EventArgs e)
        {



            Color newPixelColor = bkgrnd;
            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    bitmap.SetPixel(x, y, newPixelColor);
                }
            }
            pictureBox1.Image = bitmap;
        }


        private void color_button_Click(object sender, EventArgs e)
        {
            DialogResult diadresult = colorDialog1.ShowDialog();
            if (diadresult == DialogResult.OK && CDA_radio.Checked)
            {
                currentBorderColor = colorDialog1.Color;
            }
        }
        private void CDA(int StartX, int StartY, int EndX, int EndY)
        {
            double index, numberNodes;
            double xOutput, yOutput, dx, dy;

            int xn = StartX;
            int yn = StartY;
            int xk = EndX;
            int yk = EndY;

            dx = xk - xn;
            dy = yk - yn;
            numberNodes = Math.Max(Math.Abs(dx), Math.Abs(dy));
            xOutput = xn;
            yOutput = yn;

            for (index = 1; index <= numberNodes; index++)
            {
                bitmap.SetPixel((int)xOutput, (int)yOutput, currentBorderColor);
                xOutput = xOutput + dx / (double)numberNodes;
                yOutput = yOutput + dy / (double)numberNodes;
            }
        }



        private void use_button_Click(object sender, EventArgs e)
        {
            use_button.Enabled = false;
            Clear_button.Enabled = false;

            using (Graphics g = Graphics.FromHwnd(pictureBox1.Handle))
            {
                if (CDA_radio.Checked)
                {
                    CDA(10, 10, 10, 110);
                    CDA(10, 10, 110, 10);
                    CDA(10, 110, 110, 110);
                    CDA(110, 10, 110, 110);
                    //рисуем треугольник
                    CDA(150, 10, 150, 200);
                    CDA(250, 50, 150, 200);
                    CDA(150, 10, 250, 150);
                }
                else
                {
                    if (Fill_radio.Checked)
                    {
                        bitmap = pictureBox1.Image as Bitmap;
                        xn = 160;
                        yn = 40;
                        FloodFill((int)xn, (int)yn);
                    }
                }
                pictureBox1.Image = bitmap;
                pictureBox1.Refresh();
                use_button.Enabled = true;
                Clear_button.Enabled = true;
            }
        }
        private void FloodFill(int x1, int y1)
        {
            Color oldPixelColor = bitmap.GetPixel(x1, y1);
            if ((oldPixelColor.ToArgb() != currentBorderColor.ToArgb()) && (oldPixelColor.ToArgb() != fill_color.ToArgb()) && ((x1 + 2) < bitmap.Width) && ((x1) < bitmap.Width) && ((y1) < bitmap.Height) && ((y1) < bitmap.Height) && (x1 > 0) && (y1 > 0))
            {
                bitmap.SetPixel(x1, y1, fill_color);
                FloodFill(x1 + 1, y1);
                FloodFill(x1 - 1, y1);
                FloodFill(x1, y1 + 1);
                FloodFill(x1, y1 - 1);
            }
            else
            {
                return;
            }

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            bitmap = new Bitmap(pictureBox1.Width + 1, pictureBox1.Height + 1);
            pictureBox1.Image = bitmap;
            pictureBox1.Refresh();
            bkgrnd = bitmap.GetPixel(0, 0);
        }

        private void fill_color_button_Click(object sender, EventArgs e)
        {
            DialogResult diadresult = colorDialog1.ShowDialog();
            if (diadresult == DialogResult.OK)
            {
                fill_color = colorDialog1.Color;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CDA_radio_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
