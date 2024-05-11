using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB3_2D_PICTURES
{
    public partial class FormOTec : Form
    {
        private Point center; // Центр орбиты
        private int orbitRadius = 100; // Радиус орбиты
        private int spaceshipSize = 50; // Размер корабля
        private int spaceshipDistance = 20; // Дистанция корабля от центра орбиты
        private int spaceshipSpeed = 20; // Скорость перемещения корабля
        private bool f = false;
        private int planet = 0;
        private int size_roket = 0;
        private System.Windows.Forms.Timer timer;

        public FormOTec()
        {
            InitializeComponent();
            InitializeTimer();
            // Установка начального центра орбиты по центру формы
            center = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);
        }

        private void InitializeTimer()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // Интервал в миллисекундах (1000 мс = 1 секунда)
            timer.Tick += timer1_Tick_1; // Подписываемся на событие Tick
            timer.Start(); // Запускаем таймер
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            // Увеличиваем или уменьшаем дистанцию корабля в зависимости от нажатой клавиши
            if (e.KeyCode == Keys.Down)
            {
                spaceshipSize += 2;
            }
            else if (e.KeyCode == Keys.Up)
            {
                spaceshipSize -= 2;
            }

            // Перерисовываем PictureBox
            pictureBox1.Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            // Рисуем орбиту
            g.DrawEllipse(Pens.Blue, center.X - orbitRadius, center.Y - orbitRadius, orbitRadius * 2, orbitRadius * 2);
            // Рисуем космический корабль
            int spaceshipX = center.X + (int)(Math.Cos(spaceshipDistance * Math.PI / 180) * orbitRadius);
            int spaceshipY = center.Y + (int)(Math.Sin(spaceshipDistance * Math.PI / 180) * orbitRadius);
            g.FillRectangle(Brushes.Red, spaceshipX - spaceshipSize / 2, spaceshipY - spaceshipSize / 2, spaceshipSize, spaceshipSize);
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            // Здесь пишите код, который должен выполняться каждую секунду
            // Например, перемещение космического корабля
            spaceshipDistance += spaceshipSpeed;
            planet += 1;
            // Перерисовываем PictureBox
            if (planet /9 < 1)
            {
                Thread.Sleep(200);
                spaceshipSize = 70;
            }
            else if (planet /9 == 1)
            {
                Thread.Sleep(200);
                spaceshipSize = 30;
            }
            
            if (planet == 18)
            {
                planet = 0;
            }

            pictureBox1.Invalidate();
           
        }

        private void Form2_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            spaceshipDistance += spaceshipSpeed;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Interval = 100;

            button1.Text = "Замедлить";
            if (f == true)
                timer1.Start();
            else
            {
                timer1.Stop();
                button1.Text = "Ускорить";
            }
            f = !f;
        }
    }

}
