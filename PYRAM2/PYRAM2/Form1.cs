using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PYRAM2
{
    public partial class Form1 : Form
    {
        private String msShuffle1;
        private String msShuffle2;
        private String msRotate2;
        private int nNumber;
        private void fReset()
        {
            Random rnd1 = new Random();
            int nValue;
        
            msShuffle1 = "01020304050607080910111213141516171819202122232425262728";
            msShuffle2 = "01010101010101010101010101010101010101010101010101010101";
            msRotate2 = "01010101010101010101010101010101010101010101010101010101";

            for (int i = 1; i <= 4; i++)
            {
                nValue = rnd1.Next(1, 8);
                fPlace(3, nValue, i); ;
            }

            fUpdateDisplay();
        }

        private int fSquare(int nCol, int nRow)
        {
            switch (nRow)
            {
                case 1:
                    switch (nCol)
                    {
                        case 1:
                            return 1;
                        case 2:
                            return 5;
                        case 3:
                            return 9;
                        case 4:
                            return 13;
                        case 5:
                            return 17;
                        case 6:
                            return 21;
                        default:
                            return 25;
                    }
                case 2:
                    switch (nCol)
                    {
                        case 1:
                            return 2;
                        case 2:
                            return 6;
                        case 3:
                            return 10;
                        case 4:
                            return 14;
                        case 5:
                            return 18;
                        case 6:
                            return 22;
                        default:
                            return 26;
                    }
                case 3:
                    switch (nCol)
                    {
                        case 1:
                            return 3;
                        case 2:
                            return 7;
                        case 3:
                            return 11;
                        case 4:
                            return 15;
                        case 5:
                            return 19;
                        case 6:
                            return 23;
                        default:
                            return 27;
                    }
                default:
                    switch (nCol)
                    {
                        case 1:
                            return 4;
                        case 2:
                            return 8;
                        case 3:
                            return 12;
                        case 4:
                            return 16;
                        case 5:
                            return 20;
                        case 6:
                            return 24;
                        default:
                            return 28;
                    }

            }
        }


        private void fPlace(int nType, int nCol, int nRow)
        {
            Random rnd1 = new Random();
            String sTwo;
            int nSquare = fSquare(nCol, nRow);

            nNumber = rnd1.Next(1, 10);

            sTwo = Convert.ToString(nType);
            if (sTwo.Length == 1)
            {
                sTwo = "0" + sTwo;
            }
            msShuffle2 = msShuffle2.Substring(0, nSquare * 2 - 2) + sTwo + msShuffle2.Substring(nSquare * 2, (28 - nSquare) * 2);
            if (nNumber <= 5)
            {
                sTwo = "02";
            }
            else
            {
                sTwo = "04";
            }
            msRotate2 = msRotate2.Substring(0, nSquare * 2 - 2) + sTwo + msRotate2.Substring(nSquare * 2, (28 - nSquare) * 2);
        }

        private void fPeek(int nValue, int nRotate, ref PictureBox _pic2)
        {
            PictureBox picture1 = new PictureBox
            {
                Name = "pictureBox1",
                Image = Image.FromFile(@"F sky.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture2 = new PictureBox
            {
                Name = "pictureBox2",
                Image = Image.FromFile(@"F block.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture3 = new PictureBox
            {
                Name = "pictureBox3",
                Image = Image.FromFile(@"F pusher.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture4 = new PictureBox
            {
                Name = "pictureBox4",
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
                default:
                    _pic2 = picture4;
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
        private int fRotatetype(String sShuffle, int nSquare)
        {
            int nType = 0;

            nType = Convert.ToInt32(sShuffle.Substring(nSquare * 2 - 2, 2));
            return nType;
        }
        private void fUpdateDisplay()
        {
            PictureBox _pic = new PictureBox();
            int nType, nRotate = 1;

            //1
            nType = fHoletype(msShuffle2, 1);
            nRotate = fHoletype(msRotate2, 1);
            fPeek(nType, nRotate, ref _pic);
            pic11.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 2);
            nRotate = fHoletype(msRotate2, 2);
            fPeek(nType, nRotate, ref _pic);
            pic12.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 3);
            nRotate = fHoletype(msRotate2, 3);
            fPeek(nType, nRotate, ref _pic);
            pic13.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 4);
            nRotate = fHoletype(msRotate2, 4);
            fPeek(nType, nRotate, ref _pic);
            pic14.Image = _pic.Image;

            //2
            nType = fHoletype(msShuffle2, 5);
            nRotate = fHoletype(msRotate2, 5);
            fPeek(nType, nRotate, ref _pic);
            pic21.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 6);
            nRotate = fHoletype(msRotate2, 6);
            fPeek(nType, nRotate, ref _pic);
            pic22.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 7);
            nRotate = fHoletype(msRotate2, 7);
            fPeek(nType, nRotate, ref _pic);
            pic23.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 8);
            nRotate = fHoletype(msRotate2, 8);
            fPeek(nType, nRotate, ref _pic);
            pic24.Image = _pic.Image;

            //3
            nType = fHoletype(msShuffle2, 9);
            nRotate = fHoletype(msRotate2, 9);
            fPeek(nType, nRotate, ref _pic);
            pic31.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 10);
            nRotate = fHoletype(msRotate2, 10);
            fPeek(nType, nRotate, ref _pic);
            pic32.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 11);
            nRotate = fHoletype(msRotate2, 11);
            fPeek(nType, nRotate, ref _pic);
            pic33.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 12);
            nRotate = fHoletype(msRotate2, 12);
            fPeek(nType, nRotate, ref _pic);
            pic34.Image = _pic.Image;

            //4
            nType = fHoletype(msShuffle2, 13);
            nRotate = fHoletype(msRotate2, 13);
            fPeek(nType, nRotate, ref _pic);
            pic41.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 14);
            nRotate = fHoletype(msRotate2, 14);
            fPeek(nType, nRotate, ref _pic);
            pic42.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 15);
            nRotate = fHoletype(msRotate2, 15);
            fPeek(nType, nRotate, ref _pic);
            pic43.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 16);
            nRotate = fHoletype(msRotate2, 16);
            fPeek(nType, nRotate, ref _pic);
            pic44.Image = _pic.Image;


            //5
            nType = fHoletype(msShuffle2, 17);
            nRotate = fHoletype(msRotate2, 17);
            fPeek(nType, nRotate, ref _pic);
            pic51.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 18);
            nRotate = fHoletype(msRotate2, 18);
            fPeek(nType, nRotate, ref _pic);
            pic52.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 19);
            nRotate = fHoletype(msRotate2, 19);
            fPeek(nType, nRotate, ref _pic);
            pic53.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 20);
            nRotate = fHoletype(msRotate2, 20);
            fPeek(nType, nRotate, ref _pic);
            pic54.Image = _pic.Image;

            //6
            nType = fHoletype(msShuffle2, 21);
            nRotate = fHoletype(msRotate2, 21);
            fPeek(nType, nRotate, ref _pic);
            pic61.Image = _pic.Image;
            nType = fHoletype(msShuffle2,22);
            nRotate = fHoletype(msRotate2, 22);
            fPeek(nType, nRotate, ref _pic);
            pic62.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 23);
            nRotate = fHoletype(msRotate2, 23);
            fPeek(nType, nRotate, ref _pic);
            pic63.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 24);
            nRotate = fHoletype(msRotate2, 24);
            fPeek(nType, nRotate, ref _pic);
            pic64.Image = _pic.Image;

            //7
            nType = fHoletype(msShuffle2, 25);
            nRotate = fHoletype(msRotate2, 25);
            fPeek(nType, nRotate, ref _pic);
            pic71.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 26);
            nRotate = fHoletype(msRotate2, 26);
            fPeek(nType, nRotate, ref _pic);
            pic72.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 27);
            nRotate = fHoletype(msRotate2, 27);
            fPeek(nType, nRotate, ref _pic);
            pic73.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 28);
            nRotate = fHoletype(msRotate2, 28);
            fPeek(nType, nRotate, ref _pic);
            pic74.Image = _pic.Image;

           }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fReset();
        }

        private void btnQNext_Click_1(object sender, EventArgs e)
        {
            fReset();
        }
    }
}
