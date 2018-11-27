using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSWEEP
{
    public partial class fSub1 : Form
    {
        private String msShuffle1;
        private String msShuffle2;
        private String msCovered;
        private int nNumber;
        private int lmin, lmax;
        private bool mbMarker;
        private int mnMinesPresent, mnFlagsUsed;

        private void fUpdateStatus()
        {
            lblMinesPresent.Text = "MinesPresent = " + Convert.ToString(mnMinesPresent);
            lblFlagsUsed.Text = "FlagsUsed = " + Convert.ToString(mnFlagsUsed);
        }
        private void fCount()
        {
            int nCount = 0;
            int nCol = 0, nRow = 0;
            int nPos;
            String sTwo;
            int nValue;

            for (int i = 1; i <= 8; i++)
            {
                for (int j = 1; j <= 8; j++)
                {
                    nCount = 0;
                    sTwo = fData(i, j);
                    if (sTwo == "12")
                    {
                        goto linecontinue2;
                    }
                    for (int k = 1; k <= 8; k++)
                    {
                        nCol = i;
                        nRow = j;
                        switch (k)
                        {
                            case 1:
                                nRow -= 1;
                                break;
                            case 2:
                                nCol += 1;
                                nRow -= 1;
                                break;
                            case 3:
                                nCol += 1;
                                break;
                            case 4:
                                nCol += 1;
                                nRow += 1;
                                break;
                            case 5:
                                nRow += 1;
                                break;
                            case 6:
                                nCol -= 1;
                                nRow += 1;
                                break;
                            case 7:
                                nCol -= 1;
                                break;
                            default:
                                nCol -= 1;
                                nRow -= 1;
                                break;
                        }
                        if (nCol == 0)
                        {
                            goto linecontinue;
                        }
                        if (nCol == 9)
                        {
                            goto linecontinue;
                        }
                        if (nRow == 0)
                        {
                            goto linecontinue;
                        }
                        if (nRow == 9)
                        {
                            goto linecontinue;
                        }
                        sTwo = fData(nCol, nRow);
                        if (sTwo == "12")
                        {
                            nCount += 1;


                        }
                        else
                        {
                        }
                    linecontinue:;
                    }
                    nPos = (i - 1) * 8 + j;
                    nValue = nCount + 3;
                    sTwo = Convert.ToString(nValue);
                    if (sTwo.Length == 1)
                    {
                        sTwo = "0" + sTwo;
                    }
                    fPlace(sTwo, nPos);

                }
            linecontinue2:;
            }
        }

        private int fMinCol(int nCol, int nPos)
        {
            String sTwo = null;

            for (int i = nPos - 1; i >= 1; i--)
            {
                sTwo = fData(nCol, i);
                if (sTwo == "01")
                {

                }
                else
                {
                    nPos = i;
                    goto lineend;
                }
            }

        lineend:;
            return nPos;
        }
        private int fMaxCol(int nCol, int nPos)
        {
            String sTwo = null;

            for (int i = nPos + 1; i <= 8; i++)
            {
                sTwo = fData(nCol, i);
                if (sTwo == "01")
                {

                }
                else
                {
                    nPos = i;
                    goto lineend;
                }
            }

        lineend:;
            return nPos;
        }

        private int fMinRow(int nRow, int nPos)
        {
            String sTwo = null;

            for (int i = nPos - 1; i >= 1; i--)
            {
                sTwo = fData(i, nRow);
                if (sTwo == "01")
                {

                }
                else
                {
                    nPos = i;
                    goto lineend;
                }
            }

        lineend:;
            return nPos;
        }
        private int fMaxRow(int nRow, int nPos)
        {
            String sTwo = null;

            for (int i = nPos + 1; i <= 8; i++)
            {
                sTwo = fData(i, nRow);
                if (sTwo == "01")
                {

                }
                else
                {
                    nPos = i;
                    goto lineend;
                }
            }

        lineend:;
            return nPos;
        }

        private void fClearRow2(int nRow)
        {
            String sTwo = null;
            int nPos;

            for (int i = lmin; i <= lmax; i++)
            {
                sTwo = fData(i, nRow);
                if (sTwo == "01")
                {
                    nPos = (i - 1) * 8 + nRow;
                    msCovered = msCovered.Substring(0, nPos - 1) + "4" + msCovered.Substring(nPos, 64 - nPos);
                }
            }
        }
        private void fClearCol2(int nCol)
        {
            String sTwo = null;
            int nPos;

            for (int i = lmin; i <= lmax; i++)
            {
                sTwo = fData(nCol, i);
                if (sTwo == "01")
                {
                    nPos = (nCol - 1) * 8 + i;
                    msCovered = msCovered.Substring(0, nPos - 1) + "4" + msCovered.Substring(nPos, 64 - nPos);
                }
            }
        }

        private void fClearSight(int nCol, int nRow)
        {
            int nSavecol = nCol, nSaverow = nRow;

            //across
            lmin = fMinRow(nRow, nCol);
            lmax = fMaxRow(nRow, nCol);
            nNumber = nCol;
            fClearRow2(nRow);
            //acrossup
            if (nRow != 1)
            {
                do
                {
                    nRow -= 1;
                    if (lmin != 1)
                    {
                        fExtendMinRow();
                    }
                    if (lmax != 8)
                    {
                        fExtendMaxRow();
                    }
                    fClearRow2(nRow);
                } while (nRow > 1);

            }
            //acrossdown
            nRow = nSaverow;
            if (nRow != 8)
            {
                do
                {
                    nRow += 1;
                    if (lmin != 1)
                    {
                        fExtendMinRow();
                    }
                    if (lmax != 8)
                    {
                        fExtendMaxRow();
                    }
                    fClearRow2(nRow);
                } while (nRow < 8);

            }

            //down
            lmin = fMinCol(nCol, nRow);
            lmax = fMaxCol(nCol, nRow);
            nNumber = nRow;
            fClearCol2(nCol);
            //downleft
            if (nCol != 1)
            {
                do
                {
                    nCol -= 1;
                    if (lmin != 1)
                    {
                        fExtendMinCol();
                    }
                    if (lmax != 8)
                    {
                        fExtendMaxCol();
                    }
                    fClearCol2(nCol);
                } while (nCol > 1);

            }
            //downright
            nCol = nSavecol;
            if (nCol != 8)
            {
                do
                {
                    nCol += 1;
                    if (lmin != 1)
                    {
                        fExtendMinCol();
                    }
                    if (lmax != 8)
                    {
                        fExtendMaxCol();
                    }
                    fClearCol2(nCol);
                } while (nCol < 8);

            }
        }

        private void fExtendMinRow()
        {
            int nCol = lmin;
            String sTwo = null;

            for (int i = nCol - 1; i >= 1; i--)
            {
                sTwo = fData(i, nNumber);
                if (sTwo == "01")
                {
                    lmin -= 1;
                }

            }
        }
        private void fExtendMaxRow()
        {
            int nCol = lmax;
            String sTwo = null;

            for (int i = nCol + 1; i <= 8; i++)
            {
                sTwo = fData(i, nNumber);
                if (sTwo == "01")
                {
                    lmax += 1;
                }

            }
        }

        private void fExtendMinCol()
        {
            int nRow = lmin;
            String sTwo = null;

            for (int i = nRow - 1; i >= 1; i--)
            {
                sTwo = fData(nNumber, i);
                if (sTwo == "01")
                {
                    lmin -= 1;
                }

            }
        }
        private void fExtendMaxCol()
        {
            int nRow = lmax;
            String sTwo = null;

            for (int i = nRow + 1; i <= 8; i++)
            {
                sTwo = fData(nNumber, i);
                if (sTwo == "01")
                {
                    lmax += 1;
                }

            }
        }

        private bool fMarker(int nCol, int nRow)
        {
            String sTwo = null;
            sTwo = fData(nCol, nRow);
            int nPos;

            if (mbMarker == false)
            {
                return false;
            }

            if (sTwo == "01")
            {
                nPos = (nCol - 1) * 8 + nRow;
                msCovered = msCovered.Substring(0, nPos - 1) + "3" + msCovered.Substring(nPos, 64 - nPos);
                mnFlagsUsed += 1;
                return true;
            }
            return false;
        }
        private void fClick(int nCol, int nRow)
        {
            int nPos = (nCol - 1) * 8 + nRow;
            int nCovered = Convert.ToInt32(msCovered.Substring(nPos - 1, 1));
            String sTwo = null;
            bool bMark;


            switch (nCovered)
            {
                case 2:
                    bMark = fMarker(nCol, nRow);
                    if (bMark)
                    {
                        mbMarker = false;
                        goto lineend;
                    }
                    msCovered = msCovered.Substring(0, nPos - 1) + "4" + msCovered.Substring(nPos, 64 - nPos);
                    sTwo = fData(nCol, nRow);
                    if (sTwo == "01")
                    {
                        fClearSight(nCol, nRow);
                    }
                    break;
                case 3:
                    msCovered = msCovered.Substring(0, nPos - 1) + "2" + msCovered.Substring(nPos, 64 - nPos);
                    mnFlagsUsed -= 1;
                    break;
                default:
                    break;
            }

        lineend:;

            fUpdateDisplay();
        }
        private void fReset()
        {
            Random rnd1 = new Random();
            int nValue;
            String sTwo = null;
            int nMines = rnd1.Next(4, 13);
            int nCol = 0, nRow = 0;
            int nPos;

            msShuffle1 = "01020304050607080910111213141516171819202122232425262728293031323334353637383940414243444546474849505152535455565758596061626364";
            msShuffle2 = null;
            msCovered = null;
            mbMarker = false;
            mnMinesPresent = nMines;
            mnFlagsUsed = 0;

            for (int i = 1; i <= 64; i++)
            {
                nValue = 1;
                sTwo = Convert.ToString(nValue);
                if (sTwo.Length == 1)
                {
                    sTwo = "0" + sTwo;
                    msShuffle2 = msShuffle2 + sTwo;
                }
                msCovered = msCovered + "2";
            }

            for (int i = 1; i <= nMines; i++)
            {
                fFree(ref nCol, ref nRow);
                nPos = (nCol - 1) * 8 + nRow;
                fPlace("12", nPos);
            }
            fCount();

            fUpdateDisplay();
        }

        private void fPlace(String sText, int nPos)
        {
            if (nPos == 64)
            {
                msShuffle2 = msShuffle2.Substring(0, nPos * 2 - 2) + sText;

            }
            else
            {
                msShuffle2 = msShuffle2.Substring(0, nPos * 2 - 2) + sText + msShuffle2.Substring(nPos * 2, (64 - nPos) * 2);

            }
        }

        private String fData(int nCol, int nRow)
        {
            int nPos = (nCol - 1) * 8 + nRow;
            String sTwo = msShuffle2.Substring(nPos * 2 - 2, 2);

            return sTwo;
        }

        private void fPeek(int nValue, int nRotate, ref PictureBox _pic2)
        {
            PictureBox picture1 = new PictureBox
            {
                Name = "pictureBox1",
                Image = Image.FromFile(@"F empty.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture2 = new PictureBox
            {
                Name = "pictureBox2",
                Image = Image.FromFile(@"F covered.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture3 = new PictureBox
            {
                Name = "pictureBox3",
                Image = Image.FromFile(@"F marker.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture4 = new PictureBox
            {
                Name = "pictureBox4",
                Image = Image.FromFile(@"F n1.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture5 = new PictureBox
            {
                Name = "pictureBox5",
                Image = Image.FromFile(@"F n2.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture6 = new PictureBox
            {
                Name = "pictureBox6",
                Image = Image.FromFile(@"F n3.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture7 = new PictureBox
            {
                Name = "pictureBox7",
                Image = Image.FromFile(@"F n4.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture8 = new PictureBox
            {
                Name = "pictureBox8",
                Image = Image.FromFile(@"F n5.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture9 = new PictureBox
            {
                Name = "pictureBox9",
                Image = Image.FromFile(@"F n6.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture10 = new PictureBox
            {
                Name = "pictureBox10",
                Image = Image.FromFile(@"F n7.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture11 = new PictureBox
            {
                Name = "pictureBox11",
                Image = Image.FromFile(@"F n8.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture12 = new PictureBox
            {
                Name = "pictureBox12",
                Image = Image.FromFile(@"F revealmine.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture13 = new PictureBox
            {
                Name = "pictureBox13",
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
                case 5:
                    _pic2 = picture5;
                    break;
                case 6:
                    _pic2 = picture6;
                    break;
                case 7:
                    _pic2 = picture7;
                    break;
                case 8:
                    _pic2 = picture8;
                    break;
                case 9:
                    _pic2 = picture9;
                    break;
                case 10:
                    _pic2 = picture10;
                    break;
                case 11:
                    _pic2 = picture11;
                    break;
                case 12:
                    _pic2 = picture12;
                    break;
                default:
                    _pic2 = picture13;
                    break;
            }
            for (int i = 1; i <= nRotate - 1; i++)
            {
                _pic2.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }

        }
        private void fUpdateDisplay()
        {
            PictureBox _pic = new PictureBox();
            int nType, nRotate = 1;

            //1
            nType = fHoletype(msShuffle2, 1);
            fPeek(nType, nRotate, ref _pic);
            pic11.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 2);
            fPeek(nType, nRotate, ref _pic);
            pic12.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 3);
            fPeek(nType, nRotate, ref _pic);
            pic13.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 4);
            fPeek(nType, nRotate, ref _pic);
            pic14.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 5);
            fPeek(nType, nRotate, ref _pic);
            pic15.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 6);
            fPeek(nType, nRotate, ref _pic);
            pic16.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 7);
            fPeek(nType, nRotate, ref _pic);
            pic17.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 8);
            fPeek(nType, nRotate, ref _pic);
            pic18.Image = _pic.Image;

            //2
            nType = fHoletype(msShuffle2, 9);
            fPeek(nType, nRotate, ref _pic);
            pic21.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 10);
            fPeek(nType, nRotate, ref _pic);
            pic22.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 11);
            fPeek(nType, nRotate, ref _pic);
            pic23.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 12);
            fPeek(nType, nRotate, ref _pic);
            pic24.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 13);
            fPeek(nType, nRotate, ref _pic);
            pic25.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 14);
            fPeek(nType, nRotate, ref _pic);
            pic26.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 15);
            fPeek(nType, nRotate, ref _pic);
            pic27.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 16);
            fPeek(nType, nRotate, ref _pic);
            pic28.Image = _pic.Image;

            //3
            nType = fHoletype(msShuffle2, 17);
            fPeek(nType, nRotate, ref _pic);
            pic31.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 18);
            fPeek(nType, nRotate, ref _pic);
            pic32.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 19);
            fPeek(nType, nRotate, ref _pic);
            pic33.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 20);
            fPeek(nType, nRotate, ref _pic);
            pic34.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 21);
            fPeek(nType, nRotate, ref _pic);
            pic35.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 22);
            fPeek(nType, nRotate, ref _pic);
            pic36.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 23);
            fPeek(nType, nRotate, ref _pic);
            pic37.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 24);
            fPeek(nType, nRotate, ref _pic);
            pic38.Image = _pic.Image;

            //4
            nType = fHoletype(msShuffle2, 25);
            fPeek(nType, nRotate, ref _pic);
            pic41.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 26);
            fPeek(nType, nRotate, ref _pic);
            pic42.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 27);
            fPeek(nType, nRotate, ref _pic);
            pic43.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 28);
            fPeek(nType, nRotate, ref _pic);
            pic44.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 29);
            fPeek(nType, nRotate, ref _pic);
            pic45.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 30);
            fPeek(nType, nRotate, ref _pic);
            pic46.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 31);
            fPeek(nType, nRotate, ref _pic);
            pic47.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 32);
            fPeek(nType, nRotate, ref _pic);
            pic48.Image = _pic.Image;

            //5
            nType = fHoletype(msShuffle2, 33);
            fPeek(nType, nRotate, ref _pic);
            pic51.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 34);
            fPeek(nType, nRotate, ref _pic);
            pic52.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 35);
            fPeek(nType, nRotate, ref _pic);
            pic53.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 36);
            fPeek(nType, nRotate, ref _pic);
            pic54.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 37);
            fPeek(nType, nRotate, ref _pic);
            pic55.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 38);
            fPeek(nType, nRotate, ref _pic);
            pic56.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 39);
            fPeek(nType, nRotate, ref _pic);
            pic57.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 40);
            fPeek(nType, nRotate, ref _pic);
            pic58.Image = _pic.Image;


            //6
            nType = fHoletype(msShuffle2, 41);
            fPeek(nType, nRotate, ref _pic);
            pic61.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 42);
            fPeek(nType, nRotate, ref _pic);
            pic62.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 43);
            fPeek(nType, nRotate, ref _pic);
            pic63.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 44);
            fPeek(nType, nRotate, ref _pic);
            pic64.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 45);
            fPeek(nType, nRotate, ref _pic);
            pic65.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 46);
            fPeek(nType, nRotate, ref _pic);
            pic66.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 47);
            fPeek(nType, nRotate, ref _pic);
            pic67.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 48);
            fPeek(nType, nRotate, ref _pic);
            pic68.Image = _pic.Image;


            //7
            nType = fHoletype(msShuffle2, 49);
            fPeek(nType, nRotate, ref _pic);
            pic71.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 50);
            fPeek(nType, nRotate, ref _pic);
            pic72.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 51);
            fPeek(nType, nRotate, ref _pic);
            pic73.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 52);
            fPeek(nType, nRotate, ref _pic);
            pic74.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 53);
            fPeek(nType, nRotate, ref _pic);
            pic75.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 54);
            fPeek(nType, nRotate, ref _pic);
            pic76.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 55);
            fPeek(nType, nRotate, ref _pic);
            pic77.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 56);
            fPeek(nType, nRotate, ref _pic);
            pic78.Image = _pic.Image;


            //8
            nType = fHoletype(msShuffle2, 57);
            fPeek(nType, nRotate, ref _pic);
            pic81.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 58);
            fPeek(nType, nRotate, ref _pic);
            pic82.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 59);
            fPeek(nType, nRotate, ref _pic);
            pic83.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 60);
            fPeek(nType, nRotate, ref _pic);
            pic84.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 61);
            fPeek(nType, nRotate, ref _pic);
            pic85.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 62);
            fPeek(nType, nRotate, ref _pic);
            pic86.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 62);
            fPeek(nType, nRotate, ref _pic);
            pic87.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 64);
            fPeek(nType, nRotate, ref _pic);
            pic88.Image = _pic.Image;

            fUpdateStatus();
        }

        private int fHoletype(String sShuffle, int nSquare)
        {
            int nType = 0;
            int nCovered = 0;

            nCovered = Convert.ToInt32(msCovered.Substring(nSquare - 1, 1));
            switch (nCovered)
            {
                case 2:
                    nType = 2;
                    break;
                case 3:
                    nType = 3;
                    break;
                default:
                    nType = Convert.ToInt32(sShuffle.Substring(nSquare * 2 - 2, 2));
                    break;
            }
            return nType;
        }

        private void fFree(ref int nCol, ref int nRow)
        {
            Random rnd1 = new Random();
            bool bFound = false;
            String sData;
            int nValue;

            do
            {
                nCol = rnd1.Next(1, 9);
                nRow = rnd1.Next(1, 9);
                sData = fData(nCol, nRow);
                nValue = Convert.ToInt32(sData);
                if (nValue == 1)
                {
                    bFound = true;
                }
            } while (bFound == false);
        }

        public fSub1()
        {
            InitializeComponent();
        }

        private void fSub1_Load(object sender, EventArgs e)
        {
            fReset();
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

        private void pic21_Click(object sender, EventArgs e)
        {
            fClick(2, 1);
        }

        private void pic22_Click(object sender, EventArgs e)
        {
            fClick(2, 2);
        }

        private void pic23_Click(object sender, EventArgs e)
        {
            fClick(2, 3);
        }

        private void pic24_Click(object sender, EventArgs e)
        {
            fClick(2, 4);
        }

        private void pic25_Click(object sender, EventArgs e)
        {
            fClick(2, 5);
        }

        private void pic26_Click(object sender, EventArgs e)
        {
            fClick(2, 6);
        }

        private void pic27_Click(object sender, EventArgs e)
        {
            fClick(2, 7);
        }

        private void pic28_Click(object sender, EventArgs e)
        {
            fClick(2, 8);
        }

        private void pic31_Click(object sender, EventArgs e)
        {
            fClick(3, 1);
        }

        private void pic32_Click(object sender, EventArgs e)
        {
            fClick(3, 2);
        }

        private void pic33_Click(object sender, EventArgs e)
        {
            fClick(3, 3);
        }

        private void pic34_Click(object sender, EventArgs e)
        {
            fClick(3, 4);
        }

        private void pic35_Click(object sender, EventArgs e)
        {
            fClick(3, 5);
        }

        private void pic36_Click(object sender, EventArgs e)
        {
            fClick(3, 6);
        }

        private void pic37_Click(object sender, EventArgs e)
        {
            fClick(3, 7);
        }

        private void pic38_Click(object sender, EventArgs e)
        {
            fClick(3, 8);
        }

        private void pic41_Click(object sender, EventArgs e)
        {
            fClick(4, 1);
        }

        private void pic42_Click(object sender, EventArgs e)
        {
            fClick(4, 2);
        }

        private void pic43_Click(object sender, EventArgs e)
        {
            fClick(4, 3);
        }

        private void pic44_Click(object sender, EventArgs e)
        {
            fClick(4, 4);
        }

        private void pic45_Click(object sender, EventArgs e)
        {
            fClick(4, 5);
        }

        private void pic46_Click(object sender, EventArgs e)
        {
            fClick(4, 6);
        }

        private void pic47_Click(object sender, EventArgs e)
        {
            fClick(4, 7);
        }

        private void pic48_Click(object sender, EventArgs e)
        {
            fClick(4, 8);
        }

        private void pic51_Click(object sender, EventArgs e)
        {
            fClick(5, 1);
        }

        private void pic52_Click(object sender, EventArgs e)
        {
            fClick(5, 2);
        }

        private void pic53_Click(object sender, EventArgs e)
        {
            fClick(5, 3);
        }

        private void pic54_Click(object sender, EventArgs e)
        {
            fClick(5, 4);
        }

        private void pic55_Click(object sender, EventArgs e)
        {
            fClick(5, 5);
        }

        private void pic56_Click(object sender, EventArgs e)
        {
            fClick(5, 6);
        }

        private void pic57_Click(object sender, EventArgs e)
        {
            fClick(5, 7);
        }

        private void pic58_Click(object sender, EventArgs e)
        {
            fClick(5, 8);
        }

        private void pic61_Click(object sender, EventArgs e)
        {
            fClick(6, 1);
        }

        private void pic62_Click(object sender, EventArgs e)
        {
            fClick(6, 2);
        }

        private void pic63_Click(object sender, EventArgs e)
        {
            fClick(6, 3);
        }

        private void pic64_Click(object sender, EventArgs e)
        {
            fClick(6, 4);
        }

        private void pic65_Click(object sender, EventArgs e)
        {
            fClick(6, 5);
        }

        private void pic66_Click(object sender, EventArgs e)
        {
            fClick(6, 6);
        }

        private void pic67_Click(object sender, EventArgs e)
        {
            fClick(6, 7);
        }

        private void pic68_Click(object sender, EventArgs e)
        {
            fClick(6, 8);
        }

        private void pic71_Click(object sender, EventArgs e)
        {
            fClick(7, 1);
        }

        private void pic72_Click(object sender, EventArgs e)
        {
            fClick(7, 2);

        }

        private void pic73_Click(object sender, EventArgs e)
        {
            fClick(7, 3);

        }

        private void pic74_Click(object sender, EventArgs e)
        {
            fClick(7, 4);

        }

        private void pic75_Click(object sender, EventArgs e)
        {
            fClick(7, 5);

        }

        private void pic76_Click(object sender, EventArgs e)
        {
            fClick(7, 6);

        }

        private void pic77_Click(object sender, EventArgs e)
        {
            fClick(7, 7);

        }

        private void pic78_Click(object sender, EventArgs e)
        {
            fClick(7, 8);

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

        private void btnMarker_Click(object sender, EventArgs e)
        {
            mbMarker = true;
        }

        private void pic88_Click(object sender, EventArgs e)
        {
            fClick(8, 8);
        }
    }
}
