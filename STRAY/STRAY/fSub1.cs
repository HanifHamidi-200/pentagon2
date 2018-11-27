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
    public partial class fSub1 : Form
    {
        private String msShuffle1;
        private String msShuffle2;
        private String msAcross;
        private String msDown;
        private bool mbReversed;
        private int mnStage;
        private bool mbShowAcross, mbShowDown;
        private int mnButton;
        private int mnCol1, mnRow1,mnCol2,mnRow2;
        private int mnCol, mnRow;
      private void fClick(int nCol,int nRow)
        {
            int nValue,nPos;
            String sTwo;
            switch (mnStage)
            {
                case 0:
                    break;
                case 1:
                    nValue = 2;
                    sTwo = Convert.ToString(nValue);
                    if (sTwo.Length == 1)
                    {
                        sTwo = "0" + sTwo;
                    }
                    nPos = (nCol - 1) * 8 + nRow;
                    if (mnButton == 1)
                    {
                        fPlace2(sTwo, nPos);
                        mbShowAcross = true;
                    }
                    else
                    {
                        mbShowDown = true;
                        fPlace3(sTwo, nPos);
                    }
                    mnCol1 = nCol;
                    mnRow1 = nRow;
                    fUpdateDisplay();
                    mnStage = 2;
                    break;
                case 2:
                    nValue = 3;
                    sTwo = Convert.ToString(nValue);
                    if (sTwo.Length == 1)
                    {
                        sTwo = "0" + sTwo;
                    }
                    nPos = (nCol - 1) * 8 + nRow;
                    if (mnButton == 1)
                    {
                        mbShowAcross = true;
                        fPlace2(sTwo, nPos);
                    }
                    else
                    {
                        mbShowDown = true;
                        fPlace3(sTwo, nPos);
                    }
                    fDrawArc(mnCol1, mnRow1, nCol, nRow);
                    fUpdateDisplay();
                    break;
                default:
                    break;
            }
        }

        private void fDimensions(ref int nUp,ref int nRight,ref int nDown,ref int nLeft)
        {
            if (mnButton == 1)
            {
                if (mbReversed ==false)
                {
                    nRight = mnCol2 - mnCol1;
                    nLeft = 0;
                    if (mnRow2 == mnRow1)
                    { 
                        nUp = 0;
                        nDown = 0;
                    }
                    else
                    {
                        if (mnRow2 < mnRow1)
                        {
                            nUp = mnRow1 - mnRow2;
                            nDown = 0;
                        }
                        else
                        {
                            nUp = 0;
                            nDown = mnRow2 - mnRow1;
                        }
                    }
                 }
                else
                {
                    nLeft = mnCol1 - mnCol2;
                    nRight = 0;
                    if (mnRow2 == mnRow1)
                    {
                        nUp = 0;
                        nDown = 0;
                    }
                    else
                    {
                        if (mnRow2 < mnRow1)
                        {
                            nUp = mnRow1 - mnRow2;
                            nDown = 0;
                        }
                        else
                        {
                            nUp = 0;
                            nDown = mnRow2 - mnRow1;
                        }
                    }

                }
            }
            else
            {
                if (mbReversed == false)
                {
                    nDown = mnRow2 - mnRow1;
                    nUp = 0;
                    if (mnCol2 == mnCol1)
                    {
                        nRight = 0;
                        nLeft = 0;
                    }
                    else
                    {
                        if (mnCol2 < mnCol1)
                        {
                            nLeft = mnCol2 - mnCol1;
                            nRight = 0;
                        }
                        else
                        {
                            nLeft = 0;
                            nRight = mnCol2 - mnCol1;
                        }
                    }
                }
                else
                {
                    nUp = mnRow1 - mnRow2;
                    nDown = 0;
                    if (mnCol2 == mnCol1)
                    {
                        nRight = 0;
                        nLeft = 0;
                    }
                    else
                    {
                        if (mnCol2 < mnCol1)
                        {
                            nLeft = mnCol2 - mnCol1;
                            nRight = 0;
                        }
                        else
                        {
                            nLeft = 0;
                            nRight = mnCol2 - mnCol1;
                        }
                    }

                }

            }

        }
        private void fDrawArc(int nCol1,int nRow1,int nCol2,int nRow2)
        {
            int nUp = 0, nRight = 0, nDown = 0, nLeft = 0;
            bool bFound = false;
            int nValue, nPos;
            String sTwo;

            mnCol2 = nCol2;
            mnRow2 = nRow2;
            if (mnButton == 1)
            {
                if (nCol1 == 1)
                {
                    mbReversed = false;
                }
                else
                {
                    mbReversed = true;
                }
            }
            else
            {
                if (nRow1 == 1)
                {
                    mbReversed = false;
                }
                else
                {
                    mbReversed = true;
                }
            }

            mnCol = mnCol1;
            mnRow = mnRow1;
            do
            {

                mnCol1 = mnCol;
                mnRow1 = mnRow;
                fDimensions(ref nUp, ref nRight, ref nDown, ref nLeft);
                if ((nUp + nRight + nDown + nLeft) == 1)
                {
                    bFound = true;
                }
                else
                {


                    if (mnButton == 1)
                    {
                        if (nCol1 == 1)
                        {
                            if (nUp != 0)
                            {
                                if (nRight >= nUp)
                                {
                                    mnCol += 1;
                                    nValue = 6;
                                    sTwo = Convert.ToString(nValue);
                                    if (sTwo.Length == 1)
                                    {
                                        sTwo = "0" + sTwo;
                                    }
                                    nPos = (mnCol - 1) * 8 + mnRow;
                                    fPlace2(sTwo, nPos);

                                }
                                else
                                {
                                    mnRow -= 1;
                                    nValue = 6;
                                    sTwo = Convert.ToString(nValue);
                                    if (sTwo.Length == 1)
                                    {
                                        sTwo = "0" + sTwo;
                                    }
                                    nPos = (mnCol - 1) * 8 + mnRow;
                                    fPlace2(sTwo, nPos);

                                }
                            }
                            else
                            {
                                if (nDown != 0)
                                {
                                    if (nRight >= nDown)
                                    {
                                        mnCol += 1;
                                        nValue = 6;
                                        sTwo = Convert.ToString(nValue);
                                        if (sTwo.Length == 1)
                                        {
                                            sTwo = "0" + sTwo;
                                        }
                                        nPos = (mnCol - 1) * 8 + mnRow;
                                        fPlace2(sTwo, nPos);

                                    }
                                    else
                                    {
                                        mnRow += 1;
                                        nValue = 6;
                                        sTwo = Convert.ToString(nValue);
                                        if (sTwo.Length == 1)
                                        {
                                            sTwo = "0" + sTwo;
                                        }
                                        nPos = (mnCol - 1) * 8 + mnRow;
                                        fPlace2(sTwo, nPos);

                                    }

                                }
                                else
                                {
                                    mnCol += 1;
                                    nValue = 6;
                                    sTwo = Convert.ToString(nValue);
                                    if (sTwo.Length == 1)
                                    {
                                        sTwo = "0" + sTwo;
                                    }
                                    nPos = (mnCol - 1) * 8 + mnRow;
                                    fPlace2(sTwo, nPos);
                                }
                            }
                        }
                        else
                        {
                            if (nUp != 0)
                            {
                                if (nLeft >= nUp)
                                {
                                    mnCol -= 1;
                                    nValue = 6;
                                    sTwo = Convert.ToString(nValue);
                                    if (sTwo.Length == 1)
                                    {
                                        sTwo = "0" + sTwo;
                                    }
                                    nPos = (mnCol - 1) * 8 + mnRow;
                                    fPlace2(sTwo, nPos);

                                }
                                else
                                {
                                    mnRow -= 1;
                                    nValue = 6;
                                    sTwo = Convert.ToString(nValue);
                                    if (sTwo.Length == 1)
                                    {
                                        sTwo = "0" + sTwo;
                                    }
                                    nPos = (mnCol - 1) * 8 + mnRow;
                                    fPlace2(sTwo, nPos);

                                }
                            }
                            else
                            {
                                if (nDown != 0)
                                {
                                    if (nLeft >= nDown)
                                    {
                                        mnCol -= 1;
                                        nValue = 6;
                                        sTwo = Convert.ToString(nValue);
                                        if (sTwo.Length == 1)
                                        {
                                            sTwo = "0" + sTwo;
                                        }
                                        nPos = (mnCol - 1) * 8 + mnRow;
                                        fPlace2(sTwo, nPos);

                                    }
                                    else
                                    {
                                        mnRow += 1;
                                        nValue = 6;
                                        sTwo = Convert.ToString(nValue);
                                        if (sTwo.Length == 1)
                                        {
                                            sTwo = "0" + sTwo;
                                        }
                                        nPos = (mnCol - 1) * 8 + mnRow;
                                        fPlace2(sTwo, nPos);

                                    }

                                }
                                else
                                {
                                    mnCol -= 1;
                                    nValue = 6;
                                    sTwo = Convert.ToString(nValue);
                                    if (sTwo.Length == 1)
                                    {
                                        sTwo = "0" + sTwo;
                                    }
                                    nPos = (mnCol - 1) * 8 + mnRow;
                                    fPlace2(sTwo, nPos);
                                }
                            }
                        }
                    }

                    else
                    {
                        if (nRow1 == 1)
                        {
                            if (nRight != 0)
                            {
                                if (nDown >= nRight)
                                {
                                    mnRow += 1;
                                    nValue = 7;
                                    sTwo = Convert.ToString(nValue);
                                    if (sTwo.Length == 1)
                                    {
                                        sTwo = "0" + sTwo;
                                    }
                                    nPos = (mnCol - 1) * 8 + mnRow;
                                    fPlace2(sTwo, nPos);

                                }
                                else
                                {
                                    mnCol += 1;
                                    nValue = 7;
                                    sTwo = Convert.ToString(nValue);
                                    if (sTwo.Length == 1)
                                    {
                                        sTwo = "0" + sTwo;
                                    }
                                    nPos = (mnCol - 1) * 8 + mnRow;
                                    fPlace2(sTwo, nPos);

                                }
                            }
                            else
                            {
                                if (nLeft != 0)
                                {
                                    if (nDown >= nLeft)
                                    {
                                        mnRow += 1;
                                        nValue = 7;
                                        sTwo = Convert.ToString(nValue);
                                        if (sTwo.Length == 1)
                                        {
                                            sTwo = "0" + sTwo;
                                        }
                                        nPos = (mnCol - 1) * 8 + mnRow;
                                        fPlace2(sTwo, nPos);

                                    }
                                    else
                                    {
                                        mnCol -= 1;
                                        nValue = 7;
                                        sTwo = Convert.ToString(nValue);
                                        if (sTwo.Length == 1)
                                        {
                                            sTwo = "0" + sTwo;
                                        }
                                        nPos = (mnCol - 1) * 8 + mnRow;
                                        fPlace2(sTwo, nPos);

                                    }

                                }
                                else
                                {
                                    mnRow += 1;
                                    nValue = 7;
                                    sTwo = Convert.ToString(nValue);
                                    if (sTwo.Length == 1)
                                    {
                                        sTwo = "0" + sTwo;
                                    }
                                    nPos = (mnCol - 1) * 8 + mnRow;
                                    fPlace2(sTwo, nPos);
                                }
                            }
                        }

                        else
                        {
                            if (nRight != 0)
                            {
                                if (nUp >= nRight)
                                {
                                    mnRow -= 1;
                                    nValue = 7;
                                    sTwo = Convert.ToString(nValue);
                                    if (sTwo.Length == 1)
                                    {
                                        sTwo = "0" + sTwo;
                                    }
                                    nPos = (mnCol - 1) * 8 + mnRow;
                                    fPlace2(sTwo, nPos);

                                }
                                else
                                {
                                    mnCol += 1;
                                    nValue = 7;
                                    sTwo = Convert.ToString(nValue);
                                    if (sTwo.Length == 1)
                                    {
                                        sTwo = "0" + sTwo;
                                    }
                                    nPos = (mnCol - 1) * 8 + mnRow;
                                    fPlace2(sTwo, nPos);

                                }
                            }
                            else
                            {
                                if (nLeft != 0)
                                {
                                    if (nUp >= nLeft)
                                    {
                                        mnRow -= 1;
                                        nValue = 7;
                                        sTwo = Convert.ToString(nValue);
                                        if (sTwo.Length == 1)
                                        {
                                            sTwo = "0" + sTwo;
                                        }
                                        nPos = (mnCol - 1) * 8 + mnRow;
                                        fPlace2(sTwo, nPos);

                                    }
                                    else
                                    {
                                        mnCol -= 1;
                                        nValue = 7;
                                        sTwo = Convert.ToString(nValue);
                                        if (sTwo.Length == 1)
                                        {
                                            sTwo = "0" + sTwo;
                                        }
                                        nPos = (mnCol - 1) * 8 + mnRow;
                                        fPlace2(sTwo, nPos);

                                    }

                                }
                                else
                                {
                                    mnRow -= 1;
                                    nValue = 7;
                                    sTwo = Convert.ToString(nValue);
                                    if (sTwo.Length == 1)
                                    {
                                        sTwo = "0" + sTwo;
                                    }
                                    nPos = (mnCol - 1) * 8 + mnRow;
                                    fPlace2(sTwo, nPos);
                                }
                            }
                        }
                    }

                }
            } while (bFound != true);

         }
        private void fReset()
        {
            Random rnd1 = new Random();
            int nValue;
            String sTwo = null;
            int nMines = rnd1.Next(4, 15);
            int nCol = 0, nRow = 0;
            int nPos = 0;

            msShuffle1 = "01020304050607080910111213141516171819202122232425262728293021323334353637383940414243444546474849505152535455565758596061626364";
            msShuffle2 = null;
            mbShowAcross = false;
            mbShowDown = false;
            mnStage = 0;

            for (int i = 1; i <= 64; i++)
            {
                nValue = 1;
                sTwo = Convert.ToString(nValue);
                if (sTwo.Length == 1)
                {
                    sTwo = "0" + sTwo;
                 }
                msShuffle2 = msShuffle2 + sTwo;
            }
            nValue = 5;
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

            for (int i = 1; i <= nMines; i++)
            {
                fFree(ref nCol, ref nRow);
                nPos = (nCol - 1) * 8 + nRow;
                nValue = 4;
                sTwo = Convert.ToString(nValue);
                if (sTwo.Length == 1)
                {
                    sTwo = "0" + sTwo;
                    fPlace(sTwo, nPos);
                }
            }

            fUpdateDisplay();
         }

        private void fPeek(int nValue, int nRotate, ref PictureBox _pic2)
        {
            PictureBox picture1 = new PictureBox
            {
                Name = "pictureBox1",
                Image = Image.FromFile(@"F background.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture2 = new PictureBox
            {
                Name = "pictureBox2",
                Image = Image.FromFile(@"F marker1.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture3 = new PictureBox
            {
                Name = "pictureBox3",
                Image = Image.FromFile(@"F marker2.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture4 = new PictureBox
            {
                Name = "pictureBox4",
                Image = Image.FromFile(@"F mine.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture5 = new PictureBox
            {
                Name = "pictureBox5",
                Image = Image.FromFile(@"F wall.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture6 = new PictureBox
            {
                Name = "pictureBox6",
                Image = Image.FromFile(@"F wallacross.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture7 = new PictureBox
            {
                Name = "pictureBox7",
                Image = Image.FromFile(@"F walldown.png"),
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

        private int fHoletype(String sShuffle, int nSquare)
        {
            int nType = 0;

            nType = Convert.ToInt32(sShuffle.Substring(nSquare * 2 - 2, 2));
            return nType;
        }
        private int fHoletype2(String sShuffle, int nSquare)
        {
            int nType = 0;
            int nType2 = 0;

            nType = Convert.ToInt32(sShuffle.Substring(nSquare * 2 - 2, 2));
            if (mbShowAcross)
            {
                nType2 = Convert.ToInt32(msAcross.Substring(nSquare * 2 - 2, 2));
                if (nType2 != 1)
                {
                    nType = nType2;
                }
            }
            if (mbShowDown)
            {
                nType2 = Convert.ToInt32(msDown.Substring(nSquare * 2 - 2, 2));
                if (nType2 != 1)
                {
                    nType = nType2;
                }
            }
            return nType;
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
                if (nType ==1)
                {
                    bFound = true;
                }
            } while (bFound != true);

        }


        private void fPlace(String sText, int nPos)
        {
            msShuffle2 = msShuffle2.Substring(0, nPos * 2 - 2) + sText + msShuffle2.Substring(nPos * 2, (64 - nPos) * 2);
        }
        private void fPlace2(String sText, int nPos)
        {
            msAcross = msAcross.Substring(0, nPos * 2 - 2) + sText + msAcross.Substring(nPos * 2, (64 - nPos) * 2);
        }
        private void fPlace3(String sText, int nPos)
        {
            msDown = msDown.Substring(0, nPos * 2 - 2) + sText + msDown.Substring(nPos * 2, (64 - nPos) * 2);
        }

        public fSub1()
        {
            InitializeComponent();
        }

        private void fSub1_Load(object sender, EventArgs e)
        {
            fReset();
        }

        private void btnAcross_Click(object sender, EventArgs e)
        {
            int nValue;
            String sTwo;

            mbShowAcross = false;
            fUpdateDisplay();
            mnStage = 1;
            msAcross = null;
            mnButton = 1;
            for (int i = 1; i <= 64; i++)
            {
                nValue = 1;
                sTwo = Convert.ToString(nValue);
                if (sTwo.Length == 1)
                {
                    sTwo = "0" + sTwo;
                }
                msAcross = msAcross + sTwo;
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            int nValue;
            String sTwo;

            mbShowDown = false;
            fUpdateDisplay();
            mnStage = 1;
            msDown = null;
            mnButton = 2;
            for (int i = 1; i <= 64; i++)
            {
                nValue = 1;
                sTwo = Convert.ToString(nValue);
                if (sTwo.Length == 1)
                {
                    sTwo = "0" + sTwo;
                }
                msDown = msDown + sTwo;
            }
        }

        private void btnCancel1_Click(object sender, EventArgs e)
        {
            mbShowAcross = false;
            mnStage = 0;
            fUpdateDisplay();
        }

        private void btnCancel2_Click(object sender, EventArgs e)
        {
            mbShowDown = false;
            mnStage = 0;
            fUpdateDisplay();
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

        private void btnQNext_Click(object sender, EventArgs e)
        {
            fReset();
        }
    }
}
