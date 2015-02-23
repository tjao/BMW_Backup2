using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMW_GUI
{

    /*"COUNTER,INTERPOLATED,RAW_CQ,AF3,F7,F3, FC5, T7, P7, O1, O2,P8" +
                            ", T8, FC6, F4,F8, AF4,GYROX, GYROY, TIMESTAMP, ES_TIMESTAMP" +
                            "FUNC_ID, FUNC_VALUE, MARKER, SYNC_SIGNAL,";*/
    public class EmotivRawEEG
    {
        public DateTime date { get; set; }

        public double COUNTER { get; set; }
        public double INTERPOLATED { get; set; }
        public double RAW_CQ { get; set; }

     //   double channel[14]={ get; set; }
   //     String[] channelName = {"AF3","F7","F3", "FC5", "T7", "P7", "O1", "O2","P8","T8", "FC6", "F4","F8", "AF4"};

        #region channel
        public double AF3 { get; set; }
        public double F7 { get; set; }
        public double F3 { get; set; }
        public double FC5 { get; set; }
        public double T7 { get; set; }
        public double P7 { get; set; }
        public double O1 { get; set; }
        public double O2 { get; set; }
        public double P8 { get; set; }
        public double T8 { get; set; }
        public double FC6 { get; set; }
        public double F4 { get; set; }
        public double F8 { get; set; }
        public double AF4 { get; set; }
        #endregion

        public double GYROX { get; set; }
        public double GYROY { get; set; }
        public double TIMESTAMP { get; set; }
        public double ES_TIMESTAMP { get; set; }
        public double FUNC_ID { get; set; }
        public double FUNC_VALUE { get; set; }
        public double MARKER { get; set; }
        public double SYNC_SIGNAL { get; set; }


    }
}
