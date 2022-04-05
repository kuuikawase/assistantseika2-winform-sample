using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WinFormsApp4
{
    public partial class Form3 : Form
    {
        public string exepath;
        public string cid;
        public int i;
        public Label[] labels;

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            using (StreamReader sr = new StreamReader(".\\index.txt"))
            {
                exepath = sr.ReadLine();
                this.labels = new Label[100];
                i = 0;
                while (sr.EndOfStream == false)
                {
                    this.labels[i] = new Label();
                    this.labels[i].Text = sr.ReadLine();
                    this.labels[i].Top = 20 * i;
                    panel1.Controls.Add(this.labels[i]);
                    i += 1;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 d = new Form4();
            d.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form5 f = new Form5();
            f.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}
