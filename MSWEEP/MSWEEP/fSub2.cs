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
    public partial class fSub2 : Form
    {
        private String msShuffle;
        private String msShuffle2;
        private String msRotate;
        private String msOutlet,msOutletRotate;
        private String msNOutlet, msNOutletRotate;
        private int nNumber;
        private bool mbOutlet = false;
        private bool mbDirty = false;
        private List<int> _col = new List<int> { 0, 0, 0, 0 };
        private List<int> _row = new List<int> { 0, 0, 0, 0 };
        private List<int> _rotate = new List<int> { 0, 0, 0, 0 };
        private int mnSofar;

        private void fNext()
        {
            int nPos,nType;
            int nSofar = 0;
            Random rnd1 = new Random();
            String sText = "1234";
            int nExamine1, nExamine2;
            int nCol, nRow, nRotate=0;
            int nCol2, nRow2, nRotate2;
            String sPoss = null;
            String sTwo;
            int nSavecol, nSaverow;

            for (int i = 1; i <= 4; i++)
            {
                _col[i - 1] = 0;
                _row[i - 1] = 0;
                _rotate[i - 1] = 0;
            }
            for (int i = 1; i <= 8; i++)
            {
                for (int j = 1; j <= 8; j++)
                {
                    nPos = (i - 1) * 8 + j;
                    nType = fHoletype3(nPos, ref nRotate);
                    if (nType == 5)
                    {
                        nSofar += 1;
                        _col[nSofar - 1] = i;
                        _row[nSofar - 1] = j;
                        _rotate[nSofar - 1] = nRotate;
                    }
                    else
                    {
                        if (nType == 6)
                        {
                            nSofar += 1;
                            _col[nSofar - 1] = i;
                            _row[nSofar - 1] = j;
                            _rotate[nSofar - 1] = nRotate;
                            switch (nRotate)
                            {
                                case 1:
                                    nRotate = 3;
                                    break;
                                case 2:
                                    nRotate = 4;
                                    break;
                                case 3:
                                    nRotate = 1;
                                    break;
                                default:
                                    nRotate = 2;
                                    break;

                            }
                            nSofar += 1;
                            _col[nSofar - 1] = i;
                            _row[nSofar - 1] = j;
                            _rotate[nSofar - 1] = nRotate;
                        }
                    }
                    if (nSofar == 4)
                    {
                        goto endline;
                    }
                }
            }

            endline:;
            mnSofar = nSofar;
            sText = sText.Substring(0, mnSofar);
            nPos = rnd1.Next(1, mnSofar + 1);
            nExamine1 = Convert.ToInt32(sText.Substring(nPos - 1, 1));
            if (nPos == mnSofar)
            {
                sText = sText.Substring(0, nPos - 1);

            }
            else
            {
                sText = sText.Substring(0, nPos - 1) + sText.Substring(nPos, mnSofar - nPos);
            }
            if (mnSofar == 1)
            {
                nExamine2 = 0;
            }
            else
            {
                nPos = rnd1.Next(1, mnSofar );
                nExamine2 = Convert.ToInt32(sText.Substring(nPos - 1, 1));

            }

            fResetOutlet();

            //Examine1
            nCol = _col[nExamine1 - 1];
            nRow = _row[nExamine1 - 1];
            nSavecol = nCol;
            nSaverow = nRow;
            nRotate = _rotate[nExamine1 - 1];
            switch (nRotate)
            {
                case 1:
                    sPoss = "0301030207010901";
                    break;
                case 2:
                    sPoss = "0302030307020902";
                    break;
                case 3:
                    sPoss = "0303030407030903";
                    break;
                default:
                    sPoss = "0304030107040904";
                    break;
            }
            nPos = rnd1.Next(1, 5);
            sPoss = sPoss.Substring((nPos * 4) - 4, 4);
            sTwo = sPoss.Substring(0, 2);
            nType = Convert.ToInt32(sTwo);
            
            fCNext(ref nCol, ref nRow, nRotate);
            nPos = (nCol - 1) * 8 + nRow;
            fPlace(sTwo, nPos);
            sTwo = "0" + Convert.ToString(nRotate);
            fPlace2(sTwo, nPos);

            switch (nType)
            {
                case 3:
                    sTwo = "05";
                    break;
                case 7:
                    sTwo = "05";
                    break;
                default:
                    sTwo = "06";
                    break;
            }
            fPlace3(sTwo, nPos);
            switch (nType)
            {
                case 3:
                    nRotate += 1;
                    if (nRotate == 5)
                    {
                        nRotate = 1;
                    }
                    break;
                case 7:
                    break;
                default:
                    nRotate += 1;
                    if (nRotate == 5)
                    {
                        nRotate = 1;
                    }
                    break;
            }
            sTwo = "0" + Convert.ToString(nRotate);
            fPlace4(sTwo, nPos);

            nCol2 = nSavecol;
            nRow2 = nSaverow;
            nRotate2 = nRotate;
            fCNext(ref nCol2, ref nRow2, nRotate2);
            nPos = (nCol2 - 1) * 8 + nRow2;
            switch (nType)
            {
                case 3:
                    sTwo = "05";
                    break;
                case 7:
                    sTwo = "05";
                    break;
                default:
                    sTwo = "06";
                    break;
            }
            fPlace5(sTwo, nPos);
            sTwo = "0" + Convert.ToString(nRotate);
            fPlace6(sTwo, nPos);

            //Examine2
            fUpdateDisplay();
            if (nExamine2 == 0)
            {
                goto endline2;
            }
            nCol = _col[nExamine2 - 1];
            nRow = _row[nExamine2 - 1];
            nSavecol = nCol;
            nSaverow = nRow;
            nRotate = _rotate[nExamine2 - 1];
            switch (nRotate)
            {
                case 1:
                    sPoss = "0301030207010901";
                    break;
                case 2:
                    sPoss = "0302030307020902";
                    break;
                case 3:
                    sPoss = "0303030407030903";
                    break;
                default:
                    sPoss = "0304030107040904";
                    break;
            }
            nPos = rnd1.Next(1, 5);
            sPoss = sPoss.Substring((nPos * 4) - 4, 4);
            sTwo = sPoss.Substring(0, 2);
            nType = Convert.ToInt32(sTwo);
            fCNext(ref nCol, ref nRow, nRotate);
            nPos = (nCol - 1) * 8 + nRow;
            fPlace(sTwo, nPos);
            sTwo = "0" + Convert.ToString(nRotate);
            fPlace2(sTwo, nPos);

            switch (nType)
            {
                case 3:
                    sTwo = "05";
                    break;
                case 7:
                    sTwo = "05";
                    break;
                default:
                    sTwo = "06";
                    break;
            }
            fPlace3(sTwo, nPos);
            switch (nType)
            {
                case 3:
                    nRotate += 1;
                    if (nRotate == 5)
                    {
                        nRotate = 1;
                    }
                    break;
                case 7:
                    break;
                default:
                    nRotate += 1;
                    if (nRotate == 5)
                    {
                        nRotate = 1;
                    }
                    break;
            }
            sTwo = "0" + Convert.ToString(nRotate);
            fPlace4(sTwo, nPos);

            nCol2 = nSavecol;
            nRow2 = nSaverow;
            nRotate2 = nRotate;
            fCNext(ref nCol2, ref nRow2, nRotate2);
            nPos = (nCol2 - 1) * 8 + nRow2;
            switch (nType)
            {
                case 3:
                    sTwo = "05";
                    break;
                case 7:
                    sTwo = "05";
                    break;
                default:
                    sTwo = "06";
                    break;
            }
            fPlace5(sTwo, nPos);
            sTwo = "0" + Convert.ToString(nRotate);
            fPlace6(sTwo, nPos);

            fUpdateDisplay();

            endline2:;
        }

        private void fCancel()
        {

        }

        private void fResetOutlet()
        {
            String sTwo = null;

            msOutlet = null;
            msOutletRotate = null;

            for (int i = 1; i <= 64; i++)
            {
                sTwo = "01";
                msOutlet = msOutlet + sTwo;
                msOutletRotate = msOutletRotate + sTwo;

            }

            msNOutlet = null;
            msNOutletRotate = null;

            for (int i = 1; i <= 64; i++)
            {
                sTwo = "01";
                msNOutlet = msNOutlet + sTwo;
                msNOutletRotate = msNOutletRotate + sTwo;

            }
        }

        private void fCNext(ref int nCol,ref int nRow,int nRotate)
        {
            switch (nRotate)
            {
                case 1:
                    nRow -= 1;
                    if (nRow == 0)
                    {
                        nRow = 8;
                    }
                    break;
                case 2:
                    nCol += 1;
                    if (nCol == 9)
                    {
                        nCol = 1;
                    }
                    break;
                case 3:
                    nRow += 1;
                    if (nRow == 9)
                    {
                        nRow = 1;
                    }
                    break;
                default:
                    nCol -= 1;
                    if (nCol == 0)
                    {
                        nCol = 8;
                    }
                    break;
            }
        }

        private void fReset()
        {
            Random rnd1 = new Random();
            String sTwo = null;
            int nCol = 0, nRow = 0;
            int nCol2 = 0, nRow2 = 0,nRotate2;
            int nPos;
            int nRotate = rnd1.Next(1, 5);

            msShuffle = "01020304050607080910111213141516171819202122232425262728293031323334353637383940414243444546474849505152535455565758596061626364";
            msShuffle2 = null;
            msRotate = null;
            mbOutlet = false;
            btnOutlet.Text = "Outlet = OFF";
            fResetOutlet();
            mbDirty = false;

            for (int i = 1; i <= 64; i++)
            {
                sTwo = "01";
                msShuffle2 = msShuffle2 + sTwo;
                msRotate = msRotate + sTwo;
            }

            fFree(ref nCol, ref nRow);
            nNumber = rnd1.Next(1, 4);
            switch (nNumber)
            {
                case 1:
                    nNumber = 3;
                    break;
                case 2:
                    nNumber = 7;
                    break;
                default:
                    nNumber = 9;
                    break;
            }
            sTwo = "0"+Convert.ToString(nNumber);
            nPos = (nCol - 1) * 8 + nRow;
            fPlace(sTwo, nPos);

            sTwo = "0" + Convert.ToString(nRotate);
            fPlace2(sTwo, nPos);
            switch (nNumber)
            {
                case 3:
                    sTwo = "05";
                    break;
                case 7:
                    sTwo = "05";
                    break;
                default:
                    sTwo = "06";
                    break;
            }
            fPlace3(sTwo, nPos);
            switch (nNumber)
            {
                case 3:
                    nRotate += 1;
                    if (nRotate == 5)
                    {
                        nRotate = 1;
                    }
                    break;
                case 7:
                    break;
                default:
                    nRotate += 1;
                    if (nRotate == 5)
                    {
                        nRotate = 1;
                    }
                    break;
            }
            sTwo = "0" + Convert.ToString(nRotate);
            fPlace4(sTwo, nPos);

            nCol2 = nCol;
            nRow2 = nRow;
            nRotate2 = nRotate;
            fCNext(ref nCol2, ref nRow2, nRotate2);
            nPos = (nCol2 - 1) * 8 + nRow2;
            switch (nNumber)
            {
                case 3:
                    sTwo = "05";
                    break;
                case 7:
                    sTwo = "05";
                    break;
                default:
                    sTwo = "06";
                    break;
            }
            fPlace5(sTwo, nPos);
            sTwo = "0" + Convert.ToString(nRotate);
            fPlace6(sTwo, nPos);

            fUpdateDisplay();
        }

        private void fPeek(int nValue, int nRotate, ref PictureBox _pic2)
        {
            PictureBox picture1 = new PictureBox
            {
                Name = "pictureBox1",
                Image = Image.FromFile(@"F backgroundtile.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture2 = new PictureBox
            {
                Name = "pictureBox2",
                Image = Image.FromFile(@"F bug.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture3 = new PictureBox
            {
                Name = "pictureBox3",
                Image = Image.FromFile(@"F corner_New.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture4 = new PictureBox
            {
                Name = "pictureBox4",
                Image = Image.FromFile(@"F corner_Old.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture5 = new PictureBox
            {
                Name = "pictureBox5",
                Image = Image.FromFile(@"F outlet.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture6 = new PictureBox
            {
                Name = "pictureBox6",
                Image = Image.FromFile(@"F outlet2.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture7 = new PictureBox
            {
                Name = "pictureBox7",
                Image = Image.FromFile(@"F straight_New.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture8 = new PictureBox
            {
                Name = "pictureBox8",
                Image = Image.FromFile(@"F straight_Old.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture9 = new PictureBox
            {
                Name = "pictureBox9",
                Image = Image.FromFile(@"F T_New.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture10 = new PictureBox
            {
                Name = "pictureBox10",
                Image = Image.FromFile(@"F T_Old.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture11 = new PictureBox
            {
                Name = "pictureBox11",
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
                default:
                    _pic2 = picture11;
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
       
            nType = Convert.ToInt32(sShuffle.Substring(nSquare * 2 - 2, 2));
            if (mbOutlet)
            {
                nRotate = Convert.ToInt32(msOutletRotate.Substring(nSquare * 2 - 2, 2));

            }
            else
            {
                nRotate = Convert.ToInt32(msRotate.Substring(nSquare * 2 - 2, 2));

            }

            return nType;
        }
        private int fHoletype3( int nSquare, ref int nRotate)
        {
            int nType = 0;

            nType = Convert.ToInt32(msNOutlet.Substring(nSquare * 2 - 2, 2));
            nRotate = Convert.ToInt32(msNOutletRotate.Substring(nSquare * 2 - 2, 2));

          
            return nType;
        }

        private void fUpdateDisplay()
        {
            PictureBox _pic = new PictureBox();
            int nType, nRotate = 1;
            String sSource = msShuffle2;

            if (mbOutlet)
            {
                sSource = msOutlet;
            }

            //1
            nType = fHoletype2(sSource, 1, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic11.Image = _pic.Image;
            nType = fHoletype2(sSource, 2, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic12.Image = _pic.Image;
            nType = fHoletype2(sSource, 3, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic13.Image = _pic.Image;
            nType = fHoletype2(sSource, 4, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic14.Image = _pic.Image;
            nType = fHoletype2(sSource, 5, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic15.Image = _pic.Image;
            nType = fHoletype2(sSource, 6, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic16.Image = _pic.Image;
            nType = fHoletype2(sSource, 7, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic17.Image = _pic.Image;
            nType = fHoletype2(sSource, 8, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic18.Image = _pic.Image;

            //2
            nType = fHoletype2(sSource, 9, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic21.Image = _pic.Image;
            nType = fHoletype2(sSource, 10, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic22.Image = _pic.Image;
            nType = fHoletype2(sSource, 11, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic23.Image = _pic.Image;
            nType = fHoletype2(sSource, 12, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic24.Image = _pic.Image;
            nType = fHoletype2(sSource, 13, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic25.Image = _pic.Image;
            nType = fHoletype2(sSource, 14, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic26.Image = _pic.Image;
            nType = fHoletype2(sSource, 15, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic27.Image = _pic.Image;
            nType = fHoletype2(sSource, 16, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic28.Image = _pic.Image;

            //3
            nType = fHoletype2(sSource, 17, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic31.Image = _pic.Image;
            nType = fHoletype2(sSource, 18, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic32.Image = _pic.Image;
            nType = fHoletype2(sSource, 19, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic33.Image = _pic.Image;
            nType = fHoletype2(sSource, 20, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic34.Image = _pic.Image;
            nType = fHoletype2(sSource, 21, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic35.Image = _pic.Image;
            nType = fHoletype2(sSource, 22, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic36.Image = _pic.Image;
            nType = fHoletype2(sSource, 23, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic37.Image = _pic.Image;
            nType = fHoletype2(sSource, 24, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic38.Image = _pic.Image;

            //4
            nType = fHoletype2(sSource, 25, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic41.Image = _pic.Image;
            nType = fHoletype2(sSource, 26, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic42.Image = _pic.Image;
            nType = fHoletype2(sSource, 27, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic43.Image = _pic.Image;
            nType = fHoletype2(sSource, 28, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic44.Image = _pic.Image;
            nType = fHoletype2(sSource, 29, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic45.Image = _pic.Image;
            nType = fHoletype2(sSource, 30, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic46.Image = _pic.Image;
            nType = fHoletype2(sSource, 31, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic47.Image = _pic.Image;
            nType = fHoletype2(sSource, 32, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic48.Image = _pic.Image;

            //5
            nType = fHoletype2(sSource, 33, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic51.Image = _pic.Image;
            nType = fHoletype2(sSource, 34, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic52.Image = _pic.Image;
            nType = fHoletype2(sSource, 35, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic53.Image = _pic.Image;
            nType = fHoletype2(sSource, 36, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic54.Image = _pic.Image;
            nType = fHoletype2(sSource, 37, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic55.Image = _pic.Image;
            nType = fHoletype2(sSource, 38, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic56.Image = _pic.Image;
            nType = fHoletype2(sSource, 39, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic57.Image = _pic.Image;
            nType = fHoletype2(sSource, 40, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic58.Image = _pic.Image;


            //6
            nType = fHoletype2(sSource, 41, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic61.Image = _pic.Image;
            nType = fHoletype2(sSource, 42, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic62.Image = _pic.Image;
            nType = fHoletype2(sSource, 43, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic63.Image = _pic.Image;
            nType = fHoletype2(sSource, 44, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic64.Image = _pic.Image;
            nType = fHoletype2(sSource, 45, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic65.Image = _pic.Image;
            nType = fHoletype2(sSource, 46, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic66.Image = _pic.Image;
            nType = fHoletype2(sSource, 47, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic67.Image = _pic.Image;
            nType = fHoletype2(sSource, 48, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic68.Image = _pic.Image;


            //7
            nType = fHoletype2(sSource, 49, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic71.Image = _pic.Image;
            nType = fHoletype2(sSource, 50, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic72.Image = _pic.Image;
            nType = fHoletype2(sSource, 51, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic73.Image = _pic.Image;
            nType = fHoletype2(sSource, 52, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic74.Image = _pic.Image;
            nType = fHoletype2(sSource, 53, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic75.Image = _pic.Image;
            nType = fHoletype2(sSource, 54, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic76.Image = _pic.Image;
            nType = fHoletype2(sSource, 55, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic77.Image = _pic.Image;
            nType = fHoletype2(sSource, 56, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic78.Image = _pic.Image;


            //8
            nType = fHoletype2(sSource, 57, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic81.Image = _pic.Image;
            nType = fHoletype2(sSource, 58, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic82.Image = _pic.Image;
            nType = fHoletype2(sSource, 59, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic83.Image = _pic.Image;
            nType = fHoletype2(sSource, 60, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic84.Image = _pic.Image;
            nType = fHoletype2(sSource, 61, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic85.Image = _pic.Image;
            nType = fHoletype2(sSource, 62, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic86.Image = _pic.Image;
            nType = fHoletype2(sSource, 62, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic87.Image = _pic.Image;
            nType = fHoletype2(sSource, 64, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic88.Image = _pic.Image;
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

        private String fData(int nCol, int nRow)
        {
            int nPos = (nCol - 1) * 8 + nRow;
            String sTwo = msShuffle2.Substring(nPos * 2 - 2, 2);

            return sTwo;
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
        private void fPlace2(String sText, int nPos)
        {
            if (nPos == 64)
            {
                msRotate = msRotate.Substring(0, nPos * 2 - 2) + sText;

            }
            else
            {
                msRotate = msRotate.Substring(0, nPos * 2 - 2) + sText + msRotate.Substring(nPos * 2, (64 - nPos) * 2);

            }
        }

        private void fPlace3(String sText, int nPos)
        {
            if (nPos == 64)
            {
                msOutlet = msOutlet.Substring(0, nPos * 2 - 2) + sText;

            }
            else
            {
                msOutlet = msOutlet.Substring(0, nPos * 2 - 2) + sText + msOutlet.Substring(nPos * 2, (64 - nPos) * 2);
                
            }
        }
        private void fPlace4(String sText, int nPos)
        {
            if (nPos == 64)
            {
                msOutletRotate = msOutletRotate.Substring(0, nPos * 2 - 2) + sText;

            }
            else
            {
                msOutletRotate = msOutletRotate.Substring(0, nPos * 2 - 2) + sText + msOutletRotate.Substring(nPos * 2, (64 - nPos) * 2);

            }
        }

        private void fPlace5(String sText, int nPos)
        {
            if (nPos == 64)
            {
                msNOutlet = msNOutlet.Substring(0, nPos * 2 - 2) + sText;

            }
            else
            {
                msNOutlet = msNOutlet.Substring(0, nPos * 2 - 2) + sText + msNOutlet.Substring(nPos * 2, (64 - nPos) * 2);

            }
        }
        private void fPlace6(String sText, int nPos)
        {
            if (nPos == 64)
            {
                msNOutletRotate = msNOutletRotate.Substring(0, nPos * 2 - 2) + sText;

            }
            else
            {
                msNOutletRotate = msNOutletRotate.Substring(0, nPos * 2 - 2) + sText + msNOutletRotate.Substring(nPos * 2, (64 - nPos) * 2);

            }
        }

        public fSub2()
        {
            InitializeComponent();
        }

        private void fSub2_Load(object sender, EventArgs e)
        {
            fReset();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            mbDirty = true;
            fNext();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (mbDirty)
            {
                mbDirty = false;
                fCancel();
            }
        }

        private void btnQNext_Click(object sender, EventArgs e)
        {
            fReset();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mbOutlet = !mbOutlet;
            if (mbOutlet)
            {
                btnOutlet.Text = "Outlet = ON";

            }
            else
            {
                btnOutlet.Text = "Outlet = OFF";
            }
            fUpdateDisplay();
        }
    }
}
