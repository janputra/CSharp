using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NC_code_UNSM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Double x1 = 0.0, x2 = 0.0, y1 = 0.0, y2 = 10.0, z1 = 0.0, z2 = 10.0, temp = 0.0;
        Int16 feed = 2000;
        Int16 afeed = 1000;
        Double interval = 0.07;
        int count = 0;
        int i=0;
        private void Exit_Btt_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        bool flag = false;
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

    
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }


        void Write(System.IO.FileStream fs, string text)
        {
            text = text + "\r\n";
            Byte[] test = new UTF8Encoding(true).GetBytes(text);

            fs.Write(test, 0, test.Length);

        }



        void NC_gen(System.IO.FileStream fs, string name)
        {

            Write(fs, name + ";");
            Write(fs, "G98;");
            Write(fs, "G00 X100.000;");
            Write(fs, "G00 Y"+ y1.ToString("F3") + " Z" + z1.ToString("F3") + ";");
            Write(fs, "G00 X50.000;");
            Write(fs, "M00;");
            Write(fs, "M20;");
            Write(fs, "G01 X" + x1.ToString("F3") + " F" + afeed.ToString() + ";");


            
            if (radioButton1.Checked == true)
            {
                Write(fs, "G09 Y" + y2.ToString("F3") + " F" + feed.ToString() + ";");
                flag = false;
                temp = z1 + interval;
                while (temp <= z2)
                {



                    if (!flag)
                    {
                        Write(fs, "G09 Z" + temp.ToString("F3") + ";");
                        Write(fs, "G09 Y" + y1.ToString("F3") + ";");
                        flag = true;
                    }
                    else
                    {
                        Write(fs, "G09 Z" + temp.ToString("F3") + ";");
                        Write(fs, "G09 Y" + y2.ToString("F3") + ";");
                        flag = false;

                    }
                    temp = temp + interval;
                }


            }
            else if (radioButton2.Checked == true)
            {
                Write(fs, "G09 Z" + z2.ToString("F3") + " F" + feed.ToString() + ";");

                flag = false;
                temp = y1 + interval;
                while (temp <= y2)
                {


                    if (!flag)
                    {

                        Write(fs, "G09 Y" + temp.ToString("F3") + ";");
                        Write(fs, "G09 Z" + z1.ToString("F3") + ";");
                        flag = true;
                    }
                    else
                    {

                        Write(fs, "G09 Y" + temp.ToString("F3") + ";");
                        Write(fs, "G09 Z" + z2.ToString("F3") + ";");
                        flag = false;

                    }
                    temp = temp + interval;
                }




            }
            else if (radioButton3.Checked == true)
            {
                while (i < count)
                {

                    Write(fs, "G09 Y" + y2.ToString("F3") + " F" + feed.ToString() + ";");
                    flag = false;
                    temp = z1 + interval;
                    while (temp <= z2)
                    {



                        if (!flag)
                        {
                            Write(fs, "G09 Z" + temp.ToString("F3") + ";");
                            Write(fs, "G09 Y" + y1.ToString("F3") + ";");
                            flag = true;
                        }
                        else
                        {
                            Write(fs, "G09 Z" + temp.ToString("F3") + ";");
                            Write(fs, "G09 Y" + y2.ToString("F3") + ";");
                            flag = false;

                        }
                        temp = temp + interval;
                    }

                    Write(fs, "G00 X50.000;");
                    Write(fs, "G00 Y" + y1.ToString("F3") + " Z" + z1.ToString("F3") + ";");
                    Write(fs, "G01 X" + x1.ToString("F3") + " F" + afeed.ToString() + ";");
                    Write(fs, "G09 Z" + z2.ToString("F3") + " F" + feed.ToString() + ";");
                    flag = false;
                    temp = y1 + interval;
                    while (temp <= y2)
                    {


                        if (!flag)
                        {

                            Write(fs, "G09 Y" + temp.ToString("F3") + ";");
                            Write(fs, "G09 Z" + z1.ToString("F3") + ";");
                            flag = true;
                        }
                        else
                        {

                            Write(fs, "G09 Y" + temp.ToString("F3") + ";");
                            Write(fs, "G09 Z" + z2.ToString("F3") + ";");
                            flag = false;

                        }
                        temp = temp + interval;
                    }

                    i = i + 1;
                    if (i == count) {
                        break;
                    }

                    if (count > 1)
                    {
                        Write(fs, "G00 X50.000;");
                        Write(fs, "G00 Y" + y1.ToString("F3") + " Z" + z1.ToString("F3") + ";");
                        Write(fs, "G01 X" + x1.ToString("F3") + " F" + afeed.ToString() + ";");
                    }

                   
                }
                i = 0;
            }
            
            Write(fs, "G00 X100.000;");
            Write(fs, "M21;");
            Write(fs, "M30;");

        }




        private void Gen_butt_Click(object sender, EventArgs e)
        {

            x1 = Convert.ToDouble(textBox1.Text);
            x2 = Convert.ToDouble(textBox4.Text);
            y1 = Convert.ToDouble(textBox2.Text);
            y2 = Convert.ToDouble(textBox5.Text);
            z1 = Convert.ToDouble(textBox3.Text);
            z2 = Convert.ToDouble(textBox6.Text);
            feed = Convert.ToInt16(textBox7.Text);
            interval = Convert.ToDouble(textBox8.Text);
            afeed = Convert.ToInt16(textBox9.Text);
            count = Convert.ToInt16(textBox10.Text);

            SaveFileDialog saveFileDialog1 = new SaveFileDialog()
            {
               InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop), 
                Title = "Generate NC Code",
                DefaultExt = "nc",
                Filter = "NC(*.nc)|*.nc",
                FilterIndex = 1,
                RestoreDirectory = true,
                FileName="O0001"
            };
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                             
                string filename = saveFileDialog1.FileName;
                string name = System.IO.Path.GetFileNameWithoutExtension(filename);
                if (!System.IO.File.Exists(filename))
                {

                    using (System.IO.FileStream fs = System.IO.File.Create(filename))
                    {
                        NC_gen(fs,name);
                    }

                }

               




                
            }

        }
    }
}
