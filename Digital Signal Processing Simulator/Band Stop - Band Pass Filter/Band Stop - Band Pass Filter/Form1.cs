using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fs =  512;
        }

        int fs, i, j;
        int Amp1; int f1; int Amp2; int f2;
       double[] x = new double[10000];
       double[] y1 =new double[10000];
       double[] y2 = new double[10000];
       double[] y = new double[10000];
       double[] x1 = new double[10000];

       double[] x2 = new double[10000];
 void plot_DFT()
        {
            double temp_real, temp_imaj;
            double[] h_real = new double[10000], h_imaj = new double[10000], h_omega_before = new double[10000];
            chart3.Series[0].Points.Clear();
            chart3.ChartAreas[0].AxisY.Maximum = 5000;
            for (i = 0; i < fs/2 ; i++)
            {
                temp_real = 0;
                temp_imaj = 0;

                for (j = 0; j < fs/2 ; j++)
                {
                    h_real[i] = temp_real + y[j] * Math.Cos(2*i * Math.PI * j / fs);
                    temp_real = h_real[i];
                    h_imaj[i] = temp_imaj + y[j] * Math.Sin(2*i * Math.PI * j / fs);
                    temp_imaj = h_imaj[i];
                }
                h_omega_before[i] = Math.Sqrt((h_real[i] * h_real[i]) + (h_imaj[i] * h_imaj[i]));
                chart3.Series[0].Points.Add(i, h_omega_before[i]);
            }
        }
        
        void InpSig() 
        {
            chart1.Series[0].Points.Clear();
         
           
            for (i = 0; i < fs; i++) 
            {
                x1[i] = Amp1 * Math.Sin(2 * Math.PI * f1 * i / fs);
                x2[i] = Amp2 * Math.Sin(2 * Math.PI * f2 * i / fs);
                x[i] = x1[i] + x2[i];
                chart1.Series[0].Points.AddXY(i, x[i]);
            }
        
        
        }


 


        void h1()
        {
            chart2.Series[0].Points.Clear();
  
            for (i = 0; i < fs; i++)
            {
                if (i == 0)
                {
                    y1[i] = (0.5 * x[i]);
   
                }
                else if (i == 1)
                {
                    y1[i] = (0.5 * x[i]) + (0.5 * x[i - 1]);
                   
                }
                else
                {
                    y1[i] = (0.5 * x[i]) + (0.5 * x[i - 1]) + (0.5 * x[i - 2]);
                    
                }
                y[i] = y1[i];
                chart2.Series[0].Points.AddXY(i, y[i]);
            }
            
        }
        void h2()
        {
            chart2.Series[0].Points.Clear();
           
            for (i = 0; i < fs; i++)
            {
                if (i == 0)
                {
                   
                    y2[i] = (0.5 * x[i]);
                }
                else if (i == 1)
                {
                   
                    y2[i] = (0.5 * x[i]) - (0.5 * x[i - 1]);
                }
                else
                {
                   
                    y2[i] = (0.5 * x[i]) - (0.5 * x[i - 1]) - (0.5 * x[i - 2]);
                }
                y[i] = y2[i];
                chart2.Series[0].Points.AddXY(i, y[i]);
            }
           

        }
        
        void filter1()
        {
          

            
           h1();
            for (i = 0; i < fs; i++)
            {
                x[i] = y1[i];

            }
            h2();
          

        }
       
        void filter2()
        {
           
            h1();
            h2();
            chart2.Series[0].Points.Clear();
            for (i = 0; i < fs; i++)
            {
                y[i] = y1[1] + y2[i];
                chart2.Series[0].Points.AddXY(i, y[i]);

            }

        }
    
        void process() 
        {
            Amp1 = trackBar1.Value;
            textBox1.Text = Convert.ToString(Amp1);
            f1 = trackBar2.Value;
            textBox2.Text = Convert.ToString(f1);

            Amp2 = trackBar4.Value;
            textBox4.Text = Convert.ToString(Amp2);

            f2 = trackBar3.Value;
            textBox3.Text = Convert.ToString(f2);
            InpSig();
            if (radioButton1.Checked == true)
            {
                h1();
            }
            if (radioButton2.Checked == true)
            {
                h2();
                
            }
            if (radioButton4.Checked == true)
            {
                filter1();
            }
            if (radioButton3.Checked == true)
            {
                filter2();
            }


            plot_DFT();
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
               process();
                 
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
              
               process();
            
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
                process();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
              process();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
               process();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            process();
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            process();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            process();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }
    }
}
