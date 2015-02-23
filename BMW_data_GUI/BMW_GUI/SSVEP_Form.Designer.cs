namespace BMW_GUI
{
    partial class SSVEP_Form
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
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.rectangleShape15 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.rectangleShape13 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.rectangleShape11 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.rectangleShape9 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.SSVEP_timer1 = new System.Windows.Forms.Timer(this.components);
            this.SSVEP_11Hz = new System.Windows.Forms.Timer(this.components);
            this.SSVEP_9Hz = new System.Windows.Forms.Timer(this.components);
            this.SSVEP_13Hz = new System.Windows.Forms.Timer(this.components);
            this.SSVEP_15Hz = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.rectangleShape15,
            this.rectangleShape13,
            this.rectangleShape11,
            this.rectangleShape9});
            this.shapeContainer1.Size = new System.Drawing.Size(784, 562);
            this.shapeContainer1.TabIndex = 0;
            this.shapeContainer1.TabStop = false;
            // 
            // rectangleShape15
            // 
            this.rectangleShape15.FillColor = System.Drawing.Color.Green;
            this.rectangleShape15.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.rectangleShape15.Location = new System.Drawing.Point(323, 361);
            this.rectangleShape15.Name = "rectangleShape15";
            this.rectangleShape15.Size = new System.Drawing.Size(150, 150);
            // 
            // rectangleShape13
            // 
            this.rectangleShape13.FillColor = System.Drawing.Color.Green;
            this.rectangleShape13.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.rectangleShape13.Location = new System.Drawing.Point(325, 50);
            this.rectangleShape13.Name = "rectangleShape13";
            this.rectangleShape13.Size = new System.Drawing.Size(150, 150);
            // 
            // rectangleShape11
            // 
            this.rectangleShape11.FillColor = System.Drawing.Color.Green;
            this.rectangleShape11.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.rectangleShape11.Location = new System.Drawing.Point(600, 200);
            this.rectangleShape11.Name = "rectangleShape11";
            this.rectangleShape11.Size = new System.Drawing.Size(150, 150);
            // 
            // rectangleShape9
            // 
            this.rectangleShape9.FillColor = System.Drawing.Color.Green;
            this.rectangleShape9.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.rectangleShape9.Location = new System.Drawing.Point(50, 200);
            this.rectangleShape9.Name = "rectangleShape9";
            this.rectangleShape9.Size = new System.Drawing.Size(150, 150);
            // 
            // SSVEP_timer1
            // 
            this.SSVEP_timer1.Tick += new System.EventHandler(this.SSVEP_timer1_Tick);
            // 
            // SSVEP_11Hz
            // 
            this.SSVEP_11Hz.Interval = 91;
            this.SSVEP_11Hz.Tick += new System.EventHandler(this.SSVEP_11Hz_Tick);
            // 
            // SSVEP_9Hz
            // 
            this.SSVEP_9Hz.Interval = 111;
            this.SSVEP_9Hz.Tick += new System.EventHandler(this.SSVEP_9Hz_Tick);
            // 
            // SSVEP_13Hz
            // 
            this.SSVEP_13Hz.Interval = 77;
            this.SSVEP_13Hz.Tick += new System.EventHandler(this.SSVEP_13Hz_Tick);
            // 
            // SSVEP_15Hz
            // 
            this.SSVEP_15Hz.Interval = 67;
            this.SSVEP_15Hz.Tick += new System.EventHandler(this.SSVEP_15Hz_Tick);
            // 
            // SSVEP_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.shapeContainer1);
            this.Name = "SSVEP_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "SSVEP_Form";
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape9;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape11;
        public System.Windows.Forms.Timer SSVEP_timer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape15;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape13;
        public System.Windows.Forms.Timer SSVEP_11Hz;
        public System.Windows.Forms.Timer SSVEP_9Hz;
        public System.Windows.Forms.Timer SSVEP_13Hz;
        public System.Windows.Forms.Timer SSVEP_15Hz;
    }
}