using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamDeflection.UI.WinForm.Formulas
{
    public static class CalculateCaseFirst
    {
        public static double MidSpanLoad(double L, double P, double E, double I)
        {
            double share = P * (Math.Pow(L, 3));
            double denominator = 48 * E * I;

            return Math.Round((share / denominator), 5);
        }
        public static double LoadAtAnyPoint(double L, double a, double b, double P, double E, double I)
        {
            double share = P * b * (3 * Math.Pow(L, 2) - 4 * Math.Pow(b, 2));
            double denominator = 48 * E * I;
            return Math.Round((share / denominator), 5);
        }
        public static double UniformLoad(double L, double w, double E, double I)
        {
            double share = 5 * w * Math.Pow(L,4) ;
            double denominator = 384 * E * I;
            return Math.Round((share / denominator), 5);
        }
        public static double UniformlyVaringLoad(double w, double L, double E, double I)
        {
            double share = 0.00652 * w * Math.Pow(L,4) ;
            double denominator = E * I ;
            return Math.Round((share / denominator), 5);

        }
        public static double TringularLoad(double w, double L, double E, double I)
        {
            double share = w * Math.Pow(L, 4);
            double denominator = 120 * E * I;
            return Math.Round((share / denominator), 5);
        
        }
        public static double MomentLoadAtOneSupport(double M, double L, double E, double I)
        {
            double share = M * Math.Pow(L, 2);
            double denominator = 9 * Math.Sqrt(3) * E * I;
            return Math.Round((share / denominator), 5);

        }

    }
    public static class CalculateCaseSecond
    {
        public static double EndLoad(double L, double P, double E, double I)
        {
            double share = P * Math.Pow(L, 3);
            double denominator = 3 * E * I;
            return Math.Round((share / denominator), 5);
        }
        public static double LoadAtAnyPoint(double L, double a, double b, double P, double E, double I)
        {
            double share = P * Math.Pow(a,2) * ( 3 * L - a);
            double denominator = 6 * E * I;
            return Math.Round((share / denominator), 5);
        }
        public static double UniformLoad(double L, double w, double E, double I)
        {
            double share = w * Math.Pow(L, 4);
            double denominator = 8 * E * I;
            return Math.Round((share / denominator), 5);
        
        }
        public static double UniformlyVaringLoadCaseFirst(double w, double L, double E, double I)
        {
            double share = w * Math.Pow(L, 4);
            double denominator = 30 * E * I;
            return Math.Round((share / denominator), 5);
        }
        public static double UniformlyVaringLoadCaseSecond(double w, double L, double E, double I)
        {
            double share = 11 * w * Math.Pow(L, 4);
            double denominator = 120 * E * I;
            return Math.Round((share / denominator), 5);
         
        }
        public static double MomentLoadAtEnd(double M, double L, double E, double I)
        {
            double share = M * Math.Pow(L, 2);
            double denominator = 2 * E * I;
            return Math.Round((share / denominator), 5);
        }

    }
}
