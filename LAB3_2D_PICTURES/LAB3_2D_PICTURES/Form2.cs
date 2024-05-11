using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using lab_3_kg_zadanie;
using Задание_10;

namespace LAB3_2D_PICTURES
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Formdota f2 = new Formdota();
            f2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormOTec f2 = new FormOTec();
            f2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Evdokimino f2 = new Evdokimino();
            f2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f2 = new Form1();
            f2.Show();
        }
    }
}
