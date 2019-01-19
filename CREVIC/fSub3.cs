using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CREVIC
{
    public partial class fSub3 : Form
    {
        private List<String> _text1 = new List<string> { null, null, null, null, null, null, null, null, null, null, null, null };
        private List<String> _text2 = new List<string> { null, null, null, null, null, null, null, null, null, null, null, null };
        private List<String> _text3 = new List<string> { null, null, null, null, null };
        private List<int> _colour1 = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private List<int> _colour2 = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private List<int> _colour3 = new List<int> { 0, 0, 0, 0, 0 };
        private Color c = new Color();

        private void fColour(int nMode)
        {
            switch (nMode)
            {
                case 1:
                    c = Color.LightPink;
                    break;
                case 2:
                    c = Color.CornflowerBlue;
                    break;
                case 3:
                    c = Color.DarkGoldenrod;
                    break;
                default:
                    c = Color.Olive;
                    break;
            }
        }

        private String fName()
        {
            Random rnd1 = new Random();
            String sLetter = Convert.ToString((char)(rnd1.Next(1, 27) + 64));
            int nValue = rnd1.Next(1, 401);

            sLetter = sLetter + Convert.ToString(nValue);
            return sLetter;
        }
        private void fReset()
        {
            Random rnd1 = new Random();

            for (int i = 1; i <= 12; i++)
            {
                _text1[i - 1] = fName();
            }
            for (int i = 1; i <= 12; i++)
            {
                _text2[i - 1] = fName();
            }
            for (int i = 1; i <= 5; i++)
            {
                _text3[i - 1] = fName();
            }

            for (int i = 1; i <= 12; i++)
            {
                _colour1[i - 1] = rnd1.Next(1, 5);
            }
            for (int i = 1; i <= 12; i++)
            {
                _colour2[i - 1] = rnd1.Next(1, 5);
            }
            for (int i = 1; i <= 5; i++)
            {
                _colour3[i - 1] = rnd1.Next(1, 5);
            }

            fUpdateDisplay();

        }

        private void fUpdateDisplay()
        {
            txta1.Text = _text1[0];
            txta2.Text = _text1[1];
            txta3.Text = _text1[2];
            txta4.Text = _text1[3];
            txta5.Text = _text1[4];
            txta6.Text = _text1[5];
            txta7.Text = _text1[6];
            txta8.Text = _text1[7];
            txta9.Text = _text1[8];
            txta10.Text = _text1[9];
            txta11.Text = _text1[10];
            txta12.Text = _text1[10];

            txtb1.Text = _text2[0];
            txtb2.Text = _text2[1];
            txtb3.Text = _text2[2];
            txtb4.Text = _text2[3];
            txtb5.Text = _text2[4];
            txtb6.Text = _text2[5];
            txtb7.Text = _text2[6];
            txtb8.Text = _text2[7];
            txtb9.Text = _text2[8];
            txtb10.Text = _text2[9];
            txtb11.Text = _text2[10];
            txtvb12.Text = _text2[10];

            txtc1.Text = _text3[0];
            txtc2.Text = _text3[1];
            txtc3.Text = _text3[2];
            txtc4.Text = _text3[3];
            txtc5.Text = _text3[4];

            fColour(_colour1[0]);
            txta1.BackColor = c;
            fColour(_colour1[1]);
            txta2.BackColor = c;
            fColour(_colour1[2]);
            txta3.BackColor = c;
            fColour(_colour1[3]);
            txta4.BackColor = c;
            fColour(_colour1[4]);
            txta5.BackColor = c;
            fColour(_colour1[5]);
            txta6.BackColor = c;
            fColour(_colour1[6]);
            txta7.BackColor = c;
            fColour(_colour1[7]);
            txta8.BackColor = c;
            fColour(_colour1[8]);
            txta9.BackColor = c;
            fColour(_colour1[9]);
            txta10.BackColor = c;
            fColour(_colour1[10]);
            txta11.BackColor = c;
            fColour(_colour1[11]);
            txta12.BackColor = c;

            fColour(_colour2[0]);
            txtb1.BackColor = c;
            fColour(_colour2[1]);
            txtb2.BackColor = c;
            fColour(_colour2[2]);
            txtb3.BackColor = c;
            fColour(_colour2[3]);
            txtb4.BackColor = c;
            fColour(_colour2[4]);
            txtb5.BackColor = c;
            fColour(_colour2[5]);
            txtb6.BackColor = c;
            fColour(_colour2[6]);
            txtb7.BackColor = c;
            fColour(_colour2[7]);
            txtb8.BackColor = c;
            fColour(_colour2[8]);
            txtb9.BackColor = c;
            fColour(_colour2[9]);
            txtb10.BackColor = c;
            fColour(_colour2[10]);
            txtb11.BackColor = c;
            fColour(_colour2[11]);
            txtvb12.BackColor = c;

            fColour(_colour3[0]);
            txtc1.BackColor = c;
            fColour(_colour3[1]);
            txtc2.BackColor = c;
            fColour(_colour3[2]);
            txtc3.BackColor = c;
            fColour(_colour3[3]);
            txtc4.BackColor = c;
            fColour(_colour3[4]);
            txtc5.BackColor = c;

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
    }
}
