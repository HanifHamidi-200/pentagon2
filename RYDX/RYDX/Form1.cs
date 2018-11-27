using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RYDX
{
    public partial class Form1 : Form
    {
        private String msList1, msList2,msList3,msList4,msList5,msList6, msListEvent;
        private int nNumber;
        private List<String> _col1 = new List<string> { null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null };
        private List<String> _col2 = new List<string> { null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null };
        private List<String> _col3 = new List<string> { null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null };
        private List<String> _col4 = new List<string> { null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null };
        private List<String> _col5 = new List<string> { null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null };
        private List<String> _col6 = new List<string> { null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null };
        private int mnPos;
        private String msGoto1, msGoto2;
        private int mnWin = 0,mnLose=0;
        private String msItem;
 
        private String fFill(String sLetter)
        {
            String sTwo,sThree;
            String sReturn = null;

            for (int i = 1; i <= 30; i++){
                sTwo = Convert.ToString(i);
                if (sTwo.Length == 1)
                {
                    sTwo = "0" + sTwo;
                }
                sThree= sLetter + sTwo;
                sReturn = sReturn + sThree;
            }

            return sReturn;
        }

        private void fUpdateDisplay()
        {
            String sItem;

            if (lstRoomsOutput.Items.Count != 0)
            {
                do
                {
                    lstRoomsOutput.Items.RemoveAt(0);
                } while (lstRoomsOutput.Items.Count != 0);
            }

            for (int i = 1; i <= 30; i++)
            {
                sItem = _col1[i - 1] + "  " + _col2[i - 1] + "  " + _col3[i - 1] + "  " + _col4[i - 1] + "  " + _col5[i - 1] + "  " + _col6[i - 1];
                lstRoomsOutput.Items.Add(sItem);
            }

        }
        private void fReset()
        {
            Random rnd1 = new Random();
            String sLetter1=null, sLetter2=null;
            String sLetter3 = null, sLetter4 = null;
            String sLetter5 = null, sLetter6 = null;
            bool bFound = false;
            int nPot = 1;
            int nCount;
            String sItem;
            String sTwo;
        
            sLetter1 = "A";
            sLetter2 = "B";
            sLetter3 = "C";
            sLetter4 = "D";
            sLetter5 = "E";
            sLetter6 = "F";

            msList1 = fFill(sLetter1);
            msList2 = fFill(sLetter2);
            msList3 = fFill(sLetter3);
            msList4 = fFill(sLetter4);
            msList5 = fFill(sLetter5);
            msList6 = fFill(sLetter6);
            msListEvent = null;

            for(int i = 1; i <= 30; i++)
            {
                _col1[i - 1] = "UU";
                _col2[i - 1] = "UU";
                _col3[i - 1] = "UU";
                _col4[i - 1] = "UU";
                _col5[i - 1] = "UU";
                _col6[i - 1] = "UU";

            }

             if (lstEventsList.Items.Count != 0)
            {
                do
                {
                    lstEventsList.Items.RemoveAt(0);
                } while (lstEventsList.Items.Count != 0);
            }

            do
            {
                nCount = rnd1.Next(1, 7);
                switch (nPot)
                {
                    case 1:
                        if (msList1 == "")
                        {
                            bFound = true;
                        }
                        else
                        {
                            sItem = fTake(ref msList1);
                            sTwo = sItem.Substring(1, 2);
                            nNumber = Convert.ToInt32(sTwo);
                            lstEventsList.Items.Add(sLetter1+sItem);
                            _col1[nNumber - 1] = sLetter1 + sItem;
                            msListEvent = msListEvent + sItem;
                          }
                        nPot = 2;
                        break;
                    case 2:
                        if (msList2 == "")
                        {
                            bFound = true;
                        }
                        else
                        {
                            sItem = fTake(ref msList2);
                            sTwo = sItem.Substring(1, 2);
                            nNumber = Convert.ToInt32(sTwo);
                            lstEventsList.Items.Add(sLetter2 + sItem);
                            _col2[nNumber - 1] = sLetter2 + sItem;
                            msListEvent = msListEvent + sItem;
                        }
                        nNumber = rnd1.Next(1, 10);
                        if (nNumber <= 5)
                        {
                            nPot = 1;
                        }
                        else
                        {
                            nPot = 3;
                        }
                        break;
                    case 3:
                        if (msList3 == "")
                        {
                            bFound = true;
                        }
                        else
                        {
                            sItem = fTake(ref msList3);
                            sTwo = sItem.Substring(1, 2);
                            nNumber = Convert.ToInt32(sTwo);
                            lstEventsList.Items.Add(sLetter3 + sItem);
                            _col3[nNumber - 1] = sLetter3 + sItem;
                            msListEvent = msListEvent + sItem;
                        }
                        nNumber = rnd1.Next(1, 10);
                        if (nNumber <= 5)
                        {
                            nPot = 2;
                        }
                        else
                        {
                            nPot = 4;
                        }
                        break;
                    case 4:
                        if (msList4 == "")
                        {
                            bFound = true;
                        }
                        else
                        {
                            sItem = fTake(ref msList4);
                            sTwo = sItem.Substring(1, 2);
                            nNumber = Convert.ToInt32(sTwo);
                            lstEventsList.Items.Add(sLetter4 + sItem);
                            _col4[nNumber - 1] = sLetter4 + sItem;
                            msListEvent = msListEvent + sItem;
                        }
                        nNumber = rnd1.Next(1, 10);
                        if (nNumber <= 5)
                        {
                            nPot = 3;
                        }
                        else
                        {
                            nPot = 5;
                        }
                        break;
                    case 5:
                        if (msList5 == "")
                        {
                            bFound = true;
                        }
                        else
                        {
                            sItem = fTake(ref msList5);
                            sTwo = sItem.Substring(1, 2);
                            nNumber = Convert.ToInt32(sTwo);
                            lstEventsList.Items.Add(sLetter5 + sItem);
                            _col5[nNumber - 1] = sLetter5 + sItem;
                            msListEvent = msListEvent + sItem;
                        }
                        nNumber = rnd1.Next(1, 10);
                        if (nNumber <= 5)
                        {
                            nPot = 4;
                        }
                        else
                        {
                            nPot = 6;
                        }
                        break;
                    case 6:
                        if (msList6 == "")
                        {
                            bFound = true;
                        }
                        else
                        {
                            sItem = fTake(ref msList6);
                            sTwo = sItem.Substring(1, 2);
                            nNumber = Convert.ToInt32(sTwo);
                            lstEventsList.Items.Add(sLetter6 + sItem);
                            _col6[nNumber - 1] = sLetter6 + sItem;
                            msListEvent = msListEvent + sItem;
                        }
                        nNumber = rnd1.Next(1, 10);
                        nPot = 5;
                        break;
                }
            } while (bFound == false);
            
            for (int i = 1; i <= 6; i++)
            {
                fFree();
            }
            fUpdateDisplay();

            nCount = lstEventsList.Items.Count;
            mnPos = rnd1.Next(1,nCount + 1);
            sItem = msListEvent.Substring(mnPos * 3 - 3, 3);
            sTwo = sItem.Substring(1, 2);
            sItem = fData(fCol(sItem.Substring(0, 1)), Convert.ToInt32(sTwo));
            msItem = sItem;
            lblYou.Text = "You are on (" + sItem + ")";

            nNumber = mnPos + 1;
            if (nNumber > nCount)
            {
                nNumber = 1;
            }
            sItem = msListEvent.Substring(nNumber*3-3,3);
            sTwo = sItem.Substring(1, 2);
            nNumber = Convert.ToInt32(sTwo);

            msGoto1 = fData(fCol(sItem.Substring(0,1)), nNumber);
            msGoto2 = fData(fCol(sItem.Substring(0, 1)), nNumber);
            btnGoto1.Text = "goto " + msGoto1;
            btnGoto2.Text = "goto " + msGoto2;
            sItem = fFree2();
            sTwo = sItem.Substring(2, 2);
            nNumber = rnd1.Next(1, 10);
            if (nNumber <= 5)
            {
                msGoto1 = fData(fCol(sItem.Substring(0, 1)), Convert.ToInt32(sTwo));
                btnGoto1.Text = "goto " + msGoto1;
            }
            else
            {
                msGoto2 = fData(fCol(sItem.Substring(0, 1)), Convert.ToInt32(sTwo));
                btnGoto2.Text = "goto " + msGoto2;
            }
        }

        private void fGoto(String sGoto)
        {
            Random rnd1 = new Random();
            String sItem = msItem;
            String sTwo = sItem.Substring(2, 2);
            int nCount;
            int nCol = fCol(sItem.Substring(0, 1));

            if (sGoto == "[**]")
            {
                mnWin += 1;
                MessageBox.Show("You win", "Win" + Convert.ToString(mnWin));
                fReset();
                goto exitlabel;
            }

            fPut(nCol, Convert.ToInt32(sTwo), "[__]");
            if (sGoto == "[__]")
            {
                mnLose += 1;
                MessageBox.Show("You lose", "Lose" + Convert.ToString(mnLose));
                fReset();
                goto exitlabel;

            }

            nCount = lstEventsList.Items.Count;
            sItem = sGoto;
            sTwo = sItem.Substring(2, 2);
            sItem = fData(fCol(sItem.Substring(0, 1)), Convert.ToInt32(sTwo));
            msItem = sItem;
            lblYou.Text = "You are on (" + sItem + ")";
            mnPos += 1;

            nNumber = mnPos + 1;
            if (nNumber > nCount)
            {
                nNumber = 1;
            }
            sItem = msListEvent.Substring(nNumber * 3 - 3, 3);
            sTwo = sItem.Substring(1, 2);
            nNumber = Convert.ToInt32(sTwo);

            msGoto1 = fData(fCol(sItem.Substring(0, 1)), nNumber);
            msGoto2 = fData(fCol(sItem.Substring(0, 1)), nNumber);
            btnGoto1.Text = "goto " + msGoto1;
            btnGoto2.Text = "goto " + msGoto2;
            sItem = fFree2();
            if (sItem == "[__]")
            {
                msGoto1 = "[__]";
                btnGoto1.Text = "goto " + msGoto1;
            }
            else
            {
                if (sItem.Length == 3)
                {
                    sTwo = sItem.Substring(1, 2);

                }
                else
                {
                    sTwo = sItem.Substring(2, 2);

                }
                nNumber = rnd1.Next(1, 10);
                if (nNumber <= 5)
                {
                    msGoto1 = fData(fCol(sItem.Substring(0, 1)), Convert.ToInt32(sTwo));
                    btnGoto1.Text = "goto " + msGoto1;
                }
                else
                {
                    msGoto2 = fData(fCol(sItem.Substring(0, 1)), Convert.ToInt32(sTwo));
                    btnGoto2.Text = "goto " + msGoto2;
                }

            }
            fUpdateDisplay();

        exitlabel:;

        }

        private int fCol(String sCol)
        {
            switch (sCol)
            {
                case "A":
                    return 1;
                case "B":
                    return 2;
                case "C":
                    return 3;
                case "D":
                    return 4;
                case "E":
                    return 5;
               default:
                    return 6;
                    
            }
        }
        private String fFree2()
        {
            Random rnd1 = new Random();
            bool bFound = false;
            int nCol, nRow;
            String sText=null;
            String sTwo;

            do
            {
                nCol = rnd1.Next(1, 7);
                nRow = rnd1.Next(1, 30);
                if (fData(nCol, nRow) == "UU")
                {

                }
                else
                {
                    if (fData(nCol, nRow) == "[**]")
                    {
                        sTwo = Convert.ToString(nRow);
                        if (sTwo.Length == 1)
                        {
                            sTwo = "0" + sTwo;
                        }
                        switch (nCol)
                        {
                            case 1:
                                sText = "A";
                                break;
                            case 2:
                                sText = "B";
                                break;
                            case 3:
                                sText = "C";
                                break;
                            case 4:
                                sText = "D";
                                break;
                            case 5:
                                sText = "E";
                                break;
                            default:
                                sText = "F";
                                break;
                        }
                        sText = sText + sTwo;
                        return sText;
                    }
                    else
                    {
                        return fData(nCol, nRow);
                    }
                }
            } while (bFound == false);

            return null;
        }

        private void btnGoto1_Click(object sender, EventArgs e)
        {
            fGoto(msGoto1);
        }

        private void btnGoto2_Click(object sender, EventArgs e)
        {
            fGoto(msGoto2);
        }

        private void fFree()
        {
            Random rnd1 = new Random();
            bool bFound = false;
            int nCol, nRow;

            do
            {
                nCol = rnd1.Next(1, 7);
                nRow = rnd1.Next(1, 30);
                if(fData(nCol, nRow) == "UU")
                {

                }
                else
                {
                    if (fData(nCol, nRow) == "[**]")
                    {

                    }
                    else
                    {
                        fPut(nCol, nRow,"[**]");
                        bFound = true;
                    }
               }
            } while (bFound == false);
        }


        private void fPut(int nCol,int nRow,String sText)
        {
            switch (nCol)
            {
                case 1:
                    _col1[nRow - 1] = sText;
                    break;
                case 2:
                    _col2[nRow - 1] = sText;
                    break;
                case 3:
                    _col3[nRow - 1] = sText;
                    break;
                case 4:
                    _col4[nRow - 1] = sText;
                    break;
                case 5:
                    _col5[nRow - 1] = sText;
                    break;
                default:
                    _col6[nRow - 1] = sText;
                    break;

            }
        }
        private String fData(int nCol,int nRow)
        {
            switch (nCol)
            {
                case 1:
                    return _col1[nRow - 1];

                case 2:
                    return _col2[nRow - 1];
                case 3:
                    return _col3[nRow - 1];
                case 4:
                    return _col4[nRow - 1];
                case 5:
                    return _col5[nRow - 1];
                default:
                    return _col6[nRow - 1];
            }
        }
        private String fTake(ref String sBuffer)
        {
            Random rnd1 = new Random();
            int nLength = sBuffer.Length / 3;
            int nPos = rnd1.Next(1, nLength + 1);
            String sReturn;

            sReturn = sBuffer.Substring(nPos * 3 - 3, 3);
            sBuffer = sBuffer.Substring(0, nPos * 3 - 3) + sBuffer.Substring(nPos * 3, (nLength - nPos) * 3);

            return sReturn;
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
