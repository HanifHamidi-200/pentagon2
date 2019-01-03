using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QEDIT
{
    public partial class Form1 : Form
    {
        private String msShuffle;
        private String msShuffle2;
        private int nNumber;

        private void fReset()
        {
            Random rnd1 = new Random();
            int nType;

            msShuffle = "1234567";
            msShuffle2 = null;

            for (int i = 1; i <= 7; i++)
            {
                nType = rnd1.Next(1, 4);
                switch (nType)
                {
                    case 1:
                        msShuffle2 = msShuffle2 + "0";
                        break;
                    case 2:
                        msShuffle2 = msShuffle2 + "1";
                        break;
                    default:
                        msShuffle2 = msShuffle2 + "k";
                        break;
                }
            }

            fUpdateDisplay();
        }

        private void fUpdateDisplay()
        {
            lbl1.Text = msShuffle2.Substring(0,1);
            lbl2.Text = msShuffle2.Substring(1, 1);
            lbl3.Text = msShuffle2.Substring(2, 1);
            lbl4.Text = msShuffle2.Substring(3, 1); 
            lbl5.Text = msShuffle2.Substring(4, 1);
            lbl6.Text = msShuffle2.Substring(5, 1);
            lbl7.Text = msShuffle2.Substring(6, 1);

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
    }
}
