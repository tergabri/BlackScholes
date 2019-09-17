using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BS;

namespace MinimalMVVM.Models
{
    class BlackScholes
    {
        public double ComputeCallPrice(double s, double k, double t, double sigma, double r)
        {
            BS.BS tmp=new BS.BS();
            return tmp.computeCall(s,k,t,sigma,r);
        }

        public double ComputePutPrice(double s, double k, double t, double sigma, double r)
        {
            BS.BS tmp = new BS.BS();
            return tmp.computePut(s, k, t, sigma, r);
        }
    }
}
