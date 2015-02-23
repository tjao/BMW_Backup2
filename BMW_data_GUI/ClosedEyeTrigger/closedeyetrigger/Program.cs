using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClosedEyeTrigger
{
   
    class NaiveBayisClassifier
    {
        // input alpha_o1 list
        List<double> alpha_o1= new List<double>();
        // input beta_o1 list
        List<double> beta_o1 = new List<double>();
        // input trigger list
        List<bool> trigger = new List<bool>();
        double alpha_stable = 0.0;
        double beta_stable =0.0;
        
        // classify factors
        List<bool> Factor_High_Alpha = new List<bool>();
        List<bool> Factor_High_Beta = new List<bool>();

        double HighAlpha_Trigger = 0.0;
        double LowAlpha_Trigger = 0.0;
        double HighBeta_Trigger = 0.0;
        double LowBeta_Trigger = 0.0;
        double Trigger = 0.0;

        double P_HighAlpha_Trigger=0.0;
        double P_LowAlpha_Trigger=0.0;
        double P_HighBeta_Trigger=0.0;
        double P_LowBeta_Trigger=0.0;
        double P_Trigger=0.0;

        double HighAlpha_NOTrigger = 0.0;
        double LowAlpha_NOTrigger = 0.0;
        double HighBeta_NOTrigger = 0.0;
        double LowBeta_NOTrigger = 0.0;
      //  double NOTrigger = 0.0;

        double P_HighAlpha_NOTrigger = 0.0;
        double P_LowAlpha_NOTrigger = 0.0;
        double P_HighBeta_NOTrigger = 0.0;
        double P_LowBeta_NOTrigger = 0.0;
        double P_NOTrigger = 0.0;
       // get the input from GUI for tranning 
       void input (List<double> alpha , List<double>beta, List<bool> t)
        {
            alpha_o1 = alpha;
            beta_o1 = beta;
            trigger = t;
        }

        void Find_StablePoint()
       {
           alpha_stable = (alpha_o1.Max()+alpha_o1.Min())/2.0;
           Console.WriteLine("alpha_stable" + alpha_stable);
           beta_stable = (beta_o1.Max() + beta_o1.Min()) / 2.0;
           Console.WriteLine("beta_stable" + beta_stable);
       }

        void AnalysisTranningSet()
        {
            for (int i = 0; i < trigger.Count; i++) // Loop with for.
            {
                // update alpha status
                if (alpha_o1[i] > alpha_stable && trigger[i] == true){
                    Trigger++;
                    HighAlpha_Trigger++;
                }
                else if (alpha_o1[i] > alpha_stable && trigger[i] == false)
                    HighAlpha_NOTrigger++;
                else if (alpha_o1[i] <= alpha_stable && trigger[i] == true){
                    Trigger++;
                    LowAlpha_Trigger++;
                }
                else if (alpha_o1[i] <= alpha_stable && trigger[i] == false)
                    LowAlpha_NOTrigger++;


                
               


                // update beta status
                 if (beta_o1[i] > beta_stable && trigger[i] == true)
                     HighBeta_Trigger++;
                 else if (beta_o1[i] > beta_stable && trigger[i] == false)
                     HighBeta_NOTrigger++;
                 else if (beta_o1[i] <= beta_stable && trigger[i] == true)
                     LowBeta_Trigger++;
                 else if (beta_o1[i] <= beta_stable && trigger[i] == false)
                     LowBeta_NOTrigger++;
            }


            P_HighAlpha_Trigger = HighAlpha_Trigger / Trigger;
                P_HighAlpha_NOTrigger = HighAlpha_NOTrigger / (trigger.Count - Trigger);
                P_LowAlpha_Trigger = LowAlpha_Trigger / Trigger;
                P_LowAlpha_NOTrigger = LowAlpha_NOTrigger / (trigger.Count - Trigger);


                Console.WriteLine("P_HighAlpha_Trigger " + P_HighAlpha_Trigger);
                Console.WriteLine("P_HighAlpha_NOTrigger " + P_HighAlpha_NOTrigger);
                Console.WriteLine("P_LowAlpha_Trigger " + P_LowAlpha_Trigger);
                Console.WriteLine(" P_LowAlpha_NOTrigger " + P_LowAlpha_NOTrigger);

                 P_Trigger = Trigger / trigger.Count;
                 P_HighBeta_Trigger = HighBeta_Trigger / Trigger;
                 P_HighBeta_NOTrigger = HighBeta_NOTrigger / (trigger.Count - Trigger);
                 P_LowBeta_Trigger = LowBeta_Trigger / Trigger;
                 P_LowBeta_NOTrigger = LowBeta_NOTrigger / (trigger.Count - Trigger);

                 
                Console.WriteLine("P_Trigger " + P_Trigger);
                Console.WriteLine("P_HighBeta_Trigger " + P_HighBeta_Trigger);
                Console.WriteLine("P_HighBeta_NOTrigger " + P_HighBeta_NOTrigger);
                Console.WriteLine(" P_LowBeta_Trigger " + P_LowBeta_Trigger);
                Console.WriteLine(" P_LowBeta_NOTrigger " + P_LowBeta_NOTrigger);
                Console.WriteLine("\n\n\n");
            
        }

    bool classify(double alpha , double beta )
    {
        bool Result = false;
        double P_on = 0.0;
        double P_off =0.0;
        if(alpha <= alpha_stable && beta <= beta_stable)
        {
            P_on = P_LowAlpha_Trigger *P_LowBeta_Trigger* P_Trigger;
            Console.WriteLine("P_on" + P_on);
            P_off = P_LowAlpha_NOTrigger * P_LowBeta_NOTrigger * (1-P_Trigger);
            Console.WriteLine("P_off" + P_off);
        }
        else if(alpha > alpha_stable && beta <= beta_stable){
            P_on = P_HighAlpha_Trigger *P_LowBeta_Trigger* P_Trigger;
            P_off = P_HighAlpha_NOTrigger * P_LowBeta_NOTrigger * (1 - P_Trigger);
        }
        else if(alpha > alpha_stable && beta > beta_stable){
             P_on = P_HighAlpha_Trigger *P_HighBeta_Trigger* P_Trigger;
             P_off = P_HighAlpha_NOTrigger * P_HighBeta_NOTrigger*(1 - P_Trigger);
        }
        else{
             P_on=P_LowAlpha_Trigger*P_HighBeta_Trigger*P_Trigger;
             P_off = P_LowAlpha_NOTrigger * P_HighBeta_NOTrigger * (1 - P_Trigger);
        }

        if(P_on >= P_off)
          Result = true;
        else
         Result = false;
    

        return Result;             
        }

        static void Main(string[] args)
        {
            List<double> alpha = new List<double>();
            List<double> beta = new List<double>();
            List<bool> tri = new List<bool>();
            double[] a = {10.66178358,87.79868504,109.8623819,26.39070664,34.77600883,16.43211182,14.8526008,22.13850081,25.40871526,25.02557525,
                                28.88724447,21.79479457,18.02888231,43.82362131,58.89162098,50.20137052,17.52706361,30.30484933,41.10360287,38.08321578,
                                46.43793419,64.6921688,56.2921771,58.68889493,73.84311505,83.60653603,66.27132533,70.66488478,41.32154973,30.9376161,
                                17.05235693,27.4837544};

            double[] b = {17.00298602,55.1940691,65.8548605,34.54510489,29.14994485,23.57869361,22.86869054,27.53953628,32.0172021,
                          32.49938851,35.66198722,30.68930674,27.93514779,54.278022,53.4036818,52.12683276,24.5002717,40.12624521,
                          35.81387484,25.47700201,24.14335124,22.39188861,26.60156105,20.39004809,28.91405261,38.45561384,34.50494698,
                          43.36318324,26.21557937,27.14167731,20.18916073,27.51200176};

            bool[] trigger ={false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,
                           false,false,false,true,true,true,true,true,true,false,false,false,false,false,false,false,false};

            foreach(double ele in a)
                alpha.Add(ele);

            foreach(double ele in b)
                beta.Add(ele);

            foreach (bool ele in trigger)
                tri.Add(ele);

            NaiveBayisClassifier nb = new NaiveBayisClassifier();
            nb.input(alpha, beta, tri);
            nb.Find_StablePoint();
            nb.AnalysisTranningSet();
            bool t =nb.classify(20, 20);
            Console.WriteLine(t);
            Console.ReadKey();
        }
    }
}
