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
    public partial class SCAN : Form
    {
        Bitmap off;
        public int min = 9999999;
        List<DiskQ> L2 = new List<DiskQ>();
        List<DiskQ> LR2 = new List<DiskQ>();
        List<DiskQ> Lt2 = new List<DiskQ>();
        List<DiskQ> Lc2 = new List<DiskQ>();
        public int sub = 0;
        public int add = 0;
        public int f = 0;
        public SCAN()
        {
            InitializeComponent();
            this.Load += SCAN_Load;
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
                for (int i = 0; i < Lt2.Count; i++)
                {
                    g.DrawString(Lt2[i].v.ToString(), new Font("Times New Roman (Headings CS)", 10), Brushes.Red, 35 * i, 200);
                }
            }
            g.DrawString(add.ToString(), new Font("Times New Roman (Headings CS)", 10), Brushes.Red, 35, 100);
        }
        private void SCAN_Load(object sender, EventArgs e)
        {
            off = new Bitmap(ClientSize.Width, ClientSize.Height);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DiskQ pnn = new DiskQ();
            pnn.v = Convert.ToInt32(textBox1.Text);
            L2.Add(pnn);
            textBox1.Text = "";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            for (int k = 0; k < L2.Count; k++)
            {
                if (min > L2[k].v)
                {
                    min = L2[k].v;
                }
            }
            DiskQ pnn = new DiskQ();
            pnn.v = min;
            LR2.Add(pnn);
            f = 1;
            min = 9999;
            for (int k = 0; k < LR2.Count; k++)
            {
                for (int a = 0; a < L2.Count; a++)
                {
                    if (LR2[LR2.Count - 1].v < L2[a].v)
                    {
                        if (min > L2[a].v)
                        {
                            min = L2[a].v;
                        }
                    }
                }
                if (k == L2.Count - 1)
                {
                    break;
                }
                pnn = new DiskQ();
                pnn.v = min;
                LR2.Add(pnn);
                min = 9999;
            }
            //////////////////////////
            int i;
            for ( i = 0; i < LR2.Count - 1; i++)
            {
                if(LR2[i].v== L2[0].v)
                {
                    break;
                }
            }
            for(int w=i;w<LR2.Count;w++)
            {
                pnn = new DiskQ();
                pnn.v = LR2[w].v;
                Lt2.Add(pnn);
            }
            if (i != 0)
            {
                for (int w = i - 1; w >= 0; w--)
                {
                    pnn = new DiskQ();
                    pnn.v = LR2[w].v;
                    Lt2.Add(pnn);
                }
            }
            ////////////
            for (int w = 0; w < Lt2.Count - 1; w++)
            {
                sub = Lt2[w + 1].v - Lt2[w].v;
                pnn = new DiskQ();
                pnn.v = sub;
                Lc2.Add(pnn);
                sub = 0;
            }
            for (int w = 0; w < Lc2.Count; w++)
            {
                if (Lc2[w].v < 1)
                {
                    Lc2[w].v = Lc2[w].v * -1;
                }
            }
            add = 0;
            for (int w = 0; w < Lc2.Count; w++)
            {
                add = add + Lc2[w].v;
            }
            Dubblebuffer(CreateGraphics());
        }
    }
}