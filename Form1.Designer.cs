namespace obrabotka1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea9 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea10 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea11 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea12 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.FunTB = new System.Windows.Forms.TextBox();
            this.DrawBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.RightTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LeftTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DeltaTB = new System.Windows.Forms.TextBox();
            this.ExpRBTN = new System.Windows.Forms.RadioButton();
            this.LogRBTN = new System.Windows.Forms.RadioButton();
            this.SimpleRBN = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.randomRBTN = new System.Windows.Forms.RadioButton();
            this.NativeRndRbtn = new System.Windows.Forms.RadioButton();
            this.paramATB = new System.Windows.Forms.TextBox();
            this.paramBTB = new System.Windows.Forms.TextBox();
            this.paramCTB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ParabRBTN = new System.Windows.Forms.RadioButton();
            this.AfinRBTN = new System.Windows.Forms.RadioButton();
            this.StatBtn = new System.Windows.Forms.Button();
            this.HarmRBTN = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.toFileTB = new System.Windows.Forms.TextBox();
            this.fromFileTB = new System.Windows.Forms.TextBox();
            this.toCB = new System.Windows.Forms.ComboBox();
            this.fromCB = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // FunTB
            // 
            this.FunTB.Location = new System.Drawing.Point(64, 286);
            this.FunTB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.FunTB.Name = "FunTB";
            this.FunTB.Size = new System.Drawing.Size(132, 22);
            this.FunTB.TabIndex = 1;
            this.FunTB.Text = "x*2";
            this.FunTB.TextChanged += new System.EventHandler(this.LeftTB_TextChanged);
            // 
            // DrawBtn
            // 
            this.DrawBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.DrawBtn.Enabled = false;
            this.DrawBtn.Location = new System.Drawing.Point(76, 715);
            this.DrawBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DrawBtn.Name = "DrawBtn";
            this.DrawBtn.Size = new System.Drawing.Size(111, 33);
            this.DrawBtn.TabIndex = 2;
            this.DrawBtn.Text = "Draw";
            this.DrawBtn.UseVisualStyleBackColor = true;
            this.DrawBtn.Click += new System.EventHandler(this.DrawBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 286);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "f(x)=";
            // 
            // RightTB
            // 
            this.RightTB.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.RightTB.Location = new System.Drawing.Point(65, 124);
            this.RightTB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RightTB.Name = "RightTB";
            this.RightTB.Size = new System.Drawing.Size(132, 22);
            this.RightTB.TabIndex = 4;
            this.RightTB.Text = "5";
            this.RightTB.TextChanged += new System.EventHandler(this.LeftTB_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 128);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "right";
            // 
            // LeftTB
            // 
            this.LeftTB.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.LeftTB.Location = new System.Drawing.Point(65, 60);
            this.LeftTB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LeftTB.Name = "LeftTB";
            this.LeftTB.Size = new System.Drawing.Size(132, 22);
            this.LeftTB.TabIndex = 6;
            this.LeftTB.Text = "0";
            this.LeftTB.TextChanged += new System.EventHandler(this.LeftTB_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 65);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "left";
            // 
            // DeltaTB
            // 
            this.DeltaTB.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.DeltaTB.Location = new System.Drawing.Point(64, 92);
            this.DeltaTB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DeltaTB.Name = "DeltaTB";
            this.DeltaTB.Size = new System.Drawing.Size(132, 22);
            this.DeltaTB.TabIndex = 8;
            this.DeltaTB.Text = "0,001";
            this.DeltaTB.TextChanged += new System.EventHandler(this.LeftTB_TextChanged);
            // 
            // ExpRBTN
            // 
            this.ExpRBTN.AutoSize = true;
            this.ExpRBTN.Location = new System.Drawing.Point(25, 374);
            this.ExpRBTN.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ExpRBTN.Name = "ExpRBTN";
            this.ExpRBTN.Size = new System.Drawing.Size(96, 21);
            this.ExpRBTN.TabIndex = 9;
            this.ExpRBTN.Text = "b*exp( a x)";
            this.ExpRBTN.UseVisualStyleBackColor = true;
            this.ExpRBTN.CheckedChanged += new System.EventHandler(this.ExpRBTN_CheckedChanged);
            // 
            // LogRBTN
            // 
            this.LogRBTN.AutoSize = true;
            this.LogRBTN.Location = new System.Drawing.Point(24, 346);
            this.LogRBTN.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LogRBTN.Name = "LogRBTN";
            this.LogRBTN.Size = new System.Drawing.Size(100, 21);
            this.LogRBTN.TabIndex = 10;
            this.LogRBTN.Text = "a + b log(x)";
            this.LogRBTN.UseVisualStyleBackColor = true;
            this.LogRBTN.CheckedChanged += new System.EventHandler(this.LogRBTN_CheckedChanged);
            // 
            // SimpleRBN
            // 
            this.SimpleRBN.AutoSize = true;
            this.SimpleRBN.Location = new System.Drawing.Point(24, 318);
            this.SimpleRBN.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SimpleRBN.Name = "SimpleRBN";
            this.SimpleRBN.Size = new System.Drawing.Size(49, 21);
            this.SimpleRBN.TabIndex = 12;
            this.SimpleRBN.Text = "f(x)";
            this.SimpleRBN.UseVisualStyleBackColor = true;
            this.SimpleRBN.CheckedChanged += new System.EventHandler(this.SimpleRBN_CheckedChanged);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 96);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "delta";
            // 
            // randomRBTN
            // 
            this.randomRBTN.AutoSize = true;
            this.randomRBTN.Location = new System.Drawing.Point(27, 460);
            this.randomRBTN.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.randomRBTN.Name = "randomRBTN";
            this.randomRBTN.Size = new System.Drawing.Size(77, 21);
            this.randomRBTN.TabIndex = 14;
            this.randomRBTN.TabStop = true;
            this.randomRBTN.Text = "random";
            this.randomRBTN.UseVisualStyleBackColor = true;
            this.randomRBTN.CheckedChanged += new System.EventHandler(this.randomRBTN_CheckedChanged);
            // 
            // NativeRndRbtn
            // 
            this.NativeRndRbtn.AutoSize = true;
            this.NativeRndRbtn.Location = new System.Drawing.Point(25, 490);
            this.NativeRndRbtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.NativeRndRbtn.Name = "NativeRndRbtn";
            this.NativeRndRbtn.Size = new System.Drawing.Size(95, 21);
            this.NativeRndRbtn.TabIndex = 15;
            this.NativeRndRbtn.TabStop = true;
            this.NativeRndRbtn.Text = "NativeRnd";
            this.NativeRndRbtn.UseVisualStyleBackColor = true;
            this.NativeRndRbtn.CheckedChanged += new System.EventHandler(this.NativeRndRbtn_CheckedChanged);
            // 
            // paramATB
            // 
            this.paramATB.Location = new System.Drawing.Point(64, 190);
            this.paramATB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.paramATB.Name = "paramATB";
            this.paramATB.Size = new System.Drawing.Size(132, 22);
            this.paramATB.TabIndex = 16;
            this.paramATB.Text = "1";
            // 
            // paramBTB
            // 
            this.paramBTB.Location = new System.Drawing.Point(65, 222);
            this.paramBTB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.paramBTB.Name = "paramBTB";
            this.paramBTB.Size = new System.Drawing.Size(132, 22);
            this.paramBTB.TabIndex = 17;
            this.paramBTB.Text = "1";
            // 
            // paramCTB
            // 
            this.paramCTB.Location = new System.Drawing.Point(65, 254);
            this.paramCTB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.paramCTB.Name = "paramCTB";
            this.paramCTB.Size = new System.Drawing.Size(132, 22);
            this.paramCTB.TabIndex = 18;
            this.paramCTB.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 262);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 17);
            this.label5.TabIndex = 19;
            this.label5.Text = "C";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 230);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 17);
            this.label6.TabIndex = 20;
            this.label6.Text = "B";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 198);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 17);
            this.label7.TabIndex = 21;
            this.label7.Text = "A";
            // 
            // ParabRBTN
            // 
            this.ParabRBTN.AutoSize = true;
            this.ParabRBTN.Location = new System.Drawing.Point(25, 404);
            this.ParabRBTN.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ParabRBTN.Name = "ParabRBTN";
            this.ParabRBTN.Size = new System.Drawing.Size(119, 21);
            this.ParabRBTN.TabIndex = 22;
            this.ParabRBTN.Text = "a x^2 + b x + c";
            this.ParabRBTN.UseVisualStyleBackColor = true;
            this.ParabRBTN.CheckedChanged += new System.EventHandler(this.ParabRBTN_CheckedChanged);
            // 
            // AfinRBTN
            // 
            this.AfinRBTN.AutoSize = true;
            this.AfinRBTN.Location = new System.Drawing.Point(25, 432);
            this.AfinRBTN.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AfinRBTN.Name = "AfinRBTN";
            this.AfinRBTN.Size = new System.Drawing.Size(63, 21);
            this.AfinRBTN.TabIndex = 23;
            this.AfinRBTN.Text = "a x+b";
            this.AfinRBTN.UseVisualStyleBackColor = true;
            this.AfinRBTN.CheckedChanged += new System.EventHandler(this.AfinRBTN_CheckedChanged);
            // 
            // StatBtn
            // 
            this.StatBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.StatBtn.Location = new System.Drawing.Point(75, 756);
            this.StatBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.StatBtn.Name = "StatBtn";
            this.StatBtn.Size = new System.Drawing.Size(112, 32);
            this.StatBtn.TabIndex = 24;
            this.StatBtn.Text = "Stat";
            this.StatBtn.UseVisualStyleBackColor = true;
            this.StatBtn.Click += new System.EventHandler(this.StatBtn_Click);
            // 
            // HarmRBTN
            // 
            this.HarmRBTN.AutoSize = true;
            this.HarmRBTN.Location = new System.Drawing.Point(27, 519);
            this.HarmRBTN.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.HarmRBTN.Name = "HarmRBTN";
            this.HarmRBTN.Size = new System.Drawing.Size(119, 21);
            this.HarmRBTN.TabIndex = 25;
            this.HarmRBTN.TabStop = true;
            this.HarmRBTN.Text = "a*sin(2*PI*b*x)";
            this.HarmRBTN.UseVisualStyleBackColor = true;
            this.HarmRBTN.CheckedChanged += new System.EventHandler(this.HarmRBTN_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chart1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(267, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1549, 798);
            this.panel1.TabIndex = 26;
            // 
            // chart1
            // 
            chartArea9.Name = "ChartArea1";
            chartArea10.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.TopRight;
            chartArea10.Name = "ChartArea2";
            chartArea11.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.BottomRight;
            chartArea11.Name = "ChartArea3";
            chartArea12.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.BottomLeft;
            chartArea12.Name = "ChartArea4";
            this.chart1.ChartAreas.Add(chartArea9);
            this.chart1.ChartAreas.Add(chartArea10);
            this.chart1.ChartAreas.Add(chartArea11);
            this.chart1.ChartAreas.Add(chartArea12);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chart1.Name = "chart1";
            series3.ChartArea = "ChartArea1";
            series3.Name = "Series1";
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(1549, 798);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.toFileTB);
            this.panel3.Controls.Add(this.fromFileTB);
            this.panel3.Controls.Add(this.toCB);
            this.panel3.Controls.Add(this.fromCB);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.StatBtn);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.RightTB);
            this.panel3.Controls.Add(this.DeltaTB);
            this.panel3.Controls.Add(this.paramATB);
            this.panel3.Controls.Add(this.FunTB);
            this.panel3.Controls.Add(this.DrawBtn);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.LeftTB);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.HarmRBTN);
            this.panel3.Controls.Add(this.ExpRBTN);
            this.panel3.Controls.Add(this.AfinRBTN);
            this.panel3.Controls.Add(this.LogRBTN);
            this.panel3.Controls.Add(this.ParabRBTN);
            this.panel3.Controls.Add(this.SimpleRBN);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.randomRBTN);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.NativeRndRbtn);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.paramBTB);
            this.panel3.Controls.Add(this.paramCTB);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(267, 798);
            this.panel3.TabIndex = 28;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 618);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(160, 17);
            this.label11.TabIndex = 33;
            this.label11.Text = "Результирующий файл";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 560);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 17);
            this.label10.TabIndex = 32;
            this.label10.Text = "Файл источник";
            // 
            // toFileTB
            // 
            this.toFileTB.Location = new System.Drawing.Point(16, 638);
            this.toFileTB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.toFileTB.Name = "toFileTB";
            this.toFileTB.Size = new System.Drawing.Size(240, 22);
            this.toFileTB.TabIndex = 31;
            // 
            // fromFileTB
            // 
            this.fromFileTB.Location = new System.Drawing.Point(16, 583);
            this.fromFileTB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.fromFileTB.Name = "fromFileTB";
            this.fromFileTB.Size = new System.Drawing.Size(240, 22);
            this.fromFileTB.TabIndex = 30;
            // 
            // toCB
            // 
            this.toCB.FormattingEnabled = true;
            this.toCB.Items.AddRange(new object[] {
            "нет",
            "1",
            "2",
            "3",
            "4",
            "файл"});
            this.toCB.Location = new System.Drawing.Point(64, 156);
            this.toCB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.toCB.Name = "toCB";
            this.toCB.Size = new System.Drawing.Size(132, 24);
            this.toCB.TabIndex = 29;
            this.toCB.SelectedIndexChanged += new System.EventHandler(this.toCB_SelectedIndexChanged);
            // 
            // fromCB
            // 
            this.fromCB.FormattingEnabled = true;
            this.fromCB.Items.AddRange(new object[] {
            "нет",
            "1",
            "2",
            "3",
            "4",
            "файл",
            "картинка"});
            this.fromCB.Location = new System.Drawing.Point(65, 27);
            this.fromCB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.fromCB.Name = "fromCB";
            this.fromCB.Size = new System.Drawing.Size(132, 24);
            this.fromCB.TabIndex = 28;
            this.fromCB.SelectedIndexChanged += new System.EventHandler(this.fromCB_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(29, 160);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 17);
            this.label9.TabIndex = 27;
            this.label9.Text = "to";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 31);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 17);
            this.label8.TabIndex = 26;
            this.label8.Text = "from";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1816, 798);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox FunTB;
        private System.Windows.Forms.Button DrawBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox RightTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox LeftTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox DeltaTB;
        private System.Windows.Forms.RadioButton ExpRBTN;
        private System.Windows.Forms.RadioButton LogRBTN;
        private System.Windows.Forms.RadioButton SimpleRBN;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton randomRBTN;
        private System.Windows.Forms.RadioButton NativeRndRbtn;
        private System.Windows.Forms.TextBox paramATB;
        private System.Windows.Forms.TextBox paramBTB;
        private System.Windows.Forms.TextBox paramCTB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton ParabRBTN;
        private System.Windows.Forms.RadioButton AfinRBTN;
        private System.Windows.Forms.Button StatBtn;
        private System.Windows.Forms.RadioButton HarmRBTN;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ComboBox fromCB;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox toCB;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox toFileTB;
        private System.Windows.Forms.TextBox fromFileTB;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

