using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obrabotka1
{
    class FourierTransfom
    {

     

            ComplexNum[] mCompResult;
            int mCount;
            public ComplexNum[] mTransform( ComplexNum[] tempArr)
            {
                int N = tempArr.Length;
            mCount = N;
            mCompResult = new ComplexNum[mCount];
                for (int k = 0; k < mCount; k++)
                {
                    ComplexNum result = new ComplexNum();
                    result.Re = 0;
                    result.Im = 0;
                    for (int i = 0; i < N; i++)
                    {
                        result.Re = result.Re + tempArr[i].Re * Math.Cos(-(2 * Math.PI * k * i) / N)- tempArr[i].Im * Math.Sin(-(2 * Math.PI * k * i) / N);
                        result.Im = result.Im + tempArr[i].Re * Math.Sin(-(2 * Math.PI * k * i) / N)+ tempArr[i].Im * Math.Cos(-(2 * Math.PI * k * i) / N);
                    }
                    mCompResult[k] = result;
                }
            return mCompResult;
            }
        public ComplexNum[] mTransform(ComplexNum[] tempArr,double Fgr,double df)
        {
            int N = tempArr.Length;
            mCount = (int) (Fgr/df);
            mCompResult = new ComplexNum[mCount];
            for (int k = 0; k < mCount; k++)
            {
                ComplexNum result = new ComplexNum();
                result.Re = 0;
                result.Im = 0;
                for (int i = 0; i < N; i++)
                {
                    result.Re = result.Re + tempArr[i].Re * Math.Cos(-(2 * Math.PI * k * i) / N) - tempArr[i].Im * Math.Sin(-(2 * Math.PI * k * i) / N);
                    result.Im = result.Im + tempArr[i].Re * Math.Sin(-(2 * Math.PI * k * i) / N) + tempArr[i].Im * Math.Cos(-(2 * Math.PI * k * i) / N);
                }
                mCompResult[k] = result;
            }
            return mCompResult;
        }
        public ComplexNum[] mObrTransform(ComplexNum[] tempArr)
            {  int N = tempArr.Length;
                mCount = N;
            mCompResult = new ComplexNum[mCount];
            for (int k = 0; k < mCount; k++)
                {
                    ComplexNum result = new ComplexNum();
                    result.Re = 0;
                    result.Im = 0;
                    for (int i = 0; i < N; i++)
                    {
                        result.Re = result.Re + tempArr[i].Re * Math.Cos((2 * Math.PI * k * i) / N) - tempArr[i].Im * Math.Sin((2 * Math.PI * k * i) / N);
                        result.Im = result.Im + tempArr[i].Re * Math.Sin((2 * Math.PI * k * i) / N) + tempArr[i].Im * Math.Cos((2 * Math.PI * k * i) / N);
                    }
                    result.Re = result.Re / N;
                    result.Im = result.Im / N;
                    mCompResult[k] = result;
                }
            return mCompResult;
            }

        }
    
}
