using System;
using System.Collections.Generic;
using Emotiv;
using System.IO;
using System.Threading;
using System.Reflection;

namespace EEG_Example_1
{

    public class AffectivValue
    { 
        public double boredom;
        public double excitement;
        public double frustration;
        public double meditation;
     
    
    }
    class EEG_Logger
    {
        EmoEngine engine; // Access to the EDK is viaa the EmoEngine 
        int userID = -1; // userID is used to uniquely identify a user's headset
        string filename = "outfile.csv"; // output filename
        static System.IO.StreamWriter affLog = new System.IO.StreamWriter("affLog.log");
        static System.IO.StreamWriter engineLog = new System.IO.StreamWriter("engineLog.log");
        String[] buff = new String[10] ;
        static  string filen = "out.csv"; // output filename
        static List<AffectivValue> Affv = new List<AffectivValue>();

    
        EEG_Logger()
        {
         
            // create the engine
            engine = EmoEngine.Instance;
            engine.UserAdded += new EmoEngine.UserAddedEventHandler(engine_UserAdded_Event);
            
            ///Only for Emostate - delete after
            engine.EmoStateUpdated += new EmoEngine.EmoStateUpdatedEventHandler(engine_EmoStateUpdated);
            EmoEngine.Instance.AffectivEmoStateUpdated += new EmoEngine.AffectivEmoStateUpdatedEventHandler(engine_AffectivEmoStateUpdated);

            // connect to Emoengine.            
            engine.Connect();

            // create a header for our output file
          //  WriteHeader();
        }
        /*Emostate Only*/


       static void WriteAffectiv()
        {
            TextWriter file = new StreamWriter(filen, true);
            string header = "boredom, excitement, frustration,meditation,";
            
            file.WriteLine(header);
          
            for (int i = 0; i < Affv.Count; i++)
            {
                file.Write(Affv[i].boredom + ",");

                file.Write(Affv[i].excitement + ",");
                file.Write(Affv[i].frustration + ",");
                file.Write(Affv[i].meditation + ",");
                file.WriteLine();
            }


            file.Close();

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
                af.excitement = rawScoreEc;
//                file.Write("Excitement :" + rawScoreEc + " ");
             
              //  file.Close();

            }

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
            Affv.Add(af);
            
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
        }

        void engine_EmoStateUpdated(object sender, EmoStateUpdatedEventArgs e)
        {

          EmoState es = e.emoState;
       //   Console.WriteLine("User has lower face expression : " + es.ExpressivGetLowerFaceAction().ToString()+ " of strength " + es.ExpressivGetLowerFaceActionPower().ToString() );
          Int32 numCqChan = es.GetNumContactQualityChannels();
          EdkDll.EE_EEG_ContactQuality_t[] cq = es.GetContactQualityFromAllChannels();
            
          for (Int32 i = 0; i < numCqChan; ++i)
          {
              if (cq[i] != es.GetContactQuality(i))
              {
                  throw new Exception();
              }
          }
          for (int i = 0; i < cq.Length; ++i)
          {
          //     Console.WriteLine("{0},", cq[i]);
//              engineLog.Write("{0},", cq[i]);
          }

        }

        void engine_UserAdded_Event(object sender, EmoEngineEventArgs e)
        {
            Console.WriteLine("User Added Event has occured");
             
            // record the user 
            userID = (int)e.userId;

            // enable data aquisition for this user.
            engine.DataAcquisitionEnable((uint)userID, true);
            
            // ask for up to 1 second of buffered data
            engine.EE_DataSetBufferSizeInSec(1); 

        }
        void Run()
        {
            // Handle any waiting events
            engine.ProcessEvents();

            // If the user has not yet connected, do not proceed
            if ((int)userID == -1)
                return;

            Dictionary<EdkDll.EE_DataChannel_t, double[]> data = engine.GetData((uint)userID);


            if (data == null)
            {
                return;
            }

            int _bufferSize = data[EdkDll.EE_DataChannel_t.TIMESTAMP].Length;

        //    Console.WriteLine("Writing " + _bufferSize.ToString() + " lines of data ");

            
            // Write the data to a file
            TextWriter file = new StreamWriter(filename,true);

            for (int i = 0; i < _bufferSize; i++)
            {
                // now write the data
                foreach (EdkDll.EE_DataChannel_t channel in data.Keys)
                  //  file.Write(data[channel][i] + ",");
                file.WriteLine("");

            }
            file.Close();
            
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

        static void Main(string[] args)
        {
           // Console.WriteLine("EEG Data Reader Example");
            
            EEG_Logger p = new EEG_Logger();

            
            for (int i = 0; i < 100; i++)
            {
                p.Run();
                Thread.Sleep(100);
            }
            WriteAffectiv();
          
        }

    }
}
