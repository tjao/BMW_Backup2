using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using EEGDatabase;

namespace BMW_GUI
{
    public partial class TrainingForm : Form
    {
        #region global variable
        public EEG_DataReader dataReader;
        private BackgroundWorker DataWorker;
        public List <EmotivRawEEG> EEGStorer= new List<EmotivRawEEG>();
        public Database eegDB;
        public SSVEP_Form ssvep;
        public SensorContactForm cqForm;
        public List<BandPower> PowerStorer = new List<BandPower>();
        public List<Boolean> openEye = new List<Boolean>();
        public Fourier ft = new Fourier();
        public string userName;

        //extra but there for simplicity of computing FFT

        public List<double> O1List = new List<double>();
        public List<double> F3List = new List<double>();
        public List<double> F4List = new List<double>();
        public List<double> AF3List = new List<double>();
        public List<double> AF4List = new List<double>();
        public List<double> F7List = new List<double>();
        public List<double> F8List = new List<double>();

        public List<double> FC5List = new List<double>();
        public List<double> FC6List = new List<double>();
        public List<double> P7List = new List<double>();
        public List<double> P8List = new List<double>();
        public List<double> T7List = new List<double>();
        public List<double> T8List = new List<double>();
        #endregion



        private void EmotivDataWorker(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            while (!worker.CancellationPending)
            {
                //will collect data
                dataReader.DataCollect();
                System.Threading.Thread.Sleep(600);
            }
            if (worker.CancellationPending)
            {
                e.Cancel = true;
            }


        }

        public void ShowCQ()//int x, int y, int width)
        {
            cqForm = dataReader.scForm;
//            cqForm.Left = this.Location.X + this.Size.Width;
 //           cqForm.Top= this.Location.Y;
            cqForm.Show();

            cqForm.SetDesktopLocation(this.Location.X + this.Size.Width, this.Location.Y);

        }
        public TrainingForm( EEG_DataReader e_dataReader, Database db, String username)
        {
            InitializeComponent();
            dataReader = e_dataReader;
            eegDB = db;
            Datatimer.Enabled = true;
            userName = username;


            this.FormClosing += new FormClosingEventHandler(TrainingForm_ClosingForm);

            /*
            #region BackgroundWorker

            DataWorker = new BackgroundWorker();
            DataWorker.DoWork += new DoWorkEventHandler(EmotivDataWorker);
            DataWorker.WorkerSupportsCancellation = true;
            #endregion
            */
        }

        private void button_submit_Click(object sender, EventArgs e)
        {
            button_submit.Enabled = false;
            listBox_Type.Enabled = false;
            
            String selectedItem = listBox_Type.SelectedItem.ToString();
            
            Direction_postsubmit(selectedItem);
            experimentTimer.Interval = 1000;
            experimentTimer.Enabled = true;
   //         Datatimer.Enabled = true;

             
        }


        public void Direction_postsubmit(String selectedItem)
        {
            //Relax-baseline
            if (selectedItem == "Relax")
            {
                 richTextBox_Direction.Text = "Relax and Think of Nothing for 10 seconds. ";
            }
            else if (selectedItem == "Math-Level1" || selectedItem == "Math-Level2"
                || selectedItem == "Math-Level3" || selectedItem == "Math-Level4")
            {
                int n1, n2 = 0;
                int n3,n4 = 0;
                Random rnd1 = new Random();

                n1 = rnd1.Next(10, 100);
                n2 = rnd1.Next(10, 100);
                n3=rnd1.Next(10,100);
                n4= rnd1.Next(10,100);
                if (selectedItem == "Math-Level1")
                {
                    richTextBox_Direction.Text = "Solve the below expression in your mind : \n " +
                                                n1 + " + " + n2;
                }
                else if (selectedItem == "Math-Level2")
                {
                    richTextBox_Direction.Text = "Solve the below expression in your mind : \n " +
                                                  n1 + " x " + n2;
                }
                else if (selectedItem == "Math-Level3")
                {
                    richTextBox_Direction.Text = "Solve the below expression in your mind : \n " +
                                                      n1 + " x " + n2 + " + " + n3 + " x " + n4;

                }
                else if (selectedItem == "Math-Level4")
                {
                    richTextBox_Direction.Text = "Solve the below expression in your mind : \n " +
                                                          n1 + " x " + n2 + " x " + n3 + " x " + n4;

                
                }


            }
            //Geometric figure rotation task
            else if (selectedItem == "Geometric figure rotation")
            {
                richTextBox_Direction.Text = "Memorize the following figure \n";
            }

            else if (selectedItem == "Mental letter composing")
            {
                //  richTextBox_Direction.Text = "Mentally Compose a letter to a friend";
            }
            else if (selectedItem == "Visual counting")
            {
                richTextBox_Direction.Text = "Imagine a blackboard. \n" +
                            "First, Visualize number 0 on the board," +
                            "Erase it while counting 1, and so on. ";
            }
            else if (selectedItem == "SSVEP-9HZ")
            {
                 ssvep= new SSVEP_Form(9);
                ssvep.Show();
                ssvep.SSVEP_timer1.Interval = 111;
                ssvep.SSVEP_timer1.Enabled = true;
               // ssvep.SSVEP_timer2.Enabled = true;

                //SSVEP_Timer.Enabled = true;

            }
            else if (selectedItem == "SSVEP-11HZ")
            {
                ssvep = new SSVEP_Form(11);
                ssvep.Show();
                ssvep.SSVEP_timer1.Interval = 91;
                ssvep.SSVEP_timer1.Enabled = true;
                // ssvep.SSVEP_timer2.Enabled = true;

                //SSVEP_Timer.Enabled = true;

            }
            else if (selectedItem == "SSVEP-13HZ")
            {
                ssvep = new SSVEP_Form(13);
                ssvep.Show();
                ssvep.SSVEP_timer1.Interval =77;
                ssvep.SSVEP_timer1.Enabled = true;
                // ssvep.SSVEP_timer2.Enabled = true;

                //SSVEP_Timer.Enabled = true;

            }
            else if (selectedItem == "SSVEP-15HZ")
            {
                ssvep = new SSVEP_Form(15);
                ssvep.Show();
                ssvep.SSVEP_timer1.Interval = 67;
                ssvep.SSVEP_timer1.Enabled = true;
                // ssvep.SSVEP_timer2.Enabled = true;

                //SSVEP_Timer.Enabled = true;

            }
            else if (selectedItem == "Open-Close")
            {
                richTextBox_Direction.Text = "Open Eyes first. Close eyes when hearing a beeping sound. ";
            }

            else if (selectedItem == "Open-Eyes")
            {
                richTextBox_Direction.Text = "You will open eyes for 10 seconds";
            }
            else
            {
            }




        }
        public void Direction_presubmit(String selectedItem)
        {
            pictureBox1.Image = pictureBox1.InitialImage;
            pictureBox1.Visible = false;
            //SSVEP_light.Visible = false;

            //Relax-baseline
            if (selectedItem == "Relax")
            {
                richTextBox_Direction.Text = "Relax and Think of Nothing for 10 seconds. ";
            }
            else if (selectedItem == "Math-Level1" || selectedItem == "Math-Level2" || selectedItem == "Math-Level3" || selectedItem == "Math-Level4")
            {

                richTextBox_Direction.Text = "You will be solving mathematic expression in your mind for 10 s";

            }
                /*
            //Geometric figure rotation task
            else if (selectedItem == "Geometric figure rotation")
            {
                richTextBox_Direction.Text = "You will first memorize the following figure for 10 seconds, \n" +
                                             "then visualized the object being rotated about the axis. ";
                pictureBox1.Image = global::BMW_GUI.Properties.Resources.cube;
            }
            */
            else if (selectedItem == "Mental letter composing")
            {
                richTextBox_Direction.Text = "You will mentally compose a letter to a friend fo 10 s";
            }
            else if (selectedItem == "Visual counting")
            {
                richTextBox_Direction.Text = "You will imagine a blackboard. \n" +
                            "First, Visualize number 0 on the board," +
                            "Erase it while counting 1, and so on. ";
            }
            else if (selectedItem ==  "SSVEP-9HZ" || selectedItem == "SSVEP-11HZ" ||
                selectedItem == "SSVEP-13HZ" || selectedItem == "SSVEP-15HZ")
           
            {

                richTextBox_Direction.Text = "You will look at the blinking square for SSVEP experiment! ";
               // SSVEP_light.Visible = true;
            }

            else if (selectedItem == "Open-Close")
            {
                richTextBox_Direction.Text = "You will repeatly open eyes and close eyes within one miniutes. \n"+
                        "Hearing the Beep sounds indicates going from open eyes to close eyes, and vice versa ";
            
            }
            else if (selectedItem == "Open-Eyes")
            {
                richTextBox_Direction.Text = "You will open eyes for 10 seconds";
            }


        }

        int numOfTick = 0;
        Boolean isEyeOpen = true;
        //Experiment Timer- Keep Track of time for experiment
        private void experimentTimer_Tick(object sender, EventArgs e)
        {
            numOfTick++;
            label_TimerCount.Text = numOfTick.ToString();
            String selectedItem = listBox_Type.SelectedItem.ToString();
            /*

            if (selectedItem == "Geometric figure rotation" && numOfTick == 10)
            {
                richTextBox_Direction.Text = "Visualized the object being rotated about the axis for 10s. ";
                pictureBox1.Image = pictureBox1.InitialImage;

            }
                */

           // else if (numOfTick >=10)

            int openEyeTime = 30;
            if (numOfTick < openEyeTime && selectedItem == "Open-Close")
            {

                if (numOfTick % 5 == 0)
                {
                    Console.Beep(800, 100);
                    isEyeOpen = !isEyeOpen;
                    
                
                }

            
            }


            if ((numOfTick >= 10 && (selectedItem != "Open-Close")) || (numOfTick >= openEyeTime && selectedItem == "Open-Close"))
            {
                richTextBox_Direction.Text = "Tasks Over";
//                Direction_presubmit(selectedItem);
                button_submit.Enabled = true;
                listBox_Type.Enabled = true;
                numOfTick = 0;
                experimentTimer.Enabled = false;

                if(selectedItem ==  "SSVEP-9HZ" || selectedItem == "SSVEP-11HZ" || selectedItem == "SSVEP-13HZ" || selectedItem == "SSVEP-15HZ")
                {
                ssvep.SSVEP_timer1.Enabled = false;
                //ssvep.SSVEP_timer2.Enabled = false;
                ssvep.Hide();
                }

                //SSVEP_Timer.Enabled = false;
                //SSVEP_light.Visible = false;
                if (dataReader.CQCollector.Count != 0)
                {
                    WriteCQFile();
                }

                if (EEGStorer.Count != 0)
                {
                    WriteFile();
                    computePowerStorer();

                    WriteOpenCloseFile();
                    WritePowerFile();
                }
                else
                    label3.Text = "No Data Readed";

  
                
                
            }

        }


        private void Datatimer_Tick(object sender, EventArgs e)
        {
            //do that so unneeded data will be processed and cleared
            if (experimentTimer.Enabled == false)
            {
                label3.Text = dataReader.Run();
            }
            else
            {
                List<EmotivRawEEG> receivedData = dataReader.DataCollect();
                if (receivedData != null)
                {

                    /*add retreive EEG data to the general list*/
                    foreach (EmotivRawEEG data in receivedData)
                    {

                        EEGStorer.Add(data);
                        //add current eye state for every 0.5 seconds sample
                        //will be added to part of BandPower object after computation.
                        if (EEGStorer.Count % 64 == 0)
                        {
                            openEye.Add(isEyeOpen);
                        }
                    }
                }
                if (receivedData == null) { label3.Text = "null"; }
                //if (receivedData.Count == 1) { label3.Text = "not connect"; }
            }

        }

        private void listBox_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            String selectedItem = listBox_Type.SelectedItem.ToString();
            richTextBox_Direction.Text = selectedItem;

            Direction_presubmit(selectedItem);

        }
        
          public void WriteCQFile()
           {
               string CQFilename = listBox_Type.SelectedItem.ToString() + "_CQ_" +
                       EEGStorer[0].date.ToString("hh") +
                       EEGStorer[0].date.ToString("mm") +
                       EEGStorer[0].date.ToString("MMM") +
                       EEGStorer[0].date.ToString("dd") +
                       EEGStorer[0].date.ToString("yyyy") + ".csv";

               TextWriter file = new StreamWriter(CQFilename, false);

               string header = "AF3,F7,F3, FC5, T7, P7, O1, O2,P8" +
                               ", T8, FC6, F4,F8, AF4,DateTime";

               file.WriteLine(header);


               dataReader.CQWrite(file);
               file.Close();

               // Write the data to a file
        

           }

          public void clearAllList()
          {
              O1List.Clear();
              AF3List.Clear();
              F7List.Clear();
              F3List.Clear();
              FC5List.Clear();
              T7List.Clear();
              P7List.Clear();
              O1List.Clear();
              P8List.Clear();
              T8List.Clear();
              FC6List.Clear();
              F4List.Clear();
              F8List.Clear();
              AF4List.Clear();
          }
          public void computePowerStorer()
          {

              #region declared temp variable
              int maxFreqO1 = 0, maxFreqF3, maxFreqF4, maxFreqF7, maxFreqF8, maxFreqAF3, maxFreqAF4;
              int maxFreqFC5 = 0, maxFreqFC6, maxFreqP7, maxFreqP8, maxFreqT7, maxFreqT8;

              //    double maxMag = 0;
              double alphaPowerO1 = 0, betaPowerO1 = 0;
              double alphaPowerF3 = 0, betaPowerF3 = 0;
              double alphaPowerF4 = 0, betaPowerF4 = 0;
              double alphaPowerF7 = 0, betaPowerF7 = 0;
              double alphaPowerF8 = 0, betaPowerF8 = 0;
              double alphaPowerAF3 = 0, betaPowerAF3 = 0;
              double alphaPowerAF4 = 0, betaPowerAF4 = 0;


              double alphaPowerFC5 = 0, betaPowerFC5 = 0;
              double alphaPowerFC6 = 0, betaPowerFC6 = 0;
              double alphaPowerP7 = 0, betaPowerP7 = 0;
              double alphaPowerP8 = 0, betaPowerP8 = 0;
              double alphaPowerT7 = 0, betaPowerT7 = 0;
              double alphaPowerT8 = 0, betaPowerT8 = 0;
              #endregion

              int sampleSize = 128;
              int index_eye =0;
              //iterate EEG list - compute EEG data until the EEG data is left with less than 128
              while (O1List.Count >= 128)
              {

                  ft.computePower(O1List, sampleSize, out maxFreqO1, out alphaPowerO1, out betaPowerO1);
                  ft.computePower(F3List, sampleSize, out maxFreqF3, out alphaPowerF3, out betaPowerF3);
                  ft.computePower(F4List, sampleSize, out maxFreqF4, out alphaPowerF4, out betaPowerF4);
                  ft.computePower(F7List, sampleSize, out maxFreqF7, out alphaPowerF7, out betaPowerF7);
                  ft.computePower(F8List, sampleSize, out maxFreqF8, out alphaPowerF8, out betaPowerF8);
                  ft.computePower(AF3List, sampleSize, out maxFreqAF3, out alphaPowerAF3, out betaPowerAF3);
                  ft.computePower(AF4List, sampleSize, out maxFreqAF4, out alphaPowerAF4, out betaPowerAF4);


                  ft.computePower(FC5List, sampleSize, out maxFreqFC5, out alphaPowerFC5, out betaPowerFC5);
                  ft.computePower(FC6List, sampleSize, out maxFreqFC6, out alphaPowerFC6, out betaPowerFC6);
                  ft.computePower(P7List, sampleSize, out maxFreqP7, out alphaPowerP7, out betaPowerP7);
                  ft.computePower(P8List, sampleSize, out maxFreqP8, out alphaPowerP8, out betaPowerP8);
                  ft.computePower(T7List, sampleSize, out maxFreqT7, out alphaPowerT7, out betaPowerT7);
                  ft.computePower(T8List, sampleSize, out maxFreqT8, out alphaPowerT8, out betaPowerT8);
                  BandPower bp = new BandPower()
                  {
                      alpha_O1 = alphaPowerO1,
                      beta_O1 = betaPowerO1,
                      dominantFreq_O1 = maxFreqO1,
                      alpha_F3 = alphaPowerF3,
                      beta_F3 = betaPowerF3,
                      alpha_F4 = alphaPowerF4,
                      beta_F4 = betaPowerF4,
                      alpha_F7 = alphaPowerF7,
                      beta_F7 = betaPowerF7,
                      alpha_F8 = alphaPowerF8,
                      beta_F8 = betaPowerF8,
                      alpha_AF3 = alphaPowerAF3,
                      beta_AF3 = betaPowerAF3,
                      alpha_AF4 = alphaPowerAF4,
                      beta_AF4 = betaPowerAF4,
                      alpha_FC5=alphaPowerFC5,
                      beta_FC5=betaPowerFC5,
                      alpha_FC6=alphaPowerFC6,
                      beta_FC6=betaPowerFC6,
                      alpha_P7=alphaPowerP7,
                      beta_P7 = betaPowerP7,
                      alpha_P8=alphaPowerP8,
                      beta_P8=betaPowerP8,
                      alpha_T7=alphaPowerT7,
                      beta_T7=betaPowerT7,
                      alpha_T8=alphaPowerT8,
                      beta_T8= betaPowerT8,
                      eyeOpen=openEye[index_eye]
                  };
                  PowerStorer.Add(bp);
                  index_eye += 1;

              }
              clearAllList();
          
          }


        //put power storer's O1 alpha and beta power into database
          public void insertPower()
          {
              for (int i = 0; i < PowerStorer.Count; i++)
              {
                  eegDB.BandPowerInsert(userName, PowerStorer[i].alpha_O1, PowerStorer[i].beta_O1,openEye[i]);
              }
          
          }
        //do it after WriteEEG

          public void WriteOpenCloseFile()
          {

              string fileN = userName+"alphaO1.txt";
              TextWriter file = new StreamWriter(fileN, true);
              for (int i = 0; i < PowerStorer.Count; i++)
              {
                  file.WriteLine(PowerStorer[i].alpha_O1);
              }
              file.Close();

              fileN = userName + "betaO1.txt";
              file = new StreamWriter(fileN, true);
              for (int i = 0; i < PowerStorer.Count; i++)
              {

                  file.WriteLine(PowerStorer[i].beta_O1);

              }
              file.Close();

              fileN = userName + "isOpen.txt";
              
              file = new StreamWriter(fileN, true);
              for (int i = 0; i < PowerStorer.Count; i++)
              {
                  file.WriteLine(PowerStorer[i].eyeOpen);
              }
              file.Close();



          
          }


          public void WritePowerFile()
          {


              filename = "P"+filename;
              TextWriter file = new StreamWriter(filename, false);

              string header = "OpenEye, AlphaO1, BetaO1, DominantFreqO1, AlphaF3, BetaF3, AlphaF4, BetaF4, AlphaF7, BetaF7, AlphaF8, BetaF8, AlphaAF3, BetaAF3, AlphaAF4, BetaAF4, AlphaFC5, BetaFC5, AlphaFC6, BetaFC6, AlphaP7, BetaP7, AlphaP8, BetaP8, AlphaT7, BetaT7, AlphaT8, BetaT8 ";

              file.WriteLine(header);

              // Write the data to a file
              for (int i = 0; i < PowerStorer.Count; i++)
              {
                  file.Write(openEye[i] + ",");
                  #region Write alpha beta power to file
                  file.Write(PowerStorer[i].alpha_O1 + ", ");
                  file.Write(PowerStorer[i].beta_O1 + ",");
                  file.Write(PowerStorer[i].dominantFreq_O1 + ",");
                  file.Write(PowerStorer[i].alpha_F3 + ", ");
                  file.Write(PowerStorer[i].beta_F3 + ",");
                  file.Write(PowerStorer[i].alpha_F4 + ", ");
                  file.Write(PowerStorer[i].beta_F4 + ",");
                  file.Write(PowerStorer[i].alpha_F7 + ", ");
                  file.Write(PowerStorer[i].beta_F7 + ",");
                  file.Write(PowerStorer[i].alpha_F8 + ", ");
                  file.Write(PowerStorer[i].beta_F8 + ",");
                  file.Write(PowerStorer[i].alpha_AF3 + ", ");
                  file.Write(PowerStorer[i].beta_AF3 + ",");
                  file.Write(PowerStorer[i].alpha_AF4 + ", ");
                  file.Write(PowerStorer[i].beta_AF4 + ",");

                  file.Write(PowerStorer[i].alpha_FC5 + ", ");
                  file.Write(PowerStorer[i].beta_FC5 + ",");
                  file.Write(PowerStorer[i].alpha_FC6 + ", ");
                  file.Write(PowerStorer[i].beta_FC6 + ",");
                  file.Write(PowerStorer[i].alpha_P7 + ", ");
                  file.Write(PowerStorer[i].beta_P7 + ",");
                  file.Write(PowerStorer[i].alpha_P8 + ", ");
                  file.Write(PowerStorer[i].beta_P8 + ",");
                  file.Write(PowerStorer[i].alpha_T7 + ", ");
                  file.Write(PowerStorer[i].beta_T7 + ",");
                  file.Write(PowerStorer[i].alpha_T8 + ", ");
                  file.Write(PowerStorer[i].beta_T8 + ",");
                 

                  #endregion
                  file.WriteLine("");

              }

              PowerStorer.Clear();
              file.Close();    


          
          }

        /*For testing storing data*/
        string filename = "outfile_testing.csv"; // output filename
        public void WriteFile()
        {
            
            filename = listBox_Type.SelectedItem.ToString()+"_"+
                EEGStorer[0].date.ToString("hh") +
                EEGStorer[0].date.ToString("mm") +
                EEGStorer[0].date.ToString("MMM") +
                EEGStorer[0].date.ToString("dd")+
                EEGStorer[0].date.ToString("yyyy")+".csv";
            TextWriter file = new StreamWriter(filename, false);

            string header = "COUNTER,INTERPOLATED,RAW_CQ,AF3,F7,F3, FC5, T7, P7, O1, O2,P8" +
                            ", T8, FC6, F4,F8, AF4,GYROX, GYROY, TIMESTAMP, ES_TIMESTAMP" +
                            "FUNC_ID, FUNC_VALUE, MARKER, SYNC_SIGNAL,DateTime";

            file.WriteLine(header);
            // Write the data to a file
        
            for (int i = 0; i < EEGStorer.Count; i++)
            {

                #region Add EEGStorer to each corresponding List - memorywaste
                AF3List.Add(EEGStorer[i].AF3);
                F7List.Add(EEGStorer[i].F7);
                F3List.Add(EEGStorer[i].F3);
                FC5List.Add(EEGStorer[i].FC5);
                T7List.Add(EEGStorer[i].T7);
                P7List.Add(EEGStorer[i].P7);
                O1List.Add(EEGStorer[i].O1);
                P8List.Add(EEGStorer[i].P8);
                T8List.Add(EEGStorer[i].T8);
                FC6List.Add(EEGStorer[i].FC6);
                F4List.Add(EEGStorer[i].F4 );
                F8List.Add(EEGStorer[i].F8);
                AF4List.Add(EEGStorer[i].AF4);

                #endregion

                // now write the data
                #region write each variable to file
                file.Write(EEGStorer[i].COUNTER + ",");
                file.Write(EEGStorer[i].INTERPOLATED + ",");
                file.Write(EEGStorer[i].RAW_CQ + ",");
                file.Write(EEGStorer[i].AF3 + ",");
                file.Write(EEGStorer[i].F7 + ",");
                file.Write(EEGStorer[i].F3 + ",");
                file.Write(EEGStorer[i].FC5 + ",");
                file.Write(EEGStorer[i].T7+ ",");
                file.Write(EEGStorer[i].P7+ ",");
                file.Write(EEGStorer[i].O1 + ",");
                file.Write(EEGStorer[i].O2 + ",");
                file.Write(EEGStorer[i].P8 + ",");
                file.Write(EEGStorer[i].T8 + ",");
                file.Write(EEGStorer[i].FC6 + ",");
                file.Write(EEGStorer[i].F4 + ",");
                file.Write(EEGStorer[i].F8 + ",");
                file.Write(EEGStorer[i].AF4 + ",");
                file.Write(EEGStorer[i].GYROX + ",");
                file.Write(EEGStorer[i].GYROY + ",");
                file.Write(EEGStorer[i].TIMESTAMP + ",");
                file.Write(EEGStorer[i].ES_TIMESTAMP + ",");
                file.Write(EEGStorer[i].FUNC_ID + ",");
                file.Write(EEGStorer[i].FUNC_VALUE + ",");
                file.Write(EEGStorer[i].MARKER + ",");
                file.Write(EEGStorer[i].SYNC_SIGNAL + ",");
                file.Write(EEGStorer[i].date + ",");
                
                #endregion

     
                file.WriteLine("");

            }
            EEGStorer.Clear();
            file.Close();
        }

      private void TrainingForm_ClosingForm(object sender, FormClosingEventArgs e)
      {
     
          cqForm.Hide();
        //  cqForm.Close();
         //this.Close();

      }



    }
}
