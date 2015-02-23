using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMW_GUI
{
    public class ContactQuality
    {

        public DateTime date { get; set; }

        //   double channel[14]={ get; set; }
        //     String[] channelName = {"AF3","F7","F3", "FC5", "T7", "P7", "O1", "O2","P8","T8", "FC6", "F4","F8", "AF4"};

        #region channel
        public double CMS { get; set; }
        public double DRL { get; set; }
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

    }
}
