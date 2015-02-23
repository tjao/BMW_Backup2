using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace NaiveBayesClassifier
{
    class NaiveBayes
    {

        static void Main(string[] args)
        {
            string line;   // it is to read input.txt
            NaiveBayes NBC = new NaiveBayes();        
        }

        double TotalTranningSet =0.00F;

        double High_Number=0.0F;
        double High = 0.0F;
        double Alpha_High_High = 0.0F;
        double Alpha_Low_High = 0.0F;
        double Beta_High_High = 0.0F;
        double Beta_Low_High = 0.0F;

        double Low_Number = 0.0F;
        double low = 0.0F;
        double Alpha_High_low = 0.0F;
        double Alpha_Low_low = 0.0F;
        double Beta_High_low = 0.0F;
        double Beta_Low_low = 0.0F;

        // 
        double Num_Alpha_High_High = 0.0F;
        double Num_Alpha_Low_High = 0.0F;
        double Num_Alpha_High_Low = 0.0F;
        double Num_Alpha_Low_Low = 0.0F;

        // 
        double Num_Beta_High_High = 0.0F;
        double Num_Beta_Low_High = 0.0F;
        double Num_Beta_High_Low = 0.0F;
        double Num_Beta_Low_Low = 0.0F;

        Boolean focus = false;

        void IncreaseNumberOfAlpha_High_High()
        {
            Num_Alpha_High_High++;
        }

        void IncreaseNumberOfAlpha_Low_High()
        {
            Num_Alpha_Low_High++;
        }

        void IncreaseNumberOfAlpha_High_low()
        {
            Num_Alpha_High_Low++;
        }

        void IncreaseNumberOfAlpha_Low_low()
        {
            Num_Alpha_Low_Low++;
        }


        void IncreaseNumberOfHigh()
        {
            High_Number++;
        }

        void IncreaseNumberOfLow()
        {
            Low_Number++;
        }

        void IncreaseNumberOfBeta_Low_Low()
        {
            Num_Beta_Low_Low++;
        }

        void IncreaseNumberOfBeta_High_Low()
        {
            Num_Beta_High_Low++;
        }

        void IncreaseNumberOfBeta_High_High()
        {
            Num_Beta_High_High++;
        }

        void IncreaseNumberOfBeta_Low_High()
        {
            Num_Beta_Low_High++;
        }

        void UserFocus(Boolean f)
        {
            focus = f;
            if (f == true)
                IncreaseNumberOfHigh();
            else
                IncreaseNumberOfLow();
        }
        void Tranning(double alpha , double beta)
        {

            if (alpha > 50 && focus == true)    // Alpha_High_High
                IncreaseNumberOfAlpha_High_High();
            else if (alpha > 50 && focus == false) // Alpha_High_Low
                IncreaseNumberOfAlpha_High_low();
            else if (alpha < 50 && focus == true) // Alpha_Low_High
                IncreaseNumberOfAlpha_Low_High();
            else if (alpha < 50 && focus == false)   // Alpha_Low_Low
                IncreaseNumberOfAlpha_Low_low();

            if (beta > 50 && focus == true)    // Beta_High_High
                IncreaseNumberOfBeta_High_High();
            else if (beta > 50 && focus == false) // Beta_High_Low
                IncreaseNumberOfBeta_High_Low();
            else if (beta < 50 && focus == true)  // Beta_Low_High
                IncreaseNumberOfBeta_Low_High();
            else if (beta < 50 && focus == false) // Beta_Low_Low
                IncreaseNumberOfBeta_Low_Low();

        }

        void IncreaseTotalTranningSet()
        {
            TotalTranningSet++;
        }


          Boolean Classifier(double alpha, double beta)
        {
            Boolean result=false;
            double P_Focus = High_Number / TotalTranningSet;
            double P_UnFocus = Low_Number / TotalTranningSet;
            if (alpha > 50)
            {
                P_Focus = P_Focus * (Num_Alpha_High_High / High_Number);
                P_UnFocus = P_UnFocus * (Num_Alpha_High_Low / Low_Number);
            }
            else
            {
                P_Focus = P_Focus * (Num_Alpha_Low_High / High_Number);
                P_UnFocus = P_UnFocus * (Num_Alpha_Low_Low / Low_Number);
            }

            if(beta > 50)
            {
                P_Focus = P_Focus * (Num_Beta_High_High / High_Number);
                P_UnFocus = P_UnFocus * (Num_Beta_High_Low / Low_Number);
            }
            else
            {
                P_Focus = P_Focus * (Num_Beta_Low_High /High_Number);
                P_UnFocus = P_UnFocus * (Num_Beta_Low_Low / Low_Number);
            }
            if (P_Focus > P_UnFocus)
                result = true;
            else
                result = false;
            return result;
        }

    }

   
}