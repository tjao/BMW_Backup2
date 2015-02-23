using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

using Emotiv;
using System.IO;
using System.Threading;
using System.Reflection;

namespace BMW_GUI
{
    public class AffectivValue
    {
        public Single timeFromStart;
        public Single longTermExcitement;
        public Single shortTermExcitementScore;
        public double boredom;

        public double frustration;
        public double meditation;

        public Boolean[] isAffActiveList;

    }
    
    public class EEG_DataReader
    {
        EmoEngine engine; // Access to the EDK is viaa the EmoEngine 
        int userID = -1; // userID is used to uniquely identify a user's headset
        string filename = "outfile3.csv"; // output filename
        List<EmotivRawEEG> eegCollector = new List<EmotivRawEEG>();
        string filenameCQ = "outfile_CQ.csv";
       //public  List<EdkDll.EE_EEG_ContactQuality_t[]> CQCollector = new List<EdkDll.EE_EEG_ContactQuality_t[]>();
       public List<ContactQuality> CQCollector = new List<ContactQuality>();
        //Attempt to update the form * due to the event structure...
        //May be better to update it using polling or sth...Will try later?!
       public SensorContactForm scForm=new SensorContactForm();

       public static List<AffectivValue> Affv = new List<AffectivValue>();

       public int getEmoCount()
       {
           return Affv.Count;
       }
       public AffectivValue getEmoData()
       {

           return Affv[Affv.Count-1];
       }

        public EEG_DataReader()
        {
            // create the engine
            engine = EmoEngine.Instance;
            engine.UserAdded += new EmoEngine.UserAddedEventHandler(engine_UserAdded_Event);


            /*EmoState Only - delete if Error*/
            engine.EmoStateUpdated += new EmoEngine.EmoStateUpdatedEventHandler(engine_EmoStateUpdated);

            
         //   EmoEngine.Instance.AffectivEmoStateUpdated += new EmoEngine.AffectivEmoStateUpdatedEventHandler(engine_AffectivEmoStateUpdated);


            // connect to Emoengine.            
            engine.Connect();

            // create a header for our output file
            WriteHeader();
            scForm.textChange();
        }

        public EEG_DataReader(Boolean Control)
        {
            // create the engine
            engine = EmoEngine.Instance;
            engine.UserAdded += new EmoEngine.UserAddedEventHandler(engine_UserAdded_Event);


            /*EmoState Only - delete if Error*/
            engine.EmoStateUpdated += new EmoEngine.EmoStateUpdatedEventHandler(engine_EmoStateUpdated);


            EmoEngine.Instance.AffectivEmoStateUpdated += new EmoEngine.AffectivEmoStateUpdatedEventHandler(engine_AffectivEmoStateUpdated);


            // connect to Emoengine.            
            engine.Connect();

            // create a header for our output file
            WriteHeader();
            scForm.textChange();
        }

        static void engine_AffectivEmoStateUpdated(object sender, EmoStateUpdatedEventArgs e)
        {
            //TextWriter file = new StreamWriter(filen, true);
            AffectivValue af = new AffectivValue();
            EmoState es = e.emoState;

            Single timeFromStart = es.GetTimeFromStart();

            EdkDll.EE_AffectivAlgo_t[] affAlgoList = { 
                                                      EdkDll.EE_AffectivAlgo_t.AFF_ENGAGEMENT_BOREDOM,
                                                      EdkDll.EE_AffectivAlgo_t.AFF_EXCITEMENT,
                                                      EdkDll.EE_AffectivAlgo_t.AFF_FRUSTRATION,
                                                      EdkDll.EE_AffectivAlgo_t.AFF_MEDITATION,
                                                      };

            Boolean[] isAffActiveList = new Boolean[affAlgoList.Length];

            Single longTermExcitementScore = es.AffectivGetExcitementLongTermScore();
            Single shortTermExcitementScore = es.AffectivGetExcitementShortTermScore();
            for (int i = 0; i < affAlgoList.Length; ++i)
            {
                isAffActiveList[i] = es.AffectivIsActive(affAlgoList[i]);
            }

            Single meditationScore = es.AffectivGetMeditationScore();
            Single frustrationScore = es.AffectivGetFrustrationScore();
            Single boredomScore = es.AffectivGetEngagementBoredomScore();

            double rawScoreEc = 0, rawScoreMd = 0, rawScoreFt = 0, rawScoreEg = 0;
            double minScaleEc = 0, minScaleMd = 0, minScaleFt = 0, minScaleEg = 0;
            double maxScaleEc = 0, maxScaleMd = 0, maxScaleFt = 0, maxScaleEg = 0;
            double scaledScoreEc = 0, scaledScoreMd = 0, scaledScoreFt = 0, scaledScoreEg = 0;

  
            #region Excitement
            es.AffectivGetExcitementShortTermModelParams(out rawScoreEc, out minScaleEc, out maxScaleEc);



            if (minScaleEc != maxScaleEc)
            {
                if (rawScoreEc < minScaleEc)
                {
                    scaledScoreEc = 0;
                }
                else if (rawScoreEc > maxScaleEc)
                {
                    scaledScoreEc = 1;
                }
                else
                {
                    scaledScoreEc = (rawScoreEc - minScaleEc) / (maxScaleEc - minScaleEc);
                }

                //   Console.WriteLine("Affectiv Short Excitement: Raw Score {0:f7}", rawScoreEc);
                //  Console.WriteLine("Affectiv Short Excitement: Raw Score {0:f5} Min Scale {1:f5} max Scale {2:f5} Scaled Score {3:f5}\n", rawScoreEc, minScaleEc, maxScaleEc, scaledScoreEc);
                af.shortTermExcitementScore = (float)rawScoreEc;
                //                file.Write("Excitement :" + rawScoreEc + " ");

                //  file.Close();

            }

            #endregion
            #region Boredom
            es.AffectivGetEngagementBoredomModelParams(out rawScoreEg, out minScaleEg, out maxScaleEg);
            if (minScaleEg != maxScaleEg)
            {
                if (rawScoreEg < minScaleEg)
                {
                    scaledScoreEg = 0;
                }
                else if (rawScoreEg > maxScaleEg)
                {
                    scaledScoreEg = 1;
                }
                else
                {
                    scaledScoreEg = (rawScoreEg - minScaleEg) / (maxScaleEg - minScaleEg);
                }
                //  Console.WriteLine("Affectiv Engagement : Raw Score {0:f5}  Min Scale {1:f5} max Scale {2:f5} Scaled Score {3:f5}\n", rawScoreEg, minScaleEg, maxScaleEg, scaledScoreEg);
                af.boredom = rawScoreEg;
                //file.Write("Engagement: " + rawScoreEg + " ");
            }
            #endregion

            #region Meditation
            es.AffectivGetMeditationModelParams(out rawScoreMd, out minScaleMd, out maxScaleMd);
            if (minScaleMd != maxScaleMd)
            {
                if (rawScoreMd < minScaleMd)
                {
                    scaledScoreMd = 0;
                }
                else if (rawScoreMd > maxScaleMd)
                {
                    scaledScoreMd = 1;
                }
                else
                {
                    scaledScoreMd = (rawScoreMd - minScaleMd) / (maxScaleMd - minScaleMd);
                }
                //    Console.WriteLine("Affectiv Meditation : Raw Score {0:f5} Min Scale {1:f5} max Scale {2:f5} Scaled Score {3:f5}\n", rawScoreMd, minScaleMd, maxScaleMd, scaledScoreMd);
                af.meditation = rawScoreMd;
                // file.Write(" Meditation :" + rawScoreMd + "  ");
            }
            #endregion

            #region Frustration
            es.AffectivGetFrustrationModelParams(out rawScoreFt, out minScaleFt, out maxScaleFt);
            if (maxScaleFt != minScaleFt)
            {
                if (rawScoreFt < minScaleFt)
                {
                    scaledScoreFt = 0;
                }
                else if (rawScoreFt > maxScaleFt)
                {
                    scaledScoreFt = 1;
                }
                else
                {
                    scaledScoreFt = (rawScoreFt - minScaleFt) / (maxScaleFt - minScaleFt);
                }
                //  Console.WriteLine("Affectiv Frustration : Raw Score {0:f5} Min Scale {1:f5} max Scale {2:f5} Scaled Score {3:f5}\n", rawScoreFt, minScaleFt, maxScaleFt, scaledScoreFt);
                af.frustration = rawScoreFt;
                //file.Write("Frustration :" + rawScoreFt + "  ");
                //file.WriteLine("");
                //file.Close();

            }
            #endregion


            af.timeFromStart = timeFromStart;
            af.longTermExcitement = longTermExcitementScore;
            af.isAffActiveList = isAffActiveList;
            Affv.Add(af);
            /*

            affLog.Write(
                "{0},{1},{2},{3},{4},{5},",
                timeFromStart,
                longTermExcitementScore, shortTermExcitementScore, meditationScore, frustrationScore, boredomScore);

            for (int i = 0; i < affAlgoList.Length; ++i)
            {
                affLog.Write("{0},", isAffActiveList[i]);
            }
            
            affLog.WriteLine("");
            affLog.Flush();
             */

        }

        static string filen = "emo.csv"; // output filename


         public void WriteAffectiv()
        {
            TextWriter file = new StreamWriter(filen, true);
            string header = "boredom, excitement, frustration, meditation, act_boredom, act_excitement, act_frustration, act_meditation";

            file.WriteLine(header);

            for (int i = 0; i < Affv.Count; i++)
            {
                file.Write(Affv[i].boredom + ",");

                file.Write(Affv[i].shortTermExcitementScore + ",");
                file.Write(Affv[i].frustration + ",");
                file.Write(Affv[i].meditation + ",");
                for (int j = 0; j < Affv[i].isAffActiveList.Length; j++)
                {
                    file.Write(Affv[i].isAffActiveList[j] + ",");
                }
                file.WriteLine();
            }


            file.Close();

        }
       void engine_EmoStateUpdated(object sender, EmoStateUpdatedEventArgs e)
        {

            EmoState es = e.emoState;
            //Console.WriteLine("User has lower face expression : " + es.ExpressivGetLowerFaceAction().ToString()+ " of strength " + es.ExpressivGetLowerFaceActionPower().ToString() );
            Int32 numCqChan = es.GetNumContactQualityChannels();
            EdkDll.EE_EEG_ContactQuality_t[] cq = es.GetContactQualityFromAllChannels();

            for (Int32 i = 0; i < numCqChan; ++i)
            {
                if (cq[i] != es.GetContactQuality(i))
                {
                    throw new Exception();
                }
            }
            #region declare Contact Quality to store in datastructure
            ContactQuality contact = new ContactQuality()
            {
                CMS=(double)cq[0],
                DRL=(double)cq[1],
                AF4 = (double)cq[16],
                F8 = (double)cq[15],
                F4 = (double)cq[14],
                FC6 = (double)cq[13],
                T8 = (double)cq[12],
                P8 = (double)cq[11],
                O2 = (double)cq[10],
                O1 = (double)cq[9],
                P7 = (double)cq[8],
                T7 = (double)cq[7],
                FC5 = (double)cq[6],
                F3 = (double)cq[5],
                F7 = (double)cq[4],
                AF3 = (double)cq[3],
                date = DateTime.Now
            };
            #endregion
           scForm.updateContactQuality(contact);
           scForm.textChange();
            CQCollector.Add(contact);


        }

        public void sessionOver()
        {
            engine.Disconnect();
        }
        public void engine_UserAdded_Event(object sender, EmoEngineEventArgs e)
        {
           Console.WriteLine("User Added Event has occured");

            // record the user 
            userID = (int)e.userId;

            // enable data aquisition for this user.
            engine.DataAcquisitionEnable((uint)userID, true);

            // ask for up to 1 second of buffered data
            engine.EE_DataSetBufferSizeInSec(3);

        }

        /*
         * training: 1 ver datacollect- add data to the datastructure
         return it all together in the end of experiment session
         
         control: return list of data upon request*/

        public List<EmotivRawEEG> DataCollect()
        {
            List<EmotivRawEEG> tempEEGStorage = new List<EmotivRawEEG>();
            // Handle any waiting events
            engine.ProcessEvents();
            // If the user has not yet connected, do not proceed
            if ((int)userID == -1)
            {
                EmotivRawEEG datareader = new EmotivRawEEG() { RAW_CQ = 1 };
                tempEEGStorage.Add(datareader);
                return tempEEGStorage;
            }
            Dictionary<EdkDll.EE_DataChannel_t, double[]> data = engine.GetData((uint)userID);


            if (data == null)
            {
                return null;
            }

            int _bufferSize = data[EdkDll.EE_DataChannel_t.TIMESTAMP].Length;
           for (int i = 0; i < _bufferSize; i++)
           {
               #region dataAssignment to Data structure
               EmotivRawEEG datareader = new EmotivRawEEG() {
              COUNTER = data[EdkDll.EE_DataChannel_t.COUNTER][i],
              INTERPOLATED = data[EdkDll.EE_DataChannel_t.INTERPOLATED][i],
              RAW_CQ = data[EdkDll.EE_DataChannel_t.RAW_CQ][i],
              AF4=data[EdkDll.EE_DataChannel_t.AF4][i],
              F8 = data[EdkDll.EE_DataChannel_t.F8][i],
              F4 = data[EdkDll.EE_DataChannel_t.F4][i],
              FC6 = data[EdkDll.EE_DataChannel_t.FC6][i],
              T8 = data[EdkDll.EE_DataChannel_t.T8][i],
              P8 = data[EdkDll.EE_DataChannel_t.P8][i],
              O2 = data[EdkDll.EE_DataChannel_t.O2][i],
              O1 = data[EdkDll.EE_DataChannel_t.O1][i],
              P7 = data[EdkDll.EE_DataChannel_t.P7][i],
              T7 = data[EdkDll.EE_DataChannel_t.T7][i],
              FC5 = data[EdkDll.EE_DataChannel_t.FC5][i],
              F3 = data[EdkDll.EE_DataChannel_t.F3][i],
              F7 = data[EdkDll.EE_DataChannel_t.F7][i],
              AF3 = data[EdkDll.EE_DataChannel_t.AF3][i],
              GYROX = data[EdkDll.EE_DataChannel_t.GYROX][i],
              GYROY = data[EdkDll.EE_DataChannel_t.GYROY][i],
              TIMESTAMP = data[EdkDll.EE_DataChannel_t.TIMESTAMP][i],
              ES_TIMESTAMP = data[EdkDll.EE_DataChannel_t.ES_TIMESTAMP][i],
              FUNC_ID = data[EdkDll.EE_DataChannel_t.FUNC_ID][i],
              FUNC_VALUE = data[EdkDll.EE_DataChannel_t.FUNC_VALUE][i],
              MARKER = data[EdkDll.EE_DataChannel_t.MARKER][i],
              SYNC_SIGNAL = data[EdkDll.EE_DataChannel_t.SYNC_SIGNAL][i],
                date = DateTime.Now};
              

               #endregion

               tempEEGStorage.Add(datareader);
               eegCollector.Add(datareader);

            }

           return tempEEGStorage;
        }
        public String Run()
        {
            // Handle any waiting events
            engine.ProcessEvents();

            // If the user has not yet connected, do not proceed
            if ((int)userID == -1)
                return "userID";

            Dictionary<EdkDll.EE_DataChannel_t, double[]> data = engine.GetData((uint)userID);


            if (data == null)
            {
                return "data";
            }

            int _bufferSize = data[EdkDll.EE_DataChannel_t.TIMESTAMP].Length;

            //Console.WriteLine("Writing " + _bufferSize.ToString() + " lines of data ");
            /*
            // Write the data to a file
            filename = "outfile1.csv";
            TextWriter file = new StreamWriter(filename, true);

            for (int i = 0; i < _bufferSize; i++)
            {
               
                // now write the data
                
                foreach (EdkDll.EE_DataChannel_t channel in data.Keys)
                    file.Write(data[channel][i] + ",");
                 
                
               
                file.WriteLine("");

            }
            file.Close();
             */

            return _bufferSize.ToString();
        }

        public void setFileName(String name)
        {
            filename = name;
        }
        public void WriteHeader()
        {
           
            TextWriter file = new StreamWriter(filename, false);

            string header = "COUNTER,INTERPOLATED,RAW_CQ,AF3,F7,F3, FC5, T7, P7, O1, O2,P8" +
                            ", T8, FC6, F4,F8, AF4,GYROX, GYROY, TIMESTAMP, ES_TIMESTAMP" +
                            "FUNC_ID, FUNC_VALUE, MARKER, SYNC_SIGNAL,";

            file.WriteLine(header);
            file.Close();
        }


        public void CQWrite(TextWriter file)
        {

            for (int i = 0; i < CQCollector.Count; i++)
            {
                //dataReader.CQCollector(i)
                //EdkDll.EE_EEG_ContactQuality_t[] cq cq[i] 
                //cq.Length EdkDll.EE_EEG_ContactQuality_t
                ContactQuality cq = CQCollector[i];
                #region write each variable to file

                file.Write(CQCollector[i].AF3 + ",");
                file.Write(CQCollector[i].F7 + ",");
                file.Write(CQCollector[i].F3 + ",");
                file.Write(CQCollector[i].FC5 + ",");
                file.Write(CQCollector[i].T7 + ",");
                file.Write(CQCollector[i].P7 + ",");
                file.Write(CQCollector[i].O1 + ",");
                file.Write(CQCollector[i].O2 + ",");
                file.Write(CQCollector[i].P8 + ",");
                file.Write(CQCollector[i].T8 + ",");
                file.Write(CQCollector[i].FC6 + ",");
                file.Write(CQCollector[i].F4 + ",");
                file.Write(CQCollector[i].F8 + ",");
                file.Write(CQCollector[i].AF4 + ",");
                file.Write(CQCollector[i].date + ",");

                #endregion
                file.WriteLine("");

            }
            CQCollector.Clear();
        }

    }

 
}
