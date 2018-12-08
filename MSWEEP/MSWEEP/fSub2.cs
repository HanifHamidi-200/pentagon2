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
        private int nNumber;

        private void fReset()
        {
            Random rnd1 = new Random();
            String sTwo = null;
            int nCol = 0, nRow = 0;
            int nPos;
            int nValue;

            msShuffle = "01020304050607080910111213141516171819202122232425262728293031323334353637383940414243444546474849505152535455565758596061626364";
            msShuffle2 = null;
            msRotate = null;

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
            nValue = rnd1.Next(1, 5);
            sTwo = "0" + Convert.ToString(nValue);
            fPlace2(sTwo, nPos);


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
            nRotate = Convert.ToInt32(msRotate.Substring(nSquare * 2 - 2, 2));
            return nType;
        }


        private void fUpdateDisplay()
        {
            PictureBox _pic = new PictureBox();
            int nType, nRotate = 1;

            //1
            nType = fHoletype2(msShuffle2, 1, ref nRotate);
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
            nType = fHoletype2(msShuffle2, 62, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic87.Image = _pic.Image;
            nType = fHoletype2(msShuffle2, 64, ref nRotate);
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

        public fSub2()
        {
            InitializeComponent();
        }

        private void fSub2_Load(object sender, EventArgs e)
        {
            fReset();
        }

        private void btnQNext_Click(object sender, EventArgs e)
        {
            fReset();
        }
    }
}
