using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obrabotka1
{
   public class ComplexNum
    {
        public double Re;
        public double Im;
        public double abs
        {
            get { return Math.Sqrt(Re * Re + Im * Im); }
        }
        public double RePlusIm { get { return Re + Im; } }
        public double ReMinusIm { get { return Re - Im; } }
        public ComplexNum Sopr
        {
            get {
                ComplexNum c = new ComplexNum();
                c.Re = Re;
                c.Im = -Im;
                return c; }
        }
        public static ComplexNum operator /(ComplexNum a, ComplexNum b)
        {
            ComplexNum result = new ComplexNum();
            result.Re = (a.Re * b.Re + a.Im * b.Im) / (b.Re * b.Re+ b.Im* b.Im);
            result.Im = (b.Re * a.Im - a.Re * b.Im) / (b.Re * b.Re + b.Im * b.Im);
            return result;
        }
        public static ComplexNum operator *(ComplexNum a, ComplexNum b)
        {
            ComplexNum result = new ComplexNum();
            result.Re = (a.Re * b.Re - a.Im * b.Im);
            result.Im = (b.Re * a.Im + a.Re * b.Im);
            return result;
        }
        public ComplexNum()
        {
            Re = 0;
            Im = 0;
        }
        public ComplexNum(double d)
        {
            Re = d;
            Im = 0;
        }

        public static ComplexNum[] CompArrOfDoble (double[] tempArr)
        {
            ComplexNum[] result = new ComplexNum[tempArr.Length];
            for (int i =0; i<tempArr.Length; i++)
            {
                result[i] = new ComplexNum(tempArr[i]);
            }
            return result;
        }
    }
}
