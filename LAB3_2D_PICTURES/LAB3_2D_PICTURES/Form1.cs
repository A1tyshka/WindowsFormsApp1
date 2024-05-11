
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Задание_10

{
    public partial class Form1 : Form
    {
        private Point center2; // Центр второй орбиты
        private int orbitRadius2 = 150; // Радиус второй орбиты
        private int spaceshipDistance2 = 0; // Дистанция корабля от центра второй орбиты
        private int planetSize = 100; // Размер центральной планеты
        private Point center; // Центр орбиты
        private int orbitRadius = 100; // Радиус орбиты
        private int spaceshipSize = 50; // Размер корабля
        private int spaceshipSize2 = 50; // Размер корабля
        private int spaceshipDistance = 20; // Дистанция корабля от центра орбиты
        private int spaceshipSpeed = 20; // Скорость перемещения корабля
        private bool f = false;
        private int planet = 0;
        private int size_roket = 0;
        private System.Windows.Forms.Timer timer;


        public Form1()
        {
            InitializeComponent();
            InitializeTimer();
            // Установка начального центра орбиты по центру формы
            center = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);
            center2 = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);
        }


        private void InitializeTimer()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // Интервал в миллисекундах (1000 мс = 1 секунда)
            timer.Tick += timer1_Tick; // Подписываемся на событие Tick
            timer.Start(); // Запускаем таймер
        }



        private void Form1_Load(object sender, EventArgs e)
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Здесь пишите код, который должен выполняться каждую секунду
            // Например, перемещение космического корабля
            spaceshipDistance += spaceshipSpeed;
            planet += 1;
            // Перерисовываем PictureBox
            if (planet / 9 < 1)
            {
                Thread.Sleep(200);
                spaceshipSize = 70;
                spaceshipSize2 = 30;
            }
            else if (planet / 9 == 1)
            {
                Thread.Sleep(200);
                spaceshipSize = 30;
                spaceshipSize2 = 70;

            }

            if (planet == 18)
            {
                planet = 0;
            }

            pictureBox1.Invalidate();

            spaceshipDistance2 -= spaceshipSpeed; // Перемещение второго корабля
            planetSize += 5; // Увеличение размера центральной планеты

            if (planetSize > 150) // Проверка размера центральной планеты
            {
                planetSize = 100; // Сброс размера центральной планеты
            }

            pictureBox1.Invalidate();

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            // Рисуем орбиту
            g.DrawEllipse(Pens.Black, center.X - orbitRadius, center.Y - orbitRadius, orbitRadius * 2, orbitRadius * 2);

            g.DrawEllipse(Pens.Green, center.X+50 - orbitRadius, center.Y+50 - orbitRadius, orbitRadius, orbitRadius);

            // Рисуем космический корабль
            int spaceshipX = center.X + (int)(Math.Cos(spaceshipDistance * Math.PI / 180) * orbitRadius);
            int spaceshipY = center.Y + (int)(Math.Sin(spaceshipDistance * Math.PI / 180) * orbitRadius);
            g.FillRectangle(Brushes.Red, spaceshipX - spaceshipSize / 2, spaceshipY - spaceshipSize / 2, spaceshipSize, spaceshipSize);


            // Рисуем вторую орбиту
            g.DrawEllipse(Pens.Black, center2.X - orbitRadius2, center2.Y - orbitRadius2, orbitRadius2 * 2, orbitRadius2 * 2);
            // Рисуем второй космический корабль
            int spaceshipX2 = center2.X + (int)(Math.Cos(spaceshipDistance2 * Math.PI / 180) * orbitRadius2);
            int spaceshipY2 = center2.Y + (int)(Math.Sin(spaceshipDistance2 * Math.PI / 180) * orbitRadius2);
            g.FillRectangle(Brushes.Blue, spaceshipX2 - spaceshipSize2 / 2, spaceshipY2 - spaceshipSize2 / 2, spaceshipSize2, spaceshipSize2);

            // Рисуем зеленую окружность с заливкой
            g.FillEllipse(Brushes.Green, center.X+50 - orbitRadius, center.Y+50 - orbitRadius, orbitRadius * 1, orbitRadius * 1);
        }
    }
}

