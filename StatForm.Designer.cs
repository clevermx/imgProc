namespace obrabotka1
{
    partial class StatForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbMean = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbMeanSq = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbMeanSqEr = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbVariance = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lbStandartDev = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lbMom3 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lbMom4 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.lbSkewness = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.lbKurtosis = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.chartDensity = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label19 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.chartAutocor = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label18 = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.chartCrosscor = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label20 = new System.Windows.Forms.Label();
            this.panel13 = new System.Windows.Forms.Panel();
            this.lbIsStatic = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.chartDensity)).BeginInit();
            this.panel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartAutocor)).BeginInit();
            this.panel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartCrosscor)).BeginInit();
            this.panel13.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lbMean);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(743, 27);
            this.panel1.TabIndex = 0;
            // 
            // lbMean
            // 
            this.lbMean.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbMean.Location = new System.Drawing.Point(133, 0);
            this.lbMean.Name = "lbMean";
            this.lbMean.Size = new System.Drawing.Size(608, 25);
            this.lbMean.TabIndex = 1;
            this.lbMean.Text = "0";
            this.lbMean.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mean";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lbMeanSq);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(743, 27);
            this.panel2.TabIndex = 1;
            // 
            // lbMeanSq
            // 
            this.lbMeanSq.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbMeanSq.Location = new System.Drawing.Point(133, 0);
            this.lbMeanSq.Name = "lbMeanSq";
            this.lbMeanSq.Size = new System.Drawing.Size(608, 25);
            this.lbMeanSq.TabIndex = 1;
            this.lbMeanSq.Text = "0";
            this.lbMeanSq.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "MeanSquare";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lbMeanSqEr);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 54);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(743, 27);
            this.panel3.TabIndex = 2;
            // 
            // lbMeanSqEr
            // 
            this.lbMeanSqEr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbMeanSqEr.Location = new System.Drawing.Point(133, 0);
            this.lbMeanSqEr.Name = "lbMeanSqEr";
            this.lbMeanSqEr.Size = new System.Drawing.Size(608, 25);
            this.lbMeanSqEr.TabIndex = 1;
            this.lbMeanSqEr.Text = "0";
            this.lbMeanSqEr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 25);
            this.label5.TabIndex = 0;
            this.label5.Text = "MeanSquareError";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.lbVariance);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 81);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(743, 27);
            this.panel4.TabIndex = 3;
            // 
            // lbVariance
            // 
            this.lbVariance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbVariance.Location = new System.Drawing.Point(133, 0);
            this.lbVariance.Name = "lbVariance";
            this.lbVariance.Size = new System.Drawing.Size(608, 25);
            this.lbVariance.TabIndex = 1;
            this.lbVariance.Text = "0";
            this.lbVariance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Dock = System.Windows.Forms.DockStyle.Left;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 25);
            this.label7.TabIndex = 0;
            this.label7.Text = "Variance";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.lbStandartDev);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 108);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(743, 27);
            this.panel5.TabIndex = 4;
            // 
            // lbStandartDev
            // 
            this.lbStandartDev.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbStandartDev.Location = new System.Drawing.Point(133, 0);
            this.lbStandartDev.Name = "lbStandartDev";
            this.lbStandartDev.Size = new System.Drawing.Size(608, 25);
            this.lbStandartDev.TabIndex = 1;
            this.lbStandartDev.Text = "0";
            this.lbStandartDev.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Dock = System.Windows.Forms.DockStyle.Left;
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(133, 25);
            this.label9.TabIndex = 0;
            this.label9.Text = "StandartDeviation";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.lbMom3);
            this.panel6.Controls.Add(this.label11);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 135);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(743, 27);
            this.panel6.TabIndex = 5;
            // 
            // lbMom3
            // 
            this.lbMom3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbMom3.Location = new System.Drawing.Point(133, 0);
            this.lbMom3.Name = "lbMom3";
            this.lbMom3.Size = new System.Drawing.Size(608, 25);
            this.lbMom3.TabIndex = 1;
            this.lbMom3.Text = "0";
            this.lbMom3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Dock = System.Windows.Forms.DockStyle.Left;
            this.label11.Location = new System.Drawing.Point(0, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(133, 25);
            this.label11.TabIndex = 0;
            this.label11.Text = "CentralMoment 3";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.lbMom4);
            this.panel7.Controls.Add(this.label13);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 162);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(743, 27);
            this.panel7.TabIndex = 6;
            // 
            // lbMom4
            // 
            this.lbMom4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbMom4.Location = new System.Drawing.Point(133, 0);
            this.lbMom4.Name = "lbMom4";
            this.lbMom4.Size = new System.Drawing.Size(608, 25);
            this.lbMom4.TabIndex = 1;
            this.lbMom4.Text = "0";
            this.lbMom4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.Dock = System.Windows.Forms.DockStyle.Left;
            this.label13.Location = new System.Drawing.Point(0, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(133, 25);
            this.label13.TabIndex = 0;
            this.label13.Text = "CentralMoment 4";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.lbSkewness);
            this.panel8.Controls.Add(this.label15);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 189);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(743, 27);
            this.panel8.TabIndex = 7;
            // 
            // lbSkewness
            // 
            this.lbSkewness.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSkewness.Location = new System.Drawing.Point(133, 0);
            this.lbSkewness.Name = "lbSkewness";
            this.lbSkewness.Size = new System.Drawing.Size(608, 25);
            this.lbSkewness.TabIndex = 1;
            this.lbSkewness.Text = "0";
            this.lbSkewness.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label15.Dock = System.Windows.Forms.DockStyle.Left;
            this.label15.Location = new System.Drawing.Point(0, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(133, 25);
            this.label15.TabIndex = 0;
            this.label15.Text = "Skewness";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel9
            // 
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.lbKurtosis);
            this.panel9.Controls.Add(this.label17);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 216);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(743, 27);
            this.panel9.TabIndex = 8;
            // 
            // lbKurtosis
            // 
            this.lbKurtosis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbKurtosis.Location = new System.Drawing.Point(133, 0);
            this.lbKurtosis.Name = "lbKurtosis";
            this.lbKurtosis.Size = new System.Drawing.Size(608, 25);
            this.lbKurtosis.TabIndex = 1;
            this.lbKurtosis.Text = "0";
            this.lbKurtosis.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label17.Dock = System.Windows.Forms.DockStyle.Left;
            this.label17.Location = new System.Drawing.Point(0, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(133, 25);
            this.label17.TabIndex = 0;
            this.label17.Text = "Kurtosis";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel10
            // 
            this.panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel10.Controls.Add(this.chartDensity);
            this.panel10.Controls.Add(this.label19);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(0, 243);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(743, 161);
            this.panel10.TabIndex = 9;
            // 
            // chartDensity
            // 
            chartArea1.Name = "ChartArea1";
            this.chartDensity.ChartAreas.Add(chartArea1);
            this.chartDensity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartDensity.Location = new System.Drawing.Point(133, 0);
            this.chartDensity.Name = "chartDensity";
            series1.ChartArea = "ChartArea1";
            series1.Name = "Series1";
            this.chartDensity.Series.Add(series1);
            this.chartDensity.Size = new System.Drawing.Size(608, 159);
            this.chartDensity.TabIndex = 1;
            this.chartDensity.Text = "chart1";
            // 
            // label19
            // 
            this.label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label19.Dock = System.Windows.Forms.DockStyle.Left;
            this.label19.Location = new System.Drawing.Point(0, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(133, 159);
            this.label19.TabIndex = 0;
            this.label19.Text = "Density";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel11
            // 
            this.panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel11.Controls.Add(this.chartAutocor);
            this.panel11.Controls.Add(this.label18);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(0, 404);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(743, 161);
            this.panel11.TabIndex = 10;
            // 
            // chartAutocor
            // 
            chartArea2.AxisX.Crossing = 0D;
            chartArea2.Name = "ChartArea1";
            this.chartAutocor.ChartAreas.Add(chartArea2);
            this.chartAutocor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartAutocor.Location = new System.Drawing.Point(133, 0);
            this.chartAutocor.Name = "chartAutocor";
            series2.ChartArea = "ChartArea1";
            series2.Name = "Series1";
            this.chartAutocor.Series.Add(series2);
            this.chartAutocor.Size = new System.Drawing.Size(608, 159);
            this.chartAutocor.TabIndex = 1;
            this.chartAutocor.Text = "chart1";
            // 
            // label18
            // 
            this.label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label18.Dock = System.Windows.Forms.DockStyle.Left;
            this.label18.Location = new System.Drawing.Point(0, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(133, 159);
            this.label18.TabIndex = 0;
            this.label18.Text = "Autocorrelation";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel12
            // 
            this.panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel12.Controls.Add(this.chartCrosscor);
            this.panel12.Controls.Add(this.label20);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel12.Location = new System.Drawing.Point(0, 565);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(743, 161);
            this.panel12.TabIndex = 11;
            // 
            // chartCrosscor
            // 
            chartArea3.Name = "ChartArea1";
            this.chartCrosscor.ChartAreas.Add(chartArea3);
            this.chartCrosscor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartCrosscor.Location = new System.Drawing.Point(133, 0);
            this.chartCrosscor.Name = "chartCrosscor";
            series3.ChartArea = "ChartArea1";
            series3.Name = "Series1";
            this.chartCrosscor.Series.Add(series3);
            this.chartCrosscor.Size = new System.Drawing.Size(608, 159);
            this.chartCrosscor.TabIndex = 1;
            this.chartCrosscor.Text = "chart1";
            // 
            // label20
            // 
            this.label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label20.Dock = System.Windows.Forms.DockStyle.Left;
            this.label20.Location = new System.Drawing.Point(0, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(133, 159);
            this.label20.TabIndex = 0;
            this.label20.Text = "Crosscorrelation";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel13
            // 
            this.panel13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel13.Controls.Add(this.lbIsStatic);
            this.panel13.Controls.Add(this.label4);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel13.Location = new System.Drawing.Point(0, 726);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(743, 27);
            this.panel13.TabIndex = 12;
            // 
            // lbIsStatic
            // 
            this.lbIsStatic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbIsStatic.Location = new System.Drawing.Point(133, 0);
            this.lbIsStatic.Name = "lbIsStatic";
            this.lbIsStatic.Size = new System.Drawing.Size(608, 25);
            this.lbIsStatic.TabIndex = 1;
            this.lbIsStatic.Text = "0";
            this.lbIsStatic.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "Is static";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // StatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(760, 448);
            this.Controls.Add(this.panel13);
            this.Controls.Add(this.panel12);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "StatForm";
            this.Text = "StatForm";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartDensity)).EndInit();
            this.panel11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartAutocor)).EndInit();
            this.panel12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartCrosscor)).EndInit();
            this.panel13.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbMean;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbMeanSq;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbMeanSqEr;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lbVariance;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lbStandartDev;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lbMom3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label lbMom4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label lbSkewness;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label lbKurtosis;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDensity;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartAutocor;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCrosscor;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Label lbIsStatic;
        private System.Windows.Forms.Label label4;
    }
}