using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CIRCRY
{
    public partial class Form1 : Form
    {
        private String msShuffle1,msShuffle2,msShuffle3,msShuffle4,msShuffle5;
        private int nNumber;
        private int mnItem = 0;

        private void fClick(int nSet,int nCol,int nRow)
        {
            if (mnItem == 0)
            {
                goto endline;
            }

            fPlace(mnItem, nSet, nCol, nRow);
            fUpdateDisplay();

        endline:;
        }


        private int fSquare(int nSet,int nCol, int nRow)
        {
            switch (nSet)
            {
                case 1:
                    return (nCol - 1) * 8 + nRow;
                case 2:
                    return (nCol - 1) * 4 + nRow;
                case 3:
                    return (nCol - 1) * 1 + nRow;
                  default:
                    return (nCol - 1) * 2 + nRow;
            }
        }
        private void fPlace(int nType, int nSet,int nCol, int nRow)
        {
            String sTwo;
            int nSquare = fSquare(nSet,nCol, nRow);

            sTwo = Convert.ToString(nType);
            switch (nSet)
            {
                case 1:
                    msShuffle1 = msShuffle1.Substring(0, nSquare - 1) + sTwo + msShuffle1.Substring(nSquare, (24 - nSquare));
                    break;
                case 2:
                    msShuffle2 = msShuffle2.Substring(0, nSquare - 1) + sTwo + msShuffle2.Substring(nSquare, (16 - nSquare));
                    break;
                case 3:
                    msShuffle3 = msShuffle3.Substring(0, nSquare - 1) + sTwo + msShuffle3.Substring(nSquare, (2 - nSquare));
                    break;
                case 4:
                    msShuffle4 = msShuffle4.Substring(0, nSquare - 1) + sTwo + msShuffle4.Substring(nSquare, (4 - nSquare));
                    break;
                default:
                    msShuffle5 = msShuffle5.Substring(0, nSquare - 1) + sTwo + msShuffle5.Substring(nSquare, (16 - nSquare));
                    break;
            }
        }

        private void fReset()
        {
            Random rnd1 = new Random();

            msShuffle1 = null;
            msShuffle2 = null;
            msShuffle3 = null;
            msShuffle4 = null;
            msShuffle5 = null;


            for (int i = 1; i <= 24; i++)
            {
                nNumber = rnd1.Next(1, 4);
                msShuffle1 = msShuffle1 + Convert.ToString(nNumber);
            }
            for (int i = 1; i <= 16; i++)
            {
                nNumber = rnd1.Next(1, 4);
                msShuffle2 = msShuffle2 + Convert.ToString(nNumber);
            }
            for (int i = 1; i <= 2; i++)
            {
                nNumber = rnd1.Next(1, 4);
                msShuffle3 = msShuffle3 + Convert.ToString(nNumber);
            }
            for (int i = 1; i <= 4; i++)
            {
                nNumber = rnd1.Next(1, 4);
                msShuffle4 = msShuffle4 + Convert.ToString(nNumber);
            }
            for (int i = 1; i <= 16; i++)
            {
                nNumber = rnd1.Next(1, 4);
                msShuffle5 = msShuffle5 + Convert.ToString(nNumber);
            }

            fUpdateDisplay();
        }
        private int fHoletype(String sShuffle, int nSquare)
        {
            int nType = 0;

            nType = Convert.ToInt32(sShuffle.Substring(nSquare - 1, 1));
      
            return nType;
        }

        private void btnQNext_Click(object sender, EventArgs e)
        {
            fReset();
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            mnItem = 4;
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            mnItem = 5;
        }

        private void pica11_Click(object sender, EventArgs e)
        {
            fClick(1, 1, 1);
        }

        private void pica12_Click(object sender, EventArgs e)
        {
            fClick(1, 1, 2);
        }

        private void pica13_Click(object sender, EventArgs e)
        {
            fClick(1, 1, 3);
        }

        private void pica14_Click(object sender, EventArgs e)
        {
            fClick(1, 1, 4);
        }

        private void pica15_Click(object sender, EventArgs e)
        {
            fClick(1, 1, 5);
        }

        private void pica16_Click(object sender, EventArgs e)
        {
            fClick(1, 1, 6);
        }

        private void pica17_Click(object sender, EventArgs e)
        {
            fClick(1, 1, 7);
        }

        private void pica18_Click(object sender, EventArgs e)
        {
            fClick(1, 1, 1);
        }

        private void pica21_Click(object sender, EventArgs e)
        {
            fClick(1, 2, 1);
        }

        private void pica22_Click(object sender, EventArgs e)
        {
            fClick(1, 2, 2);
        }

        private void pica23_Click(object sender, EventArgs e)
        {
            fClick(1, 2, 3);
        }

        private void pica24_Click(object sender, EventArgs e)
        {
            fClick(1, 2, 4);
        }

        private void pica25_Click(object sender, EventArgs e)
        {
            fClick(1, 2, 5);
        }

        private void pica26_Click(object sender, EventArgs e)
        {
            fClick(1, 2, 6);
        }

        private void pica27_Click(object sender, EventArgs e)
        {
            fClick(1, 2, 7);
        }

        private void pica28_Click(object sender, EventArgs e)
        {
            fClick(1, 2, 8);
        }

        private void pica31_Click(object sender, EventArgs e)
        {
            fClick(1, 3, 1);
        }

        private void pica32_Click(object sender, EventArgs e)
        {
            fClick(1, 3, 2);
        }

        private void pica33_Click(object sender, EventArgs e)
        {
            fClick(1, 3, 3);
        }

        private void pica34_Click(object sender, EventArgs e)
        {
            fClick(1, 3, 4);
        }

        private void pica35_Click(object sender, EventArgs e)
        {
            fClick(1, 3, 5);
        }

        private void pica36_Click(object sender, EventArgs e)
        {
            fClick(1, 3, 6);
        }

        private void pica37_Click(object sender, EventArgs e)
        {
            fClick(1, 3, 7);
        }

        private void pica38_Click(object sender, EventArgs e)
        {
            fClick(1, 3, 8);
        }

        private void picb11_Click(object sender, EventArgs e)
        {
            fClick(2, 1, 1);
        }

        private void picb12_Click(object sender, EventArgs e)
        {
            fClick(2, 1, 2);
        }

        private void picb13_Click(object sender, EventArgs e)
        {
            fClick(2, 1, 3);
        }

        private void picb14_Click(object sender, EventArgs e)
        {
            fClick(2, 1, 4);
        }

        private void picb21_Click(object sender, EventArgs e)
        {
            fClick(2, 2, 1);
        }

        private void picb22_Click(object sender, EventArgs e)
        {
            fClick(2, 2, 2);
        }

        private void picb23_Click(object sender, EventArgs e)
        {
            fClick(2, 2, 3);
        }

        private void picb24_Click(object sender, EventArgs e)
        {
            fClick(2, 2, 4);
        }

        private void picb31_Click(object sender, EventArgs e)
        {
            fClick(2, 3, 1);
        }

        private void picb32_Click(object sender, EventArgs e)
        {
            fClick(2, 3, 2);
        }

        private void picb33_Click(object sender, EventArgs e)
        {
            fClick(2, 3, 3);
        }

        private void picb34_Click(object sender, EventArgs e)
        {
            fClick(2, 3, 4);
        }

        private void picb41_Click(object sender, EventArgs e)
        {
            fClick(2, 4, 1);
        }

        private void picb42_Click(object sender, EventArgs e)
        {
            fClick(2, 4, 2);
        }

        private void picb43_Click(object sender, EventArgs e)
        {
            fClick(2, 4, 3);
        }

        private void picb44_Click(object sender, EventArgs e)
        {
            fClick(2, 4, 4);
        }

        private void picc11_Click(object sender, EventArgs e)
        {
            fClick(3, 1, 1);
        }

        private void picc21_Click(object sender, EventArgs e)
        {
            fClick(3, 2, 1);
        }

        private void picd11_Click(object sender, EventArgs e)
        {
            fClick(4, 1, 1);
        }

        private void picd12_Click(object sender, EventArgs e)
        {
            fClick(4, 1, 2);
        }

        private void picd21_Click(object sender, EventArgs e)
        {
            fClick(4, 2, 1);
        }

        private void picd22_Click(object sender, EventArgs e)
        {
            fClick(4, 2, 2);
        }

        private void pice11_Click(object sender, EventArgs e)
        {
            fClick(5, 1, 1);
        }

        private void pice12_Click(object sender, EventArgs e)
        {
            fClick(5, 1, 2);
        }

        private void pice21_Click(object sender, EventArgs e)
        {
            fClick(5, 2, 1);
        }

        private void pice22_Click(object sender, EventArgs e)
        {
            fClick(5, 2, 2);
        }

        private void pice31_Click(object sender, EventArgs e)
        {
            fClick(5, 3, 1);
        }

        private void pice32_Click(object sender, EventArgs e)
        {
            fClick(5, 3, 2);
        }

        private void pice41_Click(object sender, EventArgs e)
        {
            fClick(5, 4, 1);
        }

        private void pice42_Click(object sender, EventArgs e)
        {
            fClick(5, 4, 2);
        }

        private void pice51_Click(object sender, EventArgs e)
        {
            fClick(5, 5, 1);
        }

        private void pice52_Click(object sender, EventArgs e)
        {
            fClick(5, 5, 2);
        }

        private void pice61_Click(object sender, EventArgs e)
        {
            fClick(5, 6, 1);
        }

        private void pice62_Click(object sender, EventArgs e)
        {
            fClick(5, 6, 2);
        }

        private void pice71_Click(object sender, EventArgs e)
        {
            fClick(5, 7, 1);
        }

        private void pice72_Click(object sender, EventArgs e)
        {
            fClick(5, 7, 2);
        }

        private void pice81_Click(object sender, EventArgs e)
        {
            fClick(5, 8, 1);
        }

        private void pice82_Click(object sender, EventArgs e)
        {
            fClick(5, 8, 2);
        }

        private void fUpdateDisplay()
        {
           PictureBox _pic = new PictureBox();
            int nType, nRotate = 1;

            //1
            nType = fHoletype(msShuffle1, 1);
            fPeek(nType, nRotate, ref _pic);
            pica11.Image = _pic.Image;
            nType = fHoletype(msShuffle1, 2);
            fPeek(nType, nRotate, ref _pic);
            pica12.Image = _pic.Image;
            nType = fHoletype(msShuffle1, 3);
            fPeek(nType, nRotate, ref _pic);
            pica13.Image = _pic.Image;
            nType = fHoletype(msShuffle1, 4);
            fPeek(nType, nRotate, ref _pic);
            pica14.Image = _pic.Image;
            nType = fHoletype(msShuffle1, 5);
            fPeek(nType, nRotate, ref _pic);
            pica15.Image = _pic.Image;
            nType = fHoletype(msShuffle1, 6);
            fPeek(nType, nRotate, ref _pic);
            pica16.Image = _pic.Image;
            nType = fHoletype(msShuffle1, 7);
            fPeek(nType, nRotate, ref _pic);
            pica17.Image = _pic.Image;
            nType = fHoletype(msShuffle1, 8);
            fPeek(nType, nRotate, ref _pic);
            pica18.Image = _pic.Image;

            nType = fHoletype(msShuffle1, 9);
            fPeek(nType, nRotate, ref _pic);
            pica21.Image = _pic.Image;
            nType = fHoletype(msShuffle1,10);
            fPeek(nType, nRotate, ref _pic);
            pica22.Image = _pic.Image;
            nType = fHoletype(msShuffle1, 11);
            fPeek(nType, nRotate, ref _pic);
            pica23.Image = _pic.Image;
            nType = fHoletype(msShuffle1, 12);
            fPeek(nType, nRotate, ref _pic);
            pica24.Image = _pic.Image;
            nType = fHoletype(msShuffle1, 13);
            fPeek(nType, nRotate, ref _pic);
            pica25.Image = _pic.Image;
            nType = fHoletype(msShuffle1, 14);
            fPeek(nType, nRotate, ref _pic);
            pica26.Image = _pic.Image;
            nType = fHoletype(msShuffle1, 15);
            fPeek(nType, nRotate, ref _pic);
            pica27.Image = _pic.Image;
            nType = fHoletype(msShuffle1, 16);
            fPeek(nType, nRotate, ref _pic);
            pica28.Image = _pic.Image;

            nType = fHoletype(msShuffle1, 17);
            fPeek(nType, nRotate, ref _pic);
            pica31.Image = _pic.Image;
            nType = fHoletype(msShuffle1, 18);
            fPeek(nType, nRotate, ref _pic);
            pica32.Image = _pic.Image;
            nType = fHoletype(msShuffle1, 19);
            fPeek(nType, nRotate, ref _pic);
            pica33.Image = _pic.Image;
            nType = fHoletype(msShuffle1, 20);
            fPeek(nType, nRotate, ref _pic);
            pica34.Image = _pic.Image;
            nType = fHoletype(msShuffle1, 21);
            fPeek(nType, nRotate, ref _pic);
            pica35.Image = _pic.Image;
            nType = fHoletype(msShuffle1, 22);
            fPeek(nType, nRotate, ref _pic);
            pica36.Image = _pic.Image;
            nType = fHoletype(msShuffle1, 23);
            fPeek(nType, nRotate, ref _pic);
            pica37.Image = _pic.Image;
            nType = fHoletype(msShuffle1, 24);
            fPeek(nType, nRotate, ref _pic);
            pica38.Image = _pic.Image;

            //2
            nType = fHoletype(msShuffle2, 1);
            fPeek(nType, nRotate, ref _pic);
            picb11.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 2);
            fPeek(nType, nRotate, ref _pic);
            picb12.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 3);
            fPeek(nType, nRotate, ref _pic);
            picb13.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 4);
            fPeek(nType, nRotate, ref _pic);
            picb14.Image = _pic.Image;

            nType = fHoletype(msShuffle2, 5);
            fPeek(nType, nRotate, ref _pic);
            picb21.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 6);
            fPeek(nType, nRotate, ref _pic);
            picb22.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 7);
            fPeek(nType, nRotate, ref _pic);
            picb23.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 8);
            fPeek(nType, nRotate, ref _pic);
            picb24.Image = _pic.Image;

            nType = fHoletype(msShuffle2, 9);
            fPeek(nType, nRotate, ref _pic);
            picb31.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 10);
            fPeek(nType, nRotate, ref _pic);
            picb32.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 11);
            fPeek(nType, nRotate, ref _pic);
            picb33.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 12);
            fPeek(nType, nRotate, ref _pic);
            picb34.Image = _pic.Image;

            nType = fHoletype(msShuffle2, 13);
            fPeek(nType, nRotate, ref _pic);
            picb41.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 14);
            fPeek(nType, nRotate, ref _pic);
            picb42.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 15);
            fPeek(nType, nRotate, ref _pic);
            picb43.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 16);
            fPeek(nType, nRotate, ref _pic);
            picb44.Image = _pic.Image;

            //3
            nType = fHoletype(msShuffle3, 1);
            fPeek(nType, nRotate, ref _pic);
            picc11.Image = _pic.Image;
            nType = fHoletype(msShuffle3, 2);
            fPeek(nType, nRotate, ref _pic);
            picc21.Image = _pic.Image;

            //4
            nType = fHoletype(msShuffle4, 1);
            fPeek(nType, nRotate, ref _pic);
            picd11.Image = _pic.Image;
            nType = fHoletype(msShuffle4, 2);
            fPeek(nType, nRotate, ref _pic);
            picd12.Image = _pic.Image;
            nType = fHoletype(msShuffle4, 3);
            fPeek(nType, nRotate, ref _pic);
            picd21.Image = _pic.Image;
            nType = fHoletype(msShuffle4, 4);
            fPeek(nType, nRotate, ref _pic);
            picd22.Image = _pic.Image;

            //5
            nType = fHoletype(msShuffle5, 1);
            fPeek(nType, nRotate, ref _pic);
            pice11.Image = _pic.Image;
            nType = fHoletype(msShuffle5, 2);
            fPeek(nType, nRotate, ref _pic);
            pice12.Image = _pic.Image;
            nType = fHoletype(msShuffle5, 3);
            fPeek(nType, nRotate, ref _pic);
            pice21.Image = _pic.Image;
            nType = fHoletype(msShuffle5, 4);
            fPeek(nType, nRotate, ref _pic);
            pice22.Image = _pic.Image;

            nType = fHoletype(msShuffle5, 5);
            fPeek(nType, nRotate, ref _pic);
            pice31.Image = _pic.Image;
            nType = fHoletype(msShuffle5, 6);
            fPeek(nType, nRotate, ref _pic);
            pice32.Image = _pic.Image;
            nType = fHoletype(msShuffle5, 7);
            fPeek(nType, nRotate, ref _pic);
            pice41.Image = _pic.Image;
            nType = fHoletype(msShuffle5, 8);
            fPeek(nType, nRotate, ref _pic);
            pice42.Image = _pic.Image;

            nType = fHoletype(msShuffle5, 9);
            fPeek(nType, nRotate, ref _pic);
            pice51.Image = _pic.Image;
            nType = fHoletype(msShuffle5, 10);
            fPeek(nType, nRotate, ref _pic);
            pice52.Image = _pic.Image;
            nType = fHoletype(msShuffle5, 11);
            fPeek(nType, nRotate, ref _pic);
            pice61.Image = _pic.Image;
            nType = fHoletype(msShuffle5, 12);
            fPeek(nType, nRotate, ref _pic);
            pice62.Image = _pic.Image;

            nType = fHoletype(msShuffle5, 13);
            fPeek(nType, nRotate, ref _pic);
            pice71.Image = _pic.Image;
            nType = fHoletype(msShuffle5, 14);
            fPeek(nType, nRotate, ref _pic);
            pice72.Image = _pic.Image;
            nType = fHoletype(msShuffle5, 15);
            fPeek(nType, nRotate, ref _pic);
            pice81.Image = _pic.Image;
            nType = fHoletype(msShuffle5, 16);
            fPeek(nType, nRotate, ref _pic);
            pice82.Image = _pic.Image;
        }

        private void fPeek(int nValue, int nRotate, ref PictureBox _pic2)
        {
            PictureBox picture1 = new PictureBox
            {
                Name = "pictureBox1",
                Image = Image.FromFile(@"F blue.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture2 = new PictureBox
            {
                Name = "pictureBox2",
                Image = Image.FromFile(@"F green.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture3 = new PictureBox
            {
                Name = "pictureBox3",
                Image = Image.FromFile(@"F red.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture4 = new PictureBox
            {
                Name = "pictureBox4",
                Image = Image.FromFile(@"F HoneycombManoevre.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture5 = new PictureBox
            {
                Name = "pictureBox5",
                Image = Image.FromFile(@"F PrecisionPoint.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture6 = new PictureBox
            {
                Name = "pictureBox6",
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
                default:
                    _pic2 = picture6;
                    break;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fReset();
        }
    }
}
