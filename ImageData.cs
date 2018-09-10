using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace obrabotka1
{
    class ImageData : GraphData
    {

        public int ImageW;
        public int ImageH;
        public Bitmap lBits;
        public string imagePath;
        public double DinamMin = ((1 << 16) - 1);
        public double DinamMax = 0;
        public string format = "xcr";
        override
        public bool mLoadFromFile(string path)
        {
            try
            {
                imagePath = path;
                String[] arr = imagePath.Split('.');
                format = arr.Last();
                switch (format)
                {

                    case "dat":
                        {
                            string[] resol = arr[arr.Length - 2].Substring(19, 7).Split('x');
                            ImageW = int.Parse(resol[0]);
                            ImageH = int.Parse(resol[1]);
                            mCount = ImageW * ImageH;
                            mValues = readHex(path, ImageW * ImageH);
                            mArguments = new double[mValues.Length];
                            for (int i = 0; i < mArguments.Length; i++)
                            {
                                mArguments[i] = i;
                            }
                            mDelta = 1.0;
                            mLeftBorder = 0;
                            mRightBorder = mArguments[mCount - 1];

                            for (int i = 0; i < mCount; i++)
                            {
                                double temp = mValues[i];
                                if (temp > DinamMax)
                                {
                                    DinamMax = temp;
                                }
                                if (temp < DinamMin)
                                {
                                    DinamMin = temp;
                                }
                            }

                            format = "xcr";
                            return true;


                        }
                    case "jpg":
                        {
                            System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Open);
                            lBits = new Bitmap(fs);
                            fs.Close();
                            ImageW = lBits.Width;
                            ImageH = lBits.Height;
                            mCount = ImageW * ImageH;
                            mValues = new double[ImageW * ImageH];
                            mArguments = new double[mValues.Length];
                            for (int i = 0; i < mArguments.Length; i++)
                            {
                                mArguments[i] = i;
                            }
                            mDelta = 1.0;
                            mLeftBorder = 0;
                            mRightBorder = mArguments[mCount - 1];
                            for (int i = 0; i < ImageW; i++)
                            {
                                for (int j = 0; j < ImageH; j++)
                                {
                                    var pix = lBits.GetPixel(i, j);
                                    int temp = (int)(pix.R) % 256;

                                    if (temp > DinamMax)
                                    {
                                        DinamMax = temp;
                                    }
                                    if (temp < DinamMin)
                                    {
                                        DinamMin = temp;
                                    }
                                    mValues[ImageW * j + i] = temp;
                                }


                            }
                            format = "xcr";
                            return true;
                        }
                    case "xcr":
                        {
                            int w;
                            int h;
                            System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Open);
                            BinaryReader brd = new BinaryReader(fs);
                            //skip 608 bytes
                            brd.ReadBytes(608);
                            w = int.Parse(new String(brd.ReadChars(16)).Trim('\0'));
                            h = int.Parse(new String(brd.ReadChars(16)).Trim('\0'));
                            //skip 640 bytes
                            brd.ReadBytes(1408);

                            ImageW = w;
                            ImageH = h;
                            mCount = ImageW * ImageH;
                            mValues = new double[ImageW * ImageH];
                            mArguments = new double[mValues.Length];
                            for (int i = 0; i < mArguments.Length; i++)
                            {
                                mArguments[i] = i;
                            }
                            mDelta = 1.0;
                            mLeftBorder = 0;
                            mRightBorder = mArguments[mCount - 1];

                            for (int i = 0; i < w; i++)
                            {
                                for (int j = 0; j < h; j++)
                                {
                                    int read = (brd.ReadByte() * (1 << 8)) + (brd.ReadByte());//поменять местами два байта
                                    if (read > DinamMax) {
                                        DinamMax = read;
                                    }
                                    if (read < DinamMin)
                                    {
                                        DinamMin = read;
                                    }
                                    mValues[ImageW * j + i] = read;
                                }
                            }
                            return true;

                        }


                }

            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }

        public Image GetImage()
        {
            if (format == "xcr")
            {
                lBits = new Bitmap(ImageW, ImageH);
                for (int i = 0; i < ImageW; i++)
                {
                    for (int j = 0; j < ImageH; j++)
                    {
                        int temp = (int)((mValues[j * ImageW + i] - DinamMin) / (DinamMax - DinamMin) * 255);
                        lBits.SetPixel(i, j, Color.FromArgb(temp, temp, temp));
                    }
                }
            }
            if (format == "jpg")
            {
                lBits = new Bitmap(ImageW, ImageH);
                for (int i = 0; i < ImageW; i++)
                {
                    for (int j = 0; j < ImageH; j++)
                    {

                        lBits.SetPixel(i, j, Color.FromArgb((int)mValues[j * ImageW + i]));
                    }
                }
            }
            return Image.FromHbitmap(lBits.GetHbitmap());
        }

        override public void SaveToFile(string path)
        {
            try
            {
                GetImage().Save(@path + ".jpg");

            }
            catch (Exception ex)
            {
            }

        }

        public static ComplexNum[] lineFurie(ComplexNum[] tempArr, int imgW, int imgH, int pCount)
        {
            FourierTransfom fs = new FourierTransfom();
            ComplexNum[] lFurieResult = new ComplexNum[pCount];
            for (int i = 0; i < imgH; i++)
            {
                ComplexNum[] LineFurie = fs.mTransform(tempArr.Skip(i * imgW).Take(imgW).ToArray<ComplexNum>());
                for (int j = 0; j < imgW; j++)
                {
                    lFurieResult[i * imgW + j] = LineFurie[j];
                }
            }
            return lFurieResult;
        }

        public double[] mPorog(double pA, double[] tempArr)
        {
            for (int i = 0; i < tempArr.Length; i++)
            {
                if (tempArr[i] < pA)
                {
                    tempArr[i] = 0;
                }
                
            }
            return tempArr;
        }
        public double[] mSimpleBin(double pA, double[] tempArr)
        {
            for (int i = 0; i < tempArr.Length; i++)
            {
                if (tempArr[i] < pA)
                {
                    tempArr[i] = 0;
                }
                else {
                    tempArr[i] = 255;
                }

            }
            return tempArr;
        }
        public void mSetKonturC(double porog1, double pA, double[] tempval)
        {
            double fgr = 0.04;
            double m = 16;

            double porog2 = pA;
            double[] MinusFon = mPorog(porog1, tempval);
            DinamMin = 0;
            double[] lineLpfVal = lineLPF(fgr, m, MinusFon);
            lineLpfVal = mPorog(pA, lineLpfVal);

            mFunc = (x =>
            {
                double tmp = lineLpfVal[x];
                if (DinamMin > tmp)
                {
                    DinamMin = tmp;
                }
                if (DinamMax < tmp)
                {
                    DinamMax = tmp;
                }
                return tmp;
            });
        }
        public void mSetKonturA(double porog1, double pA, double[] tempval)
        {
            double fgr = 0.05;
            double m = 16;

            double porog2 = pA;
            double[] MinusFon = mPorog(porog1, tempval);
            DinamMin = 0;
            double[] lineLpfVal = lineLPF(fgr, m, MinusFon);
            for (int i = 0; i < lineLpfVal.Length; i++)
            {
                lineLpfVal[i] -= MinusFon[i];
            }
            lineLpfVal = mPorog(pA, lineLpfVal);

            mFunc = (x =>
            {
                double tmp = lineLpfVal[x];
                if (DinamMin > tmp)
                {
                    DinamMin = tmp;
                }
                if (DinamMax < tmp)
                {
                    DinamMax = tmp;
                }
                return tmp;
            });
        }
        public double[] lineLPF(double Fgr, double m, double[] tempArr)
        {
            double[] h = Lpf(Fgr, (int)m, 1);
            double[] y = new double[tempArr.Length];
            for (int i = 0; i < ImageH; i++)
            {
                double[] x = tempArr.Skip(i * ImageW).Take(ImageW).ToArray<double>();
                for (int j = 0; j < ImageW; j++)
                {
                    y[i * ImageW + j] = ConvolutionFunction(h, x)(j + +(int)m);
                }
            }
            return y;
        }
        public double[] lineHPF(double Fgr, double m, double[] tempArr)
        {
            double[] h = Lpf(Fgr, (int)m, 1);
            double[] y = new double[tempArr.Length];
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
            for (int i = 0; i < ImageH; i++)
            {
                double[] x = tempArr.Skip(i * ImageW).Take(ImageW).ToArray<double>();
                for (int j = 0; j < ImageW; j++)
                {
                    y[i * ImageW + j] = ConvolutionFunction(h, x)(j + (int)m);
                }
            }
            return y;
        }

        public double[] lineBSF(double F1, double F2, double m, double[] tempArr)
        {
            double[] h1 = Lpf(F1, (int)m, 1);
            double[] h2 = Lpf(F2, (int)m, 1);
            double[] h = new double[2 * (int)m + 1];
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

            double[] y = new double[tempArr.Length];
            for (int i = 0; i < ImageH; i++)
            {
                double[] x = tempArr.Skip(i * ImageW).Take(ImageW).ToArray<double>();
                for (int j = 0; j < ImageW; j++)
                {
                    y[i * ImageW + j] = ConvolutionFunction(h, x)((int)m + j);
                }
            }
            return y;
        }

        public void mSetRndNoize(double pA, double[] tempArr)
        {
            Random r = new Random();

            mFunc = x => { if (r.NextDouble() > pA) {
                    return tempArr[x];
                }
                else {
                    double tmp = tempArr[x] + (r.NextDouble() * 60) - 30;
                    if (DinamMin > tmp)
                    {
                        DinamMin = tmp;
                    }
                    if (DinamMax < tmp)
                    {
                        DinamMax = tmp;
                    }
                    return tmp;
                } }
            ;
        }
        public void mSetPulseNoize(double pA, double[] tempArr)
        {
            Random r = new Random();

            mFunc = x => {
                if (r.NextDouble() > pA)
                {
                    return tempArr[x];
                }
                else
                {
                    double tmp = r.NextDouble() > 0.5 ? DinamMin : DinamMax;
                    return tmp;
                }
            }
            ;
        }

        public void mSetLineBsf(double pA, double pB, double m, double[] tempArr)
        {
            double[] result = lineBSF(pA, pB, m, tempArr);
            mFunc = t =>
             {
                 double tmp = result[t];
                 if (DinamMin > tmp)
                 {
                     DinamMin = tmp;
                 }
                 if (DinamMax < tmp)
                 {
                     DinamMax = tmp;
                 }
                 return tmp;
             };
        }
        public void mSetLineLpf(double pA, double m, double[] tempArr)
        {
            double[] result = lineLPF(pA, m, tempArr);
            mFunc = t =>
            {
                double tmp = result[t];
                if (DinamMin > tmp)
                {
                    DinamMin = tmp;
                }
                if (DinamMax < tmp)
                {
                    DinamMax = tmp;
                }
                return tmp;
            };
        }
        public void mSetMinusHPF(double pA, double m, double[] tempArr)
        {
            double[] result = lineHPF(pA, m, tempArr);
            mFunc = t =>
            {
                double tmp = tempArr[t] - result[t];
                if (DinamMin > tmp)
                {
                    DinamMin = tmp;
                }
                if (DinamMax < tmp)
                {
                    DinamMax = tmp;
                }
                return tmp;
            };
        }
        public static ComplexNum[] obrLineFurie(ComplexNum[] tempArr, int imgW, int imgH, int pCount)
        {

            FourierTransfom fs = new FourierTransfom();
            ComplexNum[] lFurieResult = new ComplexNum[pCount];
            for (int i = 0; i < imgH; i++)
            {
                ComplexNum[] LineFurie = fs.mObrTransform(tempArr.Skip(i * imgW).Take(imgW).ToArray<ComplexNum>());
                for (int j = 0; j < imgW; j++)
                {
                    lFurieResult[i * imgW + j] = LineFurie[j];
                }
            }
            return lFurieResult;
        }
        public void pSetLineFurie(double[] tempArr)
        {
            int N = tempArr.Length;



            mArguments = new double[N];
            mValues = new double[N];

            for (int i = 0; i < mCount; i++)
            {
                mArguments[i] = i;
            }
            mLeftBorder = 0;
            mRightBorder = N - 1;

            FourierTransfom fs = new FourierTransfom();
            ComplexNum[] lFurieResult = new ComplexNum[mCount];
            for (int i = 0; i < ImageH; i++)
            {
                ComplexNum[] LineFurie = fs.mTransform(DoubleArrToCompArr(tempArr).Skip(i * ImageW).Take(ImageW).ToArray<ComplexNum>());
                for (int j = 0; j < ImageW; j++)
                {
                    lFurieResult[i * ImageW + j] = LineFurie[j];
                }
            }
            Func<int, double> temp = (k =>
            {
                return lFurieResult[k].RePlusIm;
            });
            mFunc = temp;

        }
        public void pSetLineObrFurie(ComplexNum[] tempArr)
        {
            int N = tempArr.Length;



            mArguments = new double[N];
            mValues = new double[N];

            for (int i = 0; i < mCount; i++)
            {
                mArguments[i] = i;
            }
            mLeftBorder = 0;
            mRightBorder = N - 1;

            FourierTransfom fs = new FourierTransfom();
            ComplexNum[] lFurieResult = new ComplexNum[mCount];
            for (int i = 0; i < ImageH; i++)
            {
                ComplexNum[] LineFurie = fs.mObrTransform(tempArr.Skip(i * ImageW).Take(ImageW).ToArray<ComplexNum>());
                for (int j = 0; j < ImageW; j++)
                {
                    lFurieResult[i * ImageW + j] = LineFurie[j];
                }
            }
            Func<int, double> temp = (k =>
            {
                return lFurieResult[k].RePlusIm;
            });
            mFunc = temp;

        }



        public void resizeNearNeig(double k1, double k2, double[] oldImage, int oldW, int oldH)
        {

            ImageW = (int)(oldW * k1);
            ImageH = (int)(oldH * k2);
            mCount = ImageW * ImageH;
            mValues = new double[ImageW * ImageH];
            double[] tempArr = new double[ImageW * ImageH];
            for (int i = 0; i < ImageW; i++)
            {
                for (int j = 0; j < ImageH; j++)
                {
                    int line_koor = ((int)(j / k2) * oldW);
                    int x_koor = (int)(i / k1);
                    tempArr[j * ImageW + i] = oldImage[line_koor + x_koor];
                }
            }

            Func<int, double> temp = (k =>
            {
                return tempArr[k];
            });
            mFunc = temp;
        }

        public void resizeBiLin(double k1, double k2, double[] oldImage, int oldW, int oldH)
        {

            ImageW = (int)(oldW * k1);
            ImageH = (int)(oldH * k2);
            mCount = ImageW * ImageH;
            mValues = new double[ImageW * ImageH];
            double[] tempArr = new double[ImageW * ImageH];
            for (int i = 0; i < ImageW; i++)
            {
                for (int j = 0; j < ImageH; j++)
                {
                    int line_koor_o = ((int)(j / k2) * oldW);
                    int x_koor_o = (int)(i / k1);
                    int line_koor_new = j * ImageW; int left_top = line_koor_o + x_koor_o;
                    int left_bot = ((line_koor_o * k1 * k2 == line_koor_new) ? line_koor_o : Math.Min((line_koor_o + 1), oldW * (oldH - 2))) + x_koor_o;
                    int right_top = Math.Min((line_koor_o + 1), oldW * (oldH - 2)) + Math.Min((x_koor_o + 1), oldW - 1);
                    int right_bot = Math.Min((line_koor_o + 1), oldW * (oldH - 2)) + (x_koor_o * k1 == i ? x_koor_o : Math.Min((x_koor_o + 1), oldW - 2));
                    tempArr[j * ImageW + i] = ((oldImage[left_top] + oldImage[right_top]) / 2 + (oldImage[left_bot] + oldImage[right_bot]) / 2) / 2;
                }
            }

            Func<int, double> temp = (k =>
            {
                return tempArr[k];
            });
            mFunc = temp;
        }



        public void mSetNegativ()
        {
            double oldMax = DinamMax;
            double oldMin = DinamMin;
            DinamMax = 0;
            DinamMin = ((1 << 16) - 1);
            mFunc = (x =>
            {
                double val = oldMax - 1 - mValues[x];
                if (val > DinamMax) {
                    DinamMax = val;
                }
                if (val < DinamMin)
                {
                    DinamMin = val;
                }
                return val;
            });
        }
        public double[] mGetNegativ(double[] arr, double dMax, double dMin)
        {


            double[] res = new double[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                res[i] = dMax - arr[i];
            }
            return res;
        }
        public void mSetGamma(double pA, double gamma)
        {
            double oldMax = DinamMax;
            double oldMin = DinamMin;
            DinamMax = 0;
            DinamMin = ((1 << 16) - 1);
            mFunc = (x =>
            {
                double val = pA * Math.Pow(mValues[x], gamma);
                if (val > DinamMax)
                {
                    DinamMax = val;
                }
                if (val < DinamMin)
                {
                    DinamMin = val;
                }
                return val;
            });
        }

        public void mSetLogTrans(double pA)
        {
            double oldMax = DinamMax;
            double oldMin = DinamMin;
            DinamMax = 0;
            DinamMin = ((1 << 16) - 1);

            mFunc = (x =>
            {
                double val = pA * Math.Log(1 + mValues[x]);
                if (val > DinamMax)
                {
                    DinamMax = val;
                }
                if (val < DinamMin)
                {
                    DinamMin = val;
                }
                return val;
            });
        }


        public ImageData()
        {

        }
        public ImageData(ImageData dt)
        {
            ImageW = dt.ImageW;
            ImageH = dt.ImageH;
            DinamMin = dt.DinamMin;
            DinamMax = dt.DinamMax;
            format = dt.format;

        }

        public void mHistEquilization(double[] data, int start, int stop)
        {
            double[] hist = Hist(data, start, stop);
            double[] eq = Equalization(hist, stop - start + 1);
            DinamMin = (1 << 16 - 1);
            DinamMax = 0;
            mFunc = (x =>
            {
                double val = eq[(int)data[x]];
                if (val > DinamMax)
                {
                    DinamMax = val;
                }
                if (val < DinamMin)
                {
                    DinamMin = val;
                }
                return (int)val;
            });

        }
        public static double[] Reversed(double[] y, int levels)
        {

            // double[] ans = Equalization(y, levels);
            double[] res = new double[y.Length];
            for (int i = 0; i < y.Length; i++)
            {
                res[i] = Math.Pow((double)i / 255, 2);
            }
            return res;
        }

        public static ComplexNum[] DoubleArrToCompArr(double[] tempArr)
        {
            ComplexNum[] lComplexResult = new ComplexNum[tempArr.Length];
            for (int i = 0; i < tempArr.Length; i++) {
                lComplexResult[i] = new ComplexNum(tempArr[i]);
            }
            return lComplexResult;

        }

        public void mDeleteBlur(double[] tempArr, int imgW, int imgH)
        {
            string hName = "D:\\C#\\recover\\kernL64_f4.dat";
            int lHLen = 64;
            double[] OrigH = readHex(hName, lHLen);
            double[] h = new double[ImageW];
            for (int i = 0; i < lHLen; i++)
            {
                h[i] = OrigH[i];
            }


            ComplexNum[] FurieH = lineFurie(DoubleArrToCompArr(h), h.Length, 1, h.Length);
            ComplexNum[] FurieG = lineFurie(DoubleArrToCompArr(tempArr), imgW, imgH, mCount);

            ComplexNum[] FurieF = new ComplexNum[mCount];
            for (int i = 0; i < ImageH; i++)
            {
                for (int j = 0; j < ImageW; j++)
                {
                    FurieF[ImageW * i + j] = FurieG[ImageW * i + j] / FurieH[j];

                }

            }

            ComplexNum[] origF = obrLineFurie(FurieF, imgW, imgH, mCount);
            DinamMax = 0;
            DinamMin = 1 << 16;
            mFunc = (x =>
            {
                double temp = origF[x].abs;
                if (temp > DinamMax)
                {
                    DinamMax = temp;
                }
                if (temp < DinamMin)
                {
                    DinamMin = temp;
                }
                return temp;
            });



        }
        public void mDeleteBlurNoize(double[] tempArr, int imgW, int imgH, double a = 0.01)
        {
            string hName = "D:\\C#\\recover\\kernL64_f4.dat";
            int lHLen = 64;
            double[] OrigH = readHex(hName, lHLen);
            double[] h = new double[ImageW];
            for (int i = 0; i < lHLen; i++)
            {
                h[i] = OrigH[i];
            }


            ComplexNum[] FurieH = lineFurie(DoubleArrToCompArr(h), h.Length, 1, h.Length);
            ComplexNum[] FurieG = lineFurie(DoubleArrToCompArr(tempArr), imgW, imgH, mCount);

            ComplexNum[] FurieF = new ComplexNum[mCount];
            for (int i = 0; i < ImageH; i++)
            {
                for (int j = 0; j < ImageW; j++)
                {
                    ComplexNum Hi = FurieH[j];
                    FurieF[ImageW * i + j] = (FurieG[ImageW * i + j] * Hi.Sopr) / new ComplexNum((Hi.abs * Hi.abs) + a * a);

                }

            }

            ComplexNum[] origF = obrLineFurie(FurieF, imgW, imgH, mCount);
            DinamMax = 0;
            DinamMin = 1 << 16;
            mFunc = (x =>
            {
                double temp = origF[x].RePlusIm;
                if (temp > DinamMax)
                {
                    DinamMax = temp;
                }
                if (temp < DinamMin)
                {
                    DinamMin = temp;
                }
                return temp;
            });



        }
        public static int EnsureValueIsPositive(int val)
        {
            if (val < 0)
            {
                return 0;
            }
            return val;
        }
        public static double[][] ApplyMask(double[][] f, double[][] mask)
        {
            double[][] result = new double[f.Length][];
            for (int i = 0; i < f.Length; i++)
            {
                result[i] = new double[f[i].Length];
                for (int j = 0; j < f[i].Length; j++)
                {
                    int maxMi = (int)mask.Length / 2;
                    int maxMj = (int)mask[0].Length / 2;

                    //New fast version. values appeared from the commented code bellow ( aguments of skip and take when calculating submatrixes
                    int startiF = i - maxMi;
                    int endiF = startiF + (i >= maxMi ? mask.Length : i + maxMi + 1);
                    int startjF = j - maxMj;
                    int endjF = startjF + (j >= maxMj ? mask[0].Length : j + maxMj + 1);

                    int startiM = i < maxMi ? maxMi - i : 0;
                    int endiM = startiM + i + maxMi >= f.Length ? f.Length - i + 1 : mask.Length;
                    int startjM = j < maxMj ? maxMj - j : 0;
                    int endjM = startjM + j + maxMj >= f[i].Length ? f[i].Length - j + 1 : mask[0].Length;
                    startiF = EnsureValueIsPositive(startiF);
                    startjF = EnsureValueIsPositive(startjF);
                    startjM = EnsureValueIsPositive(startjM);
                    startiM = EnsureValueIsPositive(startiM);
                    //!!!!!!!!!!!!!!!!!!! Warning do not remove!!!!!!!!!!!!!!!!!!!!!!!
                    //!!!! Previous versioin of code : for demonstation of variable values above!!!!!!
                    /* double[][] range = f.Skip(i - maxMi)
                    * .Take(i >= maxMi ? mask.Length : i + maxMi + 1)
                    * .Select(x => x.Skip(j - maxMj)
                    * .Take(j >= maxMj ? mask[0].Length : j + maxMj + 1)
                    * .ToArray())
                    * .ToArray();
                    *
                    * double[][] maskRange = mask.Skip(i < maxMi ? maxMi - i : 0)
                    * .Take(i + maxMi >= f.Length ? f.Length - i + 1 : mask.Length)
                    * .Select(x => x.Skip(j < maxMj ? maxMj - j : 0)
                    * .Take(j + maxMj >= f[i].Length ? f[i].Length - j + 1 : mask[0].Length)
                    * .ToArray())
                    * .ToArray();*
                    * for (int mi = 0; mi < maskRange.Length; mi++)
                    * {
                    * for (int mj = 0; mj < maskRange[mi].Length; mj++)
                    * {
                    * sum += range[mi][mj] * maskRange[mi][mj];
                    * }
                    * }
                    */
                    //!!!!!!!!!!!!!!!!!!! end of demo code!!!!!!!!!!!!!!!!!!!!!!!

                    double sum = 0;

                    int ind1 = 0;
                    int ind2 = 0;

                    for (int mi = startiM; mi < endiM; mi++)
                    {
                        for (int mj = startjM; mj < endjM; mj++)
                        {
                            sum += f[startiF + ind1][startjF + ind2] * mask[mi][mj];
                            ind2++;
                        }
                        ind2 = 0;
                        ind1++;
                    }
                    result[i][j] = sum;
                }
            }
            return result;
        }

        public static double[][] Gradient(double[][] f)
        {

            double[][] horMask = new double[3][] { new double[3] { -1, -2, -1 }, new double[3] { 0, 0, 0 }, new double[3] { 1, 2, 1 } };
            double[][] vertMask = new double[3][] { new double[3] { -1, 0, 1 }, new double[3] { -2, 0, 2 }, new double[3] { -1, 0, 1 } };
            double[][] diagMask = new double[3][] { new double[3] { 0, 1, 1 }, new double[3] { -1, 0, 1 }, new double[3] { -1, -1, 0 } };
            double[][] diagMaskReversed = new double[3][] { new double[3] { 1, 1, 0 }, new double[3] { 1, 0, -1 }, new double[3] { 0, -1, -1 } };

            double[][] Horizontal = ApplyMask(f, horMask);
            double[][] Vertical = ApplyMask(f, vertMask);
            double[][] Diagonal = ApplyMask(f, diagMask);
            double[][] DiagonalRev = ApplyMask(f, diagMaskReversed);

            double tmp;
            for (int i = 0; i < f.Length; i++)
            {
                for (int j = 0; j < f[i].Length; j++)
                {
                    tmp = Horizontal[i][j] + Vertical[i][j] + Diagonal[i][j] + DiagonalRev[i][j];
                    if (tmp < 0)
                    {
                        tmp = 0;
                    }

                    f[i][j] = tmp;

                }

            }
            return f;

        }

        public double[] mGetRazm (double[] tempArr, int ImgH, int ImgW, double pA)
        {
            double[][] kernel = new double[3][];
            for (int i = 0; i < kernel.Length; i++)
            {
                kernel[i] = (new double[3]).Select(x => 1.0).ToArray();
            }
            double[] eros = ApplyEros(tempArr, ImgH, ImgW, kernel, 3, 3, pA, x => x);
            double[] dilat = ApplyDilat(eros, ImgH, ImgW, kernel, 3, 3, pA, x => x);

            return dilat;
        }

        Stack<Tuple<int, int>> stoneToGo;
        List<Tuple<int, int>> finalstone;
        public void build_stone(int cur_x, int cur_y, double porog,double[] map)
        {
            map[cur_y * ImageW + cur_x] = 90;
            finalstone.Add(new Tuple<int, int>(cur_x, cur_y));
            if  (cur_y<(ImageH-1) && (map[(cur_y+1)*ImageW + cur_x]> porog))
            {
                stoneToGo.Push(new Tuple<int, int>(cur_x, cur_y+1));
            }
            if (cur_y>1 &&(map[(cur_y - 1) * ImageW + cur_x] > porog))
            {
                stoneToGo.Push(new Tuple<int, int>(cur_x, cur_y - 1));
            }
            if ( cur_x<(ImageW -1) &&( map[(cur_y ) * ImageW + cur_x+1] > porog))
            {
                stoneToGo.Push(new Tuple<int, int>(cur_x+1, cur_y));
            }
            if (cur_x >  1 && (map[(cur_y) * ImageW + cur_x - 1] > porog))
            {
                stoneToGo.Push(new Tuple<int, int>(cur_x - 1, cur_y));
            }
        }
        public static int stone_count = 0;
        public double[] findStones(double[] tempArr, int stoneSize,double porog)
        {
         
            for( int  x = 0; x< ImageW; x++)
            {
                for (int y = 0; y < ImageH; y++)
                {
                    int ind = y * ImageW + x;
                if (tempArr[ind] > porog) {
                        stoneToGo = new Stack<Tuple<int, int>>();
                        finalstone = new List<Tuple<int, int>>();
                        stoneToGo.Push(new Tuple<int, int>(x, y));
                        while (stoneToGo.Count > 0)
                        {
                            Tuple<int,int> t = stoneToGo.Pop();
                            build_stone(t.Item1,t.Item2,porog, tempArr);
                        }
                       
                        int max_x = finalstone.Max(a => a.Item1);
                        int min_x = finalstone.Min(a => a.Item1);
                        int min_y = finalstone.Min(a => a.Item2);
                        int max_y = finalstone.Max(a => a.Item2);
                        if (Math.Max( max_x-min_x,max_y-min_y) == stoneSize)
                        {

                        
                             stone_count++;
                            foreach (var pix in finalstone)
                            {
                                tempArr[pix.Item2 * ImageW + pix.Item1] = -3;
                            }
                        }
                    }
                }
            }
            return tempArr;

        }
        
        public double[] exprBord(double[] tempArr, int ImgH, int ImgW,double pA)
        {
            double[] rescArr = rescImg(tempArr, 0, 255);
            double[] negativ = mGetNegativ(rescArr, DinamMax, DinamMin);
            double []  resneg = rescImg(negativ, 0, 255);
            double[] bordOut = mGetLapl(negativ, ImgW, ImgH);
           
            double[] gradN = mGetGrad(resneg, ImgW, ImgH).Select(x=> x/2).ToArray();
            double[] res = mAplyPlus(tempArr, gradN).ToArray();
            //res = ApplyLocalFunc(tempArr, ImageH, ImageW, 3, 3, x => x.SelectMany(t => t).Average(), x => x);
          
             res = mAplyMinus(res, bordOut).Select(x => x * 3).ToArray();
            
              res = mSimpleBin(DinamPorog(res, res.Average(), 0, 1, 10), res) ;
            // negativ = mGetNegativ(res, negativ.Min(), negativ.Max());


            // double[] grad = mGetGrad(tempArr, ImgW, ImgH);



            // 

            //double[] lapl = mGetLapl(res, ImgW, ImgH);
            //double lMax = lapl.Max();
            //double lMin = lapl.Min();
            //res = mAplyPlus(res, lapl.Select(x => x * 255 / (lMax - lMin)).ToArray());
            // double[] bord = mGetLapl(tempArr, ImgW, ImgH);
            //bord = mGetNegativ(bord, bord.Max(), bord.Min());
            //bord = mObrPorog(pA, bord);
            //  double 
            // double[] exprBord=mCloneZeros(tempArr, bord);


            return res;
        }


        public double[] rescImg ( double[] tempArr, double newMin, double newMax)
        {
            double oldMin = tempArr.Min();
            double oldMax = tempArr.Max();
            double[] res = new double[tempArr.Length];
            if (oldMin==oldMax) {
                oldMin = 0;
                oldMax = 1;
            }
            for( int i = 0; i < tempArr.Length; i++)
            {
                res[i] = (int)(newMin + (tempArr[i] - oldMin) / (oldMax - oldMin) * newMax);
            }
            return res;
        }
      public double DinamPorog (IEnumerable<double> tempArr,double curP, double lastP, double delta, int maxN)
        {
            if (Math.Abs(curP-lastP) < delta||maxN ==0)
            {
                return curP;
            }
            else
            {
                var leftP = tempArr.Where(x => x <= curP).Average();
                var rightP = tempArr.Where(x => x > curP).Average();
                
                return DinamPorog(tempArr, 0.5 * (rightP + leftP), curP, delta, maxN - 1);
            }
        } 
        public double[] dinamBin(double[] tempArr, int winCount, int imgW, int imgH)
        {
            int w = imgW / winCount;
            int h = imgH / winCount;
            double[] porog = new double[winCount * winCount];
            
            for (int i = 0; i < winCount*winCount; i++)
            {
                var piece = tempArr.Where((x,k)=> {
                    return (k % imgW >= (i * w) % imgW) && (k % imgW <( (i * w ) % imgW) +64) && (int)(k / imgW) < h * ((i  / winCount)+1) && (int)(k / imgW) >= h * (i / winCount);
                });
                try
                {
                    porog[i] = DinamPorog(piece, piece.Average(), 0, 1, 10);
                }
                catch (Exception ex)
                {
                    int d = i;
                    d++;
                }
            }
            double[] res = new double[tempArr.Length];
            for( int p =0; p<tempArr.Length; p++)
            {
                if (tempArr[p]> porog[p /(h* w)])
                {
                    res[p] = 255;
                }
                else
                {
                    res[p] = -1;
                }
            }
            return res;
        }
       public double[] water(double[] tempArr, int ImgH, int ImgW,  int h, int w, double porog)
            {

                double[] res = new double[tempArr.Length];

                int vertM = h / 2;
                int horM = w / 2;
            for(int i= 0; i < ImgH; i++)
            {
                for (int j = 0; j < ImgW; j++)
                    {
                        if (i > vertM - 1 && j > horM - 1 && i < ImgH - vertM && j < ImgW - horM)
                        {
                            if (tempArr[i * ImgW + j] < porog)
                            {


                                bool Intersected = false;
                                for (int m = 0; m < h; m++)
                                {
                                    if (Intersected == false)
                                    {
                                        for (int k = 0; k < w; k++)
                                        {
                                            if (tempArr[(i + m - vertM) * ImgW + (j + k - horM)] >= -1)
                                            {
                                                Intersected = true;
                                                break;

                                            }
                                        }
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }

                                if (Intersected)
                                {
                                    res[i * ImgW + j] = -1;
                                }
                                else
                                {
                                    res[i * ImgW + j] = tempArr[i * ImgW + j];
                                }
                            }
                            else
                            {
                                res[i * ImgW + j] = tempArr[i * ImgW + j];
                            }
                        }
                        else
                        {
                            res[i * ImgW + j] = -1;
                        }

                    }
                }
                return res;
            }




            public void mPorogMinus(double[] arr1, double[] arr2,double porog)
        {
            for (int i = 0; i < arr1.Length; i++)
            { if (arr1[i] - arr2[i] > DinamMin + porog)
                {
                    arr1[i] -= arr2[i];
                }
            }
          
        }
      
        public double[] mObrPorog(double pA, double[] tempArr)
        {
            double[] res = new double[tempArr.Length];
            for (int i = 0; i < tempArr.Length; i++)
            {
                if (tempArr[i] >= pA)
                {
                    res[i] = DinamMax;
                }
                else
                {
                    res[i] = -1;
                }

            }
            return res;
        }
        public double[] mAplyPlus(double[] arr1, double[] arr2){
            double[] res = new double[arr1.Length];
            for(int i =0; i<arr1.Length; i++){
                double locSum = arr1[i] + arr2[i];
                if (locSum > 255)
                {
                    res[i] = 255;
                }
                else{
                    res[i] = locSum;
                }
               
            }
            return res;
          }
        public double[] mCloneZeros(double[] arr1, double[] arr2)
        {
            for (int i = 0; i < arr1.Length; i++)
            {
                arr1[i] *= arr2[i];
                
            }
            return arr1;
        }
        public double[] mAplyMinus(double[] arr1, double[] arr2)
        {
            for (int i = 0; i < arr1.Length; i++)
            { double temp = arr1[i] - arr2[i];
                if (temp < DinamMin)
                {
                    arr1[i] = DinamMin;
                }
                else
                {
                    arr1[i] = temp;

                }
               
            }
            return arr1;
        }
        public double[] ApplyLocalFunc (double [] tempArr,int ImgH, int ImgW, int h, int w, Func<IEnumerable<double>[],double> locFunc, Func<double, double> defF )
        {
            
            double[] res = new double[tempArr.Length];
            
            int vertM = h / 2;
            int horM = w / 2;
            Parallel.For(0, ImgH, i =>
            {
                IEnumerable<double>[] ImgPiece = null;
                for (int j = 0; j < ImgW; j++)
                {

                    if (i > vertM - 1 && j > horM - 1 && i < ImgH - vertM && j < ImgW - horM)
                    {
                        ImgPiece = new IEnumerable<double>[h];
                        for (int m = 0; m < h; m++)
                        {
                            ImgPiece[m] = tempArr.Skip((i - vertM + m) * ImgW + (j - horM)).Take(w);
                        }
                        res[i * ImgW + j] = locFunc(ImgPiece);
                    }
                    else
                    {
                        res[i * ImgW + j] = defF(tempArr[i * ImgW + j]);
                    }

                }
            });
            
            return res;
        }
        public double[] ApplyDilat(double[] tempArr, int ImgH, int ImgW,double[][] kernel, int h, int w,double porog, Func<double, double> defF)
        {

            double[] res = new double[tempArr.Length];

            int vertM = h / 2;
            int horM = w / 2;
            Parallel.For(0, ImgH, i =>
            {
                for (int j = 0; j < ImgW; j++)
                { 
                    if (i > vertM - 1 && j > horM - 1 && i < ImgH - vertM && j < ImgW - horM)
                    {
                        bool Intersected = false;
                        for (int m = 0; m < h; m++)
                        { 
                            if (Intersected == false) { 
                            for (int k = 0; k < w; k++)
                            {
                                if (kernel[m][k] * tempArr[(i + m - vertM) *ImgW+ (j+k-horM)] >= porog)
                                {
                                        Intersected = true;
                                        break;
                                   
                                }
                            }
                            }
                            else
                            {
                                break;
                            }
                        }
                        if (Intersected)
                        {
                            res[i * ImgW + j] = DinamMax;
                        }
                        else
                        {
                        res[i * ImgW + j] = defF(tempArr[i * ImgW + j]);
                        }
                    }
                    else
                    {
                        res[i * ImgW + j] = defF(tempArr[i * ImgW + j]);
                    }

                }
            });

            return res;
        }
        public double[] ApplyEros(double[] tempArr, int ImgH, int ImgW, double[][] kernel, int h, int w, double porog, Func<double, double> defF)
        {

            double[] res = new double[tempArr.Length];

            int vertM = h / 2;
            int horM = w / 2;
            Parallel.For(0, ImgH, i =>
            {
                for (int j = 0; j < ImgW; j++)
                {
                    if (i > vertM - 1 && j > horM - 1 && i < ImgH - vertM && j < ImgW - horM)
                    {
                        bool Intersected = true;
                        for (int m = 0; m < h; m++)
                        {
                            if (Intersected == true)
                            {
                                for (int k = 0; k < w; k++)
                                {
                                    if (kernel[m][k] * tempArr[(i + m - vertM) * ImgW + (j + k - horM)] <= porog)
                                    {
                                        Intersected = false;
                                        break;

                                    }
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                        if (Intersected==false)
                        {
                            res[i * ImgW + j] = DinamMin;
                        }
                        else
                        {
                            res[i * ImgW + j] = defF(tempArr[i * ImgW + j]);
                        }
                    }
                    else
                    {
                        res[i * ImgW + j] = defF(tempArr[i * ImgW + j]);
                    }

                }
            });

            return res;
        }
        //unused
        public double  Dilat ( double porog, double[][] kernel, IEnumerable<double>[] imgPiece)
        {
            for(int i=0; i < kernel.Length; i++)
            {
                var line= imgPiece[i];
                for (int j =0; j < kernel[0].Length; j++)
                {
                    if  (kernel[i][j]*line.ElementAt(j)>=porog)
                    {
                        return DinamMax;
                    }
                }
            }
            return DinamMin;
        }
        //unused
        public double Eros(double porog, double[][] kernel, IEnumerable<double>[] imgPiece)
        {
            for (int i = 0; i < kernel.Length; i++)
            {
                var line = imgPiece[i];
                for (int j = 0; j < kernel[0].Length; j++)
                {
                    if (kernel[i][j] * line.ElementAt(j) < porog)
                    {
                        return DinamMin;
                    }
                }
            }
            return DinamMax;
        }
        public void mSetCurTest(double pA,double pB, double[] tempArr)
        {
            double[] testRes=null;
            try
            {

                stone_count = 0;
                testRes = findStones(tempArr,(int)pB,100) ;
                MessageBox.Show(" " + stone_count);


                for(int i = 0; i < testRes.Length; i++)
                {
                    if (testRes[i] == -3)
                    {
                        testRes[i] = 255;
                    }
                }
             }
            catch (Exception ex)
            {
                int i = 1;
                i++;
            }
            mFunc = x => {
                double val = testRes[x];
                if (val>DinamMax) {
                    DinamMax = val;
                }
                if (val < DinamMin)
                {
                    DinamMin = val;
                }
                return val;
                }
            ;
        }
        public void mSetExprBord( double[] tempArr,double pA)
        {
            double[] testRes = null;
            try
            {


                testRes = exprBord(tempArr,ImageH,ImageW,pA); ;

            }
            catch (Exception ex)
            {
                int i = 1;
                i++;
            }
            mFunc = x => {
                double val = testRes[x];
                if (val > DinamMax)
                {
                    DinamMax = val;
                }
                if (val < DinamMin)
                {
                    DinamMin = val;
                }
                return val;
            }
            ;
        }


        public void mSetObrPor(double pC,  double[] tempArr)
        {
            double[] testRes = null;
            try
            {

                //   wat = mObrPorog(0, wat);
                testRes = mObrPorog(pC, tempArr);

            }
            catch (Exception ex)
            {
                int i = 1;
                i++;
            }
            mFunc = x => {
                double val = testRes[x];
                if (val > DinamMax)
                {
                    DinamMax = val;
                }
                if (val < DinamMin)
                {
                    DinamMin = val;
                }
                return val;
            }
            ;
        }
        public void mSetFood(double pA, double pB, double[] tempArr)
        {
            double[] testRes = null;
            try
            {

                testRes = water(tempArr, ImageH, ImageW, 3, 3, pA); 

            }
            catch (Exception ex)
            {
                int i = 1;
                i++;
            }
            mFunc = x => {
                double val = testRes[x];
                if (val > DinamMax)
                {
                    DinamMax = val;
                }
                if (val < DinamMin)
                {
                    DinamMin = val;
                }
                return val;
            }
            ;
        }
        public void mSetDialt(double pB,double[][] kernel, double[] tempArr)
        {
            try
            {
                // mValues = ApplyLocalFunc(tempArr, ImageH, ImageW, kernel.Length, kernel[0].Length, x=>Dilat(pB,kernel,x),x=>x);
                mValues = ApplyDilat(tempArr, ImageH, ImageW, kernel,  kernel.Length, kernel[0].Length,pB, x => x);
            }
            catch (Exception ex)
            {
                int i = 1;
                i++;
            }
            mFunc = x => mValues[x];
        }


        public void mKontErosDilat (double pB, double[][] kernel, double[] tempArr)
        {
            double[] dil= ApplyDilat(tempArr, ImageH, ImageW, kernel, kernel.Length, kernel[0].Length, pB, x => x);


             // dil = ApplyDilat(dil, ImageH, ImageW, kernel, kernel.Length, kernel[0].Length, pB, x => x);
             // dil  = ApplyEros(dil, ImageH, ImageW, kernel, kernel.Length, kernel[0].Length, pB, x => x);
             
            mFunc = x =>
            {
                double tmp =dil[x] - tempArr[x];
                if (tmp>DinamMax) {
                    DinamMax = tmp;
                }
                if (tmp<DinamMin)
                {
                    DinamMin = tmp;
                }
                if(tmp>10)
                {
                    return DinamMax;
                }
                else
                {
                    return DinamMin;
                }
               
            };
        }
        public void mSetEros(double pB, double[][] kernel, double[] tempArr)
        {
            try
            {
                //mValues = ApplyLocalFunc(tempArr, ImageH, ImageW, kernel.Length, kernel[0].Length, x => Eros(pB, kernel, x), x => x);
                mValues = ApplyEros(tempArr, ImageH, ImageW, kernel, kernel.Length, kernel[0].Length, pB, x => x);
            }
            catch (Exception ex)
            {
                int i = 1;
                i++;
            }
            mFunc = x => mValues[x];
        }
        public void mSetOsred(double pA,double[] tempArr)
        {
            try
            {
                mValues = ApplyLocalFunc(tempArr,ImageH,ImageW, (int)pA, (int)pA, x => x.SelectMany(t => t).Average(),x=>x);
            }
           catch (Exception ex)
            {
                int i = 1;
                i++;
            }
            mFunc = x => mValues[x];
        }

        public double MatrixMedian (IEnumerable<double>[] matrix)
        {
            double[] arr = matrix.SelectMany(t => t).ToArray();
            Array.Sort(arr);
            return arr[arr.Length / 2];
        }
        public void mSetMedian(double pA, double[] tempArr)
        {
            try
            {
                mValues = ApplyLocalFunc(tempArr, ImageH, ImageW, (int)pA, (int)pA, MatrixMedian,x=>x);
            }
            catch (Exception ex)
            {
                int i = 1;
                i++;
            }
            mFunc = x => mValues[x];
        }
        public void mLapl (double[] temp, int imgW, int imgH)
        {
            double[][] ReTemp= new double[imgH][];
            for (int i = 0; i < imgH; i++)
            {
                ReTemp[i] = temp.Skip(imgW * i).Take(imgW).ToArray();
            }
            double[][] Lapl = Laplassian(ReTemp);
            DinamMin = (1 << 16 - 1);
            DinamMax = 0;
            mFunc = (x =>
            {
               double tmp= Lapl[x / imgW][x % imgW];
                if (tmp > DinamMax)
                {
                    DinamMax = tmp;
                }
                if (tmp < DinamMin)
                {
                    DinamMin = tmp;
                }
                return tmp;
            });
        }
        public double[] mGetLapl(double[] temp, int imgW, int imgH)
        {
            double[][] ReTemp = new double[imgH][];
            for (int i = 0; i < imgH; i++)
            {
                ReTemp[i] = temp.Skip(imgW * i).Take(imgW).ToArray();
            }
            double[][] Lapl = Laplassian(ReTemp);
            double[] res = new double[temp.Length];
            for(int i =0; i < temp.Length; i++)
            {
                res[i] = Lapl[i / imgW][i % imgW];
            }
            return res;
        }
        public void mGrad(double[] temp, int imgW, int imgH)
        {
            double[][] ReTemp = new double[imgH][];
            for (int i = 0; i < imgH; i++)
            {
                ReTemp[i] = temp.Skip(imgW * i).Take(imgW).ToArray();
            }
            double[][] Lapl = Gradient(ReTemp);
            DinamMin = (1 << 16 - 1);
            DinamMax = 0;
            
            mFunc = (x =>
            {
                double tmp = Lapl[x / imgW][x % imgW];
                if (tmp > DinamMax)
                {
                    DinamMax = tmp;
                }
                if (tmp < DinamMin)
                {
                    DinamMin = tmp;
                }
                return tmp>1? 255:0.0;
            });
        }
        public double[] mGetGrad(double[] temp, int imgW, int imgH)
        {
            double[][] ReTemp = new double[imgH][];
            double[] res = new double[temp.Length];
            for (int i = 0; i < imgH; i++)
            {
                ReTemp[i] = new double[imgW];
                for(int j = 0; j< imgW; j++)
                {
                    ReTemp[i][j] = temp[imgW * i + j];
                }
            }
            double[][] Lapl = Gradient(ReTemp);
       
            for (int i = 0; i < temp.Length; i++)
            {
                res[i] = Lapl[i / imgW][i % imgW];
            }
            return res;
        }
        public static double[][] Laplassian(double[][] f)
        {

            double[][] horMask = new double[3][] { new double[3] { -1, -1, -1 }, new double[3] { -1, 8, -1 }, new double[3] { -1, -1, -1 } };

            double[][] Horizontal = ApplyMask(f, horMask);

            double tmp;
            for (int i = 0; i < f.Length; i++)
            {
                for (int j = 0; j < f[i].Length; j++)
                {
                    tmp = Horizontal[i][j];
                    if (tmp < 0)
                    {
                        tmp = 0;
                    }

                    f[i][j] = tmp;

                }

            }
            return f;

        }
        public void mHistReduction(double[]data, int start, int stop)
        {
            double[] hist = Hist(data, start,stop);
            double[] density = Density(hist);
            double[] reversed = Reversed(density, stop-start+1);
            DinamMin = (1 << 16 - 1);
            DinamMax = 0;
            mFunc = (x =>
            {
                for (int h = 0; h < reversed.Length; h++)
                {
                    if (density[(int)data[x]] < reversed[h])
                    {
                       
                        if (h > DinamMax)
                        {
                            DinamMax = h;
                        }
                        if (h < DinamMin)
                        {
                            DinamMin = h;
                        }
                        return h;
                    }
                }
                if (data[x] > DinamMax)
                {
                    DinamMax = data[x];
                }
                if (data[x] < DinamMin)
                {
                    DinamMin = data[x];
                }
                return data[x];
            });
           

        }
    }
}
