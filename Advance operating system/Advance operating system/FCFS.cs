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
    public partial class FCFS : Form
    {
        Bitmap off;
        public int min = 9999999;
        List<DiskQ> L = new List<DiskQ>();
        List<DiskQ> LR = new List<DiskQ>();
        List<DiskQ> Lt = new List<DiskQ>();
        public int sub = 0;
        public int add = 0;
        public int f = 0;
        public FCFS()
        {
            InitializeComponent();
            this.Load += FCFS_Load;
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
                for (int i =0; i < LR.Count; i++)
                {
                    g.DrawString(LR[i].v.ToString(), new Font("Times New Roman (Headings CS)", 10), Brushes.Red, 35*i, 250);
                }      
            }
            g.DrawString(add.ToString(), new Font("Times New Roman (Headings CS)", 10), Brushes.Red, 35 , 100);
        }
        private void FCFS_Load(object sender, EventArgs e)
        {
            off = new Bitmap(ClientSize.Width, ClientSize.Height);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DiskQ pnn = new DiskQ();
            pnn.v = Convert.ToInt32(textBox1.Text);
            L.Add(pnn);
            textBox1.Text = "";
        }
        private void button2_Click(object sender, EventArgs e)
        {          
            for (int i = 0; i < L.Count; i++)
            {
                if (min > L[i].v)
                {
                    min = L[i].v;       
                }
            }
            DiskQ pnn = new DiskQ();
            pnn.v = min;
            LR.Add(pnn);
            f = 1;
            min = 9999;
            for (int i = 0; i < LR.Count; i++)
            {
                for (int a = 0; a < L.Count; a++)
                {
                    if(LR[LR.Count-1].v <L[a].v)
                    {
                        if(min>L[a].v)
                        {
                            min = L[a].v;
                        }
                    }
                }
                if (i == L.Count - 1)
                {
                    break;
                }
                pnn = new DiskQ();
                pnn.v = min;
                LR.Add(pnn);
                min = 9999;    
            }
            for(int i=0;i<L.Count-1;i++)
            {
                sub = L[i + 1].v - L[i].v;
                pnn = new DiskQ();
                pnn.v = sub;
                Lt.Add(pnn);
                sub = 0;
            }
            for(int i=0;i<Lt.Count;i++)
            {
                if(Lt[i].v<1)
                {
                    Lt[i].v = Lt[i].v * -1;  
                }
            }
            for (int i = 0; i < Lt.Count; i++)
            {
                add = add + Lt[i].v;
            }
                Dubblebuffer(CreateGraphics());
        }
    }
    class DiskQ
    {
        public int v;
    }
}