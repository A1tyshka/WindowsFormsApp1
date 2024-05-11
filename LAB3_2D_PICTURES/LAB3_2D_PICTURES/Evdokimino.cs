using Microsoft.VisualBasic;
using System;
using System.Drawing;
using System.Reflection.Metadata;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lab_3_kg_zadanie
{
    public partial class Evdokimino : Form
    {
        private System.Windows.Forms.Timer timer;
        private string word;
        private int fontSize = 20;
        Color textColor = Color.Black;
        int abc, ord;
        public Evdokimino()
        {
            InitializeComponent();
            InitializeTimer();
        }
        private void InitializeTimer()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 50;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (word != null)
            {
                // Get the center point of the PictureBox
                Point center = new Point(abc, ord);

                // Calculate the size of the word
                SizeF textSize = e.Graphics.MeasureString(word, new Font("Arial", fontSize));

                // Calculate the position for drawing the word
                float x = center.X - textSize.Width / 2;
                float y = center.Y - textSize.Height / 2;

                // Choose a random color for the word
                fontSize = int.Parse(textBox1.Text);
                textColor = Color.FromName(textBox2.Text);
                
                
                // Draw the word


                // Rotate the word around its center
                e.Graphics.TranslateTransform(center.X, center.Y);
                e.Graphics.RotateTransform((float)(DateTime.Now.TimeOfDay.TotalMilliseconds / 10));
                e.Graphics.TranslateTransform(-center.X, -center.Y);

                // Draw the rotated word

                e.Graphics.DrawString(word, new Font("Arial", fontSize), new SolidBrush(textColor), x, y);
            }
        }

     
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            abc = e.X;
            ord = e.Y;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            abc = pictureBox1.Width / 2;
            ord = pictureBox1.Height / 2;

        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            word = Interaction.InputBox("¬ведите слово:", "¬вод слова", "");
            pictureBox1.Invalidate();
        }
    }
}
