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
    public partial class Form5 : Form
    {
        public string exepath;
        public string cid;
        public string text;
        public string str;
        public int i;

        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            using (StreamReader sr = new StreamReader(".\\index.txt"))
            {
                exepath = sr.ReadLine();
                System.Diagnostics.Process.Start(exepath);
                i = 0;
                while (sr.EndOfStream == false)
                {
                    comboBox1.Items.Add(sr.ReadLine());
                    i += 1;
                }
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cid = comboBox1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                text = Clipboard.GetText();
            }
            str = $"{exepath} cid-{cid} -t {text}";
            Console.WriteLine(str);
        }

        private void button1_Click(object sender, EventArgs e)
            {
            while (true)
            {
                if (text != Clipboard.GetText())
                {
                    if (Clipboard.ContainsText())
                    {
                        text = Clipboard.GetText();
                    }
                    str = $"{exepath} cid-{cid} -t {text}";
                    Console.WriteLine(str);
                }
                System.Threading.Thread.Sleep(5000);

            }
        }
    }
}
