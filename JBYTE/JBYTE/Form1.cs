using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JBYTE
{
    public partial class Form1 : Form
    {
        private int mnLength;
        private String msRecords;
        private String msLetter1, msLetter2;
        private int mnPos;

        private String fLetter(String sAlready)
        {
            Random rnd1 = new Random();
            String sBuffer = "ABCEDEF";
            int nPos;
            String sLetter;

            if (sAlready == null)
            {
                nPos = rnd1.Next(1, 7);
                sLetter = sBuffer.Substring(nPos - 1, 1);
            }
            else
            {
                do
                {
                    nPos = rnd1.Next(1, 7);
                    sLetter = sBuffer.Substring(nPos - 1, 1);
                } while (sLetter == sAlready);
            }

            return sLetter;
        }

        private void fReset()
        {
            Random rnd1 = new Random();
            String sThree;
            int nPos;
            int nLength;
            String sExtra;

            mnLength = rnd1.Next(12, 31);
            msRecords = null;
            msLetter1 = fLetter(null);
            msLetter2 = fLetter(msLetter1);
                
            for (int i = 1; i <= mnLength; i++)
            {
                sThree = Convert.ToString(i);
                if (sThree.Length == 1)
                {
                    sThree = "00" + sThree;
                }
                else
                {
                    sThree = "0" + sThree;
                }
                msRecords = msRecords + sThree;
            }

            nPos = 0;
            nLength = 0;
            mnPos = 2;
            sExtra = null;
            do
            {
                nPos += 1;
                if (nLength == 0)
                {
                    nLength = rnd1.Next(1, 5);
                    sExtra = fSwap();
                }
                nLength -= 1;
                sThree = fData(nPos);
                sThree = sExtra + sThree.Substring(1, 2);
                fPlace(nPos, sThree);
            } while (nPos < mnLength);

            fUpdateDisplay();
        }

        private void fUpdateDisplay()
        {
            String sData;
            String sThree;
            String sLetter;

                if (lstData.Items.Count > 0)
            {
                do
                {
                    lstData.Items.RemoveAt(0);
                } while (lstData.Items.Count > 0);
            }
            if (lst1.Items.Count > 0)
            {
                do
                {
                    lst1.Items.RemoveAt(0);
                } while (lst1.Items.Count > 0);
            }
            if (lst2.Items.Count > 0)
            {
                do
                {
                    lst2.Items.RemoveAt(0);
                } while (lst2.Items.Count > 0);
            }
            if (lst3.Items.Count > 0)
            {
                do
                {
                    lst3.Items.RemoveAt(0);
                } while (lst3.Items.Count > 0);
            }

            for (int i = 1; i <= mnLength; i++)
            {
                sData = fData(i);
                lstData.Items.Add(sData);
            }

            for (int i = 1; i <= mnLength; i++)
            {
                sThree = fData(i);
                sLetter = sThree.Substring(0, 1);
                if (sLetter == msLetter1)
                {
                    lst1.Items.Add(sThree);
                }
                else
                {
                    lst2.Items.Add(sThree);
                }
            }
        }
        private String fData(int nPos)
        {
            String sData = msRecords.Substring(nPos * 3 - 3, 3);
            return sData;
        }

        private void fPlace(int nPos,String sData)
        {
            msRecords = msRecords.Substring(0, nPos * 3 - 3) + sData + msRecords.Substring(nPos * 3, (mnLength - nPos) * 3);
        }
        private String fSwap()
        {
            if (mnPos == 1)
            {
                mnPos = 2;
                return msLetter2;
            }
            else
            {
                mnPos = 1;
                return msLetter1;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void btnQNext_Click(object sender, EventArgs e)
        {
            fReset();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            lst3.Items.Add(txtAdd.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fReset();
        }
    }
}
