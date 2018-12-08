using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SERPO
{
    public partial class fSub1 : Form
    {
        private String msShuffle1;
        private String msShuffle2;
        private String msShuffle3;
        private List<int> _plasmacol = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private List<int> _plasmarow = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private List<int> _plasmarotate = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private int mnSerpoCol, mnSerpoRow;
        private String msPlasmaOrder;
        private int mnPercentChance=80;
        private int nNumber;
        private int mnWin = 0;

        private void fWin()
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
            mnWin += 1;
            MessageBox.Show("You win", "Win" + Convert.ToString(mnWin));
        }

        private void fDetect()
        {
            bool bFound = false;
            int nSavecol = mnSerpoCol, nSaverow = mnSerpoRow;
            int nCol=0, nRow=0;
            int nPos;
       
            for (int i = 1; i <= 8; i++)
            {
                nCol = nSavecol;
                nRow = nSaverow;
                switch (i)
                {
                    case 1:
                        nRow -= 1;
                        break;
                    case 2:
                        nCol += 1;
                        break;
                    case 3:
                        nRow += 1;
                        break;
                    case 4:
                        nCol -= 1;
                        break;
                    case 5:
                        nRow -= 2;
                        break;
                    case 6:
                        nCol += 2;
                        break;
                    case 7:
                        nRow += 2;
                        break;
                    default:
                        nCol -= 2;
                        break;
                }
                if (nCol <= 1)
                {

                }
                else
                {
                    if (nCol >= 8)
                    {

                    }
                    else
                    {
                        if (nRow <= 1)
                        {
                        }
                        else
                        {
                            if (nRow >= 8)
                            {

                            }
                            else
                            {
                                nPos = (nCol - 1) * 8 + nRow;
                                if (fPlasma(nCol, nRow))
                                {
                                    bFound = true;
                                    goto endline;

                                }
                             }
                        }
                    }
                }
            }
        endline:;
            if (bFound)
            {
                fFree(ref nCol, ref nRow);
                mnSerpoCol = nCol;
                mnSerpoRow = nRow;

                fUpdateDisplay();

            }
        }

        private bool fPlasma(int nCol,int nRow)
        {
            int nLength = 0;
            String sTwo = null;
            int nValue = 0;
      
            if (msPlasmaOrder == null)
            {
                goto endline;
            }
            nLength = msPlasmaOrder.Length / 2;
            if (nLength == 0)
            {
                goto endline;
            }
            for (int i = 1; i <= nLength; i++)
            {
                sTwo = msPlasmaOrder.Substring(i * 2 - 2, 2);
                nValue = Convert.ToInt32(sTwo);
                if (_plasmarow[nValue - 1] == mnSerpoRow)
                {
                    if (_plasmacol[nValue - 1] == mnSerpoCol)
                    {
                        return true;
                    }
                }
            }
        endline:;

            return false;
        }
        private void fAdvance()
        {
            int nLength;
            String sTwo = null;
            int nValue = 0;
            int nIndex = 0;

            do
            {
                nIndex += 1;
                if (msPlasmaOrder == null)
                {
                    goto endline;
                }
                nLength = msPlasmaOrder.Length / 2;
                if (nLength == 0)
                {
                    goto endline;
                }
                sTwo = msPlasmaOrder.Substring(nIndex * 2 - 2, 2);
                nValue = Convert.ToInt32(sTwo);
                switch (_plasmarotate[nValue - 1])
                {
                    case 1:
                         if (_plasmarow[nValue - 1] == mnSerpoRow)
                        {
                            if (_plasmacol[nValue - 1] == mnSerpoCol)
                            {
                                fUpdateDisplay();
                                fWin();
                                fReset();
                                goto endline2;
                            }
                        }
                        _plasmarow[nValue - 1] -= 1;
                        if (_plasmarow[nValue - 1] <= 1)
                        {
                            sTwo = Convert.ToString(nValue);
                            if (sTwo.Length == 1)
                            {
                                sTwo = "0" + sTwo;
                            }
                            fTakeout(sTwo);
                            nIndex -= 1;
                        }
                        break;
                    case 2:
                        if (_plasmarow[nValue - 1] == mnSerpoRow)
                        {
                            if (_plasmacol[nValue - 1] == mnSerpoCol)
                            {
                                fUpdateDisplay();
                                fWin();
                                fReset();
                                goto endline2;
                            }
                        }
                        _plasmacol[nValue - 1] += 1;
                        if (_plasmacol[nValue - 1] >= 8)
                        {
                            sTwo = Convert.ToString(nValue);
                            if (sTwo.Length == 1)
                            {
                                sTwo = "0" + sTwo;
                            }
                            fTakeout(sTwo);
                            nIndex -= 1;
                        }
                        break;
                    case 3:
                          if (_plasmarow[nValue - 1] == mnSerpoRow)
                        {
                            if (_plasmacol[nValue - 1] == mnSerpoCol)
                            {
                                fUpdateDisplay();
                                fWin();
                                fReset();
                                goto endline2;
                            }
                        }
                        _plasmarow[nValue - 1] += 1;
                        if (_plasmarow[nValue - 1] >= 8)
                        {
                            sTwo = Convert.ToString(nValue);
                            if (sTwo.Length == 1)
                            {
                                sTwo = "0" + sTwo;
                            }
                            fTakeout(sTwo);
                            nIndex -= 1;
                        }
                        break;
                    default:
                         if (_plasmarow[nValue - 1] == mnSerpoRow)
                        {
                            if (_plasmacol[nValue - 1] == mnSerpoCol)
                            {
                                fUpdateDisplay();
                                fWin();
                                fReset();
                                goto endline2;
                            }
                        }
                        _plasmacol[nValue - 1] -= 1;
                        if (_plasmacol[nValue - 1] <= 1)
                        {
                            sTwo = Convert.ToString(nValue);
                            if (sTwo.Length == 1)
                            {
                                sTwo = "0" + sTwo;
                            }
                            fTakeout(sTwo);
                            nIndex -= 1;
                        }
                        break;
                }
            } while (nIndex < nLength);

        endline:;
            fUpdateDisplay();
        endline2:;

        }

        private void fTakeout(String msSearch)
        {
            int nLength = msPlasmaOrder.Length / 2;
            String sTwo = null;
            int nPos = 0;

            for (int i = 1; i <= nLength; i++)
            {
                sTwo = msPlasmaOrder.Substring(i * 2 - 2, 2);
                if (sTwo == msSearch)
                {
                    nPos = i;
                    goto endline;
                }
            }

        endline:;
            msPlasmaOrder = msPlasmaOrder.Substring(0, nPos * 2 - 2) + msPlasmaOrder.Substring(nPos * 2, (nLength - nPos) * 2);
            
        }
        private bool fPresent(String msOrder,String msSearch)
        {
            int nLength = msOrder.Length / 2;
            String sTwo = null;

            for (int i = 1; i <= nLength; i++)
            {
                sTwo = msOrder.Substring(i * 2 - 2, 2);
                if (sTwo == msSearch)
                {
                    return true;
                }
            }
            return false;
        }
        private int fNewNumber()
        {
            String sTwo = null;

            if (msPlasmaOrder == null)
            {
                return 1;
            }
            else
            {
                for (int i = 1; i <= 14; i++)
                {
                    sTwo = Convert.ToString(i);
                    if (sTwo.Length == 1)
                    {
                        sTwo = "0" + sTwo;
                    }
                    if (fPresent(msPlasmaOrder, sTwo))
                    {

                    }
                    else
                    {
                        return i;
                    }
                }

                return 0;
            }
        }
        private void fClick(int nCol,int nRow)
        {
            int nNewNumber = fNewNumber();
            String sTwo=null;

            if (nNewNumber == 0)
            {
                goto endline;
            }

            if (nCol == 1)
            {
                _plasmacol[nNewNumber - 1] = 2;
                if (nRow == 1)
                {
                    nRow = 2;
                }
                if (nRow == 8)
                {
                    nRow = 7;
                }
                _plasmarow[nNewNumber - 1] = nRow;
                _plasmarotate[nNewNumber - 1] = 2;
            }
            else
            {
                if (nCol == 8)
                {
                    _plasmacol[nNewNumber - 1] = 7;
                    if (nRow == 1)
                    {
                        nRow = 2;
                    }
                    if (nRow == 8)
                    {
                        nRow = 7;
                    }
                    _plasmarow[nNewNumber - 1] = nRow;
                    _plasmarotate[nNewNumber - 1] = 4;

                }
                else
                {
                    if (nRow == 1)
                    {
                        _plasmarow[nNewNumber - 1] = 2;
                        _plasmacol[nNewNumber - 1] = nCol;
                        _plasmarotate[nNewNumber - 1] = 3;

                    }
                    else
                    {
                        _plasmarow[nNewNumber - 1] = 7;
                        _plasmacol[nNewNumber - 1] = nCol;
                        _plasmarotate[nNewNumber - 1] = 1;

                    }
                }
            }

            sTwo = Convert.ToString(nNewNumber);
            if (sTwo.Length == 1)
            {
                sTwo = "0" + sTwo;
            }
            msPlasmaOrder = msPlasmaOrder + sTwo;

            fUpdateDisplay();

        endline:;

        }
        private void fReset()
        {
            Random rnd1 = new Random();
            int nValue;
            String sTwo = null;
            int nCol = 0, nRow = 0;
            int nPos = 0;

            msShuffle1 = "01020304050607080910111213141516171819202122232425262728293021323334353637383940414243444546474849505152535455565758596061626364";
            msShuffle2 = null;
            msShuffle3 = null;
            msPlasmaOrder = null;
            timer1.Enabled = false;
            timer2.Enabled = false;

            for (int i = 1; i <= 64; i++)
            {
                nValue = 1;
                sTwo = Convert.ToString(nValue);
                if (sTwo.Length == 1)
                {
                    sTwo = "0" + sTwo;
                }
                msShuffle2 = msShuffle2 + sTwo;
                sTwo = "00";
                msShuffle3 = msShuffle3 + sTwo;
            }
            nValue = 2;
            sTwo = Convert.ToString(nValue);
            if (sTwo.Length == 1)
            {
                sTwo = "0" + sTwo;
            }
            for (int i = 1; i <= 8; i++)
            {
                nCol = i;
                nRow = 1;
                nPos = (nCol - 1) * 8 + nRow;
                fPlace(sTwo, nPos);
                nCol = i;
                nRow = 8;
                nPos = (nCol - 1) * 8 + nRow;
                fPlace(sTwo, nPos);
                nCol = 1;
                nRow = i;
                nPos = (nCol - 1) * 8 + nRow;
                fPlace(sTwo, nPos);
                nCol = 8;
                nRow = i;
                nPos = (nCol - 1) * 8 + nRow;
                fPlace(sTwo, nPos);
            }

            fFree(ref nCol, ref nRow);
            mnSerpoCol = nCol;
            mnSerpoRow = nRow;
              
            fUpdateDisplay();
            timer1.Enabled = true;
            timer2.Enabled = true;

        }
        private void fUpdateDisplay()
        {
            PictureBox _pic = new PictureBox();
            int nType, nRotate = 1;
            int nLength;
            String sTwo = null;
            int nValue = 0;

            if (msPlasmaOrder == null)
            {
                nLength = 0;
            }
            else
            {
                nLength = msPlasmaOrder.Length / 2;
            }

            //1
            nType = fHoletype2(msShuffle2, 1,ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic11.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 2, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic12.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 3, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic13.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 4, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic14.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 5, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic15.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 6, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic16.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 7, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic17.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 8, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic18.Image = _pic.Image;

            //2
            nType = fHoletype2(msShuffle2, 9, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic21.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 10, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic22.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 11, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic23.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 12, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic24.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 13, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic25.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 14, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic26.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 15, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic27.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 16, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic28.Image = _pic.Image;

            //3
            nType = fHoletype2(msShuffle2, 17, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic31.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 18, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic32.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 19, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic33.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 20, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic34.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 21, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic35.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 22, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic36.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 23, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic37.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 24, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic38.Image = _pic.Image;

            //4
            nType = fHoletype2(msShuffle2, 25, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic41.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 26, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic42.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 27, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic43.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 28, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic44.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 29, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic45.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 30, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic46.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 31, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic47.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 32, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic48.Image = _pic.Image;

            //5
            nType = fHoletype2(msShuffle2, 33, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic51.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 34, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic52.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 35, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic53.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 36, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic54.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 37, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic55.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 38, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic56.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 39, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic57.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 40, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic58.Image = _pic.Image;

            //6
            nType = fHoletype2(msShuffle2, 41, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic61.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 42, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic62.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 43, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic63.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 44, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic64.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 45, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic65.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 46, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic66.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 47, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic67.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 48, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic68.Image = _pic.Image;

            //7
            nType = fHoletype2(msShuffle2, 49, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic71.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 50, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic72.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 51, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic73.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 52, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic74.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 53, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic75.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 54, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic76.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 55, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic77.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 56, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic78.Image = _pic.Image;

            //8
            nType = fHoletype2(msShuffle2, 57, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic81.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 58, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic82.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 59, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic83.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 60, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic84.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 61, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic85.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 62, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic86.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 63, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic87.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 64, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic88.Image = _pic.Image;

            if (nLength != 0)
            {
                for (int i = 1; i <= nLength; i++)
                {
                    sTwo = msPlasmaOrder.Substring(i * 2 - 2, 2);
                    nValue = Convert.ToInt32(sTwo);
                    nType = 3;
                    nRotate = _plasmarotate[nValue - 1];
                    fIcon(nType, nRotate, _plasmacol[nValue - 1], _plasmarow[nValue - 1]);
                }
            }
        }

        private void fIcon(int nType,int nRotate,int nCol,int nRow)
        {
            PictureBox _pic = new PictureBox();

            fPeek(nType, nRotate, ref _pic);

            switch (nCol)
            {
                case 1:
                    switch (nRow)
                    {
                        case 1:
                            pic11.Image = _pic.Image;
                            break;
                        case 2:
                            pic12.Image = _pic.Image;
                            break;
                        case 3:
                            pic13.Image = _pic.Image;
                            break;
                        case 4:
                            pic14.Image = _pic.Image;
                            break;
                        case 5:
                            pic15.Image = _pic.Image;
                            break;
                        case 6:
                            pic16.Image = _pic.Image;
                            break;
                        case 7:
                            pic17.Image = _pic.Image;
                            break;
                        default:
                            pic18.Image = _pic.Image;
                            break;
                    }
                    break;
                case 2:
                    switch (nRow)
                    {
                        case 1:
                            pic21.Image = _pic.Image;
                            break;
                        case 2:
                            pic22.Image = _pic.Image;
                            break;
                        case 3:
                            pic23.Image = _pic.Image;
                            break;
                        case 4:
                            pic24.Image = _pic.Image;
                            break;
                        case 5:
                            pic25.Image = _pic.Image;
                            break;
                        case 6:
                            pic26.Image = _pic.Image;
                            break;
                        case 7:
                            pic27.Image = _pic.Image;
                            break;
                        default:
                            pic28.Image = _pic.Image;
                            break;
                    }
                    break;
                case 3:
                    switch (nRow)
                    {
                        case 1:
                            pic31.Image = _pic.Image;
                            break;
                        case 2:
                            pic32.Image = _pic.Image;
                            break;
                        case 3:
                            pic33.Image = _pic.Image;
                            break;
                        case 4:
                            pic34.Image = _pic.Image;
                            break;
                        case 5:
                            pic35.Image = _pic.Image;
                            break;
                        case 6:
                            pic36.Image = _pic.Image;
                            break;
                        case 7:
                            pic37.Image = _pic.Image;
                            break;
                        default:
                            pic38.Image = _pic.Image;
                            break;
                    }
                    break;
                case 4:
                    switch (nRow)
                    {
                        case 1:
                            pic41.Image = _pic.Image;
                            break;
                        case 2:
                            pic42.Image = _pic.Image;
                            break;
                        case 3:
                            pic43.Image = _pic.Image;
                            break;
                        case 4:
                            pic44.Image = _pic.Image;
                            break;
                        case 5:
                            pic45.Image = _pic.Image;
                            break;
                        case 6:
                            pic46.Image = _pic.Image;
                            break;
                        case 7:
                            pic47.Image = _pic.Image;
                            break;
                        default:
                            pic48.Image = _pic.Image;
                            break;
                    }
                    break;
                case 5:
                    switch (nRow)
                    {
                        case 1:
                            pic51.Image = _pic.Image;
                            break;
                        case 2:
                            pic52.Image = _pic.Image;
                            break;
                        case 3:
                            pic53.Image = _pic.Image;
                            break;
                        case 4:
                            pic54.Image = _pic.Image;
                            break;
                        case 5:
                            pic55.Image = _pic.Image;
                            break;
                        case 6:
                            pic56.Image = _pic.Image;
                            break;
                        case 7:
                            pic57.Image = _pic.Image;
                            break;
                        default:
                            pic58.Image = _pic.Image;
                            break;
                    }
                    break;
                case 6:
                    switch (nRow)
                    {
                        case 1:
                            pic61.Image = _pic.Image;
                            break;
                        case 2:
                            pic62.Image = _pic.Image;
                            break;
                        case 3:
                            pic63.Image = _pic.Image;
                            break;
                        case 4:
                            pic64.Image = _pic.Image;
                            break;
                        case 5:
                            pic65.Image = _pic.Image;
                            break;
                        case 6:
                            pic66.Image = _pic.Image;
                            break;
                        case 7:
                            pic67.Image = _pic.Image;
                            break;
                        default:
                            pic68.Image = _pic.Image;
                            break;
                    }
                    break;
                case 7:
                    switch (nRow)
                    {
                        case 1:
                            pic71.Image = _pic.Image;
                            break;
                        case 2:
                            pic72.Image = _pic.Image;
                            break;
                        case 3:
                            pic73.Image = _pic.Image;
                            break;
                        case 4:
                            pic74.Image = _pic.Image;
                            break;
                        case 5:
                            pic75.Image = _pic.Image;
                            break;
                        case 6:
                            pic76.Image = _pic.Image;
                            break;
                        case 7:
                            pic77.Image = _pic.Image;
                            break;
                        default:
                            pic78.Image = _pic.Image;
                            break;
                    }
                    break;
                default:
                    switch (nRow)
                    {
                        case 1:
                            pic81.Image = _pic.Image;
                            break;
                        case 2:
                            pic82.Image = _pic.Image;
                            break;
                        case 3:
                            pic83.Image = _pic.Image;
                            break;
                        case 4:
                            pic84.Image = _pic.Image;
                            break;
                        case 5:
                            pic85.Image = _pic.Image;
                            break;
                        case 6:
                            pic86.Image = _pic.Image;
                            break;
                        case 7:
                            pic87.Image = _pic.Image;
                            break;
                        default:
                            pic88.Image = _pic.Image;
                            break;
                    }
                    break;

            }
        
        }
        private void fPeek(int nValue, int nRotate, ref PictureBox _pic2)
        {
            PictureBox picture1 = new PictureBox
            {
                Name = "pictureBox1",
                Image = Image.FromFile(@"F back.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture2 = new PictureBox
            {
                Name = "pictureBox2",
                Image = Image.FromFile(@"F wall.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture3 = new PictureBox
            {
                Name = "pictureBox3",
                Image = Image.FromFile(@"F plasma.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture4 = new PictureBox
            {
                Name = "pictureBox4",
                Image = Image.FromFile(@"F serpo.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture5 = new PictureBox
            {
                Name = "pictureBox5",
                Image = Image.FromFile(@"F NullGate.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            switch (nValue)
            {
                case 1:
                    _pic2 = picture1;
                    break;
                case 2:
                    _pic2 = picture2;
                    break;
                case 3:
                    _pic2 = picture3;
                    break;
                case 4:
                    _pic2 = picture4;
                    break;
                default:
                    _pic2 = picture5;
                    break;
            }
            for (int i = 1; i <= nRotate - 1; i++)
            {
                _pic2.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }

        }

        private int fHoletype2(String sShuffle, int nSquare,ref int nRotate)
        {
            int nType = 0;
            int nType2 = 0;
            int nCol = 0, nRow = 0;

            nType = Convert.ToInt32(sShuffle.Substring(nSquare * 2 - 2, 2));
            nRotate = 1;
            if (nType==3)
            {
                nType2 = fHoletype(msShuffle3, nSquare);
                nRotate = _plasmarotate[nType2 - 1];
            }
            fCoordinates(nSquare, ref nCol, ref nRow);
            if (nCol == mnSerpoCol)
            {
                if (nRow == mnSerpoRow)
                {
                    nType = 4;
                }
            }
            return nType;
        }

        private void fCoordinates(int nSquare, ref int nCol, ref int nRow)
        {
            nCol = 1;

            if (nSquare > 8)
            {
                do
                {
                    nSquare -= 8;
                    nCol += 1;
                } while (nSquare > 8);

            }
            nRow = nSquare;
        }

        private void fPlace(String sText, int nPos)
        {
            msShuffle2 = msShuffle2.Substring(0, nPos * 2 - 2) + sText + msShuffle2.Substring(nPos * 2, (64 - nPos) * 2);
        }

        private void fFree(ref int nCol, ref int nRow)
        {
            Random rnd1 = new Random();
            bool bFound = false;
            int nType = 0, nPos = 0;

            do
            {
                nCol = rnd1.Next(1, 9);
                nRow = rnd1.Next(1, 9);
                nPos = (nCol - 1) * 8 + nRow;
                nType = fHoletype(msShuffle2, nPos);
                if (nType == 1)
                {
                    bFound = true;
                }
            } while (bFound != true);

        }

        private int fHoletype(String sShuffle, int nSquare)
        {
            int nType = 0;

            nType = Convert.ToInt32(sShuffle.Substring(nSquare * 2 - 2, 2));
            return nType;
        }


        public fSub1()
        {
            InitializeComponent();
        }

        private void btnQNext_Click(object sender, EventArgs e)
        {
            fReset();
        }

        private void pic11_Click(object sender, EventArgs e)
        {
            fClick(1, 1);
        }

        private void pic12_Click(object sender, EventArgs e)
        {
            fClick(1, 2);
        }

        private void pic13_Click(object sender, EventArgs e)
        {
            fClick(1, 3);
        }

        private void pic14_Click(object sender, EventArgs e)
        {
            fClick(1, 4);
        }

        private void pic15_Click(object sender, EventArgs e)
        {
            fClick(1, 5);
        }

        private void pic16_Click(object sender, EventArgs e)
        {
            fClick(1, 6);
        }

        private void pic17_Click(object sender, EventArgs e)
        {
            fClick(1, 7);
        }

        private void pic18_Click(object sender, EventArgs e)
        {
            fClick(1, 8);
        }

        private void pic81_Click(object sender, EventArgs e)
        {
            fClick(8, 1);
        }

        private void pic82_Click(object sender, EventArgs e)
        {
            fClick(8, 2);
        }

        private void pic83_Click(object sender, EventArgs e)
        {
            fClick(8, 3);
        }

        private void pic84_Click(object sender, EventArgs e)
        {
            fClick(8, 4);
        }

        private void pic85_Click(object sender, EventArgs e)
        {
            fClick(8, 5);
        }

        private void pic86_Click(object sender, EventArgs e)
        {
            fClick(8, 6);
        }

        private void pic87_Click(object sender, EventArgs e)
        {
            fClick(8, 7);
        }

        private void pic88_Click(object sender, EventArgs e)
        {
            fClick(8, 8);
        }

        private void pic21_Click(object sender, EventArgs e)
        {
            fClick(2, 1);
        }

        private void pic31_Click(object sender, EventArgs e)
        {
            fClick(3, 1);
        }

        private void pic41_Click(object sender, EventArgs e)
        {
            fClick(4, 1);
        }

        private void pic51_Click(object sender, EventArgs e)
        {
            fClick(5, 1);
        }

        private void pic61_Click(object sender, EventArgs e)
        {
            fClick(6, 1);
        }

        private void pic71_Click(object sender, EventArgs e)
        {
            fClick(7, 1);
        }

        private void pic28_Click(object sender, EventArgs e)
        {
            fClick(2, 8);
        }

        private void pic38_Click(object sender, EventArgs e)
        {
            fClick(3, 8);
        }

        private void pic48_Click(object sender, EventArgs e)
        {
            fClick(4, 8);
        }

        private void pic58_Click(object sender, EventArgs e)
        {
            fClick(5, 8);
        }

        private void pic68_Click(object sender, EventArgs e)
        {
            fClick(6, 8);
        }

        private void pic78_Click(object sender, EventArgs e)
        {
            fClick(7, 8);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (msPlasmaOrder != "")
            {
                fAdvance();
            }
        }

        private void fSub1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Random rnd1 = new Random();

            nNumber = rnd1.Next(1, 101);
            if (msPlasmaOrder != null)
            {
                if (nNumber <= mnPercentChance)
                {
                    fDetect();
                }
            }
        }

        private void fSub1_Load(object sender, EventArgs e)
        {
            fReset();
        }
    }
}
