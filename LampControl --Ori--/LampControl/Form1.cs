using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading;
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }




        bool portReady;

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] portnames;
            int[] Baudrate = { 9600, 115200 };
            portnames = SerialPort.GetPortNames();
            foreach (string port in portnames)
            {
                comboBox1.Items.Add(port);

            }
            foreach (int baud in Baudrate)
            {
                comboBox2.Items.Add(baud);
            }
            serialPort1.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived);

        }
        private void BtnPort_Click(object sender, EventArgs e)
        {
            string port = comboBox1.Text;
            int baud = Convert.ToInt16(comboBox2.Text);
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                    BtnPort.Text = "Connect";
                    portReady = false;
                    label5.Text = "Device Is Not Detected";
                    pictureBox1.Visible = true;
                    pictureBox2.Visible = false;
                    
                }
                else
                {

                    serialPort1.PortName = port;
                    serialPort1.BaudRate = baud;
                    serialPort1.Open();

                    serialPort1.Write("X");
                    Thread.Sleep(1000);
                    int handshake = serialPort1.ReadByte();
                    char returnMessage = Convert.ToChar(handshake);
                    if (returnMessage == 'Y')
                    {
                        BtnPort.Text = "Disconnect";
                        portReady = true;
                        label5.Text = "Device Is Detected";
                        pictureBox1.Visible = false;
                        pictureBox2.Visible = true;
                    }
                    else
                    {
                        serialPort1.Close();
                        label5.Text = "Device Is Not Detected";
                        pictureBox1.Visible = true;
                        pictureBox2.Visible = false;
                    
                    
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnLampu1_Click(object sender, EventArgs e)
        {
            if (portReady)
            {
                serialPort1.Write("A");

            }
        }

        private void BtnLampu2_Click(object sender, EventArgs e)
        {
            if (portReady)
            {
                serialPort1.Write("B");

            }
        }

       
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {                  
              
            if (portReady)
            {
                if (serialPort1.BytesToRead > 0)
                {
                    int inputdata = Convert.ToInt32(serialPort1.ReadByte());

                
                    if (inputdata == 10)
                    {
                       
                        SetText(this.BtnLampu1,"ON");
                        SetPicture(this.PB1ON, false);
                        SetPicture(this.PB1OFF, true);

                    }
                    else if (inputdata == 11)
                    {
                        SetText(this.BtnLampu1, "OFF");
                        SetPicture(this.PB1ON, true);
                        SetPicture(this.PB1OFF, false);
                    }
                    else if (inputdata == 20)
                    {
                        SetText(this.BtnLampu2, "ON");
                         SetPicture(this.PB2ON, false);
                         SetPicture(this.PB2OFF, true);

                    }
                    else if (inputdata == 21)
                    {
                        SetText(this.BtnLampu2, "OFF");
                        SetPicture(this.PB2ON, true);
                        SetPicture(this.PB2OFF, false);

                    }
                }}
            }

        void SetText(Button Button, string data) 
        {

            Button.Invoke(new Action(() =>
            {
                Button.Text = data;

            }));
        }

        void SetPicture(PictureBox PB, bool status) 
        {
            PB.Invoke(new Action(() =>
                {
                    PB.Visible = status;

                }));
        
        }

       
        





        }
    }

