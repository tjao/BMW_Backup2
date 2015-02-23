using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*Added*/
using EEGDatabase;
using Emotiv;
using System.IO;
using System.Threading;
using System.Reflection;

namespace BMW_GUI
{

    public partial class MainForm : Form
    {

        #region Forms
        TrainingForm TF;
        ControlForm CF;

        #endregion


        #region GloabalVar

        public EEG_DataReader dataReader = new EEG_DataReader();
        public EEG_DataReader dataReader_Control = new EEG_DataReader(true);

        Database db = new Database();




        #endregion
        public MainForm()
        {
            InitializeComponent();

        }

  


        private void button_submit_Click(object sender, EventArgs e)
        {


            button_submit.Enabled = false;
            Boolean operationContinue = true;

            //assume user enter String

            String userName = textBox_Name.Text;


            //User is new
            /*
            #region database check
            //if user does not enter any text
            if (textBox_Name.Text == "")
            {
                label_warning.Text = "Please enter a name";
                operationContinue = false;
            }
        
            //if user did enter name - 
            // through operation to check whether user is eligible to continue operation
             
             
            else
            {
                //if user is new, check if the name user enters existed. If existed, do not proceed.
                if (checkBox_New.Checked == true)
                {
                    db.SetUserName(textBox_Name.Text);
                    Boolean userExist = db.CreateUser();
                    if (userExist)
                    {
                        label_warning.Text = "Name existed. \nPlease enter another name";
                        operationContinue=false;
                    }
 
                }
                else if (checkBox_New.Checked == false)
                {
                    db.SetUserName(textBox_Name.Text);
                    Boolean userExist = db.CreateUser();
                    if (!userExist)
                    {
                        label_warning.Text = "Name does not exist in the database. \nPlease select new user or try another name";
                        operationContinue = false;
                    }

                }

            #endregion
                */
                if (operationContinue == true)
                {
                    switch (listBox_Mode.SelectedIndex)
                    {

                        //Training
                        case 0:
                            db.SetUserName(userName);
                            db.CreateUser();

                            TF = new TrainingForm(dataReader, db,userName);
                            TF.Show();
                            //this.Location.X + this.Size.Width, this.Location.Y
                           
    
                           TF.ShowCQ();//TF.Location.X, TF.Location.Y, TF.Size.Width);
                           //TF.ShowDialog();
                            break;
                        //Control
                        case 1:
                            CF = new ControlForm(dataReader_Control, db,userName);
                            CF.Show();
                            CF.ShowCQ();
                            break;

                        default: break;
                    }
                }
            //}

            button_submit.Enabled = true;







        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            dataReader.sessionOver(); 
            e.Cancel = true;

        }
  

    }
}
