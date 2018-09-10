using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace obrabotka1
{
    public partial class StatForm : Form
    {
        public StatForm()
        {
            InitializeComponent();
        }




        public Chart chart;
        private DataPointCollection mRndData;
             
        Statistics statistics;


        public StatForm(Chart chart, string functionName, double pMin=-1, double pMax=1 )
        {
            InitializeComponent();
            this.chart = chart;
         
            Series series = chart.Series.FindByName(functionName);


            chartAutocor.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chartAutocor.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chartAutocor.ChartAreas[0].AxisX.Crossing = 0;
            chartAutocor.ChartAreas[0].AxisY.Crossing = 0;

            lbMean.Text = Statistics.ExpectedValue(series.Points).ToString();
            lbMeanSq.Text = Statistics.MeanSquare(series.Points).ToString();
            lbMeanSqEr.Text = Statistics.MeanSquareError(series.Points).ToString();
            lbVariance.Text = Statistics.Variance(series.Points).ToString();
            lbStandartDev.Text = Statistics.StandartDeviation(series.Points).ToString();
            lbMom3.Text = Statistics.CentralMoment(series.Points, 3).ToString();
            lbMom4.Text = Statistics.CentralMoment(series.Points, 4).ToString();
            mRndData = CreateRndData(functionName, pMin, pMax);
            DrawAutocorrelationChart(chartAutocor, functionName, series.Points.Count);
            DrawCrossCorrelationChart(chartCrosscor, functionName, series.Points.Count);

            lbSkewness.Text = Statistics.Skewness(series.Points).ToString();
            lbKurtosis.Text = Statistics.Kurtosis(series.Points).ToString();


            double[] y = Statistics.Density(series.Points, 30);
            DrawDensity(y, functionName);

            lbIsStatic.Text = Statistics.isStatic(series.Points).ToString();


        }

        public void DrawDensity(double[] y, string functionName)
        {
            chartDensity.Series.Clear();
            Series series = chartDensity.Series.Add(functionName);
            series.ChartType = SeriesChartType.Column;


            for (int i = 0; i < y.Length; i++)
            {
                series.Points.AddY(y[i]);

            }

        }


        public DataPointCollection CreateRndData(string functionName, double pMin, double pMax)
        {
            Series rndData = new Series("Rnd");
            double[] x = chart.Series.FindByName(functionName).Points.Select(item => item.XValue).ToArray<double>();
            double left = x.Min();
            double right = x.Max();
            double step = x[1] - x[0];
            int count = x.Length;
            for (int i = 0; i < count; i++)
            {
                x[i] = left + i * step;
            }

            Random r = new Random();
            rndData.ChartType = SeriesChartType.Spline;
            double[] y = new double[x.Length];
            for (int i = 0; i < x.Length; i++)
            {               
                    rndData.Points.AddXY(x[i], pMin + (pMax - pMin) * r.NextDouble());

            }

            return rndData.Points;
        }



        public void DrawAutocorrelationChart(Chart AutoChart, string functionName, int N)
        {
            int[] x = new int[N];
            for (int i = 0; i < N; i++)
            {
                x[i] = i;
            }
            DrawAutoCorrelation(x, AutoChart, chart.Series.FindByName(functionName).Points, functionName);


        }


        public void DrawCrossCorrelationChart(Chart CrossChart,string functionName, int N)
        {
            
            int[] x = new int[N - 1];
            for (int i = 0; i < N - 1; i++)
            {
                x[i] = i + 1;
            }
            DrawCrossCorrelation(x, CrossChart, chart.Series.FindByName(functionName).Points,
                                       mRndData, functionName);

        }

        private void DrawAutoCorrelation(int[] x, Chart chart, DataPointCollection arr, string functionName)
        {
            /*double a = Double.Parse(tbA3.Text);
            double b = Double.Parse(tbB3.Text);*/
            chart.Series.Clear();
            Series series = chart.Series.Add(functionName);
            series.ChartType = SeriesChartType.Spline;
            double[] y = new double[x.Length];


            for (int i = 0; i < x.Length; i++)
            {
                series.Points.AddXY(x[i], Statistics.Autocorrelation(arr, x[i]));
            }
        }

        private void DrawCrossCorrelation(int[] x, Chart chart, DataPointCollection arr1, DataPointCollection arr2, string functionName)
        {
            chart.Series.Clear();
            Series series = chart.Series.Add(functionName);
            series.ChartType = SeriesChartType.Spline;
            double[] y = new double[x.Length];
            for (int i = 0; i < x.Length; i++)
            {
                series.Points.AddXY(x[i], Statistics.Crosscorrelation(arr1, arr2, x[i]));
            }
        }
    }
}
