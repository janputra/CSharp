using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Created by janpoetra ( Jan Putra Bahtra Agung S. Pelawi/1221018)
        /// </summary>
        

        int i;
        string[] ports;
        double[] data = new double[100000];
        double temp, min;
        double vmax, vmin;
        private void Form1_Load(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisX.Maximum = 256;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            ports = SerialPort.GetPortNames();
            foreach (string port in ports) 
            {
                comboBox1.Items.Add(port);
            
            }
        }

        private void Form1_FormClosing(object sender, EventArgs e)
        {
               
 
                           


        }
      

        private void button1_Click(object sender, EventArgs e)
        {
          
                if (this.serialPort1.IsOpen)
                {

                    this.serialPort1.Close();
                    button1.Text = "Open";
                    timer1.Enabled = false;
                }
                else
                {
                    this.serialPort1.PortName = comboBox1.Text;
                    this.serialPort1.BaudRate = Convert.ToInt32(comboBox2.Text);
                    this.serialPort1.Open();
                    button1.Text = "Close";
                    timer1.Enabled = true;
                }

         
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
          
            data[i] = Convert.ToDouble(this.serialPort1.ReadByte());

          temp = data[i];
            if (vmax < temp)
            {
                vmax = temp;

            }
            if (vmin > temp)
            {

                vmin = temp;
            }
            min = (vmax - vmin) / 2;
           
            if (i > 49)
            {
                
                data[i-50] = ((data[i-50] - min) / 255) * 5;

                chart1.Series[0].Points.AddXY((i-50), data[i-50]);
                if (i == chart1.ChartAreas[0].AxisX.Maximum)
                {

                    chart1.ChartAreas[0].AxisX.Maximum = chart1.ChartAreas[0].AxisX.Maximum + 50;
                    chart1.ChartAreas[0].AxisX.Minimum = chart1.ChartAreas[0].AxisX.Minimum + 50;
                }



                if (i == 100000)
                {
                    i = 0;
                    chart1.ChartAreas[0].AxisX.Maximum = 256;
                    chart1.ChartAreas[0].AxisX.Minimum = 0;
                }
               
            }
            i++;
        }


    }
}
