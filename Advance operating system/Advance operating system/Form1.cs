using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Advance_operating_system
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FCFS f1 = new FCFS();
            f1.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            SCAN f2 = new SCAN();
            f2.Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            C_SCAN f3 = new C_SCAN();
            f3.Show();
        }
    }
}
