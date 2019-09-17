﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS
{
    public class BS
    {
        public double computeCall(double s, double k, double t, double sigma, double r)
        {
            double d1 = (Math.Log(s / k) + (r + sigma * sigma * 0.5) * t) / (sigma * Math.Sqrt(t)) ;
            double d2 = d1 - sigma * Math.Sqrt(t);

            return s * Phi(d1) - k * Math.Exp(-r * t) * Phi(d2);            
        }

        public double computePut(double s, double k, double t, double sigma, double r)
        {
            double d1 = (Math.Log(s / k) + (r + sigma * sigma * 0.5) * t) / (sigma * Math.Sqrt(t));
            double d2 = d1 - sigma * Math.Sqrt(t);

            return k * Math.Exp(-r * t) * Phi(-d2) -s*Phi(-d1);
        }

        double Phi(double x)
        {
            // constants
            double a1 = 0.254829592;
            double a2 = -0.284496736;
            double a3 = 1.421413741;
            double a4 = -1.453152027;
            double a5 = 1.061405429;
            double p = 0.3275911;

            // Save the sign of x
            int sign = 1;
            if (x < 0)
                sign = -1;
            x = Math.Abs(x) / Math.Sqrt(2.0);

            // A&S formula 7.1.26
            double t = 1.0 / (1.0 + p * x);
            double y = 1.0 - (((((a5 * t + a4) * t) + a3) * t + a2) * t + a1) * t * Math.Exp(-x * x);

            return 0.5 * (1.0 + sign * y);
        }
    }
}
