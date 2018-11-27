using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STRAY
{
    public partial class fSub3 : Form
    {
        private List<int> _col1 = new List<int> { 0, 0, 0, 0 };
        private List<int> _col2 = new List<int> { 0, 0, 0, 0 };
        private List<int> _col3 = new List<int> { 0, 0, 0, 0 };
        private List<int> _col4 = new List<int> { 0, 0, 0, 0 };
        private List<int> _col5 = new List<int> { 0, 0, 0, 0 };
        private List<int> _col6 = new List<int> { 0, 0, 0, 0 };
        private List<int> _col7 = new List<int> { 0, 0, 0, 0 };
        private List<int> _col8 = new List<int> { 0, 0, 0, 0 };
        private List<int> _totalsneeded = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0,0,0 };
        private List<int> _totalsgot = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private List<bool> _plus1 = new List<bool> { false, false, false, false };
        private List<bool> _plus2 = new List<bool> { false, false, false, false };
        private List<bool> _plus3 = new List<bool> { false, false, false, false };
        private List<bool> _plus4 = new List<bool> { false, false, false, false };
        private List<bool> _plus5 = new List<bool> { false, false, false, false };
        private List<bool> _plus6 = new List<bool> { false, false, false, false };
        private List<bool> _plus7 = new List<bool> { false, false, false, false };
        private List<bool> _plus8 = new List<bool> { false, false, false, false };
        private int nNumber;
        private int mnA, mnB;
        private int mnItem;
        private int mnWin = 0;

        private void fCheck(int nMargin)
        {
            int nValue = _totalsgot[mnItem - 1];
            bool bFound = false;

            for (int i = 1; i <= 10; i++)
            {
                if (nValue - _totalsgot[i - 1]<=nMargin)
                {
                    bFound = true;
                    goto endlabel;
                }
            }

        endlabel:;
            if (bFound)
            {
                mnWin += 1;
                MessageBox.Show("You win", "Win" + Convert.ToString(mnWin));
                fReset();
            }
        }
        private void fGo()
        {
            Random rnd1 = new Random();
            int nAdd = rnd1.Next(1, 20);
            int nValue;

            nNumber = rnd1.Next(1, 10);
            switch (mnB)
            {
                case 1:
                    nValue = _col1[mnA - 1];
                    if (_plus1[mnA - 1])
                    {
                        nValue += nAdd;
                    }
                    else
                    {
                        nValue -= nAdd;
                    }
                    _col1[mnA - 1] = nValue;
                    if (nNumber <= 5)
                    {
                        _plus1[mnA - 1] = true;
                    }
                    else
                    {
                        _plus1[mnA - 1] = false;
                    }
                    break;
                case 2:
                    nValue = _col2[mnA - 1];
                    if (_plus2[mnA - 1])
                    {
                        nValue += nAdd;
                    }
                    else
                    {
                        nValue -= nAdd;
                    }
                    _col2[mnA - 1] = nValue;
                    if (nNumber <= 5)
                    {
                        _plus2[mnA - 1] = true;
                    }
                    else
                    {
                        _plus2[mnA - 1] = false;
                    }
                    break;
                case 3:
                    nValue = _col3[mnA - 1];
                    if (_plus3[mnA - 1])
                    {
                        nValue += nAdd;
                    }
                    else
                    {
                        nValue -= nAdd;
                    }
                    _col3[mnA - 1] = nValue;
                    if (nNumber <= 5)
                    {
                        _plus3[mnA - 1] = true;
                    }
                    else
                    {
                        _plus3[mnA - 1] = false;
                    }
                    break;
                case 4:
                    nValue = _col4[mnA - 1];
                    if (_plus4[mnA - 1])
                    {
                        nValue += nAdd;
                    }
                    else
                    {
                        nValue -= nAdd;
                    }
                    _col4[mnA - 1] = nValue;
                    if (nNumber <= 5)
                    {
                        _plus4[mnA - 1] = true;
                    }
                    else
                    {
                        _plus4[mnA - 1] = false;
                    }
                    break;
                case 5:
                    nValue = _col5[mnA - 1];
                    if (_plus5[mnA - 1])
                    {
                        nValue += nAdd;
                    }
                    else
                    {
                        nValue -= nAdd;
                    }
                    _col5[mnA - 1] = nValue;
                    if (nNumber <= 5)
                    {
                        _plus5[mnA - 1] = true;
                    }
                    else
                    {
                        _plus5[mnA - 1] = false;
                    }
                    break;
                case 6:
                    nValue = _col6[mnA - 1];
                    if (_plus6[mnA - 1])
                    {
                        nValue += nAdd;
                    }
                    else
                    {
                        nValue -= nAdd;
                    }
                    _col6[mnA - 1] = nValue;
                    if (nNumber <= 5)
                    {
                        _plus6[mnA - 1] = true;
                    }
                    else
                    {
                        _plus6[mnA - 1] = false;
                    }
                    break;
                case 7:
                    nValue = _col7[mnA - 1];
                    if (_plus7[mnA - 1])
                    {
                        nValue += nAdd;
                    }
                    else
                    {
                        nValue -= nAdd;
                    }
                    _col7[mnA - 1] = nValue;
                    if (nNumber <= 5)
                    {
                        _plus7[mnA - 1] = true;
                    }
                    else
                    {
                        _plus7[mnA - 1] = false;
                    }
                    break;
                default:
                    nValue = _col1[mnA - 1];
                    if (_plus8[mnA - 1])
                    {
                        nValue += nAdd;
                    }
                    else
                    {
                        nValue -= nAdd;
                    }
                    _col8[mnA - 1] = nValue;
                    if (nNumber <= 5)
                    {
                        _plus8[mnA - 1] = true;
                    }
                    else
                    {
                        _plus8[mnA - 1] = false;
                    }
                    break;
            }

            fUpdateDisplay();
        }

        private void fUpdateList()
        {
            int nTotal = 0;
            String sText = null;

            if (lst2.Items.Count > 0)
            {
                do
                {
                    lst2.Items.RemoveAt(0);
                } while (lst2.Items.Count > 0);
            }

            nTotal = _col1[0] + _col2[0] + _col3[0] + _col4[0] + _col5[0] + _col6[0] + _col7[0] + _col8[0];
            _totalsgot[0] = nTotal;
            nTotal = _col1[1] + _col2[1] + _col3[1] + _col4[1] + _col5[1] + _col6[1] + _col7[1] + _col8[1];
            _totalsgot[1] = nTotal;
            nTotal = _col1[2] + _col2[2] + _col3[2] + _col4[2] + _col5[2] + _col6[2] + _col7[2] + _col8[2];
            _totalsgot[2] = nTotal;
            nTotal = _col1[3] + _col2[3] + _col3[3] + _col4[3] + _col5[3] + _col6[3] + _col7[3] + _col8[3];
            _totalsgot[3] = nTotal;
            nTotal = 0;
            for (int i = 1; i <= 4; i++)
            {
                 nTotal += _col1[i - 1];
            }
            _totalsgot[4] = nTotal;
            nTotal = 0;
            for (int i = 1; i <= 4; i++)
            {
                nTotal += _col2[i - 1];
            }
            _totalsgot[5] = nTotal;
            nTotal = 0;
            for (int i = 1; i <= 4; i++)
            {
                nTotal += _col3[i - 1];
            }
            _totalsgot[6] = nTotal;
            nTotal = 0;
            for (int i = 1; i <= 4; i++)
            {
                nTotal += _col4[i - 1];
            }
            _totalsgot[7] = nTotal;
            nTotal = 0;
            for (int i = 1; i <= 4; i++)
            {
                nTotal += _col5[i - 1];
            }
            _totalsgot[8] = nTotal;
            nTotal = 0;
            for (int i = 1; i <= 4; i++)
            {
                nTotal += _col6[i - 1];
            }
            _totalsgot[9] = nTotal;
            nTotal = 0;
            for (int i = 1; i <= 4; i++)
            {
                nTotal += _col7[i - 1];
            }
            _totalsgot[10] = nTotal;
            nTotal = 0;
            for (int i = 1; i <= 4; i++)
            {
                nTotal += _col8[i - 1];
            }
            _totalsgot[11] = nTotal;

            sText = "A1 =" + Convert.ToString(_totalsgot[0]);
            lst2.Items.Add(sText);
            sText = "A2 =" + Convert.ToString(_totalsgot[1]);
            lst2.Items.Add(sText);
            sText = "A3 =" + Convert.ToString(_totalsgot[2]);
            lst2.Items.Add(sText);
            sText = "A4 =" + Convert.ToString(_totalsgot[3]);
            lst2.Items.Add(sText);
            sText = "B1 =" + Convert.ToString(_totalsgot[4]);
            lst2.Items.Add(sText);
            sText = "B2 =" + Convert.ToString(_totalsgot[5]);
            lst2.Items.Add(sText);
            sText = "B3 =" + Convert.ToString(_totalsgot[6]);
            lst2.Items.Add(sText);
            sText = "B4 =" + Convert.ToString(_totalsgot[7]);
            lst2.Items.Add(sText);
            sText = "B5 =" + Convert.ToString(_totalsgot[8]);
            lst2.Items.Add(sText);
            sText = "B6 =" + Convert.ToString(_totalsgot[9]);
            lst2.Items.Add(sText);
            sText = "B7 =" + Convert.ToString(_totalsgot[10]);
            lst2.Items.Add(sText);
            sText = "B8 =" + Convert.ToString(_totalsgot[11]);
            lst2.Items.Add(sText);

        }

      private void fUpdateStatus()
        {
            btnA1.Text = "A1";
            btnA2.Text = "A2";
            btnA3.Text = "A3";
            btnA4.Text = "A4";
            btnB1.Text = "B1";
            btnB2.Text = "B2";
            btnB3.Text = "B3";
            btnB4.Text = "B4";
            btnB5.Text = "B5";
            btnB6.Text = "B6";
            btnB7.Text = "B7";
            btnB8.Text = "B8";

            switch (mnA)
            {
                case 1:
                    btnA1.Text = "[A1]";
                    break;
                case 2:
                    btnA2.Text = "[A2]";
                    break;
                case 3:
                    btnA3.Text = "[A3]";
                    break;
                default:
                    btnA4.Text = "[A4]";
                    break;
            }
            switch (mnB)
            {
                case 1:
                    btnB1.Text = "[B1]";
                    break;
                case 2:
                    btnB2.Text = "[B2]";
                    break;
                case 3:
                    btnB3.Text = "[B3]";
                    break;
                case 4:
                    btnB4.Text = "[B4]";
                    break;
                case 5:
                    btnB5.Text = "[B5]";
                    break;
                case 6:
                    btnB6.Text = "[B6]";
                    break;
                case 7:
                    btnB7.Text = "[B7]";
                    break;
                default:
                    btnB8.Text = "[B8]";
                    break;
            }
        }

        private void fReset()
        {
            Random rnd1 = new Random();

            mnA = rnd1.Next(1, 5);
            mnB = rnd1.Next(1, 9);
            mnItem = rnd1.Next(1, 13);

            for (int i = 1; i <= 4; i++)
            {
                _col1[i - 1] = rnd1.Next(1, 101);
                _col2[i - 1] = rnd1.Next(1, 101);
                _col3[i - 1] = rnd1.Next(1, 101);
                _col4[i - 1] = rnd1.Next(1, 101);
                _col5[i - 1] = rnd1.Next(1, 101);
                _col6[i - 1] = rnd1.Next(1, 101);
                _col7[i - 1] = rnd1.Next(1, 101);
                _col8[i - 1] = rnd1.Next(1, 101);
                nNumber = rnd1.Next(1, 10);
                if (nNumber <= 5)
                {
                    _plus1[i - 1] = true;
                }
                else
                {
                    _plus1[i - 1] = false;
                }
                nNumber = rnd1.Next(1, 10);
                if (nNumber <= 5)
                {
                    _plus2[i - 1] = true;
                }
                else
                {
                    _plus2[i - 1] = false;
                }
                nNumber = rnd1.Next(1, 10);
                if (nNumber <= 5)
                {
                    _plus3[i - 1] = true;
                }
                else
                {
                    _plus3[i - 1] = false;
                }
                nNumber = rnd1.Next(1, 10);
                if (nNumber <= 5)
                {
                    _plus4[i - 1] = true;
                }
                else
                {
                    _plus4[i - 1] = false;
                }
                nNumber = rnd1.Next(1, 10);
                if (nNumber <= 5)
                {
                    _plus5[i - 1] = true;
                }
                else
                {
                    _plus5[i - 1] = false;
                }
                nNumber = rnd1.Next(1, 10);
                if (nNumber <= 5)
                {
                    _plus6[i - 1] = true;
                }
                else
                {
                    _plus6[i - 1] = false;
                }
                nNumber = rnd1.Next(1, 10);
                if (nNumber <= 5)
                {
                    _plus7[i - 1] = true;
                }
                else
                {
                    _plus7[i - 1] = false;
                }
                nNumber = rnd1.Next(1, 10);
                if (nNumber <= 5)
                {
                    _plus8[i - 1] = true;
                }
                else
                {
                    _plus8[i - 1] = false;
                }
            }

            if (lst1.Items.Count > 0)
            {
                do
                {
                    lst1.Items.RemoveAt(0);
                } while (lst1.Items.Count > 0);
            }
            for(int i = 1; i <= 10; i++)
            {
                _totalsneeded[i - 1] = rnd1.Next(1, 401);
                lst1.Items.Add(Convert.ToString(_totalsneeded[i - 1]));
            }

            fUpdateList();
            fUpdateDisplay();
            fUpdateStatus();
        }

        private void fUpdateDisplay()
        {
            String sText = null;

            //1
            sText = Convert.ToString(_col1[0]);
            if (_plus1[0])
            {
                sText = sText + "+";
            }
            else
            {
                sText = sText + "-";
            }
            lbl11.Text = sText;
            sText = Convert.ToString(_col1[1]);
            if (_plus1[1])
            {
                sText = sText + "+";
            }
            else
            {
                sText = sText + "-";
            }
            lbl12.Text = sText;
            sText = Convert.ToString(_col1[2]);
            if (_plus1[2])
            {
                sText = sText + "+";
            }
            else
            {
                sText = sText + "-";
            }
            lbl13.Text = sText;
            sText = Convert.ToString(_col1[3]);
            if (_plus1[3])
            {
                sText = sText + "+";
            }
            else
            {
                sText = sText + "-";
            }
            lbl14.Text = sText;

            //2
            sText = Convert.ToString(_col2[0]);
            if (_plus2[0])
            {
                sText = sText + "+";
            }
            else
            {
                sText = sText + "-";
            }
            lbl21.Text = sText;
            sText = Convert.ToString(_col2[1]);
            if (_plus2[1])
            {
                sText = sText + "+";
            }
            else
            {
                sText = sText + "-";
            }
            lbl22.Text = sText;
            sText = Convert.ToString(_col2[2]);
            if (_plus2[2])
            {
                sText = sText + "+";
            }
            else
            {
                sText = sText + "-";
            }
            lbl23.Text = sText;
            sText = Convert.ToString(_col2[3]);
            if (_plus2[3])
            {
                sText = sText + "+";
            }
            else
            {
                sText = sText + "-";
            }
            lbl24.Text = sText;


            //3
            sText = Convert.ToString(_col3[0]);
            if (_plus3[0])
            {
                sText = sText + "+";
            }
            else
            {
                sText = sText + "-";
            }
            lbl31.Text = sText;
            sText = Convert.ToString(_col3[1]);
            if (_plus3[1])
            {
                sText = sText + "+";
            }
            else
            {
                sText = sText + "-";
            }
            lbl32.Text = sText;
            sText = Convert.ToString(_col3[2]);
            if (_plus3[2])
            {
                sText = sText + "+";
            }
            else
            {
                sText = sText + "-";
            }
            lbl33.Text = sText;
            sText = Convert.ToString(_col3[3]);
            if (_plus3[3])
            {
                sText = sText + "+";
            }
            else
            {
                sText = sText + "-";
            }
            lbl34.Text = sText;


            //4
            sText = Convert.ToString(_col4[0]);
            if (_plus4[0])
            {
                sText = sText + "+";
            }
            else
            {
                sText = sText + "-";
            }
            lbl41.Text = sText;
            sText = Convert.ToString(_col4[1]);
            if (_plus4[1])
            {
                sText = sText + "+";
            }
            else
            {
                sText = sText + "-";
            }
            lbl42.Text = sText;
            sText = Convert.ToString(_col4[2]);
            if (_plus4[2])
            {
                sText = sText + "+";
            }
            else
            {
                sText = sText + "-";
            }
            lbl43.Text = sText;
            sText = Convert.ToString(_col4[3]);
            if (_plus4[3])
            {
                sText = sText + "+";
            }
            else
            {
                sText = sText + "-";
            }
            lbl44.Text = sText;


            //5
            sText = Convert.ToString(_col5[0]);
            if (_plus5[0])
            {
                sText = sText + "+";
            }
            else
            {
                sText = sText + "-";
            }
            lbl51.Text = sText;
            sText = Convert.ToString(_col5[1]);
            if (_plus5[1])
            {
                sText = sText + "+";
            }
            else
            {
                sText = sText + "-";
            }
            lbl52.Text = sText;
            sText = Convert.ToString(_col5[2]);
            if (_plus5[2])
            {
                sText = sText + "+";
            }
            else
            {
                sText = sText + "-";
            }
            lbl53.Text = sText;
            sText = Convert.ToString(_col5[3]);
            if (_plus5[3])
            {
                sText = sText + "+";
            }
            else
            {
                sText = sText + "-";
            }
            lbl54.Text = sText;


            //6
            sText = Convert.ToString(_col6[0]);
            if (_plus6[0])
            {
                sText = sText + "+";
            }
            else
            {
                sText = sText + "-";
            }
            lbl61.Text = sText;
            sText = Convert.ToString(_col6[1]);
            if (_plus6[1])
            {
                sText = sText + "+";
            }
            else
            {
                sText = sText + "-";
            }
            lbl62.Text = sText;
            sText = Convert.ToString(_col6[2]);
            if (_plus6[2])
            {
                sText = sText + "+";
            }
            else
            {
                sText = sText + "-";
            }
            lbl63.Text = sText;
            sText = Convert.ToString(_col6[3]);
            if (_plus6[3])
            {
                sText = sText + "+";
            }
            else
            {
                sText = sText + "-";
            }
            lbl64.Text = sText;


            //7
            sText = Convert.ToString(_col7[0]);
            if (_plus7[0])
            {
                sText = sText + "+";
            }
            else
            {
                sText = sText + "-";
            }
            lbl71.Text = sText;
            sText = Convert.ToString(_col7[1]);
            if (_plus7[1])
            {
                sText = sText + "+";
            }
            else
            {
                sText = sText + "-";
            }
            lbl72.Text = sText;
            sText = Convert.ToString(_col7[2]);
            if (_plus7[2])
            {
                sText = sText + "+";
            }
            else
            {
                sText = sText + "-";
            }
            lbl73.Text = sText;
            sText = Convert.ToString(_col7[3]);
            if (_plus7[3])
            {
                sText = sText + "+";
            }
            else
            {
                sText = sText + "-";
            }
            lbl74.Text = sText;


            //8
            sText = Convert.ToString(_col8[0]);
            if (_plus8[0])
            {
                sText = sText + "+";
            }
            else
            {
                sText = sText + "-";
            }
            lbl81.Text = sText;
            sText = Convert.ToString(_col8[1]);
            if (_plus8[1])
            {
                sText = sText + "+";
            }
            else
            {
                sText = sText + "-";
            }
            lbl82.Text = sText;
            sText = Convert.ToString(_col8[2]);
            if (_plus8[2])
            {
                sText = sText + "+";
            }
            else
            {
                sText = sText + "-";
            }
            lbl83.Text = sText;
            sText = Convert.ToString(_col8[3]);
            if (_plus8[3])
            {
                sText = sText + "+";
            }
            else
            {
                sText = sText + "-";
            }
            lbl84.Text = sText;




        }

        public fSub3()
        {
            InitializeComponent();
        }

        private void fSub3_Load(object sender, EventArgs e)
        {
            fReset();
        }

        private void btnQNext_Click(object sender, EventArgs e)
        {
            fReset();
        }

        private void btnA1_Click(object sender, EventArgs e)
        {
            mnA = 1;
            fUpdateStatus();
        }

        private void btnA2_Click(object sender, EventArgs e)
        {
            mnA = 2;
            fUpdateStatus();

        }

        private void btnA3_Click(object sender, EventArgs e)
        {
            mnA = 3;
            fUpdateStatus();

        }

        private void btnA4_Click(object sender, EventArgs e)
        {
            mnA = 4;
            fUpdateStatus();

        }

        private void btnB1_Click(object sender, EventArgs e)
        {
            mnB = 1;
            fUpdateStatus();

        }

        private void btnB2_Click(object sender, EventArgs e)
        {
            mnB = 2;
            fUpdateStatus();

        }

        private void btnB3_Click(object sender, EventArgs e)
        {
            mnB = 3;
            fUpdateStatus();

        }

        private void btnB4_Click(object sender, EventArgs e)
        {
            mnB = 4;
            fUpdateStatus();

        }

        private void btnB5_Click(object sender, EventArgs e)
        {
            mnB = 5;
            fUpdateStatus();

        }

        private void btnB6_Click(object sender, EventArgs e)
        {
            mnB = 6;
            fUpdateStatus();

        }

        private void btnB7_Click(object sender, EventArgs e)
        {
            mnB = 7;
            fUpdateStatus();

        }

        private void btnB8_Click(object sender, EventArgs e)
        {
            mnB = 8;
            fUpdateStatus();

        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            fGo();
        }

        private void lst2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lst2_Click(object sender, EventArgs e)
        {
            mnItem = lst2.SelectedIndex - 1;
        }

        private void btnCheck5_Click(object sender, EventArgs e)
        {
            fCheck(5);
        }

        private void btnCheck10_Click(object sender, EventArgs e)
        {
            fCheck(10);
        }

        private void btnUpdateList_Click(object sender, EventArgs e)
        {
            fUpdateList();
        }
    }
}
