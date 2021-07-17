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

namespace FileCrusher
{  
    public partial class Form1 : Form
    {
        string filepath = "Input";
        int lowerbound = 128;
        int upperbound = 512;
        int start = 512;
        int finish = 60000;
        string outputpath = "Output";
        public Form1()
      {
            InitializeComponent();
            
        }


        private void textBox1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                filepath = textBox1.Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            filepath = openFileDialog1.FileName;
            textBox1.Text = filepath;

        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                outputpath = textBox2.Text;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            outputpath = saveFileDialog1.FileName;
            textBox2.Text = outputpath;
        }

        private void button3_Click(object sender, EventArgs e)
           {
                File.Copy(filepath, outputpath, true);
                using (var stream = new FileStream(outputpath, FileMode.Open, FileAccess.ReadWrite))
                {
                    var rand = new Random();
                    Byte[] b = new Byte[10];
                    rand.NextBytes(b);
                    int counter = start;
                    while (counter < finish)
                    {
                        counter = rand.Next(3000, 5000) + counter;
                        stream.Position = counter;
                        stream.WriteByte(b[1]);
                    }
                }
                pictureBox2.ImageLocation = outputpath;
          
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            upperbound = trackBar1.Value;
           
            if (lowerbound > upperbound)
            {
                upperbound = lowerbound + 1;
                trackBar1.Value = upperbound;
            }
            textBox5.Text = upperbound.ToString();

        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            lowerbound = trackBar2.Value;
            
            if (lowerbound > upperbound)
            {
                lowerbound = upperbound - 1;
                trackBar2.Value = lowerbound;
                    }
            textBox6.Text = lowerbound.ToString();

        }



        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            start = Int32.Parse(textBox3.Text);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            finish = Int32.Parse(textBox4.Text);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}
