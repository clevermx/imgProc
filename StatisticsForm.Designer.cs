namespace Graphics
{
    partial class StatisticsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lbMean = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbMeanSquare = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbMeanSquareError = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lbVariance = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lbStandartDeviation = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lbCentralMoment3 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.lbCentralMoment4 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.lbSkewness = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.lbKurtosis = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.label20 = new System.Windows.Forms.Label();
            this.chartDensity = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel233 = new System.Windows.Forms.Panel();
            this.label1221 = new System.Windows.Forms.Label();
            this.panel13 = new System.Windows.Forms.Panel();
            this.label123 = new System.Windows.Forms.Label();
            this.panel14 = new System.Windows.Forms.Panel();
            this.lbIsStatic = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.chartAutoCorrelation = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartCrossCorelation = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDensity)).BeginInit();
            this.panel233.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartAutoCorrelation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCrossCorelation)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel14);
            this.panel1.Controls.Add(this.panel13);
            this.panel1.Controls.Add(this.panel233);
            this.panel1.Controls.Add(this.panel11);
            this.panel1.Controls.Add(this.panel10);
            this.panel1.Controls.Add(this.panel9);
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(638, 744);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lbMean);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(638, 19);
            this.panel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mean:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbMean
            // 
            this.lbMean.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbMean.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbMean.Location = new System.Drawing.Point(157, 0);
            this.lbMean.Name = "lbMean";
            this.lbMean.Size = new System.Drawing.Size(479, 17);
            this.lbMean.TabIndex = 1;
            this.lbMean.Text = "label2";
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lbMeanSquare);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 19);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(638, 19);
            this.panel3.TabIndex = 1;
            // 
            // lbMeanSquare
            // 
            this.lbMeanSquare.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbMeanSquare.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbMeanSquare.Location = new System.Drawing.Point(157, 0);
            this.lbMeanSquare.Name = "lbMeanSquare";
            this.lbMeanSquare.Size = new System.Drawing.Size(479, 17);
            this.lbMeanSquare.TabIndex = 1;
            this.lbMeanSquare.Text = "label3";
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "MeanSquare:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel4
            // 
            this.panel4.AutoSize = true;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.lbMeanSquareError);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 38);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(638, 19);
            this.panel4.TabIndex = 2;
            // 
            // lbMeanSquareError
            // 
            this.lbMeanSquareError.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbMeanSquareError.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbMeanSquareError.Location = new System.Drawing.Point(157, 0);
            this.lbMeanSquareError.Name = "lbMeanSquareError";
            this.lbMeanSquareError.Size = new System.Drawing.Size(479, 17);
            this.lbMeanSquareError.TabIndex = 1;
            this.lbMeanSquareError.Text = "label5";
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(157, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "MeanSquareError:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel5
            // 
            this.panel5.AutoSize = true;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.lbVariance);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 57);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(638, 19);
            this.panel5.TabIndex = 3;
            // 
            // lbVariance
            // 
            this.lbVariance.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbVariance.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbVariance.Location = new System.Drawing.Point(157, 0);
            this.lbVariance.Name = "lbVariance";
            this.lbVariance.Size = new System.Drawing.Size(479, 17);
            this.lbVariance.TabIndex = 1;
            this.lbVariance.Text = "label7";
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Left;
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(157, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "Variance:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel6
            // 
            this.panel6.AutoSize = true;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.lbStandartDeviation);
            this.panel6.Controls.Add(this.label10);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 76);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(638, 19);
            this.panel6.TabIndex = 4;
            // 
            // lbStandartDeviation
            // 
            this.lbStandartDeviation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbStandartDeviation.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbStandartDeviation.Location = new System.Drawing.Point(157, 0);
            this.lbStandartDeviation.Name = "lbStandartDeviation";
            this.lbStandartDeviation.Size = new System.Drawing.Size(479, 17);
            this.lbStandartDeviation.TabIndex = 1;
            this.lbStandartDeviation.Text = "label9";
            // 
            // label10
            // 
            this.label10.Dock = System.Windows.Forms.DockStyle.Left;
            this.label10.Location = new System.Drawing.Point(0, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(157, 17);
            this.label10.TabIndex = 0;
            this.label10.Text = "StandartDeviation:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel7
            // 
            this.panel7.AutoSize = true;
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.lbCentralMoment3);
            this.panel7.Controls.Add(this.label12);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 95);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(638, 19);
            this.panel7.TabIndex = 5;
            // 
            // lbCentralMoment3
            // 
            this.lbCentralMoment3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbCentralMoment3.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbCentralMoment3.Location = new System.Drawing.Point(157, 0);
            this.lbCentralMoment3.Name = "lbCentralMoment3";
            this.lbCentralMoment3.Size = new System.Drawing.Size(479, 17);
            this.lbCentralMoment3.TabIndex = 1;
            this.lbCentralMoment3.Text = "label11";
            this.lbCentralMoment3.Click += new System.EventHandler(this.lbCentralMoment_Click);
            // 
            // label12
            // 
            this.label12.Dock = System.Windows.Forms.DockStyle.Left;
            this.label12.Location = new System.Drawing.Point(0, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(157, 17);
            this.label12.TabIndex = 0;
            this.label12.Text = "CentralMoment 3:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel8
            // 
            this.panel8.AutoSize = true;
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.lbCentralMoment4);
            this.panel8.Controls.Add(this.label14);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 114);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(638, 19);
            this.panel8.TabIndex = 6;
            // 
            // lbCentralMoment4
            // 
            this.lbCentralMoment4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbCentralMoment4.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbCentralMoment4.Location = new System.Drawing.Point(157, 0);
            this.lbCentralMoment4.Name = "lbCentralMoment4";
            this.lbCentralMoment4.Size = new System.Drawing.Size(479, 17);
            this.lbCentralMoment4.TabIndex = 1;
            this.lbCentralMoment4.Text = "label13";
            // 
            // label14
            // 
            this.label14.Dock = System.Windows.Forms.DockStyle.Left;
            this.label14.Location = new System.Drawing.Point(0, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(157, 17);
            this.label14.TabIndex = 0;
            this.label14.Text = "CentralMoment 4:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel9
            // 
            this.panel9.AutoSize = true;
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.lbSkewness);
            this.panel9.Controls.Add(this.label16);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 133);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(638, 19);
            this.panel9.TabIndex = 7;
            // 
            // lbSkewness
            // 
            this.lbSkewness.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbSkewness.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbSkewness.Location = new System.Drawing.Point(157, 0);
            this.lbSkewness.Name = "lbSkewness";
            this.lbSkewness.Size = new System.Drawing.Size(479, 17);
            this.lbSkewness.TabIndex = 1;
            this.lbSkewness.Text = "label15";
            // 
            // label16
            // 
            this.label16.Dock = System.Windows.Forms.DockStyle.Left;
            this.label16.Location = new System.Drawing.Point(0, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(157, 17);
            this.label16.TabIndex = 0;
            this.label16.Text = "Skewness:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel10
            // 
            this.panel10.AutoSize = true;
            this.panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel10.Controls.Add(this.lbKurtosis);
            this.panel10.Controls.Add(this.label18);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(0, 152);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(638, 19);
            this.panel10.TabIndex = 8;
            // 
            // lbKurtosis
            // 
            this.lbKurtosis.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbKurtosis.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbKurtosis.Location = new System.Drawing.Point(157, 0);
            this.lbKurtosis.Name = "lbKurtosis";
            this.lbKurtosis.Size = new System.Drawing.Size(479, 17);
            this.lbKurtosis.TabIndex = 1;
            this.lbKurtosis.Text = "label17";
            // 
            // label18
            // 
            this.label18.Dock = System.Windows.Forms.DockStyle.Left;
            this.label18.Location = new System.Drawing.Point(0, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(157, 17);
            this.label18.TabIndex = 0;
            this.label18.Text = "Kurtosis";
            this.label18.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel11
            // 
            this.panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel11.Controls.Add(this.chartDensity);
            this.panel11.Controls.Add(this.label20);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(0, 171);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(638, 143);
            this.panel11.TabIndex = 9;
            // 
            // label20
            // 
            this.label20.Dock = System.Windows.Forms.DockStyle.Left;
            this.label20.Location = new System.Drawing.Point(0, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(157, 141);
            this.label20.TabIndex = 0;
            this.label20.Text = "Density:";
            this.label20.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // chartDensity
            // 
            chartArea3.Name = "ChartArea1";
            this.chartDensity.ChartAreas.Add(chartArea3);
            this.chartDensity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartDensity.Location = new System.Drawing.Point(157, 0);
            this.chartDensity.Name = "chartDensity";
            series3.ChartArea = "ChartArea1";
            series3.Name = "Series1";
            this.chartDensity.Series.Add(series3);
            this.chartDensity.Size = new System.Drawing.Size(479, 141);
            this.chartDensity.TabIndex = 1;
            this.chartDensity.Text = "chart1";
            // 
            // panel233
            // 
            this.panel233.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel233.Controls.Add(this.chartAutoCorrelation);
            this.panel233.Controls.Add(this.label1221);
            this.panel233.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel233.Location = new System.Drawing.Point(0, 314);
            this.panel233.Name = "panel233";
            this.panel233.Size = new System.Drawing.Size(638, 141);
            this.panel233.TabIndex = 10;
            // 
            // label1221
            // 
            this.label1221.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1221.Location = new System.Drawing.Point(0, 0);
            this.label1221.Name = "label1221";
            this.label1221.Size = new System.Drawing.Size(157, 139);
            this.label1221.TabIndex = 0;
            this.label1221.Text = "Autocorrelation:";
            this.label1221.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel13
            // 
            this.panel13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel13.Controls.Add(this.chartCrossCorelation);
            this.panel13.Controls.Add(this.label123);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel13.Location = new System.Drawing.Point(0, 455);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(638, 141);
            this.panel13.TabIndex = 11;
            // 
            // label123
            // 
            this.label123.Dock = System.Windows.Forms.DockStyle.Left;
            this.label123.Location = new System.Drawing.Point(0, 0);
            this.label123.Name = "label123";
            this.label123.Size = new System.Drawing.Size(157, 139);
            this.label123.TabIndex = 0;
            this.label123.Text = "Crosscorrelation:";
            this.label123.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel14
            // 
            this.panel14.AutoSize = true;
            this.panel14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel14.Controls.Add(this.lbIsStatic);
            this.panel14.Controls.Add(this.label25);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel14.Location = new System.Drawing.Point(0, 596);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(638, 19);
            this.panel14.TabIndex = 12;
            // 
            // lbIsStatic
            // 
            this.lbIsStatic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbIsStatic.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbIsStatic.Location = new System.Drawing.Point(157, 0);
            this.lbIsStatic.Name = "lbIsStatic";
            this.lbIsStatic.Size = new System.Drawing.Size(479, 17);
            this.lbIsStatic.TabIndex = 1;
            this.lbIsStatic.Text = "label24";
            // 
            // label25
            // 
            this.label25.Dock = System.Windows.Forms.DockStyle.Left;
            this.label25.Location = new System.Drawing.Point(0, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(157, 17);
            this.label25.TabIndex = 0;
            this.label25.Text = "isStatic:";
            this.label25.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // chartAutoCorrelation
            // 
            chartArea2.Name = "ChartArea1";
            this.chartAutoCorrelation.ChartAreas.Add(chartArea2);
            this.chartAutoCorrelation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartAutoCorrelation.Location = new System.Drawing.Point(157, 0);
            this.chartAutoCorrelation.Name = "chartAutoCorrelation";
            series2.ChartArea = "ChartArea1";
            series2.Name = "Series1";
            this.chartAutoCorrelation.Series.Add(series2);
            this.chartAutoCorrelation.Size = new System.Drawing.Size(479, 139);
            this.chartAutoCorrelation.TabIndex = 2;
            this.chartAutoCorrelation.Text = "chart1";
            // 
            // chartCrossCorelation
            // 
            chartArea1.Name = "ChartArea1";
            this.chartCrossCorelation.ChartAreas.Add(chartArea1);
            this.chartCrossCorelation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartCrossCorelation.Location = new System.Drawing.Point(157, 0);
            this.chartCrossCorelation.Name = "chartCrossCorelation";
            series1.ChartArea = "ChartArea1";
            series1.Name = "Series1";
            this.chartCrossCorelation.Series.Add(series1);
            this.chartCrossCorelation.Size = new System.Drawing.Size(479, 139);
            this.chartCrossCorelation.TabIndex = 3;
            this.chartCrossCorelation.Text = "chart2";
            // 
            // StatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 853);
            this.Controls.Add(this.panel1);
            this.Name = "StatisticsForm";
            this.Text = "StatisticsForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartDensity)).EndInit();
            this.panel233.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartAutoCorrelation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCrossCorelation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label lbSkewness;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label lbCentralMoment4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label lbCentralMoment3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lbStandartDeviation;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lbVariance;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lbMeanSquareError;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbMeanSquare;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbMean;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label lbKurtosis;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Label lbIsStatic;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Label label123;
        private System.Windows.Forms.Panel panel233;
        private System.Windows.Forms.Label label1221;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDensity;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCrossCorelation;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartAutoCorrelation;
    }
}