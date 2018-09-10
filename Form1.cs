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
    public partial class Form1 : Form
    {
        private GraphData[] mDrawData;
        private double mLeft;
        private double mRight;
        private double mDelta;
        private string mFunc;
        private double pA, pB, pC;
        private int mFrom, mTo;
        private RndGenerator r;
        private const string SERIES_NAME = "Series";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            r = new RndGenerator();
            validate_input();
            mDrawData = new GraphData[5];
            for (int i = 0; i < 5; i++)
            {
                mDrawData[i] = new GraphData();
            }
        }

        private bool DrawPlot(GraphData g, int pTo)
        {
            try
            {
                pTo++;
                string SerName = SERIES_NAME + pTo;
                chart1.Series.Remove(chart1.Series.FindByName(SerName));
                chart1.Series.Add(new Series(SerName));
                chart1.Series[SerName].ChartArea = "ChartArea" + pTo;
                chart1.Series[SerName].ChartType = SeriesChartType.Line;
                chart1.Series[SerName].Color = Color.Red;
                chart1.Series[SerName].BorderWidth = 3;
                if (!(g is ImageData))
                {
                g.mValues = g.mValues.Select(x => Double.IsInfinity(x) ? (Double.IsPositiveInfinity(x) ? 10 ^ 5 : -10 ^ 5) : x).ToArray<double>();

                chart1.Series[SerName].Points.DataBindXY(g.mArguments, g.mValues);
                }
                return true;
            }
            catch (Exception ignored)
            {
                MessageBox.Show(ignored.Message);
                return false;
            }
        }
        private void validate_input()
        {
            try
            {
                double.TryParse(LeftTB.Text, out mLeft);
                double.TryParse(RightTB.Text, out mRight);
                double.TryParse(DeltaTB.Text, out mDelta);
                mTo = toCB.SelectedIndex - 1;
                mFrom = fromCB.SelectedIndex - 1;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Неверные значения");

            }
        }

        private void LeftTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void OpenFileDialog()
        {

        }
        private void DrawBtn_Click(object sender, EventArgs e)
        {


            validate_input();
            validate_params();
            if (mFrom < 0)
            {
                try
                {
                    mDrawData[mTo].size_init(mLeft, mRight, mDelta);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("не распарсилось");
                }
            }
            else if (mFrom == 4)
            {
                if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                string filename = openFileDialog1.FileName;
                fromFileTB.Text = filename;
                mDrawData[mTo].mLoadFromFile(filename);
            }
            else if (mFrom == 5)
            {
                if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                string filename = openFileDialog1.FileName;
                fromFileTB.Text = filename;
                mDrawData[mTo] = new ImageData();
                mDrawData[mTo].mLoadFromFile(filename);
                ImageForm imgForm = new ImageForm(((ImageData)(mDrawData[mTo])).GetImage());
                imgForm.Show();
            }
            else
            {
                if (mTo != mFrom && mDrawData[mFrom] is ImageData)
                {
                    mDrawData[mTo] = new ImageData((ImageData)mDrawData[mFrom]);
                   
                }
                mDrawData[mTo].mDelta = mDrawData[mFrom].mDelta;
                mDrawData[mTo].x_init(mDrawData[mFrom].mArguments);
                mDrawData[mTo].from_val_init(mDrawData[mFrom].mValues);
            }
            if (mTo!=4) {
                ChooseFunc(mTo);
                mDrawData[mTo].compute();

                if (!DrawPlot(mDrawData[mTo], mTo))
                {
                    MessageBox.Show("Ошибка");
                };
                if ( mFrom!=5 && mFrom != 5 && mDrawData[mFrom] is ImageData && mDrawData[mTo] is ImageData)
                {
                    ImageForm imgForm = new ImageForm(((ImageData)(mDrawData[mTo])).GetImage());
                    imgForm.Show();
                }
                }
            else
            {
              
                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                string filename = saveFileDialog1.FileName;
                fromFileTB.Text = filename;
                mDrawData[mFrom].SaveToFile(filename);
            }
          

        }

        public void ChooseFunc(int pIndex)
        {
            if (LogRBTN.Checked)
            {
                mDrawData[pIndex].mSetLogFunc(pA, pB);

            }
            if (SimpleRBN.Checked)
            {
                switch (FunTB.Text)
                {
                    case "harm3":

                        mDrawData[pIndex].mSetHarm3();
                        break;
                    case "antirnd":

                        mDrawData[pIndex].mSetHarmRnd(pA, pB, pC);
                        break;
                    case "ult_rnd":

                        mDrawData[pIndex].mAntiRnd(pA,mDrawData[mFrom].mValues);
                        break;
                    case "spikeharm":

                        mDrawData[pIndex].mSetSpikeHarm(pA, pB);
                        break;
                    case "card":
                        mLeft = 0;
                        mDelta = 0.005;
                        mRight = 6;
                        LeftTB.Text = mLeft.ToString();
                        RightTB.Text = mRight.ToString();
                        DeltaTB.Text = mDelta.ToString();
                        mDrawData[pIndex].mSetCard();
                        break;
                    case "furie":


                        double Fgr = 1.0 / ( mDrawData[mFrom].mDelta);
                        double Fdelta = Fgr / mDrawData[mFrom].mValues.Length;
                        MessageBox.Show("Преобразование Фурье Fgr = " + Fgr + " ; Fdelta = " + Fdelta);

                        mDrawData[pIndex].pSetFurie( mDrawData[mFrom].mValues);
                        break;
                    case "obrfurie":


                        double obrFgr = 1.0 /  mDrawData[mFrom].mDelta;
                        double obrFdelta = obrFgr  / mDrawData[mFrom].mValues.Length;
                        MessageBox.Show("Преобразование Фурье Fgr = " + obrFgr + " ; Fdelta = " + obrFdelta);

                        mDrawData[pIndex].pSetObrFurie( mDrawData[mFrom].mValues);
                        break;
                    case "noize":
                        mDrawData[pIndex].mAddNoize(pC);
                        break;
                    case "shift":
                        mDrawData[pIndex].mShift(pC);
                        break;
                    case "antishift":
                        mDrawData[pIndex].mAntiShift();
                        break;
                    case "antispike":
                        mDrawData[pIndex].mAntiSpike(pC);
                        break;
                    case "cutsigma":
                        mDrawData[pIndex].mCutSigma(pC);
                        break;
                    case "antitrend":
                        mDrawData[pIndex].mAntiTrend((int)pC);
                        break;
                    case "lpf":
                        mDrawData[pIndex].ConwolutionWithLpf(mDrawData[mFrom].mValues, pA, pB, mDrawData[mFrom].mDelta);
                        break;
                    case "hpf":
                        mDrawData[pIndex].ConwolutionWithHpf(mDrawData[mFrom].mValues, pA, pB, mDrawData[mFrom].mDelta);
                        break;
                    case "bpf":
                        mDrawData[pIndex].ConwolutionWithBpf(mDrawData[mFrom].mValues, pA, pB, pC, mDrawData[mFrom].mDelta);
                        break;
                    case "bsf":
                        mDrawData[pIndex].ConwolutionWithBsf(mDrawData[mFrom].mValues, pA, pB, pC, mDrawData[mFrom].mDelta);
                        break;
                    case "ult":
                        mDrawData[pIndex].mSetUltra(pA, pB);
                        break;
                    case "trend":
                        mDrawData[pIndex].mTrend((int)pC);
                        break;
                    case "rescale":
                        mDrawData[pIndex].mSelectEvery((int)pC, mDrawData[mFrom].mValues);
                        break;
                    case "minusevery":
                        mDrawData[pIndex].mMinusEvery((int)pC, mDrawData[mFrom].mValues);
                        break;
                    case "autocor":

                        mDrawData[pIndex].mSetAutocor(mDrawData[mFrom].mValues);
                        break;
                    case "resIm":
                        
                        ((ImageData)mDrawData[pIndex]).resizeNearNeig(pA, pA, mDrawData[mFrom].mValues, ((ImageData)mDrawData[mFrom]).ImageW, ((ImageData)mDrawData[mFrom]).ImageH);
                        break;
                    case "resBil":

                        ((ImageData)mDrawData[pIndex]).resizeBiLin(pA, pA, mDrawData[mFrom].mValues, ((ImageData)mDrawData[mFrom]).ImageW, ((ImageData)mDrawData[mFrom]).ImageH);
                        break;
                    case "neg":

                        ((ImageData)mDrawData[pIndex]).mSetNegativ();
                        break;
                    case "gam":

                        ((ImageData)mDrawData[pIndex]).mSetGamma(pA,pB);
                        break;
                    case "logIm":
                        ((ImageData)mDrawData[pIndex]).mSetLogTrans(pA);
                        break;
                    case "hist":
                        if (mDrawData[mFrom] is ImageData)
                        {
                        ImageData FromIm = ((ImageData)mDrawData[mFrom]);
                        mDrawData[pIndex] = new GraphData(0, FromIm.DinamMax, 1);
                        mDrawData[pIndex].mSetHist(FromIm.mValues, 0, FromIm.DinamMax);
                        }
                        break;
                    case "dens":
                        mDrawData[pIndex].mSetDensity(mDrawData[mFrom].mValues);
                        break;
                    case "equal":
                        mDrawData[pIndex].mSetEqualization(mDrawData[mFrom].mValues, mDrawData[mFrom].mValues.Length);
                        break;
                    case "hisEq":
                        if (mDrawData[mFrom] is ImageData)
                        {
                            ImageData FromIm = ((ImageData)mDrawData[mFrom]);
                           ((ImageData) mDrawData[pIndex]).mHistEquilization(FromIm.mValues, 0, (int)FromIm.DinamMax);
                        }

                        break;
                    case "hisRed":
                        if (mDrawData[mFrom] is ImageData)
                        {
                            ImageData FromIm = ((ImageData)mDrawData[mFrom]);
                            ((ImageData)mDrawData[pIndex]).mHistReduction(FromIm.mValues, 0, (int)FromIm.DinamMax);
                        }

                        break;
                     case "rec":
                        if (mDrawData[mFrom] is ImageData)
                        {
                            ImageData FromIm = ((ImageData)mDrawData[mFrom]);
                            ((ImageData)mDrawData[pIndex]).mDeleteBlur(FromIm.mValues, FromIm.ImageW, FromIm.ImageH);
                        }
                        break;
                    
                    case "recN":
                        if (mDrawData[mFrom] is ImageData)
                        {
                            ImageData FromIm = ((ImageData)mDrawData[mFrom]);
                            ((ImageData)mDrawData[pIndex]).mDeleteBlurNoize(FromIm.mValues, FromIm.ImageW, FromIm.ImageH,pA);
                        }
                        break;
                    case "kontA": //есть серединка pA=1
                        if (mDrawData[mFrom] is ImageData)
                        {
                            ImageData FromIm = ((ImageData)mDrawData[mFrom]);
                            ((ImageData)mDrawData[pIndex]).mSetKonturA(200,pA, FromIm.mValues);
                        }
                        break;
                    case "kontB": //нет серединка pA=50
                        if (mDrawData[mFrom] is ImageData)
                        {
                            ImageData FromIm = ((ImageData)mDrawData[mFrom]);
                            ((ImageData)mDrawData[pIndex]).mSetKonturA(100, pA, FromIm.mValues);
                        }
                        break;
                    case "kontC": // pA=30-60
                        if (mDrawData[mFrom] is ImageData)
                        {
                            ImageData FromIm = ((ImageData)mDrawData[mFrom]);
                            ((ImageData)mDrawData[pIndex]).mSetKonturA(200, pA, FromIm.mValues);
                        }
                        break;
                    case "fNet": // 
                        if (mDrawData[mFrom] is ImageData)
                        {

                            ImageData FromIm = ((ImageData)mDrawData[mFrom]);
                            mDrawData[mTo] = new GraphData(1, FromIm.ImageW, 1);
                            mDrawData[mTo].mLineAutoSpectr(FromIm.mValues, FromIm.ImageW, FromIm.ImageH);
                        }
                        break;
                    case "lineFurie": // 
                        if (mDrawData[mFrom] is ImageData)
                        {

                            ImageData FromIm = ((ImageData)mDrawData[mFrom]);
                            mDrawData[mTo] = new GraphData(1, FromIm.ImageW, 1);
                            mDrawData[mTo].mLineSpectr(FromIm.mValues, FromIm.ImageW, FromIm.ImageH);
                        }
                        break;
                    case "lineBsf":
                        if (mDrawData[mFrom] is ImageData)
                        {
                            double m = 64;
                            ImageData FromIm = ((ImageData)mDrawData[mFrom]);
                            ((ImageData)mDrawData[pIndex]).mSetLineBsf(pA, pB, m, FromIm.mValues);
                        }
                            break;
                    case "lineLpf":
                        if (mDrawData[mFrom] is ImageData)
                        {
                            ImageData FromIm = ((ImageData)mDrawData[mFrom]);
                            ((ImageData)mDrawData[pIndex]).mSetLineLpf(pA, pB, FromIm.mValues);
                        }
                        break;
                    case "minusHpf":
                        if (mDrawData[mFrom] is ImageData)
                        {
                            ImageData FromIm = ((ImageData)mDrawData[mFrom]);
                            ((ImageData)mDrawData[pIndex]).mSetMinusHPF(pA, pB, FromIm.mValues);
                        }
                        break;
                    case "lapl":
                        if (mDrawData[mFrom] is ImageData)
                        {
                            ImageData FromIm = ((ImageData)mDrawData[mFrom]);
                            ((ImageData)mDrawData[pIndex]).mLapl(FromIm.mValues, FromIm.ImageW, FromIm.ImageH);
                        }
                        break;
                    case "grad":
                        if (mDrawData[mFrom] is ImageData)
                        {
                            ImageData FromIm = ((ImageData)mDrawData[mFrom]);
                            ((ImageData)mDrawData[pIndex]).mGrad(FromIm.mValues, FromIm.ImageW, FromIm.ImageH);

                        }
                        break;
                    case "imgrnd":
                        if (mDrawData[mFrom] is ImageData)
                        {
                            ImageData FromIm = ((ImageData)mDrawData[mFrom]);
                            ((ImageData)mDrawData[pIndex]).mSetRndNoize(pA,FromIm.mValues);

                        }
                        break;
                    case "imgpulse":
                        if (mDrawData[mFrom] is ImageData)
                        {
                            ImageData FromIm = ((ImageData)mDrawData[mFrom]);
                            ((ImageData)mDrawData[pIndex]).mSetPulseNoize(pA, FromIm.mValues);

                        }
                        break;
                    case "osred":
                        if (mDrawData[mFrom] is ImageData)
                        {
                            ImageData FromIm = ((ImageData)mDrawData[mFrom]);
                            ((ImageData)mDrawData[pIndex]).mSetOsred(pA, FromIm.mValues);

                        }
                        break;
                    case "median":
                        if (mDrawData[mFrom] is ImageData)
                        {
                            ImageData FromIm = ((ImageData)mDrawData[mFrom]);
                            ((ImageData)mDrawData[pIndex]).mSetMedian(pA, FromIm.mValues);

                        }
                        break;
                    case "dilat":
                        if (mDrawData[mFrom] is ImageData)
                        {
                            ImageData FromIm = ((ImageData)mDrawData[mFrom]);

                            double[][] kernel = new double[(int)pA][];
                            for(int i=0;i<kernel.Length; i++)
                            {
                                kernel[i] = (new double[(int)pA]).Select(x => 1.0).ToArray();
                            }

                            ((ImageData)mDrawData[pIndex]).mSetDialt(pB,kernel, FromIm.mValues);

                        }
                        break;
                    case "eros":
                        if (mDrawData[mFrom] is ImageData)
                        {
                            ImageData FromIm = ((ImageData)mDrawData[mFrom]);

                            double[][] kernel = new double[(int)pA][];
                            for (int i = 0; i < kernel.Length; i++)
                            {
                                kernel[i] = (new double[(int)pA]).Select(x => 1.0).ToArray();
                            }

                            ((ImageData)mDrawData[pIndex]).mSetEros(pB, kernel, FromIm.mValues);

                        }
                        break;
                    case "flood":
                        if (mDrawData[mFrom] is ImageData)
                        {
                            ImageData FromIm = ((ImageData)mDrawData[mFrom]);



                            ((ImageData)mDrawData[pIndex]).mSetFood(pA, pB, FromIm.mValues);
                        }
                        break;
                    case "obrpor":
                        if (mDrawData[mFrom] is ImageData)
                        {
                            ImageData FromIm = ((ImageData)mDrawData[mFrom]);
                            ((ImageData)mDrawData[pIndex]).mSetObrPor(pC, FromIm.mValues);
                        }
                        break;
                    case "expbor":
                        if (mDrawData[mFrom] is ImageData)
                        {
                            ImageData FromIm = ((ImageData)mDrawData[mFrom]);
                            ((ImageData)mDrawData[pIndex]).mSetExprBord( FromIm.mValues,pA);
                        }
                        break;
                    case "test":
                        if (mDrawData[mFrom] is ImageData)
                        {
                            ImageData FromIm = ((ImageData)mDrawData[mFrom]);

                          

                            ((ImageData)mDrawData[pIndex]).mSetCurTest(pA,pB, FromIm.mValues);
                        }
                        break;

                    default:
                        mDrawData[pIndex].mSetAnyFunc(FunTB.Text);
                        break;

                }
            }
            if (ParabRBTN.Checked)
            {
                mDrawData[pIndex].mSetParabFunc(pA, pB, pC);

            }
            if (AfinRBTN.Checked)
            {
                mDrawData[pIndex].mSetAfinFunc(pA, pB);
            }

            if (NativeRndRbtn.Checked)
            {
                mDrawData[pIndex].mSetNativeRnd((int)pC, pA, pB);
            }
            if (HarmRBTN.Checked)
            {
                mDrawData[pIndex].mSetHarm(pA, pB);
            }
            if (ExpRBTN.Checked)
            {
                mDrawData[pIndex].mSetExpFunc(pA, pB);
            }

            if (randomRBTN.Checked)
            {
                mDrawData[pIndex].mSetMyRnd(r, pA, pB);
            }
        }

        public void validate_params()
        {
            pA = Double.Parse(paramATB.Text);
            pB = Double.Parse(paramBTB.Text);
            pC = Double.Parse(paramCTB.Text);
        }

        private void LogRBTN_CheckedChanged(object sender, EventArgs e)
        {

            if (LogRBTN.Checked)
            {
                DrawBtn.Enabled = true;
            }
            else
            {
                DrawBtn.Enabled = false;
            }
        }

        private void SimpleRBN_CheckedChanged(object sender, EventArgs e)
        {
            if (SimpleRBN.Checked)
            {
                DrawBtn.Enabled = true;
            }
            else
            {
                DrawBtn.Enabled = false;
            }

        }

        private void ParabRBTN_CheckedChanged(object sender, EventArgs e)
        {
            if (ParabRBTN.Checked)
            {
                DrawBtn.Enabled = true;
            }
            else
            {
                DrawBtn.Enabled = false;
            }
        }

        private void AfinRBTN_CheckedChanged(object sender, EventArgs e)
        {
            if (AfinRBTN.Checked)
            {
                DrawBtn.Enabled = true;
            }
            else
            {
                DrawBtn.Enabled = false;
            }
        }

        private void NativeRndRbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (NativeRndRbtn.Checked)
            {
                DrawBtn.Enabled = true;
            }
            else
            {
                DrawBtn.Enabled = false;
            }
        }

        private void StatBtn_Click(object sender, EventArgs e)
        {
            StatForm statForm = new StatForm(chart1, SERIES_NAME + (mTo + 1), pA, pB);
            statForm.Show();
        }

        private void HarmRBTN_CheckedChanged(object sender, EventArgs e)
        {
            if (HarmRBTN.Checked)
            {
                DrawBtn.Enabled = true;
            }
            else
            {
                DrawBtn.Enabled = false;
            }
        }

        private void toCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fromCB.SelectedIndex < 1)
            {
                if (fromCB.SelectedIndex == -1)
                {
                    MessageBox.Show("Выберите сначала откуда");
                }

            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void fromCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fromCB.SelectedIndex == -1)
            {
                toCB.Enabled = false;

            }
            else
            {

                toCB.Enabled = true;
            }
        }

        private void ExpRBTN_CheckedChanged(object sender, EventArgs e)
        {
            if (ExpRBTN.Checked)
            {
                DrawBtn.Enabled = true;
            }
            else
            {
                DrawBtn.Enabled = false;
            }
        }



        private void randomRBTN_CheckedChanged(object sender, EventArgs e)
        {
            if (randomRBTN.Checked)
            {
                DrawBtn.Enabled = true;
            }
            else
            {
                DrawBtn.Enabled = false;
            }
        }
    }
}
