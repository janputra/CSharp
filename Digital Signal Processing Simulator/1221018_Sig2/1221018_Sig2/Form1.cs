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
        int i,fs,amp, f;
        double[] x = new double [10000];
        double[] x1 = new double[10000];
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            amp = trackBar1.Value;
            f = trackBar2.Value;
            textBox1.Text = Convert.ToString(trackBar1.Value);
            sig0(amp, f);
            sig1(amp, f);
            sig2(amp, f);
            sig3(amp, f);

        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            amp = trackBar1.Value;
            f = trackBar2.Value;
            textBox2.Text = Convert.ToString(trackBar2.Value);
            sig0(amp, f);
            sig1(amp, f);
            sig2(amp, f);
            sig3(amp, f);

        }
    
    
    void sig0(int amp, int f)
    {

        chart1.Series[0].Points.Clear();
        for (i = 0; i <= fs; i++)
        {
            x[i] = (amp * Math.Sin(2 * Math.PI * f * i / fs));
            chart1.Series[0].Points.AddXY(i, x[i]);
        }
    
        
    }


        void sig1(int amp,int f)
    {

        chart2.Series[0].Points.Clear();
        for (i = 3; i <= fs; i++)
            {
            x1[i] = (x[i] + x[i - 3]) / 3 + x1[i - 1];
                
            chart2.Series[0].Points.AddXY(i, x1[i]);
           
        }
   
    
    }


        void sig2(int amp, int f)
        {
            chart3.Series[0].Points.Clear();
            for (i = 2; i <= fs; i++)
            {
                x1[i] = 0.125 * x1[i - 2] + 0.5 * x1[i - 1] + 0.5 * x[i - 2];


                chart3.Series[0].Points.AddXY(i, x1[i]);
            } 
        }

        void sig3(int amp, int f) 
        {
            chart4.Series[0].Points.Clear();

            for (i = 1; i <= fs; i++)
            { 
               x1[i] = x[i] + 0.8 * x[i - 1] + 0.6 * x1[i - 1];
           
            chart4.Series[0].Points.AddXY(i, x1[i]);
           }
        }
    private void Form1_Load(object sender, EventArgs e)
    {
        fs = 1024;
    }

    }


}
