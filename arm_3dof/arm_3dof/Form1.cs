using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace arm_3dof
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Brush bblack = new SolidBrush(Color.Black);
        float teta1, teta2, teta3, sdtTotal,Q,mag;
        int x = 250, y = 170;
        int xCoord, yCoord;
        int ARM_LENGTH_0 ;
        int ARM_LENGTH_1 ;
        int ARM_LENGTH_2;
        int ARM_LENGTH_3 ;

        int a(int x)
        {
            int result = x ^ 2;
            return result;
        }


        private void display()
        {   Graphics gbr = picCanvas.CreateGraphics();
            gbr.Clear(Color.White);
            int cx = 150;
            int cy = 400;
            // Make sure we start from scratch.
            gbr.ResetTransform();
            // For each stage in the arm, draw and then *prepend* the
            // new transformation to represent the next arm in the sequence.
            // Translate to center of form.
            gbr.TranslateTransform(cx, cy);
            gbr.DrawEllipse(Pens.Red, -8, -7, 17, 17);
            // Draw the shoulder centered at the origin.
            // Rotate at the shoulder.
            // (Negative to make the angle increase counter-clockwise).
            gbr.RotateTransform(-90, System.Drawing.Drawing2D.MatrixOrder.Prepend);
            // Draw the first arm.
            gbr.DrawRectangle(Pens.Blue, 0, -5, ARM_LENGTH_0, 15);
            // Translate to the end of the first arm.
            gbr.TranslateTransform(ARM_LENGTH_0, 0, System.Drawing.Drawing2D.MatrixOrder.Prepend);
            // Draw the elbow.
            // Draw the shoulder centered at the origin.
            gbr.DrawEllipse(Pens.Red, -8, -7, 17,17);
            // Rotate at the shoulder.
            // (Negative to make the angle increase counter-clockwise).
            gbr.RotateTransform((90-teta1), System.Drawing.Drawing2D.MatrixOrder.Prepend);
            gbr.DrawString(" teta1 : " + (teta1).ToString(), new Font("Arial", 10), bblack, -5, 5);
            // Draw the first arm.
            gbr.DrawRectangle(Pens.Blue, 0, -2, ARM_LENGTH_1, 5);
            // Translate to the end of the first arm.
            gbr.TranslateTransform(ARM_LENGTH_1, 0, System.Drawing.Drawing2D.MatrixOrder.Prepend);
            // Draw the elbow.
            gbr.DrawEllipse(Pens.Red, -8, -7, 17, 17);
            // Rotate at the elbow.
            gbr.RotateTransform(-(teta2), System.Drawing.Drawing2D.MatrixOrder.Prepend);
            gbr.DrawString(" teta2 : " + (teta2).ToString(), new Font("Arial", 10), bblack, -5, 5);
            // Draw the second arm.
            gbr.DrawRectangle(
                Pens.Blue, 0, -2, ARM_LENGTH_2, 5);
            // Translate to the end of the second arm.
            gbr.TranslateTransform(ARM_LENGTH_2, 0, System.Drawing.Drawing2D.MatrixOrder.Prepend);
            // Draw the hand.
            gbr.DrawEllipse(Pens.Red, -8, -7, 17, 17);
            // Rotate at the elbow.
            gbr.RotateTransform(-(teta3), System.Drawing.Drawing2D.MatrixOrder.Prepend);
            gbr.DrawString(" teta3 : " + (teta3).ToString(), new Font("Arial", 10), bblack, -5, 5);
            // Draw the second arm.
            gbr.DrawRectangle(Pens.Blue, 0, -2, ARM_LENGTH_3, 5);
            // Translate to the end of the second arm.
            gbr.TranslateTransform(ARM_LENGTH_3, 0, System.Drawing.Drawing2D.MatrixOrder.Prepend);
                xCoord = x - cx;
                yCoord = cy - y-ARM_LENGTH_0;
           ///////////////////// Inverse Kinematics ///////////////                  
                teta1 = Convert.ToInt32(RadtoDeg(In_teta1(xCoord,yCoord,ARM_LENGTH_1,ARM_LENGTH_2,ARM_LENGTH_3,sdtTotal)));
                teta2 = Convert.ToInt32(RadtoDeg(In_teta2(xCoord, yCoord, ARM_LENGTH_1, ARM_LENGTH_2, ARM_LENGTH_3, sdtTotal, teta1)));
                teta3 = Convert.ToInt32(In_teta3(sdtTotal, teta1, teta2));

          //////////////////// Forward kinematic /////////////////    
                textBox1.Text = Convert.ToString(F_x((teta1),teta2,teta3,ARM_LENGTH_1,ARM_LENGTH_2,ARM_LENGTH_3));
                textBox2.Text = Convert.ToString((F_y((teta1),teta2,teta3,ARM_LENGTH_1,ARM_LENGTH_2,ARM_LENGTH_3)));
              
            
           gbr.ResetTransform();
           gbr.DrawEllipse(Pens.Black, x-5, y-5, 15, 15);
          
           Q = Convert.ToInt16(RadtoDeg(Math.Atan2(yCoord+ARM_LENGTH_0, xCoord)));
           mag = Convert.ToInt16(Math.Sqrt(Math.Pow(yCoord+ARM_LENGTH_0, 2) + Math.Pow(xCoord, 2)));

           textBox10.Text = Q.ToString();
           textBox11.Text = mag.ToString();
           textBox4.Text =  xCoord.ToString();
           textBox3.Text = yCoord.ToString();

        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            display();
        }

        private void picCanvas_click(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
        }


        double In_teta2(double x, double y, int l1, int l2, int l3, float sdtTotal,double teta1)
        {
            double hasil, xr, yr, a1,a2;
            xr = x - (l3 * Math.Cos(DegtoRad(sdtTotal)));
            yr = y - (l3 * Math.Sin(DegtoRad(sdtTotal)));
            a1 = (yr - (l1 * Math.Sin(DegtoRad(teta1)))) / l2;
            a2 = (xr - (l1 * Math.Cos(DegtoRad(teta1)))) / l2;
            hasil = Math.Atan2(a1, a2) - DegtoRad(teta1);
            return hasil;
        }

        double In_teta1(double x, double y, int l1, int l2, int l3, float sdtTotal)
        {
            double hasil, xr, yr,R, a1, a2, xr2,yr2;
            xr = x - (l3 * Math.Cos(DegtoRad(sdtTotal)));
            yr = y - (l3 * Math.Sin(DegtoRad(sdtTotal)));
            xr2 = xr*xr;
            yr2 = yr*yr;
            R = Math.Sqrt((xr2) + (yr2));
            a1 = Math.Atan2((yr / R), (xr / R));
            a2 = (((R*R) + (l1 * l1) - (l2 * l2)) / (2 * l1 * R));
            if (a2 > 1) 
            {
                a2 = 0;
            }
            else if (a2 < -1)
            {
                a2 = Math.PI;
            }
            else 
            {
                a2 = Math.Acos(a2);
            }
            hasil = a1 + a2;
            return hasil;
        }
        double In_teta3(double sdtTotal, double teta1, double teta2)
        {
            double hasil;
            hasil = sdtTotal - teta1 - teta2;
            return hasil;

        }

        double RadtoDeg(double x)
      {    double hasil;
           hasil = x*(180 / Math.PI) ;
           return hasil;
        
      }
        double DegtoRad(double x)
        {
            double hasil;
            hasil = x * (Math.PI/180);
            return hasil;

        }

        double F_x(double teta1, double teta2, double teta3, int l1, int l2, int l3)
        {
            double hasil;
            hasil = l1 * Math.Cos(DegtoRad(teta1));
            hasil = hasil + (l2 *(Math.Cos(DegtoRad((teta1+teta2)))));
            hasil = hasil + (l3 *(Math.Cos(DegtoRad((teta1+teta2+teta3)))));
            return hasil;              
         }
        double F_y(double teta1, double teta2, double teta3, int l1, int l2, int l3) 
        {
          double hasil;
            hasil = l1 * Math.Sin(DegtoRad(teta1));
            hasil = hasil + (l2 *(Math.Sin(DegtoRad((teta1+teta2)))));
            hasil = hasil + (l3 *(Math.Sin(DegtoRad((teta1+teta2+teta3)))));
           return hasil;   
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sdtTotal = 0;
            ARM_LENGTH_0 = 50;
            ARM_LENGTH_1 = 100;
            ARM_LENGTH_2 = 100;
            ARM_LENGTH_3 = 25;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            ARM_LENGTH_0 = trackBar1.Value;
            textBox5.Text = ARM_LENGTH_0.ToString();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            ARM_LENGTH_1 = trackBar2.Value;
            textBox6.Text = ARM_LENGTH_1.ToString();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            ARM_LENGTH_2 = trackBar3.Value;
            textBox7.Text = ARM_LENGTH_2.ToString();
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            ARM_LENGTH_3 = trackBar4.Value;
            textBox8.Text = ARM_LENGTH_3.ToString();
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            sdtTotal = trackBar5.Value;
            textBox9.Text = sdtTotal.ToString();
        }

     
    }

}
