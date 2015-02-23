namespace BMW_GUI
{
    partial class TrainingForm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.richTextBox_Direction = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.experimentTimer = new System.Windows.Forms.Timer(this.components);
            this.button_submit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox_Type = new System.Windows.Forms.ListBox();
            this.Datatimer = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label_TimerCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(373, 235);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(215, 215);
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // richTextBox_Direction
            // 
            this.richTextBox_Direction.BackColor = System.Drawing.Color.White;
            this.richTextBox_Direction.Enabled = false;
            this.richTextBox_Direction.Font = new System.Drawing.Font("PMingLiU", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.richTextBox_Direction.Location = new System.Drawing.Point(276, 32);
            this.richTextBox_Direction.Name = "richTextBox_Direction";
            this.richTextBox_Direction.ReadOnly = true;
            this.richTextBox_Direction.Size = new System.Drawing.Size(374, 114);
            this.richTextBox_Direction.TabIndex = 28;
            this.richTextBox_Direction.Text = "Direction will be given here. ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("PMingLiU", 12F);
            this.label1.Location = new System.Drawing.Point(273, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 16);
            this.label1.TabIndex = 27;
            this.label1.Text = "Direction: ";
            // 
            // experimentTimer
            // 
            this.experimentTimer.Tick += new System.EventHandler(this.experimentTimer_Tick);
            // 
            // button_submit
            // 
            this.button_submit.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_submit.Location = new System.Drawing.Point(23, 218);
            this.button_submit.Margin = new System.Windows.Forms.Padding(4);
            this.button_submit.Name = "button_submit";
            this.button_submit.Size = new System.Drawing.Size(112, 31);
            this.button_submit.TabIndex = 26;
            this.button_submit.Text = "Submit";
            this.button_submit.UseVisualStyleBackColor = true;
            this.button_submit.Click += new System.EventHandler(this.button_submit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(23, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 16);
            this.label2.TabIndex = 25;
            this.label2.Text = "Choose Stimuli";
            // 
            // listBox_Type
            // 
            this.listBox_Type.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.listBox_Type.FormattingEnabled = true;
            this.listBox_Type.ItemHeight = 16;
            this.listBox_Type.Items.AddRange(new object[] {
            "Relax",
            "SSVEP-9HZ",
            "SSVEP-11HZ",
            "SSVEP-13HZ",
            "SSVEP-15HZ",
            "Math-Level1",
            "Math-Level2",
            "Math-Level3",
            "Math-Level4",
            "Open-Eyes",
            "Open-Close"});
            this.listBox_Type.Location = new System.Drawing.Point(23, 31);
            this.listBox_Type.Name = "listBox_Type";
            this.listBox_Type.Size = new System.Drawing.Size(221, 180);
            this.listBox_Type.TabIndex = 24;
            this.listBox_Type.SelectedIndexChanged += new System.EventHandler(this.listBox_Type_SelectedIndexChanged);
            // 
            // Datatimer
            // 
            this.Datatimer.Interval = 50;
            this.Datatimer.Tick += new System.EventHandler(this.Datatimer_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(672, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 16);
            this.label3.TabIndex = 30;
            this.label3.Text = "label3";
            // 
            // label_TimerCount
            // 
            this.label_TimerCount.AutoSize = true;
            this.label_TimerCount.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_TimerCount.Location = new System.Drawing.Point(672, 78);
            this.label_TimerCount.Name = "label_TimerCount";
            this.label_TimerCount.Size = new System.Drawing.Size(83, 16);
            this.label_TimerCount.TabIndex = 31;
            this.label_TimerCount.Text = "TimerCount";
            // 
            // TrainingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 462);
            this.Controls.Add(this.label_TimerCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.richTextBox_Direction);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_submit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox_Type);
            this.Name = "TrainingForm";
            this.Text = "TrainingForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox richTextBox_Direction;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer experimentTimer;
        private System.Windows.Forms.Button button_submit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox_Type;
        private System.Windows.Forms.Timer Datatimer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_TimerCount;
    }
}