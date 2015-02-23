namespace BMW_GUI
{
    partial class MainForm
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
            this.listBox_Mode = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_submit = new System.Windows.Forms.Button();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox_New = new System.Windows.Forms.CheckBox();
            this.label_warning = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBox_Mode
            // 
            this.listBox_Mode.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.listBox_Mode.FormattingEnabled = true;
            this.listBox_Mode.ItemHeight = 16;
            this.listBox_Mode.Items.AddRange(new object[] {
            "Training",
            "Control"});
            this.listBox_Mode.Location = new System.Drawing.Point(16, 107);
            this.listBox_Mode.Margin = new System.Windows.Forms.Padding(4);
            this.listBox_Mode.Name = "listBox_Mode";
            this.listBox_Mode.Size = new System.Drawing.Size(100, 52);
            this.listBox_Mode.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(13, 85);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "Choose Mode";
            // 
            // button_submit
            // 
            this.button_submit.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_submit.Location = new System.Drawing.Point(309, 25);
            this.button_submit.Margin = new System.Windows.Forms.Padding(4);
            this.button_submit.Name = "button_submit";
            this.button_submit.Size = new System.Drawing.Size(112, 31);
            this.button_submit.TabIndex = 14;
            this.button_submit.Text = "Submit";
            this.button_submit.UseVisualStyleBackColor = true;
            this.button_submit.Click += new System.EventHandler(this.button_submit_Click);
            // 
            // textBox_Name
            // 
            this.textBox_Name.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_Name.Location = new System.Drawing.Point(13, 47);
            this.textBox_Name.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(148, 27);
            this.textBox_Name.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(10, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Please Enter Your Name";
            // 
            // checkBox_New
            // 
            this.checkBox_New.AutoSize = true;
            this.checkBox_New.Font = new System.Drawing.Font("PMingLiU", 12F);
            this.checkBox_New.Location = new System.Drawing.Point(203, 25);
            this.checkBox_New.Name = "checkBox_New";
            this.checkBox_New.Size = new System.Drawing.Size(85, 20);
            this.checkBox_New.TabIndex = 17;
            this.checkBox_New.Text = "NewUser";
            this.checkBox_New.UseVisualStyleBackColor = true;
            // 
            // label_warning
            // 
            this.label_warning.AutoSize = true;
            this.label_warning.Font = new System.Drawing.Font("PMingLiU", 12F);
            this.label_warning.Location = new System.Drawing.Point(201, 62);
            this.label_warning.Name = "label_warning";
            this.label_warning.Size = new System.Drawing.Size(47, 16);
            this.label_warning.TabIndex = 18;
            this.label_warning.Text = "Hello!";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 209);
            this.Controls.Add(this.label_warning);
            this.Controls.Add(this.checkBox_New);
            this.Controls.Add(this.listBox_Mode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_submit);
            this.Controls.Add(this.textBox_Name);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "Form1";
          
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_Mode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_submit;
        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox_New;
        private System.Windows.Forms.Label label_warning;

    }
}

