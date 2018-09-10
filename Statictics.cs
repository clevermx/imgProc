using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace obrabotka1
{
    public class Statistics
    {



        public static double ExpectedValue(DataPointCollection arr)
        {
            double sum = 0;
            foreach (var point in arr)
            {

                sum += point.YValues[0];

            }
            return sum / arr.Count;
        }

        public static double ExpectedValue(IEnumerable<DataPoint> arr)
        {
            double sum = 0;
            foreach (var point in arr)
            {

                sum += point.YValues[0];

            }
            return sum / arr.Count();
        }


        public static double ExpectedValue(double[] arr)
        {
            double sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {

                sum += arr[i];

            }
            return sum / arr.Length;
        }



        public static double MeanSquare(DataPointCollection arr)
        {
            double sum = 0;
            foreach (var point in arr)
            {

                sum += Math.Pow(point.YValues[0], 2);

            }
            return sum / arr.Count;
        }
        public static double MeanSquare(IEnumerable<DataPoint> arr)
        {
            double sum = 0;
            foreach (var point in arr)
            {

                sum += Math.Pow(point.YValues[0], 2);

            }
            return sum / arr.Count();
        }


        public static double MeanSquareError(DataPointCollection arr)
        {
            return Math.Sqrt(MeanSquare(arr));
        }

        public static double MeanSquareError(IEnumerable<DataPoint> arr)
        {
            return Math.Sqrt(MeanSquare(arr));
        }



        public static double Variance(DataPointCollection arr)
        {
            double Mx = ExpectedValue(arr);
            double sum = 0;
            foreach (var point in arr)
            {

                sum += Math.Pow((point.YValues[0] - Mx), 2);

            }
            return sum / arr.Count;
        }

        public static double Variance(IEnumerable<DataPoint> arr)
        {
            double Mx = ExpectedValue(arr);
            double sum = 0;
            foreach (var point in arr)
            {

                sum += Math.Pow((point.YValues[0] - Mx), 2);

            }
            return sum / arr.Count();
        }

        public static double Variance(double[] arr)
        {
            double Mx = ExpectedValue(arr);
            double sum = 0;
            foreach (var point in arr)
            {

                sum += Math.Pow((point - Mx), 2);

            }
            return sum / arr.Length;
        }


        public static double StandartDeviation(DataPointCollection arr)
        {
            return Math.Sqrt(Variance(arr));
        }
        public static double StandartDeviation(double[] arr)
        {
            return Math.Sqrt(Variance(arr));
        }

        public static double StandartDeviation(IEnumerable<DataPoint> arr)
        {
            return Math.Sqrt(Variance(arr));
        }
        public static double CentralMoment(DataPointCollection arr, int k)
        {
            double Mx = ExpectedValue(arr);

            double sum = 0;
            foreach (var point in arr)
            {

                sum += Math.Pow((point.YValues[0] - Mx), k);

            }
            return sum / arr.Count;
        }
        /// <summary>
        /// Коэффициент ассиметрии
        /// </summary>
        /// <param name="functionName"> Имя функции в объекте chart</param>
        /// <returns> Коэффициент ассиметрии</returns>
        public static double Skewness(DataPointCollection arr)
        {
            return CentralMoment(arr, 3) / (Math.Pow(StandartDeviation(arr), 3));

        }
        /// <summary>
        /// Коэффициент эксцесса
        /// </summary>
        /// <param name="functionName"> Имя функции в объекте chart</param>
        /// <returns> Коэффициент эксцесса</returns>
        public static double Kurtosis(DataPointCollection arr)
        {
            return CentralMoment(arr, 4) / (Math.Pow(StandartDeviation(arr), 4));
        }

        public static double[] Density(DataPointCollection arr, int M)
        {

            double lMin = arr.Min(x => x.YValues[0]);
            double lMax = arr.Max(x => x.YValues[0]);
            double divisor = (lMax - lMin) / M;
            double[] ans = new double[M];
            foreach (var point in arr)
            {
                try
                {
                    ans[(int)Math.Floor((point.YValues[0] - lMin) / divisor)] += 1;
                }
                catch (Exception)
                {
                    ans[ans.Length - 1] += 1;
                }
            }
            for (int i = 0; i < ans.Length; i++)
            {
                ans[i] /= arr.Count;
            }
            return ans;
        }

        public static double Crosscorrelation(DataPointCollection arr1, DataPointCollection arr2, int lag)
        {
            if (arr1.Count != arr2.Count)
            {
                throw new Exception("Lengths of function arrays are different");
            }
            double avg1 = ExpectedValue(arr1);
            double avg2 = ExpectedValue(arr2);
            double variance = Variance(arr1);
            double sum = 0;

            for (int i = 0; i < arr2.Count - lag; i++)
            {
                sum += (arr1[i].YValues[0] - avg1) * (arr2[i + lag].YValues[0] - avg2);
            }
            return sum / ((arr1.Count - lag) * variance);

        }
        public static double Crosscorrelation(double[] arr1, double[] arr2, int lag)
        {
            if (arr1.Length != arr2.Length)
            {
                throw new Exception("Lengths of function arrays are different");
            }
            double avg1 = ExpectedValue(arr1);
            double avg2 = ExpectedValue(arr2);
            double variance = Variance(arr1);
            double sum = 0;

            for (int i = 0; i < arr2.Length - lag; i++)
            {
                sum += (arr1[i]- avg1) * (arr2[i + lag] - avg2);
            }
            return sum / ((arr1.Length - lag) * variance);

        }
        public static double Autocorrelation(DataPointCollection arr, int lag)
        {

            return Crosscorrelation(arr, arr, lag);
        }
        public static Boolean isStatic(DataPointCollection arr)
        {


            int shag = arr.Count / 10;
            double[] means = new double[10];
            double[] meansquares = new double[10];
            double[] deviations = new double[10];
            for (int i = 0; i < 10; i++)
            {
                means[i] = ExpectedValue(arr.Skip(shag * i).Take(shag));
                meansquares[i] = MeanSquare(arr.Skip(shag * i).Take(shag));
                deviations[i] = StandartDeviation(arr.Skip(shag * i).Take(shag));
            }
            for (int i = 0; i < means.Length; i++)
            {
                for (int j = 0; j < means.Length; j++)
                {
                    if (means[i] / means[j] < 0.9)
                    {
                        return false;
                    }
                    if (meansquares[i] / meansquares[j] < 0.9)
                    {
                        return false;
                    }
                    if (deviations[i] / deviations[j] < 0.9)
                    {
                        return false;
                    }

                }
            }
            return true;
        }



















    }
}
