using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zhucai.LambdaParser;
namespace obrabotka1
{
     class GraphData
    {
        public double[] mValues;
        public double[] mArguments;
        public double mDelta;
        protected int mCount;
        protected double mLeftBorder;
        protected double mRightBorder;
        public Func<int, double> mFunc;
        public class FurieResult
        {
            public double Re;
            public double Im;
            public double abs
            {
                get { return Math.Sqrt(Re * Re + Im * Im); }
            }
            public double value { get { return Re + Im; } }
            public double _value { get { return Re - Im; } }
           
        }
        /* public GraphData( double pLeft,  double pRight ,double pDelta, string pFunc)
          {
              mCount =  (int)Math.Ceiling((pRight- pLeft)/pDelta);

              mFunc = ExpressionParser.Compile<Func<int, double>>(pFunc);
              mLeftBorder = pLeft;
              mRightBorder = pRight;
              mDelta = pDelta;
              mValues = new double[mCount];
              mArguments = new double[mCount];
              mArguments[0] = mLeftBorder;
              mValues[0] = mArguments[0];
              for (int i = 1; i < mCount; i++)
              {
                  mArguments[i] = (mArguments[i - 1] + mDelta) > mRightBorder ? mRightBorder : (mArguments[i - 1] + mDelta);
                  mValues[i] = mArguments[i];
              }

          }*/
        public GraphData() { }
        public GraphData(double pLeft, double pRight, double pDelta)
        {
            mCount = (int)Math.Ceiling((pRight - pLeft) / pDelta);
            mLeftBorder = pLeft;
            mRightBorder = pRight;
            mDelta = pDelta;
            mValues = new double[mCount];
            mArguments = new double[mCount];
            mArguments[0] = mLeftBorder;
            mValues[0] = mArguments[0];
            for (int i = 1; i < mCount; i++)
            {
                mArguments[i] = (mArguments[i - 1] + mDelta) > mRightBorder ? mRightBorder : (mArguments[i - 1] + mDelta);
                mValues[i] = mArguments[i];
            }

        }
        public GraphData(double pLeft, double pRight, double pDelta, RndGenerator pr)
        {
            mCount = (int)Math.Ceiling((pRight - pLeft) / pDelta);
            Func<int, double> temp = x => pr.GetNext();
            mFunc = temp;
            mLeftBorder = pLeft;
            mRightBorder = pRight;
            mDelta = pDelta;
            mValues = new double[mCount];
            mArguments = new double[mCount];
            mArguments[0] = mLeftBorder;
            mValues[0] = mArguments[0];
            for (int i = 1; i < mCount; i++)
            {
                mArguments[i] = (mArguments[i - 1] + mDelta) > mRightBorder ? mRightBorder : (mArguments[i - 1] + mDelta);
                mValues[i] = mArguments[i];
            }

        }
        public void size_init(double pLeft, double pRight, double pDelta)
        {
            mCount = (int)Math.Ceiling((pRight - pLeft) / pDelta);
            mLeftBorder = pLeft;
            mRightBorder = pRight;
            mDelta = pDelta;
            mValues = new double[mCount];
            mArguments = new double[mCount];
            mArguments[0] = mLeftBorder;
            mValues[0] = mArguments[0];
            for (int i = 1; i < mCount; i++)
            {
                mArguments[i] = (mArguments[i - 1] + mDelta) > mRightBorder ? mRightBorder : (mArguments[i - 1] + mDelta);
                mValues[i] = mArguments[i];
            }
        }
        public void from_val_init(double[] argArr)
        {

            mValues = new double[argArr.Length];
            for (int i = 0; i < argArr.Length; i++)
            {
                mValues[i] = argArr[i];
            }
        }

        public void x_init(double[] argArr)
        {
            mCount = argArr.Length;
            mArguments = new double[mCount];
            for (int i = 0; i < mCount; i++)
            {
                mArguments[i] = argArr[i];
            }
        }


        public void mLineAutoSpectr(double[] temparr,int imgW, int imgH)
        {
            Random r = new Random();
            int lineInd = r.Next(0, imgH);
            double[] line = temparr.Skip(lineInd * imgW).Take(imgW).ToArray<double>();
            double[] dLineDt = new double[imgW];
            for (int i = 0; i < imgW - 2; i++)
            {
                dLineDt[i] = line[i] - line[i + 1];
            }
            ComplexNum[] lineAutocor = new ComplexNum[imgW];
                for (int i = 0; i < imgW; i++) {
                lineAutocor[i]= new ComplexNum(Statistics.Crosscorrelation(dLineDt, dLineDt, i));
                }

            FourierTransfom ft = new FourierTransfom();
            double Fgr = 1.0 / 1;
            double Fdelta = Fgr / lineAutocor.Length;
            ComplexNum[] res = ft.mTransform(lineAutocor);
            for (int i = 0; i < mCount; i++)
            {
                mArguments[i]=i*Fdelta;
            }
                mFunc = t =>res[t].abs ;

        }
        public void mLineSpectr(double[] temparr, int imgW, int imgH)
        {
            Random r = new Random();
            int lineInd = r.Next(0, imgH);
            double[] line = temparr.Skip(lineInd * imgW).Take(imgW).ToArray<double>();
         
            FourierTransfom ft = new FourierTransfom();
            double Fgr = 1.0 / (1*2);
            double Fdelta = 2*Fgr / line.Length;
            mCount = (int)(Fgr / Fdelta);
            mDelta = Fdelta;
            mRightBorder = Fgr;
            mLeftBorder = 0;
            mValues = new double[mCount];
            ComplexNum[] res = ft.mTransform(ComplexNum.CompArrOfDoble(line),Fgr,Fdelta);
            mArguments = new double[mCount];
            for (int i = 0; i<mCount; i++)
            {
                mArguments[i] = i * Fdelta;
            }
            mFunc = t => res[t].abs;

        }
        public bool compute()
        {
            try
            {
                for (int i = 0; i < mCount; i++)
                {
                    mValues[i] = mFunc(i);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public void rescale(double pNewDelta)
        {
            mDelta = pNewDelta;
            for (int i = 1; i < mCount; i++)
            {
                mArguments[i] = (mArguments[i - 1] + mDelta) > mRightBorder ? mRightBorder : mArguments[i - 1] + mDelta;
                mValues[i] = mArguments[i];
            }
            compute();
        }

        public void mSetExpFunc(double a, double b)
        {
            mFunc = x => b * Math.Exp(a * mValues[x]);
        }
        public void mSetLogFunc(double a, double b)
        {
            mFunc = x => a + b * Math.Log(mValues[x]);
        }
        public void mSetAfinFunc(double a, double b)
        {
            mFunc = x => a * mValues[x] + b;
        }
        public void mSetParabFunc(double a, double b, double c)
        {
            mFunc = x => a * mValues[x] * mValues[x] + b * mValues[x] + c;
        }
        public void mSetNativeRnd(int seed = 1, double a = -1, double b = 1)
        {
            Random r = new Random(seed);
            mFunc = x => a + (b - a) * r.NextDouble();
        }
        public void mSetMyRnd(RndGenerator r, double a = -1, double b = 1)
        {
            mFunc = x => a + (b - a) * r.GetNext();
        }
        /// <summary>
        /// unused
        /// </summary>
        /// <param name="pFunc"></param>
        public void mSetAnyFunc(string pFunc)
        {
            // mFunc = ExpressionParser.Compile<Func<double, double>>("x=>" + pFunc);          
        }
        public void mSetHarm(double a, double b)
        {
            mFunc = x => a * Math.Sin(2 * Math.PI * b * mValues[x]);
        }
        public void mSetHarmRnd(double a, double b, double pC)
        {
            Random r = new Random();
            double d = 10 * a;
            double m = pC;
            mFunc = x =>
            {
                double t = 0;
                for (int i = 0; i < m; i++)
                {
                    t = t + a * Math.Sin(2 * Math.PI * b * mValues[x]) + (r.NextDouble() - 0.5) * d;
                }
                return t / m;
            };
        }

        public void mAntiRnd(double a,double[] temp)
        {
            mValues = new double[(int)(temp.Length / a)];
            mFunc = x =>
            {
                double t = 0;
                for (int i = x; i < temp.Length; i=i+(int)a)
                {
                    t = t + temp[i];
                }
                return t / a;
            };
        }

        public void mAddNoize(double pC)
        {
            Random r = new Random();

            mFunc = x => mValues[x] + (r.NextDouble() - 0.5) * pC;

        }



        public void mSetHarm3()
        {
            double a0 = 20;
            double a1 = 100;
            double a2 = 35;
            double b0 = 5;
            double b1 = 57;
            double b2 = 190;
            mFunc = x => a0 * Math.Sin(2 * Math.PI * b0 * mValues[x]) + a1 * Math.Sin(2 * Math.PI * b1 * mValues[x]) + a2 * Math.Sin(2 * Math.PI * b2 * mValues[x]);
        }

        public double GetSpike(Random r, double sigma = 1)
        {
            double a = mCount * 10;
            return (r.NextDouble() - 0.5) * a * sigma;
        }

        public void mSetSpike(int m, double sigma = 1)
        {
            Random r = new Random();
            mFunc = x => r.NextDouble() > m ? mValues[x] : mValues[x] + GetSpike(r);


        }

        public void mAddRnd(double c)
        {
            Random r = new Random();
            mFunc = x => mValues[x] + (r.NextDouble() * c - c / 2);
        }

        public void mAntiTrend(int pW)
        {
            double[] tmpArr = new double[mCount];
            for (int i = 0; i < mCount; i++)
            {

                if (i + pW <= mCount)
                {
                    double expect = 0;
                    for (int j = 0; j < pW; j++)
                    {
                        expect = expect + mValues[i + j];
                    }

                    tmpArr[i] = expect / pW;
                }
                else
                {
                    tmpArr[i] = 0;
                }
            }

            mFunc = x => mValues[x] - tmpArr[x];
        }
        public void mTrend(int pW)
        {
            double[] tmpArr = new double[mCount];
            for (int i = 0; i < mCount; i++)
            {

                if (i + pW <= mCount)
                {
                    double expect = 0;
                    for (int j = 0; j < pW; j++)
                    {
                        expect = expect + mValues[i + j];
                    }
                    tmpArr[i] = expect / pW;
                }
                else
                {
                    tmpArr[i] = 0;
                }
            }

            mFunc = x => tmpArr[x];
        }
        public void mSetSpikeHarm(double a, double b)
        {
            Random r = new Random();
            double m = 0.03;
            mFunc = x => r.NextDouble() > m ? a * Math.Sin(2 * Math.PI * b * mValues[x]) : a * Math.Sin(2 * Math.PI * b * mValues[x]) + GetSpike(r);
        }
        public void rndVal()
        {
            RndGenerator r = new RndGenerator(mLeftBorder, mRightBorder);
            Func<int, double> temp = x => r.GetNext();
            mFunc = temp;
            compute();
        }     
        public void mSetUltra( double I,double d)
        {
            double a1 = 0.009;
            double z1 = 4180*10^4;
            double z2 = 417;

            double r = (z2 - z1) / (z2 + z1);
            double dt = d / mDelta;

            double[] xt = new double[mCount];
            xt[0] = I;
            double t = 0;
            Random rnd = new Random();
            double def_d =1/16*d+ rnd.NextDouble() * 1 / 2 * d;        
            int def_dt = (int)(def_d / mDelta);
            xt[2 * def_dt] += I / 4;

            for(int j = 4 * def_dt; j < mCount; j = j + 2 * def_dt)
            {
                xt[j] += Math.Abs( r* Math.Exp(-2 * a1 * def_d) * xt[ j- 2 *def_dt]* Math.Exp(-2 * a1 * def_d));
            }
            for (int i = 2*(int)dt; i < mCount; i=i+2*(int)dt)
            {              
                t = r * Math.Exp(-2 * a1 * d) * xt[i - 2 * (int)dt];
                xt[i] =xt[i]+ Math.Abs( t* Math.Exp(-2 * a1 * d));
                if (i + 2 * def_dt < mCount)
                {
                    xt[i + 2 * def_dt] += xt[i] / 4;
                    for (int j = 4 * def_dt; j < mCount && i+j<mCount; j = j + 2 * def_dt)
                    {                        
                        xt[i + j] += Math.Abs(r * Math.Exp(-2 * a1 * def_dt) * xt[i + j - 2 * def_dt] * Math.Exp(-2 * a1 * def_dt));
                    }
                }
            }         
            mFunc = a =>Math.Abs(xt[a]); 
        }
     
        public virtual void pSetFurie( double[] tempArr)
        {
            int N = tempArr.Length;

           
           
            mArguments = new double[N];
            mValues = new double[N];
            for (int i= 0; i<mCount;i++)
            {
                mArguments[i] = i;
            }
            mLeftBorder = 0;
            mRightBorder = N-1;
            FourierTransfom fs = new FourierTransfom();

            ComplexNum[] lFurieResult = fs.mTransform( ComplexNum.CompArrOfDoble(tempArr));
            Func<int, double> temp = (k =>
            {
                return lFurieResult[k].RePlusIm;
            });
            mFunc = temp;

        }
        public virtual void pSetObrFurie( double[] tempArr)
        {
            int N = tempArr.Length;            
            mArguments = new double[N];
            mValues = new double[N];
            for (int i = 0; i < mCount; i++)
            {
                mArguments[i] = i;
            }       
            mLeftBorder = 0;
            mRightBorder = N-1;
            FourierTransfom fs = new FourierTransfom();

            ComplexNum[] lFurieResult = fs.mObrTransform(ComplexNum.CompArrOfDoble(tempArr));
            Func<int, double> temp = (k =>
            {
                return lFurieResult[k].RePlusIm;
            });
            mFunc = temp;
        }

        public void mSetCard()
        {

            int M = 200;
            int N = 1000;
            double dt = 0.005;
            double f0 = 10;
            double alpha = 45;
            double A0 = 1;
            size_init(0, (N + M - 1) * dt, dt);
            Func<double, double> h = (x => A0 * Math.Sin(2 * Math.PI * f0 * x) * Math.Exp(-alpha * x));
            double[] ht = new double[M];
            for (int i = 0; i < M; i++)
            {
                ht[i] = h(i * dt);
            }
            double[] xt = new double[N];
            Random r = new Random();
            for (int i = 0; i < 4; i++)
            {
                xt[i * 200] = 120 + (r.NextDouble() * 20 - 10);
            }

            Func<int, double> temp = (x =>
             {
                 double yk = 0;
                 for (int i = 0; i < M; i++)
                 {
                     if ((x - i < 0) || (x - i >= N))
                     {

                     }
                     else
                     {
                         yk = yk + xt[x - i] * ht[i];
                     }

                 }
                 return yk;
             });
            mFunc = temp;
        }


        public Func<int, double> ConvolutionFunction(double[] h, double[] x)
        {
            int M = h.Length;
            int N = x.Length;
            Func<int, double> temp = (a =>
            {
                double yk = 0;
                for (int i = 0; i < M; i++)
                {
                    if ((a - i < 0) || (a - i >= N))
                    {

                    }
                    else
                    {
                        yk = yk + x[a - i] * h[i];
                    }

                }
                return yk;
            });
            return temp;
        }

        public void ConwolutionWithLpf(double[] x, double fcut, double m, double dt)
        {

            double[] h = Lpf(fcut, (int)m, dt);

            mFunc = a => ConvolutionFunction(h, x)(a + (int)m);

        }


        public void ConwolutionWithHpf(double[] x, double fcut, double m, double dt)
        {

            double[] h = Lpf(fcut, (int)m, dt);
            for (int k = 0; k <= 2 * m; k++)
            {
                if (k == m)
                {
                    h[k] = 1 - h[k];
                }
                else
                {
                    h[k] = -h[k];
                }
            }

            mFunc = a => ConvolutionFunction(h, x)(a + (int)m);

        }

        public void ConwolutionWithBpf(double[] x, double f1, double f2, double m, double dt)
        {

            double[] h1 = Lpf(f1, (int)m, dt);
            double[] h2 = Lpf(f2, (int)m, dt);
            double[] h = new double[mCount];
            for (int k = 0; k <= 2 * m; k++)
            {
                h[k] = h2[k] - h1[k];
            }

            mFunc = a => ConvolutionFunction(h, x)(a + (int)m);

        }
        public void ConwolutionWithBsf(double[] x, double f1, double f2, double m, double dt)
        {

            double[] h1 = Lpf(f1, (int)m, dt);
            double[] h2 = Lpf(f2, (int)m, dt);
            double[] h = new double[mCount];
            for (int k = 0; k <= 2 * m; k++)
            {
                if (k == m)
                {
                    h[k] = 1 + h1[k] - h2[k];

                }
                else
                {
                    h[k] = h1[k] - h2[k];
                }
            }

            mFunc = a => ConvolutionFunction(h, x)(a + (int)m);

        }
        public void mShift(double shift_val)
        {

            mFunc = x => mValues[x] + shift_val;
        }
        public void mAntiShift()
        {
            double expectedVal = Statistics.ExpectedValue(mValues);

            mFunc = x => mValues[x] - expectedVal;
        }




        //х для отображения низкочастотного фильтра
        public static double[] LpfX(int m)
        {
            double[] x = new double[2 * m + 1];
            for (int i = 0; i < 2 * m + 1; i++)
            {
                x[i] = i;
            }
            return x;
        }
        public static double[] Lpf(double fcut, int m, double dt)
        {
            double[] lpw = new double[m + 1];
            double[] d = { 0.35577019, 0.2436983, 0.07211497, 0.00630165 };
            //прямоугольная часть
            double arg = 2 * fcut * dt;
            lpw[0] = arg;
            arg *= Math.PI;
            for (int i = 1; i <= m; i++)
            {
                lpw[i] = Math.Sin(arg * i) / (Math.PI * i);
            }
            //трапеция
            lpw[m] /= 2;
            //окно
            double sumg = lpw[0];

            for (int i = 1; i <= m; i++)
            {
                double sum = d[0];
                arg = (Math.PI * i) / m;

                for (int k = 1; k <= 3; k++)
                {
                    sum += 2 * d[k] * Math.Cos(arg * k);
                }
                lpw[i] *= sum;
                sumg += 2 * lpw[i];

            }
            //сглаживание(нормировка)
            for (int i = 0; i <= m; i++)
            {
                lpw[i] = lpw[i] / sumg;
            }
            double[] reverse = lpw.Reverse().ToArray();
            double[] result = new double[2 * m + 1];
            for (int i = 0; i < m; i++)
            {
                result[i] = reverse[i];
            }
            for (int i = 0; i <= m; i++)
            {
                result[m + i] = lpw[i];
            }
            return result;
        }
        public void mSelectEvery(int d,double[] pOld)
        {
            mCount = (int)(pOld.Length / d);
            mDelta = 1;
            mArguments = new double[mCount];
            mValues= new double[mCount];
            for (int i = 0; i < mCount; i++)
            {
                mArguments[i] = i;
            }
            mFunc = x => pOld[x * d];
        }
        public void mMinusEvery(int d, double[] pOld)
        {
        
            for (int i = 0; i < mCount; i=i+d)
            {
                mValues[i] -= pOld[i];
            }
            mFunc = x =>mValues[x];
        }
        public void mAntiSpike(double pC)
        {
            double expectedVal = Statistics.ExpectedValue(mValues);
            double sigma = Statistics.StandartDeviation(mValues);
            double s_count = pC;

            mFunc = x => Math.Abs(mValues[x]) < expectedVal + s_count * sigma ? mValues[x] : x == 0 ? expectedVal : x == mValues.Length ? expectedVal : ((mValues[x - 1] + mValues[x + 1]) / 2);
        }
        public void mCutSigma(double pC)
        {
            double expectedVal = Statistics.ExpectedValue(mValues);
            double sigma = Statistics.StandartDeviation(mValues);
            double s_count = pC;

            mFunc = x => Math.Abs(mValues[x]) < expectedVal + s_count * sigma ? mValues[x] :expectedVal ;
        }
        /// <summary>
        /// unused
        /// </summary>
        public void mSetAutocor(double [] arr)
        {
            int[] x = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                x[i] = i;
            }

            double[] y = new double[x.Length];

            mFunc = t => Statistics.Crosscorrelation(arr,arr,t);

               
            
        }
        public void mSetCardAndCompute()
        {
            int M = 200;
            int N = 1000;
            double dt = 0.005;
            double f0 = 10;
            double alpha = 45;
            double A0 = 1;
            size_init(0, (N + M - 1) * dt, dt);
            Func<double, double> h = (x => A0 * Math.Sin(2 * Math.PI * f0 * x) * Math.Exp(-alpha * x));
            double[] ht = new double[M];
            for (int i = 0; i < M; i++)
            {
                ht[i] = h(i * dt);
            }
            double[] xt = new double[N];
            Random r = new Random();
            for (int i = 0; i < 4; i++)
            {
                xt[i * 200] = 120 + (r.NextDouble() * 20 - 10);
            }
            for (int k = 0; k < mCount; k++)
            {
                double yk = 0;

                for (int i = 0; i < M; i++)
                {
                    if ((k - i < 0) || (k - i >= N))
                    {

                    }
                    else
                    {
                        yk = yk + xt[k - i] * ht[i];
                    }

                }
                mValues[k] = yk;
            }
        }

        public static WaveFormat waveFormat;


    
      

        public virtual bool mLoadFromFile(string filename)
        {
            String[] arr = filename.Split('.');
            switch (arr.Last())
            {
                case "dat":
                    {
                        int lFileLen = 1000;
                        mValues = readHex(filename, lFileLen);
                        mArguments = new double[mValues.Length];
                        for (int i = 0; i < mArguments.Length; i++)
                        {
                            mArguments[i] = i;
                        }
                        mDelta = 1.0;
                        mCount = mValues.Length;
                        mLeftBorder = 0;
                        mRightBorder = mArguments[mCount-1];
                        break;
                    }

                case "wav":
                    {
                        mValues = readWav(filename, out int rate, out waveFormat);
                        mArguments = new double[mValues.Length];
                        mDelta = 1.0 / rate;
                        for (int i = 0; i < mArguments.Length; i++)
                        {
                            mArguments[i] = i * mDelta;
                        }
                        mCount = mValues.Length;
                        break;
                    }           
                default:
                    {
                        return false;
                    }
            }
            return true;
        }
        public virtual void SaveToFile(string path)
        {

        }
        public static double[] readHex(string filename, int pFileLen)
        {
            BinaryReader reader = new BinaryReader(new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.None));
            reader.BaseStream.Position = 0x0;     // The offset you are reading the data from
            double[] data = new double[pFileLen];
            for (int i = 0; i < pFileLen; i++)
            {
                data[i] = reader.ReadSingle();
            }
            reader.Close();
            return data;
        }
        static double[] readWav(string filename, out int rate, out WaveFormat format)
        {
            WaveFileReader reader = new WaveFileReader(filename);
            format = reader.WaveFormat;
            float[] buffer;
            double[] data = new double[reader.SampleCount];
            int counter = 0;
            rate = reader.WaveFormat.SampleRate;
            while ((buffer = reader.ReadNextSampleFrame()) != null)
            {
                for (int i = 0; i < buffer.Length; i++)
                {
                    data[counter++] = buffer[i];
                }
            }
            reader.Close();
            return data;
        }


        public static void writeWav(string path, WaveFormat format, float[] samples)

        {
            using (WaveFileWriter writer = new WaveFileWriter(path, format))
            {
                writer.WriteSamples(samples, 0, samples.Length);
                writer.Flush();
            }

        }

        public double[] Hist(double[] tempArr, double start, double stop)
        {
            int levels = (int)(stop - start + 1);
            double[] ans = new double[levels];
            for (int i = 0; i < tempArr.Length; i++)
            {
                try
                {
                    ans[(int)tempArr[i]] += 1;
                }
                catch (Exception)
                {
                    ans[ans.Length - 1] += 1;
                }

            }
            return ans;
        }

        public void mSetHist(double[] tempArr, double start, double stop)
        {
            int levels = (int)(stop - start + 1);
            mValues = new double[levels];
            mCount = levels;
            mLeftBorder = start;
            mRightBorder = stop;
            mDelta = 1;
            double[] ans = new double[levels];
            for (int i = 0; i < tempArr.Length; i++)
            {
                try
                {
                    ans[(int)tempArr[i]] += 1;
                }
                catch (Exception)
                {
                    ans[ans.Length - 1] += 1;
                }

            }
            mFunc = x => ans[x];
        }

        public void mSetDensity (double [] tempArr)
        {
            double N = tempArr.Sum();
            mFunc = x => tempArr.Take(x + 1).Sum() / N;
        }

        public static double[] Density(double[] y)
        {

            double[] ans = new double[y.Length];
            double N = y.Sum();

            for (int i = 0; i < ans.Length; i++)
            {
                ans[i] = (double)y.Take(i + 1).Sum() / N;
            }

            return ans;

        }

        public void mSetEqualization( double[] tempArr, int levels)
        {
            double N = tempArr.Sum();
            mFunc = x => (levels - 1)*tempArr.Take(x + 1).Sum() / N;
        }
        public static double[] Equalization(double[] y, int levels)
        {

            double[] ans = new double[y.Length];
            double N = y.Sum();

            for (int i = 0; i < ans.Length; i++)
            {
                ans[i] = (int)((double)y.Take(i + 1).Sum() / N * (levels - 1));
            }

            return ans;

        }

    }
}
