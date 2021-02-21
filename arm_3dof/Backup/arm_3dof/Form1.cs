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
        int teta1, teta2, teta3;
        int x = 0, y = 0;
        int xCoord, yCoord;

        private void display()
        {
           
            const int ARM_LENGTH_0 = 50;
            const int ARM_LENGTH_1 = 75;
            const int ARM_LENGTH_2 = 65;
            const int ARM_LENGTH_3 = 65;

            Graphics gbr = picCanvas.CreateGraphics();
            gbr.Clear(Color.White);
            int cx = 150 + ARM_LENGTH_0;
            int cy = 250;
            // Make sure we start from scratch.
            gbr.ResetTransform();
            // For each stage in the arm, draw and then *prepend* the
            // new transformation to represent the next arm in the sequence.
            // Translate to center of form.
            gbr.TranslateTransform(cx, cy);
            // Draw the shoulder centered at the origin.
            gbr.DrawEllipse(Pens.Red, -8, -7, 17, 17);
            // Rotate at the shoulder.
            // (Negative to make the angle increase counter-clockwise).
            gbr.RotateTransform(0, System.Drawing.Drawing2D.MatrixOrder.Prepend);
            // Draw the first arm.
            gbr.DrawRectangle(Pens.Blue, 0, -2, ARM_LENGTH_0, 5);
            // Translate to the end of the first arm.
            gbr.TranslateTransform(ARM_LENGTH_0, 0, System.Drawing.Drawing2D.MatrixOrder.Prepend);
            // Draw the elbow.
            // Draw the shoulder centered at the origin.
            gbr.DrawEllipse(Pens.Red, -8, -7, 17, 17);
            // Rotate at the shoulder.
            // (Negative to make the angle increase counter-clockwise).
            gbr.RotateTransform(Joint1.Value - 90, System.Drawing.Drawing2D.MatrixOrder.Prepend);
            // Draw the first arm.
            gbr.DrawRectangle(Pens.Blue, 0, -2, ARM_LENGTH_1, 5);
            // Translate to the end of the first arm.
            gbr.TranslateTransform(ARM_LENGTH_1, 0, System.Drawing.Drawing2D.MatrixOrder.Prepend);
            // Draw the elbow.
            gbr.DrawEllipse(Pens.Red, -8, -7, 17, 17);
            // Rotate at the elbow.
            gbr.RotateTransform(Joint2.Value, System.Drawing.Drawing2D.MatrixOrder.Prepend);
            // Draw the second arm.
            gbr.DrawRectangle(Pens.Blue, 0, -2, ARM_LENGTH_2, 5);
            // Translate to the end of the second arm.
            gbr.TranslateTransform(ARM_LENGTH_2, 0, System.Drawing.Drawing2D.MatrixOrder.Prepend);
            // Draw the hand.
            gbr.DrawEllipse(Pens.Red, -8, -7, 17, 17);
            // Rotate at the elbow.
            gbr.RotateTransform(Joint3.Value, System.Drawing.Drawing2D.MatrixOrder.Prepend);
            // Draw the second arm.
            gbr.DrawRectangle(Pens.Blue, 0, -2, ARM_LENGTH_3, 5);
            // Translate to the end of the second arm.
            gbr.TranslateTransform(ARM_LENGTH_3, 0, System.Drawing.Drawing2D.MatrixOrder.Prepend);
            
            teta1 = Joint1.Value;
            teta2 = Joint2.Value;
            teta3 = Joint3.Value;
            gbr.ResetTransform();
            gbr.DrawEllipse(Pens.Black, x , y ,12, 12);
                     
            label1.Text = "teta1 : " + teta1.ToString();
            label2.Text = "teta2 : " + teta2.ToString();
            label3.Text = "teta3 : " + teta3.ToString();
            xCoord = x - cx;
            yCoord =  cy-y;
            label4.Text = "mouse x : " + xCoord.ToString();
            label5.Text = "mouse y : " + yCoord.ToString();
          
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

       
      
      }
}
