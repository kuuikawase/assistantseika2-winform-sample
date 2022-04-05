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
    public partial class Form2 : Form
    {
        public int i;
        public Form2()
        {
            InitializeComponent();
        }

        private testButton[] buttons;
        private const int ElementNum = 100;

        private void Form2_Load(object sender, EventArgs e)
        {
            using (StreamReader sr = new StreamReader(".\\index.txt"))
            {

                this.buttons = new testButton[ElementNum];
                label2.Text = sr.ReadLine();
                textBox1.Text = label2.Text;
                int i = 0;

                while (sr.EndOfStream == false)
                {
                    this.buttons[i] = new testButton();
                    this.buttons[i].targetlabel = label5;
                    this.buttons[i].Text = sr.ReadLine();
                    this.buttons[i].Top = i * 30;
                    panel1.Controls.Add(this.buttons[i]);
                    i += 1;
                }
            }
        }




        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            label2.Text=textBox1.Text;
            using (StreamWriter writer = new StreamWriter(".\\index.txt", false, Encoding.UTF8))
            {
                writer.WriteLine(textBox1.Text);
                if (buttons[0]!=null){
                    for (int s = 0; s < i; s++)
                    {
                        writer.WriteLine(buttons[s].Text);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label2.Text = textBox1.Text;
            i += 1;
            string text1 = textBox2.Text;
            string text2 = textBox3.Text;
            this.buttons[i] = new testButton();
            this.buttons[i].Text = $"{text1}:{text2}";
            this.buttons[i].Top = i * 30;
            panel1.Controls.Add(this.buttons[i]);
            using (StreamWriter writer = new StreamWriter(".\\index.txt", false, Encoding.UTF8))
            {
                writer.WriteLine(textBox1.Text);
                if (buttons[0] != null)
                {
                    for (int s = 0; s <= i; s++)
                    {
                        writer.WriteLine(buttons[s].Text);
                    }
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void button4_Click(object sender, EventArgs e)
        {
            label2.Text = textBox1.Text;
            using (StreamReader sr = new StreamReader(".\\index.txt"))
            {

                this.buttons = new testButton[ElementNum];
                textBox1.Text = sr.ReadLine();
                int i = 0;

                while (sr.EndOfStream == false)
                {
                    this.buttons[i] = new testButton();
                    this.buttons[i].targetlabel = label5;
                    this.buttons[i].Text = sr.ReadLine();
                    this.buttons[i].Top = i * 30;
                    panel1.Controls.Add(this.buttons[i]);
                }
            }
        }

        public class testButton : Button
        {
            public string buttonMsg { get; set; }

            public Label targetlabel { get; set; }

            public void eventMaking()
            {
                this.Click += new EventHandler(doClickEvent);
            }

            public void eventSuspend()
            {
                this.Click -= new EventHandler(doClickEvent);
            }

            public void doClickEvent(object sender, EventArgs e)
            {
                this.targetlabel.Text =this.buttonMsg;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || '9' < e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form2_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileName = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            textBox1.Text = fileName[0];
        }

        private void Form2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }
    }
}
