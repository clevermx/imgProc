using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obrabotka1
{
    class RndGenerator
    {
        Stopwatch timer = new Stopwatch();
        List<int> list = new List<int>();
        double a;
        double b;


        public RndGenerator(double pa = 0, double pb = 1)
        {
            a = pa;
            b = pb;
            timer.Start();
        }

        public double GetNext()
        {
           

            String str = timer.ElapsedTicks.ToString();

            str = str.Substring(str.Length - 3);
            double funValue;
           double d = Double.Parse(str);
            str= timer.ElapsedTicks.ToString();
            str = str.Substring(0, 1+((int)d) % 4);
            d = d * Double.Parse(str);
            if ( d % 2==0)
             {
                funValue = Math.Sin(d);
            }
            else
            {
                funValue = Math.Cos(d);
            }

            funValue =a+ funValue * (b - a);   

            return funValue;



        }
    }
}
