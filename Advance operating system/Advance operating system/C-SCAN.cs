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
    public partial class C_SCAN : Form
    {
        Bitmap off;
        public int min = 9999999;
        List<DiskQ> L3 = new List<DiskQ>();
        List<DiskQ> LR3 = new List<DiskQ>();
        List<DiskQ> Lt3 = new List<DiskQ>();
        List<DiskQ> Lc3 = new List<DiskQ>();
        public int sub = 0;
        public int add = 0;
        public int f = 0;
        public C_SCAN()
        {
            InitializeComponent();
            this.Load += C_SCAN_Load;
            this.Paint += Form1_paint;
        }
        private void Form1_paint(object sender, PaintEventArgs e)
        {
            Dubblebuffer(e.Graphics);
        }
        void Dubblebuffer(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            Drowscene(g2);
            g.DrawImage(off, 0, 0);
        }
        void Drowscene(Graphics g)
        {
            g.Clear(Color.White);
            if (f == 1)
            {
                for (int i = 0; i < Lt3.Count; i++)
                {
                    g.DrawString(Lt3[i].v.ToString(), new Font("Times New Roman (Headings CS)", 10), Brushes.Red, 35 * i, 200);
                }
            }
            g.DrawString(add.ToString(), new Font("Times New Roman (Headings CS)", 10), Brushes.Red, 35, 100);
        }
        private void C_SCAN_Load(object sender, EventArgs e)
        {
            off = new Bitmap(ClientSize.Width, ClientSize.Height);
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            DiskQ pnn = new DiskQ();
            pnn.v = Convert.ToInt32(textBox1.Text);
            L3.Add(pnn);
            textBox1.Text = "";
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            for (int k = 0; k < L3.Count; k++)
            {
                if (min > L3[k].v)
                {
                    min = L3[k].v;
                }
            }
            DiskQ pnn = new DiskQ();
            pnn.v = min;
            LR3.Add(pnn);
            f = 1;
            min = 9999;
            for (int k = 0; k < LR3.Count; k++)
            {
                for (int a = 0; a < L3.Count; a++)
                {
                    if (LR3[LR3.Count - 1].v < L3[a].v)
                    {
                        if (min > L3[a].v)
                        {
                            min = L3[a].v;
                        }
                    }
                }
                if (k == L3.Count - 1)
                {
                    break;
                }
                pnn = new DiskQ();
                pnn.v = min;
                LR3.Add(pnn);
                min = 9999;
            }
            //////////////////////////
            int i;
            for (i = 0; i < LR3.Count - 1; i++)
            {
                if (LR3[i].v == L3[0].v)
                {
                    break;
                }
            }
            for (int w = i; w < LR3.Count; w++)
            {
                pnn = new DiskQ();
                pnn.v = LR3[w].v;
                Lt3.Add(pnn);
            }
            if (i != 0)
            {
                for (int w = 0 ; i > w; w++)
                {
                    pnn = new DiskQ();
                    pnn.v = LR3[w].v;
                    Lt3.Add(pnn);
                }
            }
            ////////////
            for (int w = 0; w < Lt3.Count - 1; w++)
            {
                sub = Lt3[w + 1].v - Lt3[w].v;
                pnn = new DiskQ();
                pnn.v = sub;
                Lc3.Add(pnn);
                sub = 0;
            }
            for (int w = 0; w < Lc3.Count; w++)
            {
                if (Lc3[w].v < 1)
                {
                    Lc3[w].v = Lc3[w].v * -1;
                }
            }
            add = 0;
            for (int w = 0; w < Lc3.Count; w++)
            {
                add = add + Lc3[w].v;
            }
            Dubblebuffer(CreateGraphics());
        }
    }
}