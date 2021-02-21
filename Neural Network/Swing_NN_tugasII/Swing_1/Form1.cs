using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Swing_1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        
        double[,] a1 = new double[100, 10000];
        
        double[,] w3 = new double[1000, 1000];
        double[,] w2 = new double[1000, 1000];
        double[,] w1 = new double[1000, 1000];
        double[,] s3 = new double[10, 100000];
        double[,] s2 = new double[100, 100000];
        double[,] s1 = new double[100, 100000];
       
        double[,] a3 = new double[100, 10000];
        
        double[,] a2 = new double[100, 10000];
        double[] es1 = new double[1000];
        double[] es2 = new double[1000];
        double[] p = new double[1000];
  
        double[] ee = new double[1000000];
        double[] tho = new double[1000000];
        double[] ttd = new double[1000000];
        double[] g3 = new double[1000];
        double[] g2 = new double[1000];
        double[] g1 = new double[1000];
        int inersia, jml_input, gain, jml_output, hidden1, hidden2, jj, epo;
        double sse,bfr, n1, n2, n3, err, deg,  tt2, c, tt1, tt0, kons, alpha, momentum;
       
        double g = 9.8;
        double ma = 20;
        private double PendulumMass = 1;
        private double PendulumLength = 1;
        private double DampingCoefficient = 0.5;
        private double Theta0 = 75;
        private double Alpha0 = 0;
        int scale;
        double[] xx = new double[2];
        double time = 0;
        double dt = 0.003;
       
        double deg_tar;
        double xMax = 50;
        int posx1;
        Pen black = new Pen(Color.Black);
        Pen red = new Pen(Color.Red);

        private void btnStart_Click(object sender, EventArgs e)
        {
            posx1 = 0; 
            scale = 5;
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            
            PendulumMass = Double.Parse(tbMass.Text);
            PendulumLength = Double.Parse(tbLength.Text);
            DampingCoefficient = Double.Parse(tbDamping.Text);
            Theta0 = Double.Parse(tbTheta0.Text);
            Theta0 = Math.PI * Theta0 / 180;
            Alpha0 = Double.Parse(tbAlpha0.Text);
            Alpha0 = Math.PI * Alpha0 / 180;
      
            time = 0;
            xx = new double[2] { Theta0, Alpha0 };
            // Invoke ODE solver:
            for (int i = 0; i < (scale*1000); i++)
            {
                ODESolver.Function[] f = new ODESolver.Function[2] { f1, f2 };
                double[] result = ODESolver.RungeKutta4(f, xx, time, dt);
                if (time < xMax)
                xx = result;
                time += dt;
                textBox1.Text = Convert.ToString(180 * xx[0] / Math.PI);
                deg_tar = 180 * xx[0] / Math.PI;
                gain = int.Parse(textGain.Text);
                NN_Control();
                gambar_graf(); 
                pictureBox1.Invalidate();
                Delay(0.0001);
                if (time > 0 && Math.Abs(result[0]) < 0.01 && Math.Abs(result[1]) < 0.001)
                {
                    Delay(0);
                    i = (scale * 1000);
                }
            }
          
        }
     
        public void gambar_graf()
        {
            posx1++;
           
            chart1.Series[0].Points.AddXY(posx1, deg_tar);
            chart1.Series[1].Points.AddXY(posx1, deg);
            
        }
       
        private double f1(double[] xx, double t)
        {
            return xx[1];
        }
        private double f2(double[] xx, double t)
        {
            double m = PendulumMass;
            double L = PendulumLength;
            double g = 9.81;
            double b = DampingCoefficient;
            return (-g * Math.Sin(xx[0]) / L) - (b * xx[1] / m);
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            int cx = pictureBox1.ClientSize.Width / 2;
            int cy = (pictureBox1.ClientSize.Height / 2) - 60;
            e.Graphics.Clear(Color.White);
            //=================================================== target pendulum
            e.Graphics.ResetTransform();
            e.Graphics.TranslateTransform(cx, cy);
            e.Graphics.FillEllipse(Brushes.Blue, -15, -9, 25, 25);
            e.Graphics.DrawEllipse(Pens.Blue, -15, -9, 25, 25);
            e.Graphics.RotateTransform((float)-deg_tar + 90, System.Drawing.Drawing2D.MatrixOrder.Prepend);
            e.Graphics.FillRectangle(Brushes.Blue, 0, 0, (float)PendulumLength * 100, 2);
            e.Graphics.DrawRectangle(Pens.Blue, 0, 0, (float)PendulumLength * 100, 2);
            e.Graphics.TranslateTransform((float)PendulumLength * 100, 0, System.Drawing.Drawing2D.MatrixOrder.Prepend);
            e.Graphics.FillEllipse(Brushes.Red, 0, -7, Convert.ToInt16(PendulumMass * 10), Convert.ToInt16(PendulumMass * 10));
            e.Graphics.DrawEllipse(Pens.Red, 0, -7, Convert.ToInt16(PendulumMass * 10), Convert.ToInt16(PendulumMass * 10));

            //=================================================== output pendulum
            e.Graphics.ResetTransform();
            e.Graphics.TranslateTransform(cx, cy);
            //e.Graphics.FillEllipse(Brushes.Blue, -15, -9, 25, 25);
            //e.Graphics.DrawEllipse(Pens.Blue, -15, -9, 25, 25);
            e.Graphics.RotateTransform((float)-deg + 90, System.Drawing.Drawing2D.MatrixOrder.Prepend);
           // e.Graphics.FillRectangle(Brushes.Blue, 0, 0, (float)PendulumLength * 100, 2);
            e.Graphics.DrawRectangle(Pens.Blue, 0, -1, (float)PendulumLength * 100, 7);
            e.Graphics.TranslateTransform((float)PendulumLength * 100, 0, System.Drawing.Drawing2D.MatrixOrder.Prepend);
           // e.Graphics.FillEllipse(Brushes.Red, 0, -7, Convert.ToInt16(PendulumMass * 10), Convert.ToInt16(PendulumMass * 10));
            e.Graphics.DrawEllipse(Pens.Red, 0, -10, Convert.ToInt16(PendulumMass * 13), Convert.ToInt16(PendulumMass * 13));
        }
  
        public void Delay(double dblSecs)
        {
            const double OneSec = 1.0 / (1440.0 * 60.0);
            System.DateTime dblWaitTil = default(System.DateTime);
            DateTime.Now.AddSeconds(OneSec);
            dblWaitTil = DateTime.Now.AddSeconds(OneSec).AddSeconds(dblSecs);
            while (!(DateTime.Now > dblWaitTil))
            {
                Application.DoEvents();   // Allow windows messages to be processed
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            inersia = 8;
            jml_input = 4;
            jml_output = 1;
            c = 50;
            kons = 20;
            alpha = 0.4;
            momentum = 0.8;
            
            hidden1 = 8;
            hidden2 = 8;
          
           
           
            jj = 0;

            //============================================================================================ inisialisasi
           

            for(int z=1; z<=jml_input; z++)
            {
                for(int i=1; i<=hidden1; i++)
                {
                    w1[z, i] = (1 / (10)) - 0.5;
                   
                }
            }

            for(int k=1; k<=hidden1; k++)
            {
                for(int z=1; z<=hidden2; z++)
                {
                    w2[k, z] = (1 / (10)) - 0.5;
                    
                }
            }

            for(int l=1; l<=hidden2; l++)
            {
                for(int k=1; k<=jml_output; k++)
                {
                    w3[l, k] = (1 / (10)) - 0.5;
                    
                }
            }

            
            p[1] = 0;
            p[2] = 0;
            p[3] = 0;
            p[4] = 0;
            ee[1] = 0;
            tt1 = 0;
            tt0 = 0;
            epo = 0;
            PendulumMass = Double.Parse(tbMass.Text);
            PendulumLength = Double.Parse(tbLength.Text);
            DampingCoefficient = Double.Parse(tbDamping.Text);
            deg_tar = Theta0;
            pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
         }

        private void NN_Control()
        {
            epo = epo + 1;
            ttd[jj] = deg_tar;

            //===================================================================================feed forward
            for (int z = 1; z <= hidden1; z++)
            {
                n1 = 0;
                for (int i = 1; i <= jml_input; i++)
                {
                    n1 = n1 + p[i] * w1[i, z];
                }
                n1 = n1 - 0.000001;
                a1[z, jj] = (1 - Math.Exp(-2 * momentum * n1)) / (1 + Math.Exp(-2 * momentum * n1));
            }

            for (int k = 1; k <= hidden2; k++)
            {
                n2 = 0;
                for (int z = 1; z <= hidden1; z++)
                {
                    n2 = n2 + a1[z, jj] * w2[z, k];
                }
                n2 = n2 - 0.000001;
                a2[k, jj] = (1 - Math.Exp(-2 * momentum * n2)) / (1 + Math.Exp(-2 * momentum * n2));
            }

            for (int l = 1; l <= jml_output; l++)
            {
                n3 = 0;
                for (int k = 1; k <= hidden2; k++)
                {
                    n3 = n3 + a2[k, jj] * w3[k, l];
                }
                n3 = n3 - 0.000001;
                a3[l, jj] = (1 - Math.Exp(-2 * momentum * n3)) / (1 + Math.Exp(-2 * momentum * n3));
            }

           
                tho[jj] = a3[1, jj] * gain - (c * tt1 * 180 / Math.PI + kons * tt0);
                //tho[jj] = a3[1, jj] * gain;
           

            tt2 = (tho[jj] - (ma * g * (float)PendulumLength * Math.Sin(tt0))) / ((ma * (float)PendulumLength * (float)PendulumLength) + inersia);
          
            tt1 = tt1 + tt2 * dt;
            tt0 = tt0 + tt1 * dt;
            deg = tt0 * 180 / Math.PI;
          

            textBox3.Text = Convert.ToString(deg);
            ee[jj] = (ttd[jj] - deg);
            err = ee[jj];
            sse = sse + (0.5 * (Math.Pow(ee[jj], 2)));     //Sum Sequare Error (SSE)


            //===============================================================================================backward
            //=========================================================================s3
            for (int l = 1; l <= jml_output; l++)
            {
                g3[l] = alpha * (1 - (a3[l, jj] * a3[l, jj]));
                s3[l, jj] = ee[jj] * g3[l] * gain * dt * dt;
            }

            //=========================================================================s2
            for (int l = 1; l <= hidden2; l++)
            {
                bfr = 0;
                for (int k = 1; k <= jml_output; k++)
                {
                    bfr = bfr + (w3[l, k] * s3[k, jj]);
                }
                es2[l] = bfr;
            }

            for (int k = 1; k <= hidden2; k++)
            {
                g2[k] = alpha * (1 - (a2[k, jj] * a2[k, jj]));
                s2[k, jj] = es2[k] * g2[k];
            }

            //=========================================================================s1
            for (int k = 1; k <= hidden1; k++)
            {
                bfr = 0;
                for (int z = 1; z <= hidden2; z++)
                {
                    bfr = bfr + (w2[k, z]) * s2[z, jj];
                }
                es1[k] = bfr;
            }


            for (int z = 1; z <= hidden1; z++)
            {
                g1[z] = alpha * (1 - (a1[z, jj] * a1[z, jj]));
                s1[z, jj] = es1[z] * g1[z];
            }

            //========================================================================update w
            for (int z = 1; z <= jml_input; z++)
            {
                for (int i = 1; i <= hidden1; i++)
                {
                    if (jj >= 1)
                    {
                        w1[z, i] = w1[z, i] + alpha * ((s1[i, jj] * p[z]) + (momentum * s1[i, jj - 1] * p[z - 1]));
                    }
                    else
                    {
                        w1[z, i] = w1[z, i] + alpha * ((s1[i, jj] * p[z]) + (momentum));
                    }
                }
            }

            for (int k = 1; k <= hidden1; k++)
            {
                for (int z = 1; z <= hidden2; z++)
                {
                    if (jj >= 1)
                    {
                        w2[k, z] = w2[k, z] + alpha * ((s2[z, jj] * a1[k, jj]) + (momentum * s2[z, jj - 1] * a1[k, jj - 1]));
                    }
                    else
                    {
                        w2[k, z] = w2[k, z] + alpha * ((s2[z, jj] * a1[k, jj]) + (momentum));
                    }
                }
            }

            for (int l = 1; l <= hidden2; l++)
            {
                for (int k = 1; k <= jml_output; k++)
                {
                    if (jj >= 1)
                    {
                        w3[l, k] = w3[l, k] + alpha * ((s3[k, jj] * a2[l, jj]) + (momentum * s3[k, jj - 1] * a2[l, jj - 1]));
                    }
                    else
                    {
                        w3[l, k] = w3[l, k] + alpha * ((s3[k, jj] * a2[l, jj]) + (momentum));
                    }
                }
            }

            //=======================================================input
            p[1] = ee[jj];

            if (jj >= 1)
            {
                p[2] = ee[jj - 1];
            }
            else
            {
                p[2] = 0.001;
            }

            if (jj >= 2)
            {
                p[3] = ee[jj - 2];
            }
            else
            {
                p[3] = 0.001;
            }

            if (jj >= 3)
            {
                p[4] = ee[jj - 3];
            }
            else
            {
                p[4] = 0.001;
            }

            jj = jj + 1;

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

       private void button1_Click_1(object sender, EventArgs e)
        {
            scale = 0;
        }

       private void button3_Click(object sender, EventArgs e)
       {
           chart1.ChartAreas[0].AxisX.Maximum = chart1.ChartAreas[0].AxisX.Maximum + 100;
       }

       private void button2_Click(object sender, EventArgs e)
       {
           chart1.ChartAreas[0].AxisX.Maximum = chart1.ChartAreas[0].AxisX.Maximum - 100;
       }

     
    }

    public class ODESolver
    {
        public delegate double Function(double[] x, double t);
        public static double[] RungeKutta4(Function[] f, double[] x0, double t0, double dt)
        {
            int n = x0.Length;
            double[] k1 = new double[n];
            double[] k2 = new double[n];
            double[] k3 = new double[n];
            double[] k4 = new double[n];
            double t = t0;
            double[] x1 = new double[n];
            double[] x = x0;
            for (int i = 0; i < n; i++)
                k1[i] = dt * f[i](x, t);
            for (int i = 0; i < n; i++)
                x1[i] = x[i] + k1[i] / 2;
            for (int i = 0; i < n; i++)
                k2[i] = dt * f[i](x1, t + dt / 2);
            for (int i = 0; i < n; i++)
                x1[i] = x[i] + k2[i] / 2;
            for (int i = 0; i < n; i++)
                k3[i] = dt * f[i](x1, t + dt / 2);
            for (int i = 0; i < n; i++)
                x1[i] = x[i] + k3[i];
            for (int i = 0; i < n; i++)
                k4[i] = dt * f[i](x1, t + dt);
            for (int i = 0; i < n; i++)
                x[i] +=
                (k1[i] + 2 * k2[i] + 2 * k3[i] + k4[i]) / 6; 
            return x;
        }
    }
       
}
