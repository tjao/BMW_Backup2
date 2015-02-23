using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMW_GUI
{
    public partial class SSVEP_Form : Form
    {
        int SSVEPFreq = 9;
   
        public SSVEP_Form(int freq)
        {
            InitializeComponent();
            SSVEPFreq = freq;
           
        }
        public void HideSquare(int freq)
        {
            if (freq == 9)
                rectangleShape9.Visible = false; 

            else if (freq==11)
                rectangleShape11.Visible = false;
            else if (freq == 13)
                rectangleShape13.Visible = false;
            else if (freq==15)
                rectangleShape15.Visible = false;
        
        }

        private void SSVEP_timer1_Tick(object sender, EventArgs e)
        {
            if (SSVEPFreq == 9)
            {

                if (rectangleShape9.Visible == false) rectangleShape9.Visible = true;
                else if (rectangleShape9.Visible == true) rectangleShape9.Visible = false;
            }

            else if (SSVEPFreq == 11)
            {

                if (rectangleShape11.Visible == false) rectangleShape11.Visible = true;
                else if (rectangleShape11.Visible == true) rectangleShape11.Visible = false;
            }
            else if (SSVEPFreq == 13)
            {

                if (rectangleShape13.Visible == false) rectangleShape13.Visible = true;
                else if (rectangleShape13.Visible == true) rectangleShape13.Visible = false;
            }
            else if (SSVEPFreq == 15)
            {

                if (rectangleShape15.Visible == false) rectangleShape15.Visible = true;
                else if (rectangleShape15.Visible == true) rectangleShape15.Visible = false;
            }


        }

        private void SSVEP_11Hz_Tick(object sender, EventArgs e)
        {
            if (rectangleShape11.Visible == false) rectangleShape11.Visible = true;
            else if (rectangleShape11.Visible == true) rectangleShape11.Visible = false;

        }

        private void SSVEP_15Hz_Tick(object sender, EventArgs e)
        {

            if (rectangleShape15.Visible == false) rectangleShape15.Visible = true;
            else if (rectangleShape15.Visible == true) rectangleShape15.Visible = false;

        }

        private void SSVEP_13Hz_Tick(object sender, EventArgs e)
        {
            if (rectangleShape13.Visible == false) rectangleShape13.Visible = true;
            else if (rectangleShape13.Visible == true) rectangleShape13.Visible = false;


        }

        private void SSVEP_9Hz_Tick(object sender, EventArgs e)
        {
            if (rectangleShape9.Visible == false) rectangleShape9.Visible = true;
            else if (rectangleShape9.Visible == true) rectangleShape9.Visible = false;

        }


    }
}
