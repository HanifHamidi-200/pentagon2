using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAUCH
{
    

    public partial class Form1 : Form
    {
        private String msType;
        private List<String> _name = new List<string> { null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null };
        private List<String> _value = new List<string> { null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null };
        private List<String> _window = new List<string> { null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null };
        private int mnCol = 0, mnRow = 0;

        private String fRow(int nRow)
        {
            switch (nRow)
            {
                case 1:
                    return "68Hz";
                case 2:
                    return "120Hz";
                case 3:
                    return "140Hz";
                case 4:
                    return "150Hz";
                case 5:
                    return "200Hz";
                case 6:
                    return "400Hz";
                case 7:
                    return "600Hz";
                default:
                    return "680Hz";

            }
        }

        private String fCol(int nCol)
        {
            switch (nCol)
            {
                case 1:
                    return "RED";
                case 2:
                    return "GREEN";
                case 3:
                    return "BLUE";
                default:
                    return "YELLOW";

            }
        }
        private void fClick(int nCol,int nRow)
        {
            String sName =fRow(nRow)+"-" + fCol(nCol);
            int nPos = (nCol - 1) * 8 + nRow;
            int nValue = Convert.ToInt32(msType.Substring(nPos-1, 1));
            String sType = fText2(nValue);
            String _sName = _name[nPos - 1];
            String _sValue = _value[nPos - 1];
            String _sWindow = _window[nPos - 1];

            fra1.Text = sName;
            lblType.Text = "TYPE = "+sType;

            mnCol = nCol;
            mnRow = nRow;

            txtName.Text = _sName;
            txtValue.Text = _sValue;
            txtWindow.Text = _sWindow;

        }

        private void fReset()
        {
            Random rnd1 = new Random();
            int nType;

            msType = null;
            for (int i = 1; i <= 32; i++)
            {
                nType = rnd1.Next(1, 5);
                msType = msType + Convert.ToString(nType);
            }

            for (int i = 1; i <= 32; i++)
            {
                _name[i - 1] = null;
                _value[i - 1] = null;
                _window[i - 1] = null;

            }
            fUpdateDisplay();
        }

        private String fText(int nValue)
        {
            switch (nValue)
            {
                case 1:
                    return "(m)";
                case 2:
                    return "(a)";
                case 3:
                    return "(e)";
                default:
                    return "(t)";
            }
        }
        private String fText2(int nValue)
        {
            switch (nValue)
            {
                case 1:
                    return "(m) module";
                case 2:
                    return "(a) ai";
                case 3:
                    return "(e) efficiency";
                default:
                    return "(t) textlibrary";
            }
        }

        private void fUpdateDisplay()
        {
            String sText;
            int nValue;

            //1
            nValue = Convert.ToInt32(msType.Substring(0, 1));
            sText = fText(nValue);
            btn11.Text = sText;
            nValue = Convert.ToInt32(msType.Substring(1, 1));
            sText = fText(nValue);
            btn12.Text = sText;
            nValue = Convert.ToInt32(msType.Substring(2, 1));
            sText = fText(nValue);
            btn13.Text = sText;
            nValue = Convert.ToInt32(msType.Substring(3, 1));
            sText = fText(nValue);
            btn14.Text = sText;
            nValue = Convert.ToInt32(msType.Substring(4, 1));
            sText = fText(nValue);
            btn15.Text = sText;
            nValue = Convert.ToInt32(msType.Substring(5, 1));
            sText = fText(nValue);
            btn16.Text = sText;
            nValue = Convert.ToInt32(msType.Substring(6, 1));
            sText = fText(nValue);
            btn17.Text = sText;
            nValue = Convert.ToInt32(msType.Substring(7, 1));
            sText = fText(nValue);
            btn18.Text = sText;


            //2
            nValue = Convert.ToInt32(msType.Substring(8, 1));
            sText = fText(nValue);
            btn21.Text = sText;
            nValue = Convert.ToInt32(msType.Substring(9, 1));
            sText = fText(nValue);
            btn22.Text = sText;
            nValue = Convert.ToInt32(msType.Substring(10, 1));
            sText = fText(nValue);
            btn23.Text = sText;
            nValue = Convert.ToInt32(msType.Substring(11, 1));
            sText = fText(nValue);
            btn24.Text = sText;
            nValue = Convert.ToInt32(msType.Substring(12, 1));
            sText = fText(nValue);
            btn25.Text = sText;
            nValue = Convert.ToInt32(msType.Substring(13, 1));
            sText = fText(nValue);
            btn26.Text = sText;
            nValue = Convert.ToInt32(msType.Substring(14, 1));
            sText = fText(nValue);
            btn27.Text = sText;
            nValue = Convert.ToInt32(msType.Substring(15, 1));
            sText = fText(nValue);
            btn28.Text = sText;

            //3
            nValue = Convert.ToInt32(msType.Substring(16, 1));
            sText = fText(nValue);
            btn31.Text = sText;
            nValue = Convert.ToInt32(msType.Substring(17, 1));
            sText = fText(nValue);
            btn32.Text = sText;
            nValue = Convert.ToInt32(msType.Substring(18, 1));
            sText = fText(nValue);
            btn33.Text = sText;
            nValue = Convert.ToInt32(msType.Substring(19, 1));
            sText = fText(nValue);
            btn34.Text = sText;
            nValue = Convert.ToInt32(msType.Substring(20, 1));
            sText = fText(nValue);
            btn35.Text = sText;
            nValue = Convert.ToInt32(msType.Substring(21, 1));
            sText = fText(nValue);
            btn36.Text = sText;
            nValue = Convert.ToInt32(msType.Substring(22, 1));
            sText = fText(nValue);
            btn37.Text = sText;
            nValue = Convert.ToInt32(msType.Substring(23, 1));
            sText = fText(nValue);
            btn38.Text = sText;


            //4
            nValue = Convert.ToInt32(msType.Substring(24, 1));
            sText = fText(nValue);
            btn41.Text = sText;
            nValue = Convert.ToInt32(msType.Substring(25, 1));
            sText = fText(nValue);
            btn42.Text = sText;
            nValue = Convert.ToInt32(msType.Substring(26, 1));
            sText = fText(nValue);
            btn43.Text = sText;
            nValue = Convert.ToInt32(msType.Substring(27, 1));
            sText = fText(nValue);
            btn44.Text = sText;
            nValue = Convert.ToInt32(msType.Substring(28, 1));
            sText = fText(nValue);
            btn45.Text = sText;
            nValue = Convert.ToInt32(msType.Substring(29, 1));
            sText = fText(nValue);
            btn46.Text = sText;
            nValue = Convert.ToInt32(msType.Substring(30, 1));
            sText = fText(nValue);
            btn47.Text = sText;
            nValue = Convert.ToInt32(msType.Substring(31, 1));
            sText = fText(nValue);
            btn48.Text = sText;


        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fReset();
        }

        private void btnQNext_Click(object sender, EventArgs e)
        {
            fReset();
        }

        private void btn11_Click(object sender, EventArgs e)
        {
            fClick(1, 1);
        }

        private void btn12_Click(object sender, EventArgs e)
        {
            fClick(1, 2);
        }

        private void btn13_Click(object sender, EventArgs e)
        {
            fClick(1, 3);
        }

        private void btn14_Click(object sender, EventArgs e)
        {
            fClick(1, 4);
        }

        private void btn15_Click(object sender, EventArgs e)
        {
            fClick(1, 5);
        }

        private void btn16_Click(object sender, EventArgs e)
        {
            fClick(1, 6);
        }

        private void btn17_Click(object sender, EventArgs e)
        {
            fClick(1, 7);
        }

        private void btn18_Click(object sender, EventArgs e)
        {
            fClick(1, 8);
        }

        private void btn21_Click(object sender, EventArgs e)
        {
            fClick(2, 1);
        }

        private void btn22_Click(object sender, EventArgs e)
        {
            fClick(2, 2);
        }

        private void btn23_Click(object sender, EventArgs e)
        {
            fClick(2, 3);
        }

        private void btn24_Click(object sender, EventArgs e)
        {
            fClick(2, 4);
        }

        private void btn25_Click(object sender, EventArgs e)
        {
            fClick(2, 5);
        }

        private void btn26_Click(object sender, EventArgs e)
        {
            fClick(2, 6);
        }

        private void btn27_Click(object sender, EventArgs e)
        {
            fClick(2, 7);
        }

        private void btn28_Click(object sender, EventArgs e)
        {
            fClick(2, 8);
        }

        private void btn31_Click(object sender, EventArgs e)
        {
            fClick(3, 1);
        }

        private void btn32_Click(object sender, EventArgs e)
        {
            fClick(3, 2);
        }

        private void btn33_Click(object sender, EventArgs e)
        {
            fClick(3, 3);
        }

        private void btn34_Click(object sender, EventArgs e)
        {
            fClick(3, 4);
        }

        private void btn35_Click(object sender, EventArgs e)
        {
            fClick(3, 5);
        }

        private void btn36_Click(object sender, EventArgs e)
        {
            fClick(3, 6);
        }

        private void btn37_Click(object sender, EventArgs e)
        {
            fClick(3, 7);
        }

        private void btn38_Click(object sender, EventArgs e)
        {
            fClick(3, 8);
        }

        private void btn41_Click(object sender, EventArgs e)
        {
            fClick(4, 1);
        }

        private void btn42_Click(object sender, EventArgs e)
        {
            fClick(4, 2);
        }

        private void btn43_Click(object sender, EventArgs e)
        {
            fClick(4, 3);
        }

        private void btn44_Click(object sender, EventArgs e)
        {
            fClick(4, 4);
        }

        private void btn45_Click(object sender, EventArgs e)
        {
            fClick(4, 5);
        }

        private void btn46_Click(object sender, EventArgs e)
        {
            fClick(4, 6);
        }

        private void btn47_Click(object sender, EventArgs e)
        {
            fClick(4, 7);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int nPos = (mnCol - 1) * 8 + mnRow;

            _name[nPos - 1] = txtName.Text;
            _value[nPos - 1] = txtValue.Text;
            _window[nPos - 1] = txtWindow.Text;
        }

        private void btn48_Click(object sender, EventArgs e)
        {
            fClick(4, 8);
        }
    }
}
