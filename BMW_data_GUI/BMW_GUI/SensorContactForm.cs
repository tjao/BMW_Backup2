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
    public partial class SensorContactForm : Form
    {
        public SensorContactForm()
        {
            InitializeComponent();
        }

        int count = 0;
        public void textChange()
        {
            label1.Text = count.ToString();
            count++;
        }

        public void updateContactQuality(ContactQuality cq)
        {
            setColor( ovalShape_AF3,cq.AF3);
            setColor(ovalShape_F7, cq.F7);
            setColor(ovalShape_F3, cq.F3);
            setColor(ovalShape_FC5, cq.FC5);
            setColor(ovalShape_T7, cq.T7);
            setColor(ovalShape_P7, cq.P7);
            setColor(ovalShape_O1, cq.O1);
            setColor(ovalShape_O2, cq.O2);
            setColor(ovalShape_P8, cq.P8);
            setColor(ovalShape_T8, cq.T8);
            setColor(ovalShape_FC6, cq.FC6);
            setColor(ovalShape_F4, cq.F4);
            setColor(ovalShape_F8, cq.F8);
            setColor(ovalShape_AF4, cq.AF4);
            setColor(ovalShape_CMS, cq.CMS);

            setColor(ovalShape_DRL, cq.DRL);

        }
        
        
        

        public void setColor(Microsoft.VisualBasic.PowerPacks.OvalShape oval, double quality)
        {

            if (quality == 0)
            oval.FillColor = Color.Black;
            
            else if (quality == 1)
            oval.FillColor= Color.Red;
            else if (quality == 2)
                oval.FillColor = Color.Orange;
            else if (quality == 3)
            oval.FillColor= Color.Yellow;
            else if(quality == 4)
                oval.FillColor = Color.Green;


        }
    }
}
