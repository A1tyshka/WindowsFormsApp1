using lab_3_kg_zadanie;
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
    public partial class MainForm3 : Form
    {
        public MainForm3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.showdialog;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Evdokimino f = new Evdokimino();
            f.ShowDialog();
        }
    }
}
