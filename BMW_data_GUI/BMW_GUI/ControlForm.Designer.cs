namespace BMW_GUI
{
    partial class ControlForm
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
            this.button_submit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox_Type = new System.Windows.Forms.ListBox();
            this.DataTimer = new System.Windows.Forms.Timer(this.components);
            this.EmoUpdate = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_boredom = new System.Windows.Forms.TextBox();
            this.textBox_frustration = new System.Windows.Forms.TextBox();
            this.textBox_ShortExcitement = new System.Windows.Forms.TextBox();
            this.textBox_longExcitement = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button_stop = new System.Windows.Forms.Button();
            this.textBox_freq = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_alphaO1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_BetaO1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_AlphaDiff = new System.Windows.Forms.TextBox();
            this.textBox_BetaDiff = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.textBox_BetaF3 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox_alphaF3 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox_BetaF4 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox_alphaF4 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox_BetaF8 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textBox_alphaF8 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.textBox_BetaF7 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.textBox_alphaF7 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.textBox_BetaAF4 = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.textBox_alphaAF4 = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.textBox_BetaAF3 = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.textBox_alphaAF3 = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.BluetoothPort = new System.IO.Ports.SerialPort(this.components);
            this.SuspendLayout();
            // 
            // button_submit
            // 
            this.button_submit.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_submit.Location = new System.Drawing.Point(231, 10);
            this.button_submit.Margin = new System.Windows.Forms.Padding(4);
            this.button_submit.Name = "button_submit";
            this.button_submit.Size = new System.Drawing.Size(112, 31);
            this.button_submit.TabIndex = 20;
            this.button_submit.Text = "Submit";
            this.button_submit.UseVisualStyleBackColor = true;
            this.button_submit.Click += new System.EventHandler(this.button_submit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(28, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 16);
            this.label2.TabIndex = 19;
            this.label2.Text = "Choose Type";
            // 
            // listBox_Type
            // 
            this.listBox_Type.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.listBox_Type.FormattingEnabled = true;
            this.listBox_Type.ItemHeight = 16;
            this.listBox_Type.Items.AddRange(new object[] {
            "SSVEP",
            "Mental Task"});
            this.listBox_Type.Location = new System.Drawing.Point(28, 29);
            this.listBox_Type.Name = "listBox_Type";
            this.listBox_Type.Size = new System.Drawing.Size(103, 52);
            this.listBox_Type.TabIndex = 18;
            // 
            // DataTimer
            // 
            this.DataTimer.Interval = 50;
            this.DataTimer.Tick += new System.EventHandler(this.DataTimer_Tick);
            // 
            // EmoUpdate
            // 
            this.EmoUpdate.Interval = 1000;
            this.EmoUpdate.Tick += new System.EventHandler(this.EmoUpdate_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 12);
            this.label1.TabIndex = 21;
            this.label1.Text = "Boredom";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 12);
            this.label3.TabIndex = 22;
            this.label3.Text = "Frustration";
            // 
            // textBox_boredom
            // 
            this.textBox_boredom.Location = new System.Drawing.Point(120, 115);
            this.textBox_boredom.Name = "textBox_boredom";
            this.textBox_boredom.Size = new System.Drawing.Size(100, 22);
            this.textBox_boredom.TabIndex = 23;
            // 
            // textBox_frustration
            // 
            this.textBox_frustration.Location = new System.Drawing.Point(120, 153);
            this.textBox_frustration.Name = "textBox_frustration";
            this.textBox_frustration.Size = new System.Drawing.Size(100, 22);
            this.textBox_frustration.TabIndex = 24;
            // 
            // textBox_ShortExcitement
            // 
            this.textBox_ShortExcitement.Location = new System.Drawing.Point(370, 153);
            this.textBox_ShortExcitement.Name = "textBox_ShortExcitement";
            this.textBox_ShortExcitement.Size = new System.Drawing.Size(100, 22);
            this.textBox_ShortExcitement.TabIndex = 28;
            // 
            // textBox_longExcitement
            // 
            this.textBox_longExcitement.Location = new System.Drawing.Point(370, 115);
            this.textBox_longExcitement.Name = "textBox_longExcitement";
            this.textBox_longExcitement.Size = new System.Drawing.Size(100, 22);
            this.textBox_longExcitement.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(250, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 12);
            this.label4.TabIndex = 26;
            this.label4.Text = "Short-Term Excitemenet";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(250, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 12);
            this.label5.TabIndex = 25;
            this.label5.Text = "Long-Term Excitement";
            // 
            // button_stop
            // 
            this.button_stop.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_stop.Location = new System.Drawing.Point(231, 50);
            this.button_stop.Margin = new System.Windows.Forms.Padding(4);
            this.button_stop.Name = "button_stop";
            this.button_stop.Size = new System.Drawing.Size(112, 31);
            this.button_stop.TabIndex = 29;
            this.button_stop.Text = "Stop";
            this.button_stop.UseVisualStyleBackColor = true;
            this.button_stop.Click += new System.EventHandler(this.button_stop_Click);
            // 
            // textBox_freq
            // 
            this.textBox_freq.Location = new System.Drawing.Point(120, 195);
            this.textBox_freq.Name = "textBox_freq";
            this.textBox_freq.Size = new System.Drawing.Size(100, 22);
            this.textBox_freq.TabIndex = 31;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 195);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 12);
            this.label6.TabIndex = 30;
            this.label6.Text = "Dominant Freq";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 269);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 12);
            this.label7.TabIndex = 32;
            this.label7.Text = "AlphaDifference";
            // 
            // textBox_alphaO1
            // 
            this.textBox_alphaO1.Location = new System.Drawing.Point(120, 231);
            this.textBox_alphaO1.Name = "textBox_alphaO1";
            this.textBox_alphaO1.Size = new System.Drawing.Size(100, 22);
            this.textBox_alphaO1.TabIndex = 34;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(29, 231);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 33;
            this.label8.Text = "Alpha_O1";
            // 
            // textBox_BetaO1
            // 
            this.textBox_BetaO1.Location = new System.Drawing.Point(344, 231);
            this.textBox_BetaO1.Name = "textBox_BetaO1";
            this.textBox_BetaO1.Size = new System.Drawing.Size(100, 22);
            this.textBox_BetaO1.TabIndex = 36;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(250, 231);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 12);
            this.label9.TabIndex = 35;
            this.label9.Text = "Beta_O1";
            // 
            // textBox_AlphaDiff
            // 
            this.textBox_AlphaDiff.Location = new System.Drawing.Point(120, 266);
            this.textBox_AlphaDiff.Name = "textBox_AlphaDiff";
            this.textBox_AlphaDiff.Size = new System.Drawing.Size(100, 22);
            this.textBox_AlphaDiff.TabIndex = 37;
            // 
            // textBox_BetaDiff
            // 
            this.textBox_BetaDiff.Location = new System.Drawing.Point(344, 269);
            this.textBox_BetaDiff.Name = "textBox_BetaDiff";
            this.textBox_BetaDiff.Size = new System.Drawing.Size(100, 22);
            this.textBox_BetaDiff.TabIndex = 39;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(250, 272);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 12);
            this.label10.TabIndex = 38;
            this.label10.Text = "BetaDifference";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(250, 195);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 12);
            this.label11.TabIndex = 40;
            this.label11.Text = "CLose Eye";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(485, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.Size = new System.Drawing.Size(311, 316);
            this.listBox1.TabIndex = 41;
            // 
            // textBox_BetaF3
            // 
            this.textBox_BetaF3.Location = new System.Drawing.Point(344, 306);
            this.textBox_BetaF3.Name = "textBox_BetaF3";
            this.textBox_BetaF3.Size = new System.Drawing.Size(100, 22);
            this.textBox_BetaF3.TabIndex = 45;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(250, 306);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 12);
            this.label12.TabIndex = 44;
            this.label12.Text = "Beta_F3";
            // 
            // textBox_alphaF3
            // 
            this.textBox_alphaF3.Location = new System.Drawing.Point(120, 306);
            this.textBox_alphaF3.Name = "textBox_alphaF3";
            this.textBox_alphaF3.Size = new System.Drawing.Size(100, 22);
            this.textBox_alphaF3.TabIndex = 43;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(29, 306);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 12);
            this.label13.TabIndex = 42;
            this.label13.Text = "Alpha_F3";
            // 
            // textBox_BetaF4
            // 
            this.textBox_BetaF4.Location = new System.Drawing.Point(344, 343);
            this.textBox_BetaF4.Name = "textBox_BetaF4";
            this.textBox_BetaF4.Size = new System.Drawing.Size(100, 22);
            this.textBox_BetaF4.TabIndex = 49;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(250, 343);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 12);
            this.label14.TabIndex = 48;
            this.label14.Text = "Beta_F4";
            // 
            // textBox_alphaF4
            // 
            this.textBox_alphaF4.Location = new System.Drawing.Point(120, 343);
            this.textBox_alphaF4.Name = "textBox_alphaF4";
            this.textBox_alphaF4.Size = new System.Drawing.Size(100, 22);
            this.textBox_alphaF4.TabIndex = 47;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(29, 343);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(51, 12);
            this.label15.TabIndex = 46;
            this.label15.Text = "Alpha_F4";
            // 
            // textBox_BetaF8
            // 
            this.textBox_BetaF8.Location = new System.Drawing.Point(344, 419);
            this.textBox_BetaF8.Name = "textBox_BetaF8";
            this.textBox_BetaF8.Size = new System.Drawing.Size(100, 22);
            this.textBox_BetaF8.TabIndex = 57;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(250, 419);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(44, 12);
            this.label16.TabIndex = 56;
            this.label16.Text = "Beta_F8";
            // 
            // textBox_alphaF8
            // 
            this.textBox_alphaF8.Location = new System.Drawing.Point(120, 419);
            this.textBox_alphaF8.Name = "textBox_alphaF8";
            this.textBox_alphaF8.Size = new System.Drawing.Size(100, 22);
            this.textBox_alphaF8.TabIndex = 55;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(29, 419);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(51, 12);
            this.label17.TabIndex = 54;
            this.label17.Text = "Alpha_F8";
            // 
            // textBox_BetaF7
            // 
            this.textBox_BetaF7.Location = new System.Drawing.Point(344, 382);
            this.textBox_BetaF7.Name = "textBox_BetaF7";
            this.textBox_BetaF7.Size = new System.Drawing.Size(100, 22);
            this.textBox_BetaF7.TabIndex = 53;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(250, 382);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(44, 12);
            this.label18.TabIndex = 52;
            this.label18.Text = "Beta_F7";
            // 
            // textBox_alphaF7
            // 
            this.textBox_alphaF7.Location = new System.Drawing.Point(120, 382);
            this.textBox_alphaF7.Name = "textBox_alphaF7";
            this.textBox_alphaF7.Size = new System.Drawing.Size(100, 22);
            this.textBox_alphaF7.TabIndex = 51;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(29, 382);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(51, 12);
            this.label19.TabIndex = 50;
            this.label19.Text = "Alpha_F7";
            // 
            // textBox_BetaAF4
            // 
            this.textBox_BetaAF4.Location = new System.Drawing.Point(342, 494);
            this.textBox_BetaAF4.Name = "textBox_BetaAF4";
            this.textBox_BetaAF4.Size = new System.Drawing.Size(100, 22);
            this.textBox_BetaAF4.TabIndex = 65;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(248, 494);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(52, 12);
            this.label20.TabIndex = 64;
            this.label20.Text = "Beta_AF4";
            // 
            // textBox_alphaAF4
            // 
            this.textBox_alphaAF4.Location = new System.Drawing.Point(118, 494);
            this.textBox_alphaAF4.Name = "textBox_alphaAF4";
            this.textBox_alphaAF4.Size = new System.Drawing.Size(100, 22);
            this.textBox_alphaAF4.TabIndex = 63;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(27, 494);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(59, 12);
            this.label21.TabIndex = 62;
            this.label21.Text = "Alpha_AF4";
            // 
            // textBox_BetaAF3
            // 
            this.textBox_BetaAF3.Location = new System.Drawing.Point(342, 457);
            this.textBox_BetaAF3.Name = "textBox_BetaAF3";
            this.textBox_BetaAF3.Size = new System.Drawing.Size(100, 22);
            this.textBox_BetaAF3.TabIndex = 61;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(248, 457);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(52, 12);
            this.label22.TabIndex = 60;
            this.label22.Text = "Beta_AF3";
            // 
            // textBox_alphaAF3
            // 
            this.textBox_alphaAF3.Location = new System.Drawing.Point(118, 457);
            this.textBox_alphaAF3.Name = "textBox_alphaAF3";
            this.textBox_alphaAF3.Size = new System.Drawing.Size(100, 22);
            this.textBox_alphaAF3.TabIndex = 59;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(27, 457);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(59, 12);
            this.label23.TabIndex = 58;
            this.label23.Text = "Alpha_AF3";
            // 
            // ControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 521);
            this.Controls.Add(this.textBox_BetaAF4);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.textBox_alphaAF4);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.textBox_BetaAF3);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.textBox_alphaAF3);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.textBox_BetaF8);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.textBox_alphaF8);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.textBox_BetaF7);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.textBox_alphaF7);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.textBox_BetaF4);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.textBox_alphaF4);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.textBox_BetaF3);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textBox_alphaF3);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox_BetaDiff);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox_AlphaDiff);
            this.Controls.Add(this.textBox_BetaO1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox_alphaO1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox_freq);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button_stop);
            this.Controls.Add(this.textBox_ShortExcitement);
            this.Controls.Add(this.textBox_longExcitement);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_frustration);
            this.Controls.Add(this.textBox_boredom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_submit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox_Type);
            this.Name = "ControlForm";
            this.Text = "ControlForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_submit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox_Type;
        private System.Windows.Forms.Timer DataTimer;
        private System.Windows.Forms.Timer EmoUpdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_boredom;
        private System.Windows.Forms.TextBox textBox_frustration;
        private System.Windows.Forms.TextBox textBox_ShortExcitement;
        private System.Windows.Forms.TextBox textBox_longExcitement;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_stop;
        private System.Windows.Forms.TextBox textBox_freq;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_alphaO1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_BetaO1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_AlphaDiff;
        private System.Windows.Forms.TextBox textBox_BetaDiff;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox textBox_BetaF3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox_alphaF3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox_BetaF4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox_alphaF4;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox_BetaF8;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBox_alphaF8;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBox_BetaF7;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textBox_alphaF7;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox textBox_BetaAF4;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox textBox_alphaAF4;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox textBox_BetaAF3;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox textBox_alphaAF3;
        private System.Windows.Forms.Label label23;
        private System.IO.Ports.SerialPort BluetoothPort;
    }
}