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

        /// <summary>
        /// Created by janpoetra (Name/NPM : Jan Putra Bahtra Agung S. Pelawi/1221018)
        /// Wall Follower Robotino using Fuzzy Logic Controller
        /// </summary>



        Robot robot = new Robot();
        double vx, vy,omega;
        double m1, m2, m3;
        int t;
        float s1, s2, s3;
        double[] x1 = new double[3], x2 = new double[3], x3 = new double[3];
        double[,,] x = new double[3,3,3];
        double[, ,] ux = new double[3, 3, 3];
        double[, ,] uy = new double[3, 3, 3];
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        double DegtoRad(int x) 
        {
            double hasil;
            hasil = (Math.PI / 180) * x;
            return hasil;
        }
       
        void omnidrive(int x, int y, int omega) // x --> velocity in x-axis, y --> velocity in y-axis, omega --> rotation
        {
       
            int theta = 0;
            double R = 0.12;
            double r = 0.04;

            m1 = (-Math.Sin(DegtoRad(theta))) * Math.Cos(DegtoRad(theta)) * x;   // velocity value for 1st motor
            m1 = m1 + (Math.Cos(DegtoRad(theta)) * Math.Cos(DegtoRad(theta)) * y);
            m1 = m1 + (R * omega);
            m1 = m1 / r;

            m2 = (-Math.Sin(DegtoRad(theta + 120))) * Math.Cos(DegtoRad(theta)) * x;   // velocity value for 2nd motor
            m2 = m2 + (Math.Cos(DegtoRad(theta + 120))  * Math.Cos(DegtoRad(theta)) * y);
            m2 = m2 + (R * omega);
            m2 = m2 / r;

            m3 = (-Math.Sin(DegtoRad(theta + 240))) * Math.Cos(DegtoRad(theta)) * x;   // velocity value for 3nd motor
            m3 = m3 + (Math.Cos(DegtoRad(theta + 240))  * Math.Cos(DegtoRad(theta)) * y);
            
            m3 = m3 + (R * omega);
            
            m3 = m3 / r;

              robot.wheel(0, Convert.ToSingle(m2));
              robot.wheel(1, Convert.ToSingle(m1));
              robot.wheel(2, Convert.ToSingle(m3));    
                        

        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Connect")
            {
                robot.Connect(textBox1.Text, true);
                button1.Text = "Disconnect";
            }
            else 
            {
                robot.Disconnect();
                
                button1.Text = "Connect";
            }
        }

        void  fuzzifikasi(double[] x,float s) 
        {
            double z = 0, a = 0.75, b = 1.5, c = 2.25, d = 3; //inisialisasi konstanta yang digunakan


            //proses fuzzifikasi saat kondisi sensor depan jauh
            if ((s <= z) || (s >= b))
            {
                x[0] = 0;
            }
            else if ((s > z) && (s < a))
            {
                x[0] = 1;
            }
            else if ((s >= a) && (s < b))
            {
                x[0] = ((b - s) / (b - a));
            }
            else
            {
                x[0] = 0;
            }

            //proses fuzzifikasi saat kondisi sensor depan normal
            if (s <= a || s >= c)
            {
                x[1] = 0;
            }
            else if (s > a && s <= b)
            {
                x[1] = (s - a) / (b - a);
            }
            else if (s > b && s < c)
            {
                x[1] = (c - s) / (c - b);
            }
            else
            {
                x[1] = 0;
            }

            //proses fuzzifikasi saat kondisi sensor depan dekat
            if (s <= b || s >= d)
            {
                x[2] = 0;
            }
            else if (s > b && s <= c)
            {
                x[2] = (s - b) / (c - b);
            }
            else if (s > c && s < d)
            {
                x[2] = 1;
            }
            else
            {
                x[2] = 0;
            }
        
        
        }

        void rule_evaluation() 
        {
            double MAC,Z,MAL,MUC,MUL, KAC,KAL,KAS;
            MAC = 200;
            MAL=100;
            Z=0;
            MUC=-200;
            MUL=-100;
            KAC = 400;
            KAS = 300;
            KAL = 200;

           int i, j, k;

            for (i = 0; i < 3; i++)
            {
                for (j = 0; j < 3; j++)
                {
                    for (k = 0; k < 3; k++)
                    {
                      x[i, j, k] = Math.Min(x1[i], Math.Min(x2[j], x3[k]));
                      
                    }
                }
            }
        
            ux[0,0,0]=MAC;uy[0,0,0]=Z; //rule1
            ux[0,0,1]=MUC;uy[0,0,1]=Z;//rule2
            ux[0,0,2]=MUC;uy[0,0,2]=Z;//rule3

            ux[0,1,0]=MUL;uy[0,1,0]=Z;//rule4
            ux[0,1,1]=MUL;uy[0,1,1]=Z;//rule5
            ux[0,1,2]=MUL;uy[0,1,2]=Z;//rule6
           
            ux[0,2,0]=Z;uy[0,2,0]=KAC;//rule7
            ux[0,2,1]=Z;uy[0,2,1]=KAS;//rule8
            ux[0,2,2]=Z;uy[0,2,2]=KAL;//rule9

            ux[1,0,0]=Z;uy[1,0,0]=KAC; //rule10
            ux[1,0,1]=Z;uy[1,0,1]=KAS;//rule11
            ux[1,0,2]=Z;uy[1,0,2]=KAL;//rule12

            ux[1,1,0]=Z;uy[1,1,0]=KAC;//rule13
            ux[1,1,1]=Z;uy[1,1,1]=KAS;//rule14
            ux[1,1,2]=Z;uy[1,1,2]=KAL;//rule15
           
            ux[1,2,0]=Z;uy[1,2,0]=KAC;//rule16
            ux[1,2,1]=Z;uy[1,2,1]=KAS;//rule17
            ux[1,2,2]=Z;uy[1,2,2]=KAL;//rule18

            
            ux[2,0,0]=MAC;uy[2,0,0]=Z;//rule19
            ux[2,0,1]=MAC;uy[2,0,1]=Z;//rule20
            ux[2,0,2]=Z;uy[2,0,2]=Z;//rule21

            ux[2,1,0]=MAL;uy[2,1,0]=KAC;//rule22
            ux[2,1,1]=MAL;uy[2,1,1]=KAS;//rule23
            ux[2,1,2]=MAL;uy[2,1,2]=KAL;//rule24
           
            ux[2,2,0]=Z;uy[2,2,0]=KAC;//rule25
            ux[2,2,1]=Z;uy[2,2,1]=KAS;//rule26
            ux[2,2,2]=Z;uy[2,2,2]=Z;//rule27
           
        }
        void defuzzifikasi()
        {
            int i, j, k;
           double sigmaX = 0;
           vy = 0; vx = 0; 
            for (i = 0; i < 3; i++)
            {
                for (j = 0; j < 3; j++)
                {
                    for (k = 0; k < 3; k++)
                    {
                        vx = vx+(x[i,j,k]*ux[i,j,k]);
                        vy = vy + (x[i, j, k] * uy[i, j, k]); ;
                        sigmaX = sigmaX + x[i, j, k];
                       
                    }
                }
            }

            vx = vx / sigmaX;
            vy = vy / sigmaX;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {

            t++;
            s2 = robot.distance(0);
            s1 = robot.distance(1);
            s3 = robot.distance(8);
            fuzzifikasi(x1, s1);
            fuzzifikasi(x2, s2);
            fuzzifikasi(x3, s3);
            rule_evaluation();
            defuzzifikasi();
            omnidrive((int)vx, (int)vy, 0);
            data();
        }

        void data()
        {
            textBox46.Text = Convert.ToString(vx);
            textBox43.Text = Convert.ToString(vy);
            textBox40.Text = Convert.ToString(omega);

            textBox2.Text = Convert.ToString(x1[0]);
            textBox7.Text = Convert.ToString(x1[1]);
            textBox10.Text = Convert.ToString(x1[2]);

            textBox3.Text = Convert.ToString(x2[0]);
            textBox6.Text = Convert.ToString(x2[1]);
            textBox9.Text = Convert.ToString(x2[2]);

            textBox4.Text = Convert.ToString(x3[0]);
            textBox5.Text = Convert.ToString(x3[1]);
            textBox8.Text = Convert.ToString(x3[2]);


            textBox19.Text = Convert.ToString(x[0,0,0]);
            textBox16.Text = Convert.ToString(x[0,0,1]);
            textBox13.Text = Convert.ToString(x[0,0,2]);

            textBox18.Text = Convert.ToString(x[0, 1, 0]);
            textBox15.Text = Convert.ToString(x[0, 1, 1]);
            textBox12.Text = Convert.ToString(x[0, 1, 2]);

            textBox17.Text = Convert.ToString(x[0, 2, 0]);
            textBox14.Text = Convert.ToString(x[0, 2, 1]);
            textBox11.Text = Convert.ToString(x[0, 2, 2]);

            textBox28.Text = Convert.ToString(x[1, 0, 0]);
            textBox25.Text = Convert.ToString(x[1, 0, 1]);
            textBox22.Text = Convert.ToString(x[1, 0, 2]);

            textBox27.Text = Convert.ToString(x[1, 1, 0]);
            textBox24.Text = Convert.ToString(x[1, 1, 1]);
            textBox21.Text = Convert.ToString(x[1, 1, 2]);

            textBox26.Text = Convert.ToString(x[1, 2, 0]);
            textBox23.Text = Convert.ToString(x[1, 2, 1]);
            textBox20.Text = Convert.ToString(x[1, 2, 2]);


            textBox37.Text = Convert.ToString(x[2, 0, 0]);
            textBox34.Text = Convert.ToString(x[2, 0, 1]);
            textBox31.Text = Convert.ToString(x[2, 0, 2]);

            textBox36.Text = Convert.ToString(x[2, 1, 0]);
            textBox33.Text = Convert.ToString(x[2, 1, 1]);
            textBox30.Text = Convert.ToString(x[2, 1, 2]);

            textBox35.Text = Convert.ToString(x[2, 2, 0]);
            textBox32.Text = Convert.ToString(x[2, 2, 1]);
            textBox29.Text = Convert.ToString(x[2, 2, 2]);
            textBox41.Text = Convert.ToString(distanceData(1));
            textBox39.Text = Convert.ToString(distanceData(0));
            textBox38.Text = Convert.ToString(distanceData(8));
            
            chart1.Series[0].Points.AddXY(t, vx);
            chart1.Series[1].Points.AddXY(t, vy);
            chart1.Series[2].Points.AddXY(t, omega);
        }


        double distanceData(uint i) 
        {
            double hasil;
            hasil = 34 - (robot.distance(i) * 11.811023622047244094488188976378);
            return hasil;
        }
        private void button13_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            omnidrive(200, 0, 0);
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            omnidrive(200, -100, 0);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            omnidrive(200, 100, 0);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            omnidrive(0, 0, 0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            omnidrive(0, -200, 0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            omnidrive(0, 200, 0);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            omnidrive(0, 0, -300);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            omnidrive(0, 0, 300);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            omnidrive(-200, 0, 0);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            omnidrive(-200, -100, 0);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            omnidrive(-200, 100, 0);
        }

 
      
    }
}
