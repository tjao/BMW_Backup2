using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EEGDatabase;
using System.IO;
using ClosedEyeTrigger;

namespace BMW_GUI
{

    
    public partial class ControlForm : Form
    {

        #region global variable

        public EEG_DataReader dataReader;

        public List<double> O1List= new List<double>();
        public List<double> F3List = new List<double>();
        public List<double> F4List = new List<double>();
        public List<double> AF3List = new List<double>();
        public List<double> AF4List = new List<double>();
        public List<double> F7List = new List<double>();
        public List<double> F8List = new List<double>();

        public List<EmotivRawEEG> EEGStorer = new List<EmotivRawEEG>();
        public List<BandPower> PowerStorer = new List<BandPower>();

        public Database eegDB;
        public SSVEP_Form ssvep;
        public SensorContactForm cqForm;

        public Boolean OPStart = false;
        public Fourier ft = new Fourier();
        public NaiveBayisClassifier nb = new NaiveBayisClassifier(); 
        String userName;

        List<double> alpha_O1 = new List<double>();
        // input beta_o1 list
        List<double> beta_O1 = new List<double>();
        // input trigger list
        List<bool> isEyeOpen = new List<bool>();

        //for car
        int command = 1;
        int triggerOnCount = 0;

        #endregion


        public ControlForm(EEG_DataReader e_dataReader, Database db, String username)
        {
            InitializeComponent();
            dataReader = e_dataReader;
            eegDB = db;
            DataTimer.Enabled = true;
            userName = username;

            HideLabel();
            this.FormClosing += new FormClosingEventHandler(ControlForm_ClosingForm);

            // Load Algorithm Setup
           // loadPowerdata();
            tempLoadOpenClosedata();
            nb.input(alpha_O1, beta_O1, isEyeOpen);
            nb.Find_StablePoint();
          nb.AnalysisTranningSet();


        }

        void HideLabel()
        {
            label1.Hide();
            label3.Hide();
            label4.Hide();
            label5.Hide();
            textBox_boredom.Hide();
            textBox_frustration.Hide();
            textBox_ShortExcitement.Hide();
            textBox_longExcitement.Hide();
            textBox_freq.Hide();
            label6.Hide();

        
        }
        void ShowEMOLabel()
        {
            label1.Show();
            label3.Show();
            label4.Show();
            label5.Show();
            textBox_boredom.Show();
            textBox_frustration.Show();
            textBox_ShortExcitement.Show();
            textBox_longExcitement.Show();


        }
        void ShowFreq()
        {
            label6.Show();
            textBox_freq.Show();
        }

        public void ShowCQ()
        {
            cqForm = dataReader.scForm;
            cqForm.Show();
            cqForm.SetDesktopLocation(this.Location.X + this.Size.Width, this.Location.Y);

        }

        private void button_submit_Click(object sender, EventArgs e)
        {

            String selectedItem = listBox_Type.SelectedItem.ToString();

            button_submit.Enabled = false;
            listBox_Type.Enabled = false;

            PostSubmit(selectedItem);
            OPStart = true;


        }

        public void PostSubmit(String selectedItem)
        {
            
            if (selectedItem == "SSVEP")
            {
                ssvep = new SSVEP_Form(9);
                ssvep.Show();

                ssvep.SSVEP_11Hz.Enabled = true;
                ssvep.SSVEP_13Hz.Enabled = true;
                // ssvep.SSVEP_timer2.Enabled = true;
                ShowFreq();
                //SSVEP_Timer.Enabled = true;

            }
            else if (selectedItem == "Mental Task")
            {
                EmoUpdate.Enabled = true;
                ShowEMOLabel();
                ShowFreq();
            }
        

        
        }
        int index = 0;
        public double avgAlphaOpen= 0;
        public double avgBetaOpen= 0;

        public int halfSec = 0;
        public Boolean CloseEyeTrigger = false;


        private void DataTimer_Tick(object sender, EventArgs e)
        {
            //just in case needing to clear data buffer - discard data by not doing anything to it
            if (!OPStart)
            {
                List<EmotivRawEEG> receivedData = dataReader.DataCollect();
            }

            if (OPStart)
            {
                List<EmotivRawEEG> receivedData = dataReader.DataCollect();

                #region add received Data
                if (receivedData != null)
                {
                    /*add retreive EEG data to the general list*/
                    foreach (EmotivRawEEG data in receivedData)
                    {
                        EEGStorer.Add(data);
                    }

                    for (int i = 0; i < receivedData.Count; i++)
                    {
                        O1List.Add(receivedData[i].O1);
                        F3List.Add(receivedData[i].F3);
                        F4List.Add(receivedData[i].F4);
                        F7List.Add(receivedData[i].F7);
                        F8List.Add(receivedData[i].F8);
                        AF3List.Add(receivedData[i].AF3);
                        AF4List.Add(receivedData[i].AF4);
                    }
                }
                #endregion

                #region declared temp variable
                int maxFreqO1 = 0, maxFreqF3, maxFreqF4, maxFreqF7, maxFreqF8, maxFreqAF3, maxFreqAF4;
            //    double maxMag = 0;
                double alphaPowerO1=0, betaPowerO1 = 0;
                double alphaPowerF3 = 0, betaPowerF3 = 0;
                double alphaPowerF4 = 0, betaPowerF4 = 0;
                double alphaPowerF7 = 0, betaPowerF7 = 0;
                double alphaPowerF8 = 0, betaPowerF8= 0;
                double alphaPowerAF3 = 0, betaPowerAF3 = 0;
                double alphaPowerAF4 = 0, betaPowerAF4 = 0;
                #endregion 

                int sampleSize = 128;
                /*If one of the channel has sample size larger than the given value -
                 all channel did. */

                if (O1List.Count >= sampleSize)
                {

                    #region compute  Alpha beta power
                    ft.computePower(O1List,sampleSize, out maxFreqO1, out alphaPowerO1, out betaPowerO1);
                    ft.computePower(F3List, sampleSize, out maxFreqF3, out alphaPowerF3, out betaPowerF3);
                    ft.computePower(F4List, sampleSize, out maxFreqF4, out alphaPowerF4, out betaPowerF4);
                    ft.computePower(F7List, sampleSize, out maxFreqF7, out alphaPowerF7, out betaPowerF7);
                    ft.computePower(F8List, sampleSize, out maxFreqF8, out alphaPowerF8, out betaPowerF8);
                    ft.computePower(AF3List, sampleSize, out maxFreqAF3, out alphaPowerAF3, out betaPowerAF3);
                    ft.computePower(AF4List, sampleSize, out maxFreqAF4, out alphaPowerAF4, out betaPowerAF4);
                    #endregion


                    BandPower bp = new BandPower() { alpha_O1 = alphaPowerO1, beta_O1 = betaPowerO1, dominantFreq_O1=maxFreqO1,
                    alpha_F3=alphaPowerF3, beta_F3 =betaPowerF3, alpha_F4=alphaPowerF4, beta_F4 = betaPowerF4,
                    alpha_F7= alphaPowerF7, beta_F7 = betaPowerF7, alpha_F8=alphaPowerF8, beta_F8 = betaPowerF8,
                    alpha_AF3 = alphaPowerAF3, beta_AF3 = betaPowerAF3, alpha_AF4 = alphaPowerAF4, beta_AF4 = betaPowerAF4};
                    PowerStorer.Add(bp);

                    #region comments out
                    /*
                     * 
                     // Compute Eye Open Avg Alpha & Beta

                    //Compute Percent difference betweeen the the avgAlphaOpen  & current alpha power
                   //if haven't detected Close eye 
                    
                  if(closeEye ==false)
                  {
                        if(PowerStorer.Count == 1) {avgAlphaOpen=alphaPower; avgBetaOpen = betaPower;}
                        else if (PowerStorer.Count >1)
                        {
                            if((avgAlphaOpen - alphaPower)/avgAlphaOpen <= 4) // anythreshold
                            {
                                for(int j=0; j< PowerStorer.Count;j++)
                                {
                                avgAlphaOpen += PowerStorer[j].alpha;
                                }
                                avgAlphaOpen = avgAlphaOpen / PowerStorer.Count;
                             }
                            else
                            {
                                closeEye = true;
                                
                            }
                        }
                   }
                    */

                    #endregion

                    if (PowerStorer.Count >= 2)
                    {
                        double avgAlphaPDifference = 0;
                        avgAlphaPDifference = (alphaPowerO1 -PowerStorer[PowerStorer.Count - 2].alpha_O1) / PowerStorer[PowerStorer.Count - 2].alpha_O1;
                        textBox_AlphaDiff.Text = avgAlphaPDifference.ToString();

                        double avgBetaPDifference =(betaPowerO1 - PowerStorer[PowerStorer.Count - 2].beta_O1) / PowerStorer[PowerStorer.Count - 2].beta_O1;
                        textBox_BetaDiff.Text = avgBetaPDifference.ToString();
                    }



                    //Condition for Close / Open eyes trigger
                    //if close eye for 2 seconds frame already - reset CloseEye second
                    /*
                    if (alphaPowerO1 >= 60 && alphaPowerO1 <= 100 && betaPowerO1 <= 30)
                    {
                        CloseEyeTrigger = true;
                    }
                    else
                    {
                        CloseEyeTrigger = false;
                    }

                    */
                    #region command classification

                   
                    bool trigger = nb.classify(alphaPowerO1, betaPowerO1);
                    if (trigger)
                    {
                        label11.Text = "Trigger on";
                        listBox1.Items.Add("Trigger On");

                        triggerOnCount++;

                    }
                    else if(!trigger)
                    {
                        label11.Text = "Trigger off";
                        listBox1.Items.Add("Trigger off");

                        triggerOnCount = 0;
                    }

                    if (trigger && command == 1 &&( triggerOnCount > 8 || triggerOnCount==1))
                    {
                        command = 2;
                        listBox1.Items.Add("command: " + command.ToString());
                    
                    }
                    else if (trigger && command == 2 && (triggerOnCount > 8 || triggerOnCount == 1))
                    {
                        command = 1;
                        listBox1.Items.Add("command: " + command.ToString());
                    
                    }

                    #endregion 

                    #region update TextBox
                    textBox_freq.Text = maxFreqO1.ToString();
                    textBox_alphaO1.Text=alphaPowerO1.ToString();
                    textBox_BetaO1.Text = betaPowerO1.ToString();

                    textBox_alphaF3.Text = alphaPowerF3.ToString();
                    textBox_BetaF3.Text = betaPowerF3.ToString();
                    
                    textBox_alphaF4.Text = alphaPowerF4.ToString();
                    textBox_BetaF4.Text = betaPowerF4.ToString();
                    
                    textBox_alphaF7.Text = alphaPowerF7.ToString();
                    textBox_BetaF7.Text = betaPowerF7.ToString();
                    
                    textBox_alphaF8.Text = alphaPowerF8.ToString();
                    textBox_BetaF8.Text = betaPowerF8.ToString();
                    
                    textBox_alphaAF3.Text = alphaPowerAF3.ToString();
                    textBox_BetaAF3.Text = betaPowerAF3.ToString();
                    
                    textBox_alphaAF4.Text = alphaPowerAF4.ToString();
                    textBox_BetaAF4.Text = betaPowerAF4.ToString();
                    #endregion

                    #region update Listbox
                    //list box
                    listBox1.Items.Add("O1 Alpha: " + alphaPowerO1.ToString());
                    listBox1.Items.Add("O1 Beta:" +betaPowerO1.ToString());
                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                    //listBox1.Items.Add();
                    listBox1.SelectedIndex = -1;
                    #endregion
                    // O1List.RemoveRange(0, 64);

                    }

                   
                
                }
                
              
            
        }

        private void ControlForm_ClosingForm(object sender, FormClosingEventArgs e)
        {

            cqForm.Hide();
            //  cqForm.Close();
            //this.Close();

        }

        private void EmoUpdate_Tick(object sender, EventArgs e)
        {
            if (dataReader.getEmoCount()>  0)
            {
                AffectivValue affv = dataReader.getEmoData();

                textBox_boredom.Text = affv.boredom.ToString();
                textBox_frustration.Text = affv.frustration.ToString();
                textBox_longExcitement.Text = affv.longTermExcitement.ToString();
                textBox_ShortExcitement.Text = affv.shortTermExcitementScore.ToString();
            }
        }

        private void button_stop_Click(object sender, EventArgs e)
        {
             String selectedItem = listBox_Type.SelectedItem.ToString();

              if (selectedItem == "SSVEP")
            {
               ssvep.Hide();
                ssvep.SSVEP_11Hz.Enabled = false;
                ssvep.SSVEP_13Hz.Enabled = false;
                // ssvep.SSVEP_timer2.Enabled = true;

                //SSVEP_Timer.Enabled = true;

            }
            else if (selectedItem == "Mental Task")
            {
            EmoUpdate.Enabled=false;
            dataReader.WriteAffectiv();
            }

              button_submit.Enabled = true;
              listBox_Type.Enabled = true;
              OPStart = false;


              /*may delete*/

              if (EEGStorer.Count != 0)
              {

                  WritePowerFile();

                  WriteFile();
              }

        }

        public void WritePowerFile()
        {
               filename = listBox_Type.SelectedItem.ToString() + "_Power_O1" +
               EEGStorer[0].date.ToString("hh") +
               EEGStorer[0].date.ToString("mm") +
               EEGStorer[0].date.ToString("MMM") +
               EEGStorer[0].date.ToString("dd") +
               EEGStorer[0].date.ToString("yyyy") + ".csv";

             TextWriter file = new StreamWriter(filename, false);

             string header = "AlphaO1, BetaO1, DominantFreqO1, AlphaF3, BetaF3, AlphaF4, BetaF4, AlphaF7, BetaF7, AlphaF8, BetaF8, AlphaAF3, BetaAF3, AlphaAF4, BetaAF4 ";

            file.WriteLine(header);

            // Write the data to a file
            for (int i = 0; i < PowerStorer.Count; i++)
            {
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
                #endregion
                file.WriteLine("");
            
            }

            PowerStorer.Clear();
            file.Close();    
        
        }

        /*
        public void computePower(List<double> channel, int sampleSize, out int maxFreq, out double alphaPower, out double betaPower)
        {
            List<double> range = channel.GetRange(0, sampleSize);
            double[] FFT_data = new double[sampleSize];
            FFT_data = range.ToArray();

            double maxMag = 0;
            maxFreq = 0;
            alphaPower = 0;
            betaPower = 0;
            ft.RealFFT(FFT_data, true);
           
            
            //Compute MaxFreq
            for (int i = 0; i < FFT_data.Length; i += 2){
                if (i > 6 && ((Math.Pow(FFT_data[i], 2)) + Math.Pow(FFT_data[i + 1], 2) > maxMag))
                {
                    maxMag = Math.Pow(FFT_data[i], 2) + Math.Pow(FFT_data[i + 1], 2);
                    maxFreq = (i * 128 / FFT_data.Length) / 2;
                }
            }

            //Compute Alpha
            for (int j = 8 * 2; j <= 12 * 2; j += 2){

                alphaPower += Math.Pow(FFT_data[j], 2) + Math.Pow(FFT_data[j + 1], 2);
            }

            //Compute Beta
            for (int k = 13 * 2; k <= 30 * 2; k += 2){

                betaPower += Math.Pow(FFT_data[k], 2) + Math.Pow(FFT_data[k + 1], 2);
           }


            alphaPower = Math.Sqrt(alphaPower);
            betaPower = Math.Sqrt(betaPower);

            channel.RemoveRange(0, 64);
        }
        */

        string filename = "outfile_testing.csv"; // output filename
        public void WriteFile()
        {

            filename = listBox_Type.SelectedItem.ToString() + "_" +
                EEGStorer[0].date.ToString("hh") +
                EEGStorer[0].date.ToString("mm") +
                EEGStorer[0].date.ToString("MMM") +
                EEGStorer[0].date.ToString("dd") +
                EEGStorer[0].date.ToString("yyyy") + ".csv";
            TextWriter file = new StreamWriter(filename, false);

            string header = "COUNTER,INTERPOLATED,RAW_CQ,AF3,F7,F3, FC5, T7, P7, O1, O2,P8" +
                            ", T8, FC6, F4,F8, AF4,GYROX, GYROY, TIMESTAMP, ES_TIMESTAMP" +
                            "FUNC_ID, FUNC_VALUE, MARKER, SYNC_SIGNAL,DateTime";

            file.WriteLine(header);
            // Write the data to a file

            for (int i = 0; i < EEGStorer.Count; i++)
            {

                // now write the data
                #region write each variable to file
                file.Write(EEGStorer[i].COUNTER + ",");
                file.Write(EEGStorer[i].INTERPOLATED + ",");
                file.Write(EEGStorer[i].RAW_CQ + ",");
                file.Write(EEGStorer[i].AF3 + ",");
                file.Write(EEGStorer[i].F7 + ",");
                file.Write(EEGStorer[i].F3 + ",");
                file.Write(EEGStorer[i].FC5 + ",");
                file.Write(EEGStorer[i].T7 + ",");
                file.Write(EEGStorer[i].P7 + ",");
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

        
        public void loadPowerdata()
        {
            eegDB.Load_BandPowerData(userName);

            for(int i =0;i < eegDB.alpha_o1.Count; i++)
            {
                alpha_O1.Add(eegDB.alpha_o1.Peek());
                eegDB.alpha_o1.Dequeue();

                beta_O1.Add(eegDB.beta_o1.Peek());
                eegDB.beta_o1.Dequeue();

                isEyeOpen.Add(eegDB.closedEye.Peek());
                eegDB.closedEye.Dequeue();
            }

        }
        public void tempLoadOpenClosedata()
        { 
            //load alpha, beta, open/CLose
            TextReader file = new StreamReader(userName + "alphaO1.txt");
            string nextline;
            while ((nextline = file.ReadLine()) != null)
            {
                alpha_O1.Add(Convert.ToDouble(nextline));
                /*listBox1.SelectedIndex = listBox1.Items.Count - 1;
                listBox1.Items.Add(alpha_O1[alpha_O1.Count-1]);
                listBox1.SelectedIndex = -1;
                 */

            }
            file.Close();


            file = new StreamReader(userName + "betaO1.txt");
            
            while ((nextline = file.ReadLine()) != null)
            {
                beta_O1.Add(Convert.ToDouble(nextline));
                /*
                 * listBox1.SelectedIndex = listBox1.Items.Count - 1;
                listBox1.Items.Add(beta_O1[beta_O1.Count - 1]);
                listBox1.SelectedIndex = -1;
                 */
            }
            file.Close();

            file = new StreamReader(userName + "isOpen.txt");
            
            while ((nextline = file.ReadLine()) != null)
            {
                isEyeOpen.Add(Convert.ToBoolean(nextline));

                /*
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                listBox1.Items.Add(isEyeOpen[isEyeOpen.Count - 1]);
                listBox1.SelectedIndex = -1;
                 * */
            }
            file.Close();





        }

    }
   
  
    

}
