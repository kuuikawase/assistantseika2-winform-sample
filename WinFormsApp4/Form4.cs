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
    public partial class Form4 : Form
    {
        public string cid;
        public string exepath;
        public string str;
        public int i;
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileName　 =　(string[])e.Data.GetData(DataFormats.FileDrop, false);
            str = $"{exepath} cid-{cid} -f {fileName}";
            Console.WriteLine(str);

        }

        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cid = comboBox1.Text;
        }
    }
}
