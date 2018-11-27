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
    public partial class fSub2 : Form
    {
        private String msShuffle1;
        private String msShuffle2;
        private String msShuffle3;
        private int mnCol, mnRow;
        private int nNumber;
        private List<int> _hpmax = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private List<int> _hpnow = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private int mnTick;

        private void fHit(int nCol, int nRow)
        {
            Random rnd1 = new Random();
            int nPos = (nCol - 1) * 8 + nRow;
            int nType = fHoletype(msShuffle3, nPos);
            int nAmount = rnd1.Next(10, 41);
            String sText;
            String sTwo;

            if (nAmount > _hpnow[nType - 1])
            {
                nAmount = _hpnow[nType - 1];
            }
            _hpnow[nType - 1] -= nAmount;
            sText = "HIT ENEMY" + Convert.ToString(nType) + " for " + Convert.ToString(nAmount) + "HP";
            lst1.Items.Add(sText);
            if (_hpnow[nType - 1] < 1)
            {
                sText = "ENEMY is now DEAD";
                lst1.Items.Add(sText);
                nNumber = rnd1.Next(1, 10);
                if (nNumber <= 5)
                {
                    sTwo = "01";
                }
                else
                {
                    sTwo = "02";
                }
                fPlace(sTwo, nPos);
            }
            else
            {
                sText = "ENEMY at " + _hpnow[nType - 1] + "/" + _hpmax[nType - 1];
                lst1.Items.Add(sText);
            }
        }

        private void fNav(int nMode)
        {
            Random rnd1 = new Random();
            int nDirection=0;
            int nUp = 0, nRight = 0, nLeft = 0, nDown = 0;
             int nNumber2 = rnd1.Next(1, 10);
            bool bFound = false;
            int nCol, nRow;

            nNumber = rnd1.Next(1, 10);
            fDirections(ref nUp, ref nRight, ref nDown, ref nLeft);

            switch (nMode)
            {
                case 1:
                    if (nLeft == 1)
                    {
                        nCol = mnCol;
                        nRow = mnRow;
                        nCol -= 1;
                        fHit(nCol,nRow);
                             bFound = true;
                        mnTick = 2;
                        timer1.Enabled = true;
                    }
                    if (nUp == 1)
                    {
                        nCol = mnCol;
                        nRow = mnRow;
                        nRow -= 1;
                        fHit(nCol, nRow);
                            bFound = true;
                        mnTick = 2;
                        timer1.Enabled = true;
                    }
                    if (!bFound)
                    {
                        if (nNumber <= 5)
                        {
                            nDirection = 4;
                        }
                        else
                        {
                            nDirection = 1;
                        }
                    }
                    break;
                case 2:
                    if (nUp == 1)
                    {
                        nCol = mnCol;
                        nRow = mnRow;
                        nRow -= 1;
                        fHit(nCol, nRow);
                           bFound = true;
                        mnTick = 2;
                        timer1.Enabled = true;
                    }
                    if (nRight == 1)
                    {
                        nCol = mnCol;
                        nRow = mnRow;
                        nCol += 1;
                        fHit(nCol, nRow);
                              bFound = true;
                        mnTick = 2;
                        timer1.Enabled = true;
                    }
                    if (!bFound)
                    {
                        if (nNumber <= 5)
                        {
                            nDirection = 1;
                        }
                        else
                        {
                            nDirection = 2;
                        }
                    }
                    break;
                case 3:
                    if (nRight == 1)
                    {
                        nCol = mnCol;
                        nRow = mnRow;
                        nCol += 1;
                        fHit(nCol, nRow);
                          bFound = true;
                        mnTick = 2;
                        timer1.Enabled = true;
                    }
                    if (nDown == 1)
                    {
                        nCol = mnCol;
                        nRow = mnRow;
                        nRow += 1;
                        fHit(nCol, nRow);
                         bFound = true;
                        mnTick = 2;
                        timer1.Enabled = true;
                    }
                    if (!bFound)
                    {
                        if (nNumber <= 5)
                        {
                            nDirection = 2;
                        }
                        else
                        {
                            nDirection = 3;
                        }
                    }
                    break;
                default:
                    if (nDown == 1)
                    {
                        nCol = mnCol;
                        nRow = mnRow;
                        nRow += 1;
                        fHit(nCol, nRow);
                               bFound = true;
                        mnTick = 2;
                        timer1.Enabled = true;
                    }
                    if (nLeft == 1)
                    {
                        nCol = mnCol;
                        nRow = mnRow;
                        nCol -= 1;
                        fHit(nCol, nRow);
                              bFound = true;
                        mnTick = 2;
                        timer1.Enabled = true;
                    }
                    if (!bFound)
                    {
                        if (nNumber <= 5)
                        {
                            nDirection = 3;
                        }
                        else
                        {
                            nDirection = 4;
                        }
                    }
                    break;
            }
            if (!bFound)
            {
                switch (nDirection)
                {
                    case 1:
                        if (mnRow != 1)
                        {
                            mnRow -= 1;
                            fUpdateDisplay();
                        }
                        break;
                    case 2:
                        if (mnCol != 8)
                        {
                            mnCol += 1;
                            fUpdateDisplay();
                        }
                        break;
                    case 3:
                        if (mnRow != 8)
                        {
                            mnRow += 1;
                            fUpdateDisplay();
                        }
                        break;
                    default:
                        if (mnCol != 1)
                        {
                            mnCol -= 1;
                            fUpdateDisplay();
                        }
                        break;
                }
            }
        }

        private void fDirections(ref int nUp,ref int nRight,ref int nDown,ref int nLeft)
        {
            int nSavecol = mnCol, nSaverow = mnRow;
            int nCol, nRow;
            int nPos = 0;
            int nType=0;

            nCol = nSavecol;
            nRow = nSaverow;
            nRow = nRow - 1;
            if (nRow ==0)
            {
                nUp = 0;
            }
            else
            {
                nPos = (nCol - 1) * 8 + nRow;
                nType = fHoletype(msShuffle2, nPos);
                if (nType >= 4)
                {
                    nUp = 1;
                }
                else
                {
                    nUp = 0;
                }
            }
            nCol = nSavecol;
            nRow = nSaverow;
            nCol = nCol + 1;
            if (nCol == 9)
            {
                nRight = 0;
            }
            else
            {
                nPos = (nCol - 1) * 8 + nRow;
                nType = fHoletype(msShuffle2, nPos);
                if (nType >= 4)
                {
                    nRight = 1;
                }
                else
                {
                    nRight = 0;
                }
            }
            nCol = nSavecol;
            nRow = nSaverow;
            nRow = nRow + 1;
            if (nRow == 9)
            {
                nDown = 0;
            }
            else
            {
                nPos = (nCol - 1) * 8 + nRow;
                nType = fHoletype(msShuffle2, nPos);
                if (nType >= 4)
                {
                    nDown = 1;
                }
                else
                {
                    nDown = 0;
                }
            }
            nCol = nSavecol;
            nRow = nSaverow;
            nCol = nCol - 1;
            if (nCol == 0)
            {
                nLeft = 0;
            }
            else
            {
                nPos = (nCol - 1) * 8 + nRow;
                nType = fHoletype(msShuffle2, nPos);
                if (nType >= 4)
                {
                    nLeft = 1;
                }
                else
                {
                    nLeft = 0;
                }
            }
        }

        private void fReset()
        {
            Random rnd1 = new Random();
            int nValue;
            String sTwo = null;
            int nPos = 0;
            int nSpiders = rnd1.Next(4, 15);
            int nCol = 0, nRow = 0;

            msShuffle1 = "01020304050607080910111213141516171819202122232425262728293021323334353637383940414243444546474849505152535455565758596061626364";
            msShuffle2 = null;
            msShuffle3 = null;
            timer1.Enabled = false;
            mnTick = 0;

            if (lst1.Items.Count > 0)
            {
                do
                {
                    lst1.Items.RemoveAt(0);
                } while (lst1.Items.Count > 0);
            }
            for (int i = 1; i <= 14; i++)
            {
                _hpmax[i - 1] = 0;
                _hpnow[i - 1] = 0;
            }

            for (int i = 1; i <= 64; i++)
            {
                nNumber = rnd1.Next(1, 10);
                if (nNumber <= 5)
                {
                    nValue = 1;
                }
                else
                {
                    nValue = 2;
                }
                 sTwo = Convert.ToString(nValue);
                if (sTwo.Length == 1)
                {
                    sTwo = "0" + sTwo;
                }
                msShuffle2 = msShuffle2 + sTwo;
                sTwo = "01";
                msShuffle3 = msShuffle3 + sTwo;
            }

            for (int i = 1; i <= nSpiders; i++)
            {
                fFree(ref nCol, ref nRow);
                nPos = (nCol - 1) * 8 + nRow;
                nNumber = rnd1.Next(1, 4);
                nValue = nNumber + 3;
                sTwo = Convert.ToString(nValue);
                if (sTwo.Length == 1)
                {
                    sTwo = "0" + sTwo;
                    fPlace(sTwo, nPos);
                }
                switch (sTwo)
                {
                    case "04":
                        _hpmax[i - 1] = rnd1.Next(60, 81);
                        break;
                    case "05":
                        _hpmax[i - 1] = rnd1.Next(40, 61);
                        break;
                    default:
                        _hpmax[i - 1] = rnd1.Next(20, 41);
                        break;
                }
                _hpnow[i - 1] = _hpmax[i - 1];
                fPlace2(sTwo, nPos);

            }

            fFree(ref nCol, ref nRow);
            mnCol = nCol;
            mnRow = nRow;

            fUpdateDisplay();
        }

        private void fUpdateDisplay()
        {
            PictureBox _pic = new PictureBox();
            int nType, nRotate = 1;

            //1
            nType = fHoletype2(msShuffle2, 1);
            fPeek(nType, nRotate, ref _pic);
            pic11.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 2);
            fPeek(nType, nRotate, ref _pic);
            pic12.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 3);
            fPeek(nType, nRotate, ref _pic);
            pic13.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 4);
            fPeek(nType, nRotate, ref _pic);
            pic14.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 5);
            fPeek(nType, nRotate, ref _pic);
            pic15.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 6);
            fPeek(nType, nRotate, ref _pic);
            pic16.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 7);
            fPeek(nType, nRotate, ref _pic);
            pic17.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 8);
            fPeek(nType, nRotate, ref _pic);
            pic18.Image = _pic.Image;

            //2
            nType = fHoletype2(msShuffle2, 9);
            fPeek(nType, nRotate, ref _pic);
            pic21.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 10);
            fPeek(nType, nRotate, ref _pic);
            pic22.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 11);
            fPeek(nType, nRotate, ref _pic);
            pic23.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 12);
            fPeek(nType, nRotate, ref _pic);
            pic24.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 13);
            fPeek(nType, nRotate, ref _pic);
            pic25.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 14);
            fPeek(nType, nRotate, ref _pic);
            pic26.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 15);
            fPeek(nType, nRotate, ref _pic);
            pic27.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 16);
            fPeek(nType, nRotate, ref _pic);
            pic28.Image = _pic.Image;

            //3
            nType = fHoletype2(msShuffle2, 17);
            fPeek(nType, nRotate, ref _pic);
            pic31.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 18);
            fPeek(nType, nRotate, ref _pic);
            pic32.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 19);
            fPeek(nType, nRotate, ref _pic);
            pic33.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 20);
            fPeek(nType, nRotate, ref _pic);
            pic34.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 21);
            fPeek(nType, nRotate, ref _pic);
            pic35.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 22);
            fPeek(nType, nRotate, ref _pic);
            pic36.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 23);
            fPeek(nType, nRotate, ref _pic);
            pic37.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 24);
            fPeek(nType, nRotate, ref _pic);
            pic38.Image = _pic.Image;

            //4
            nType = fHoletype2(msShuffle2, 25);
            fPeek(nType, nRotate, ref _pic);
            pic41.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 26);
            fPeek(nType, nRotate, ref _pic);
            pic42.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 27);
            fPeek(nType, nRotate, ref _pic);
            pic43.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 28);
            fPeek(nType, nRotate, ref _pic);
            pic44.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 29);
            fPeek(nType, nRotate, ref _pic);
            pic45.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 30);
            fPeek(nType, nRotate, ref _pic);
            pic46.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 31);
            fPeek(nType, nRotate, ref _pic);
            pic47.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 32);
            fPeek(nType, nRotate, ref _pic);
            pic48.Image = _pic.Image;

            //5
            nType = fHoletype2(msShuffle2, 33);
            fPeek(nType, nRotate, ref _pic);
            pic51.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 34);
            fPeek(nType, nRotate, ref _pic);
            pic52.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 35);
            fPeek(nType, nRotate, ref _pic);
            pic53.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 36);
            fPeek(nType, nRotate, ref _pic);
            pic54.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 37);
            fPeek(nType, nRotate, ref _pic);
            pic55.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 38);
            fPeek(nType, nRotate, ref _pic);
            pic56.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 39);
            fPeek(nType, nRotate, ref _pic);
            pic57.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 40);
            fPeek(nType, nRotate, ref _pic);
            pic58.Image = _pic.Image;

            //6
            nType = fHoletype2(msShuffle2, 41);
            fPeek(nType, nRotate, ref _pic);
            pic61.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 42);
            fPeek(nType, nRotate, ref _pic);
            pic62.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 43);
            fPeek(nType, nRotate, ref _pic);
            pic63.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 44);
            fPeek(nType, nRotate, ref _pic);
            pic64.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 45);
            fPeek(nType, nRotate, ref _pic);
            pic65.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 46);
            fPeek(nType, nRotate, ref _pic);
            pic66.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 47);
            fPeek(nType, nRotate, ref _pic);
            pic67.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 48);
            fPeek(nType, nRotate, ref _pic);
            pic68.Image = _pic.Image;

            //7
            nType = fHoletype2(msShuffle2, 49);
            fPeek(nType, nRotate, ref _pic);
            pic71.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 50);
            fPeek(nType, nRotate, ref _pic);
            pic72.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 51);
            fPeek(nType, nRotate, ref _pic);
            pic73.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 52);
            fPeek(nType, nRotate, ref _pic);
            pic74.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 53);
            fPeek(nType, nRotate, ref _pic);
            pic75.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 54);
            fPeek(nType, nRotate, ref _pic);
            pic76.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 55);
            fPeek(nType, nRotate, ref _pic);
            pic77.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 56);
            fPeek(nType, nRotate, ref _pic);
            pic78.Image = _pic.Image;

            //8
            nType = fHoletype2(msShuffle2, 57);
            fPeek(nType, nRotate, ref _pic);
            pic81.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 58);
            fPeek(nType, nRotate, ref _pic);
            pic82.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 59);
            fPeek(nType, nRotate, ref _pic);
            pic83.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 60);
            fPeek(nType, nRotate, ref _pic);
            pic84.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 61);
            fPeek(nType, nRotate, ref _pic);
            pic85.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 62);
            fPeek(nType, nRotate, ref _pic);
            pic86.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 63);
            fPeek(nType, nRotate, ref _pic);
            pic87.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 64);
            fPeek(nType, nRotate, ref _pic);
            pic88.Image = _pic.Image;

        }

        private void fPeek(int nValue, int nRotate, ref PictureBox _pic2)
        {
            PictureBox picture1 = new PictureBox
            {
                Name = "pictureBox1",
                Image = Image.FromFile(@"F floor1.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture2 = new PictureBox
            {
                Name = "pictureBox2",
                Image = Image.FromFile(@"F floor2.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture3 = new PictureBox
            {
                Name = "pictureBox3",
                Image = Image.FromFile(@"F hit.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture4 = new PictureBox
            {
                Name = "pictureBox4",
                Image = Image.FromFile(@"F spider_black.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture5 = new PictureBox
            {
                Name = "pictureBox5",
                Image = Image.FromFile(@"F spider_blue.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture6 = new PictureBox
            {
                Name = "pictureBox6",
                Image = Image.FromFile(@"F spider_red.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture7 = new PictureBox
            {
                Name = "pictureBox7",
                Image = Image.FromFile(@"F YOU.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture8 = new PictureBox
            {
                Name = "pictureBox8",
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
                default:
                    _pic2 = picture8;
                    break;
            }
            for (int i = 1; i <= nRotate - 1; i++)
            {
                _pic2.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }

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
                if (nType <= 2)
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

        private int fHoletype2(String sShuffle, int nSquare)
        {
            int nType = 0;
            int nCol = 0, nRow = 0;

            nType = Convert.ToInt32(sShuffle.Substring(nSquare * 2 - 2, 2));
            fCoordinates(nSquare, ref nCol, ref nRow);
            if (nCol == mnCol)
            {
               if (nRow == mnRow)
               {
                   nType = 7;
               }
            }
            if (timer1.Enabled)
            {
                switch (mnTick)
                {
                    case 0:
                        break;
                    case 1:
                        break;
                    case 2:
                             switch (nType)
                            {
                                case 4:
                                    nType = 3;
                                     break;
                                case 5:
                                    nType = 3;
                                      break;
                                case 6:
                                    nType = 3;
                                      break;
                                default:
                                    break;
                            }
                        
                        break;
                    default:
                        break;
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
        private void fPlace2(String sText, int nPos)
        {
            msShuffle3 = msShuffle3.Substring(0, nPos * 2 - 2) + sText + msShuffle3.Substring(nPos * 2, (64 - nPos) * 2);
        }

        public fSub2()
        {
            InitializeComponent();
        }

        private void btnQNext_Click(object sender, EventArgs e)
        {
            fReset();
        }

        private void btnNav1_Click(object sender, EventArgs e)
        {
            fNav(1);
        }

        private void btnNav2_Click(object sender, EventArgs e)
        {
            fNav(2);
        }

        private void btnNav3_Click(object sender, EventArgs e)
        {
            fNav(3);
        }

        private void btnNav4_Click(object sender, EventArgs e)
        {
            fNav(4);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
                  switch (mnTick)
                {
                    case 1:
                        fUpdateDisplay();
                        mnTick += 1;
                        break;
                    case 2:
                        fUpdateDisplay();
                        mnTick += 1;
                        break;
                    default:
                        timer1.Enabled = false;
                        fUpdateDisplay();
                        mnTick = 0;
                        break;
                }

            }

            private void fSub2_Load(object sender, EventArgs e)
        {
            fReset();
        }
    }
}
