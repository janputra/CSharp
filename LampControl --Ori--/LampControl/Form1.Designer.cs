namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.BtnLampu1 = new System.Windows.Forms.Button();
            this.BtnLampu2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.BtnPort = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PB2ON = new System.Windows.Forms.PictureBox();
            this.PB1ON = new System.Windows.Forms.PictureBox();
            this.PB2OFF = new System.Windows.Forms.PictureBox();
            this.PB1OFF = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB2ON)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB1ON)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB2OFF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB1OFF)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnLampu1
            // 
            this.BtnLampu1.Location = new System.Drawing.Point(29, 117);
            this.BtnLampu1.Name = "BtnLampu1";
            this.BtnLampu1.Size = new System.Drawing.Size(75, 23);
            this.BtnLampu1.TabIndex = 0;
            this.BtnLampu1.Text = "ON";
            this.BtnLampu1.UseVisualStyleBackColor = true;
            this.BtnLampu1.Click += new System.EventHandler(this.BtnLampu1_Click);
            // 
            // BtnLampu2
            // 
            this.BtnLampu2.Location = new System.Drawing.Point(152, 117);
            this.BtnLampu2.Name = "BtnLampu2";
            this.BtnLampu2.Size = new System.Drawing.Size(75, 23);
            this.BtnLampu2.TabIndex = 1;
            this.BtnLampu2.Text = "ON";
            this.BtnLampu2.UseVisualStyleBackColor = true;
            this.BtnLampu2.Click += new System.EventHandler(this.BtnLampu2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Lampu 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(165, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Lampu 2";
            // 
            // BtnPort
            // 
            this.BtnPort.Location = new System.Drawing.Point(196, 221);
            this.BtnPort.Name = "BtnPort";
            this.BtnPort.Size = new System.Drawing.Size(64, 23);
            this.BtnPort.TabIndex = 4;
            this.BtnPort.Text = "Connect";
            this.BtnPort.UseVisualStyleBackColor = true;
            this.BtnPort.Click += new System.EventHandler(this.BtnPort_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(29, 223);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(61, 21);
            this.comboBox1.TabIndex = 5;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(113, 223);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(61, 21);
            this.comboBox2.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Port";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(124, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Baudrate";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(149, 253);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Device Is Not Detected";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::WindowsFormsApplication1.Properties.Resources.green_led_on_th;
            this.pictureBox2.Location = new System.Drawing.Point(121, 250);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(22, 23);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsFormsApplication1.Properties.Resources.black_led_off_th;
            this.pictureBox1.Location = new System.Drawing.Point(121, 250);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(22, 23);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // PB2ON
            // 
            this.PB2ON.Image = global::WindowsFormsApplication1.Properties.Resources._128;
            this.PB2ON.Location = new System.Drawing.Point(152, 30);
            this.PB2ON.Name = "PB2ON";
            this.PB2ON.Size = new System.Drawing.Size(75, 68);
            this.PB2ON.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PB2ON.TabIndex = 12;
            this.PB2ON.TabStop = false;
            this.PB2ON.Visible = false;
            // 
            // PB1ON
            // 
            this.PB1ON.Image = global::WindowsFormsApplication1.Properties.Resources._128;
            this.PB1ON.Location = new System.Drawing.Point(29, 30);
            this.PB1ON.Name = "PB1ON";
            this.PB1ON.Size = new System.Drawing.Size(75, 68);
            this.PB1ON.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PB1ON.TabIndex = 11;
            this.PB1ON.TabStop = false;
            this.PB1ON.Visible = false;
            // 
            // PB2OFF
            // 
            this.PB2OFF.Image = global::WindowsFormsApplication1.Properties.Resources._128__1_;
            this.PB2OFF.Location = new System.Drawing.Point(152, 30);
            this.PB2OFF.Name = "PB2OFF";
            this.PB2OFF.Size = new System.Drawing.Size(75, 68);
            this.PB2OFF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PB2OFF.TabIndex = 10;
            this.PB2OFF.TabStop = false;
            // 
            // PB1OFF
            // 
            this.PB1OFF.Image = global::WindowsFormsApplication1.Properties.Resources._128__1_;
            this.PB1OFF.Location = new System.Drawing.Point(29, 30);
            this.PB1OFF.Name = "PB1OFF";
            this.PB1OFF.Size = new System.Drawing.Size(75, 68);
            this.PB1OFF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PB1OFF.TabIndex = 9;
            this.PB1OFF.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 275);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.PB2ON);
            this.Controls.Add(this.PB1ON);
            this.Controls.Add(this.PB2OFF);
            this.Controls.Add(this.PB1OFF);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.BtnPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnLampu2);
            this.Controls.Add(this.BtnLampu1);
            this.Name = "Form1";
            this.Text = "LampControl";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB2ON)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB1ON)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB2OFF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB1OFF)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnLampu1;
        private System.Windows.Forms.Button BtnLampu2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button BtnPort;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox PB1OFF;
        private System.Windows.Forms.PictureBox PB2OFF;
        private System.Windows.Forms.PictureBox PB1ON;
        private System.Windows.Forms.PictureBox PB2ON;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

