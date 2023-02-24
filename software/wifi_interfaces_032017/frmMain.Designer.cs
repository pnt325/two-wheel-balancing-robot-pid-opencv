namespace wifi_interfaces_032017
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btn_connect = new System.Windows.Forms.Button();
            this.txb_address = new System.Windows.Forms.TextBox();
            this.txb_port = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txb_console = new System.Windows.Forms.TextBox();
            this.txb_send = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pic_image = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rabOff = new System.Windows.Forms.RadioButton();
            this.rabOn = new System.Windows.Forms.RadioButton();
            this.grbConfigure = new System.Windows.Forms.GroupBox();
            this.lblLRSpeedMax = new System.Windows.Forms.Label();
            this.lblLRSpeedMin = new System.Windows.Forms.Label();
            this.txbLRSpeed = new System.Windows.Forms.TextBox();
            this.trbLRSpeed = new System.Windows.Forms.TrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.lblFBSpeedMax = new System.Windows.Forms.Label();
            this.lblFBSpeedMin = new System.Windows.Forms.Label();
            this.txbFBSpeed = new System.Windows.Forms.TextBox();
            this.trbFBSpeed = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.chbEnable = new System.Windows.Forms.CheckBox();
            this.grbDisplay = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnForward = new System.Windows.Forms.Button();
            this.chbGraph = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_image)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.grbConfigure.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbLRSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbFBSpeed)).BeginInit();
            this.grbDisplay.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_connect
            // 
            this.btn_connect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_connect.Location = new System.Drawing.Point(293, 24);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(112, 24);
            this.btn_connect.TabIndex = 0;
            this.btn_connect.Text = "Connect";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // txb_address
            // 
            this.txb_address.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_address.Location = new System.Drawing.Point(82, 25);
            this.txb_address.MaxLength = 15;
            this.txb_address.Name = "txb_address";
            this.txb_address.Size = new System.Drawing.Size(107, 23);
            this.txb_address.TabIndex = 1;
            this.txb_address.TextChanged += new System.EventHandler(this.txb_address_TextChanged);
            // 
            // txb_port
            // 
            this.txb_port.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_port.Location = new System.Drawing.Point(243, 25);
            this.txb_port.MaxLength = 4;
            this.txb_port.Name = "txb_port";
            this.txb_port.Size = new System.Drawing.Size(44, 22);
            this.txb_port.TabIndex = 2;
            this.txb_port.TextChanged += new System.EventHandler(this.txb_port_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Address :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(195, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Port :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btn_connect);
            this.groupBox1.Controls.Add(this.txb_address);
            this.groupBox1.Controls.Add(this.txb_port);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(415, 62);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection";
            // 
            // txb_console
            // 
            this.txb_console.BackColor = System.Drawing.Color.DarkSlateGray;
            this.txb_console.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_console.ForeColor = System.Drawing.Color.SpringGreen;
            this.txb_console.Location = new System.Drawing.Point(6, 19);
            this.txb_console.Multiline = true;
            this.txb_console.Name = "txb_console";
            this.txb_console.ReadOnly = true;
            this.txb_console.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txb_console.Size = new System.Drawing.Size(403, 206);
            this.txb_console.TabIndex = 6;
            this.txb_console.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txb_console_KeyDown);
            this.txb_console.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txb_console_KeyUp);
            // 
            // txb_send
            // 
            this.txb_send.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_send.Location = new System.Drawing.Point(6, 231);
            this.txb_send.Name = "txb_send";
            this.txb_send.Size = new System.Drawing.Size(322, 23);
            this.txb_send.TabIndex = 5;
            this.txb_send.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txb_send_KeyDown);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(334, 230);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 24);
            this.button1.TabIndex = 5;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pic_image
            // 
            this.pic_image.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pic_image.Location = new System.Drawing.Point(7, 20);
            this.pic_image.Name = "pic_image";
            this.pic_image.Size = new System.Drawing.Size(400, 300);
            this.pic_image.TabIndex = 7;
            this.pic_image.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txb_console);
            this.groupBox3.Controls.Add(this.txb_send);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(3, 80);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(415, 260);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Console";
            // 
            // rabOff
            // 
            this.rabOff.AutoSize = true;
            this.rabOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rabOff.Location = new System.Drawing.Point(14, 52);
            this.rabOff.Name = "rabOff";
            this.rabOff.Size = new System.Drawing.Size(84, 20);
            this.rabOff.TabIndex = 11;
            this.rabOff.TabStop = true;
            this.rabOff.Text = "Detect Off";
            this.rabOff.UseVisualStyleBackColor = true;
            this.rabOff.CheckedChanged += new System.EventHandler(this.rabOff_CheckedChanged);
            // 
            // rabOn
            // 
            this.rabOn.AutoSize = true;
            this.rabOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rabOn.Location = new System.Drawing.Point(14, 26);
            this.rabOn.Name = "rabOn";
            this.rabOn.Size = new System.Drawing.Size(85, 20);
            this.rabOn.TabIndex = 12;
            this.rabOn.TabStop = true;
            this.rabOn.Text = "Detect On";
            this.rabOn.UseVisualStyleBackColor = true;
            this.rabOn.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // grbConfigure
            // 
            this.grbConfigure.Controls.Add(this.lblLRSpeedMax);
            this.grbConfigure.Controls.Add(this.lblLRSpeedMin);
            this.grbConfigure.Controls.Add(this.txbLRSpeed);
            this.grbConfigure.Controls.Add(this.trbLRSpeed);
            this.grbConfigure.Controls.Add(this.label6);
            this.grbConfigure.Controls.Add(this.lblFBSpeedMax);
            this.grbConfigure.Controls.Add(this.lblFBSpeedMin);
            this.grbConfigure.Controls.Add(this.txbFBSpeed);
            this.grbConfigure.Controls.Add(this.trbFBSpeed);
            this.grbConfigure.Controls.Add(this.label3);
            this.grbConfigure.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbConfigure.Location = new System.Drawing.Point(424, 346);
            this.grbConfigure.Name = "grbConfigure";
            this.grbConfigure.Size = new System.Drawing.Size(414, 171);
            this.grbConfigure.TabIndex = 13;
            this.grbConfigure.TabStop = false;
            this.grbConfigure.Text = "Configure Speed";
            // 
            // lblLRSpeedMax
            // 
            this.lblLRSpeedMax.AutoSize = true;
            this.lblLRSpeedMax.Location = new System.Drawing.Point(334, 105);
            this.lblLRSpeedMax.Name = "lblLRSpeedMax";
            this.lblLRSpeedMax.Size = new System.Drawing.Size(46, 17);
            this.lblLRSpeedMax.TabIndex = 9;
            this.lblLRSpeedMax.Text = "label5";
            // 
            // lblLRSpeedMin
            // 
            this.lblLRSpeedMin.AutoSize = true;
            this.lblLRSpeedMin.Location = new System.Drawing.Point(81, 105);
            this.lblLRSpeedMin.Name = "lblLRSpeedMin";
            this.lblLRSpeedMin.Size = new System.Drawing.Size(46, 17);
            this.lblLRSpeedMin.TabIndex = 8;
            this.lblLRSpeedMin.Text = "label4";
            // 
            // txbLRSpeed
            // 
            this.txbLRSpeed.Location = new System.Drawing.Point(362, 125);
            this.txbLRSpeed.MaxLength = 2;
            this.txbLRSpeed.Name = "txbLRSpeed";
            this.txbLRSpeed.Size = new System.Drawing.Size(36, 23);
            this.txbLRSpeed.TabIndex = 7;
            this.txbLRSpeed.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbLRSpeed_KeyDown);
            // 
            // trbLRSpeed
            // 
            this.trbLRSpeed.LargeChange = 10;
            this.trbLRSpeed.Location = new System.Drawing.Point(84, 125);
            this.trbLRSpeed.Maximum = 50;
            this.trbLRSpeed.Minimum = 10;
            this.trbLRSpeed.Name = "trbLRSpeed";
            this.trbLRSpeed.Size = new System.Drawing.Size(273, 45);
            this.trbLRSpeed.SmallChange = 10;
            this.trbLRSpeed.TabIndex = 6;
            this.trbLRSpeed.Value = 10;
            this.trbLRSpeed.Scroll += new System.EventHandler(this.trbLRSpeed_Scroll);
            this.trbLRSpeed.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trbLRSpeed_MouseUp);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "LR Speed";
            // 
            // lblFBSpeedMax
            // 
            this.lblFBSpeedMax.AutoSize = true;
            this.lblFBSpeedMax.Location = new System.Drawing.Point(331, 31);
            this.lblFBSpeedMax.Name = "lblFBSpeedMax";
            this.lblFBSpeedMax.Size = new System.Drawing.Size(46, 17);
            this.lblFBSpeedMax.TabIndex = 4;
            this.lblFBSpeedMax.Text = "label5";
            // 
            // lblFBSpeedMin
            // 
            this.lblFBSpeedMin.AutoSize = true;
            this.lblFBSpeedMin.Location = new System.Drawing.Point(81, 34);
            this.lblFBSpeedMin.Name = "lblFBSpeedMin";
            this.lblFBSpeedMin.Size = new System.Drawing.Size(46, 17);
            this.lblFBSpeedMin.TabIndex = 3;
            this.lblFBSpeedMin.Text = "label4";
            // 
            // txbFBSpeed
            // 
            this.txbFBSpeed.Location = new System.Drawing.Point(362, 51);
            this.txbFBSpeed.MaxLength = 3;
            this.txbFBSpeed.Name = "txbFBSpeed";
            this.txbFBSpeed.Size = new System.Drawing.Size(36, 23);
            this.txbFBSpeed.TabIndex = 2;
            this.txbFBSpeed.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbSpeed_KeyDown);
            // 
            // trbFBSpeed
            // 
            this.trbFBSpeed.LargeChange = 10;
            this.trbFBSpeed.Location = new System.Drawing.Point(84, 51);
            this.trbFBSpeed.Maximum = 100;
            this.trbFBSpeed.Minimum = 20;
            this.trbFBSpeed.Name = "trbFBSpeed";
            this.trbFBSpeed.Size = new System.Drawing.Size(273, 45);
            this.trbFBSpeed.SmallChange = 10;
            this.trbFBSpeed.TabIndex = 1;
            this.trbFBSpeed.Value = 20;
            this.trbFBSpeed.Scroll += new System.EventHandler(this.trbSpeed_Scroll);
            this.trbFBSpeed.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trbSpeed_MouseUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "FB Speed";
            // 
            // chbEnable
            // 
            this.chbEnable.AutoSize = true;
            this.chbEnable.Location = new System.Drawing.Point(14, 78);
            this.chbEnable.Name = "chbEnable";
            this.chbEnable.Size = new System.Drawing.Size(113, 21);
            this.chbEnable.TabIndex = 13;
            this.chbEnable.Text = "Enable Robot";
            this.chbEnable.UseVisualStyleBackColor = true;
            this.chbEnable.CheckedChanged += new System.EventHandler(this.chbEnable_CheckedChanged);
            // 
            // grbDisplay
            // 
            this.grbDisplay.Controls.Add(this.pic_image);
            this.grbDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbDisplay.Location = new System.Drawing.Point(424, 12);
            this.grbDisplay.Name = "grbDisplay";
            this.grbDisplay.Size = new System.Drawing.Size(414, 328);
            this.grbDisplay.TabIndex = 14;
            this.grbDisplay.TabStop = false;
            this.grbDisplay.Text = "Camera";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnRight);
            this.groupBox5.Controls.Add(this.btnBack);
            this.groupBox5.Controls.Add(this.btnLeft);
            this.groupBox5.Controls.Add(this.btnForward);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(3, 346);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(223, 171);
            this.groupBox5.TabIndex = 15;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Control";
            // 
            // btnRight
            // 
            this.btnRight.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRight.BackgroundImage")));
            this.btnRight.Location = new System.Drawing.Point(147, 95);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(65, 65);
            this.btnRight.TabIndex = 3;
            this.btnRight.Text = "D";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnRight_MouseDown);
            this.btnRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnRight_MouseUp);
            // 
            // btnBack
            // 
            this.btnBack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBack.BackgroundImage")));
            this.btnBack.Location = new System.Drawing.Point(78, 95);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(65, 65);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "S";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnBack_MouseDown);
            this.btnBack.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnBack_MouseUp);
            // 
            // btnLeft
            // 
            this.btnLeft.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLeft.BackgroundImage")));
            this.btnLeft.Location = new System.Drawing.Point(9, 95);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(65, 65);
            this.btnLeft.TabIndex = 1;
            this.btnLeft.Text = "A";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnLeft_MouseDown);
            this.btnLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnLeft_MouseUp);
            // 
            // btnForward
            // 
            this.btnForward.BackColor = System.Drawing.Color.White;
            this.btnForward.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnForward.BackgroundImage")));
            this.btnForward.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnForward.Location = new System.Drawing.Point(78, 26);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(65, 65);
            this.btnForward.TabIndex = 0;
            this.btnForward.Text = "W";
            this.btnForward.UseVisualStyleBackColor = false;
            this.btnForward.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnForward_MouseDown);
            this.btnForward.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnForward_MouseUp);
            // 
            // chbGraph
            // 
            this.chbGraph.AutoSize = true;
            this.chbGraph.Location = new System.Drawing.Point(14, 105);
            this.chbGraph.Name = "chbGraph";
            this.chbGraph.Size = new System.Drawing.Size(67, 21);
            this.chbGraph.TabIndex = 14;
            this.chbGraph.Text = "Graph";
            this.chbGraph.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chbGraph);
            this.groupBox2.Controls.Add(this.rabOn);
            this.groupBox2.Controls.Add(this.chbEnable);
            this.groupBox2.Controls.Add(this.rabOff);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(232, 346);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(185, 171);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Configure";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(843, 523);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.grbDisplay);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grbConfigure);
            this.ForeColor = System.Drawing.SystemColors.Desktop;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "Balacning Robot (TCP/IP Interface) ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
 
            
 
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_image)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.grbConfigure.ResumeLayout(false);
            this.grbConfigure.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbLRSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbFBSpeed)).EndInit();
            this.grbDisplay.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.TextBox txb_address;
        private System.Windows.Forms.TextBox txb_port;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txb_console;
        private System.Windows.Forms.TextBox txb_send;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pic_image;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rabOn;
        private System.Windows.Forms.RadioButton rabOff;
        private System.Windows.Forms.GroupBox grbConfigure;
        private System.Windows.Forms.TextBox txbFBSpeed;
        private System.Windows.Forms.TrackBar trbFBSpeed;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grbDisplay;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnForward;
        private System.Windows.Forms.Label lblFBSpeedMax;
        private System.Windows.Forms.Label lblFBSpeedMin;
        private System.Windows.Forms.Label lblLRSpeedMax;
        private System.Windows.Forms.Label lblLRSpeedMin;
        private System.Windows.Forms.TextBox txbLRSpeed;
        private System.Windows.Forms.TrackBar trbLRSpeed;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chbEnable;
        private System.Windows.Forms.CheckBox chbGraph;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

