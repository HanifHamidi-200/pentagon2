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
    public partial class fSub3 : Form
    {
        private String msShuffle1;
        private String msShuffle2;
        private String msRotate;
        private int nNumber;
        private bool mbJob1, mbJob2, mbJob3;
        private int mnCol, mnRow;
        private int mnSafeCol, mnSafeRow;
        private bool mbActivated;

        private void fReset()
        {
            Random rnd1 = new Random();
            int nValue;
            String sThree = null;
            int nTimes = rnd1.Next(1,5);
            int nLength = rnd1.Next(1, 4);
            int nDiamonds = rnd1.Next(6, 21);
            int nCol = 0, nRow = 0;
            int nPos;
            int nDirection;

            msShuffle1 = "001002003004005006007008009010011012013014015016017018019020021022023024025026027028029030031032033034035036037038039040041042043044045046047048049050051052053054055056057058059060061062063064065066067068069070071072073074075076077078079080081082083084085086087088089090091092093094095096097098099100101102103104105106107108109110111112113114115116117118119120";
            msShuffle2 = null;
            msRotate = null;

            nNumber = rnd1.Next(1, 10);
            if (nNumber <= 5)
            {
                mbJob1 = true;
            }
            else
            {
                mbJob1 = true;
            }
            nNumber = rnd1.Next(1, 10);
            if (nNumber <= 5)
            {
                mbJob2 = true;
            }
            else
            {
                mbJob2 = true;
            }
            nNumber = rnd1.Next(1, 10);
            if (nNumber <= 5)
            {
                mbJob3 = true;
            }
            else
            {
                mbJob3 = true;
            }

            for (int i = 1; i <= 120; i++)
            {
                nValue = 1;
                sThree = Convert.ToString(nValue);
                if (sThree.Length == 1)
                {
                    sThree = "00" + sThree;
                    msShuffle2 = msShuffle2 + sThree;
                }
                else
                {
                    if (sThree.Length == 2)
                    {
                        sThree = "0" + sThree;
                        msShuffle2 = msShuffle2 + sThree;
                    }
                }
                msRotate = msRotate + "001";
            }

            if (mbJob1)
            {
                for (int i = 1; i <= nTimes; i++)
                {
                    fFree(ref nCol, ref nRow);
                    nPos = (nCol - 1) * 10 + nRow;
                    fPlace("007", nPos);
                    mnCol = nCol;
                    mnRow = nRow;
                    nDirection = rnd1.Next(1, 5);
                    for (int j = 1; j <= nLength; j++)
                    {
                        fNext(nDirection, ref mnCol, ref mnRow);
                        if (mnCol == 0)
                        {
                            goto nextline;
                        }
                        nPos = (mnCol - 1) * 10 + mnRow;
                        fPlace("002", nPos);
                        switch (nDirection)
                        {
                            case 1:
                                fPlace2("003", nPos);
                                break;
                            case 2:
                                fPlace2("004", nPos);
                                break;
                            case 3:
                                fPlace2("001", nPos);
                                break;
                            default:
                                fPlace2("002", nPos);
                                break;
                        }
                    }

                nextline:;
                }
            }

            if (mbJob2)
            {
                for (int i = 1; i <= nDiamonds; i++)
                {
                    fFree(ref nCol, ref nRow);
                    nPos = (nCol - 1) * 10 + nRow;
                    fPlace("003", nPos);
                }
            }

            if (mbJob3)
            {
                fFree(ref nCol, ref nRow);
                nPos = (nCol - 1) * 10 + nRow;
                fPlace("006", nPos);
                fFree(ref nCol, ref nRow);
                mnSafeCol = nCol;
                mnSafeRow = nRow;
            }
            fUpdateDisplay();
        }

        private void fNext(int nDirection,ref int nCol,ref int nRow)
        {
            switch (nDirection)
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
               default:
                    nCol -= 1;
                    break;
            }
            if (nRow == 0)
            {
                nCol = 0;
                nRow = 0;
            }
            else
            {
                if (nRow == 11)
                {
                    nCol = 0;
                    nRow = 0;

                }
                else
                {
                    if (nCol == 0)
                    {
                        nCol = 0;
                        nRow = 0;

                    }
                    else
                    {
                        if (nCol == 13)
                        {
                            nCol = 0;
                            nRow = 0;

                        }
                    }
                }
            }
        }

        private void fUpdateDisplay()
        {
            PictureBox _pic = new PictureBox();
            int nType, nRotate = 1;

            //1
            nType = fHoletype(msShuffle2, 1,ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic11.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 2, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic12.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 3, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic13.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 4, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic14.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 5, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic15.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 6, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic16.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 7, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic17.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 8, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic18.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 9, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic19.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 10, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic1a.Image = _pic.Image;

            //2
            nType = fHoletype(msShuffle2, 11, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic21.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 12, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic22.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 13, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic23.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 14, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic24.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 15, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic25.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 16, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic26.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 17, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic27.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 18, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic28.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 19, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic29.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 20, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic2a.Image = _pic.Image;

            //3
            nType = fHoletype(msShuffle2, 21, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic31.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 22, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic32.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 23, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic33.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 24, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic34.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 25, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic35.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 26, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic36.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 27, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic37.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 28, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic38.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 29, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic39.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 30, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic3a.Image = _pic.Image;

            //4
            nType = fHoletype(msShuffle2, 31, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic41.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 32, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic42.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 33, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic43.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 34, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic44.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 35, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic45.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 36, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic46.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 37, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic47.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 38, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic48.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 39, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic49.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 40, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic4a.Image = _pic.Image;

            //5
            nType = fHoletype(msShuffle2, 41, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic51.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 42, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic52.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 43, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic53.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 44, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic54.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 45, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic55.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 46, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic56.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 47, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic57.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 48, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic58.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 49, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic59.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 50, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic5a.Image = _pic.Image;

            //6
            nType = fHoletype(msShuffle2, 51, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic61.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 52, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic62.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 53, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic63.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 54, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic64.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 55, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic65.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 56, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic66.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 57, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic67.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 58, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic68.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 59, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic69.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 60, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic6a.Image = _pic.Image;

            //7
            nType = fHoletype(msShuffle2, 61, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic71.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 62, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic72.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 63, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic73.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 64, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic74.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 65, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic75.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 66, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic76.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 67, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic77.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 68, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic78.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 69, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic79.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 70, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic7a.Image = _pic.Image;

            //8
            nType = fHoletype(msShuffle2, 71, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic81.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 72, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic82.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 73, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic83.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 74, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic84.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 75, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic85.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 76, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic86.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 77, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic87.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 78, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic88.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 79, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic89.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 80, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic8a.Image = _pic.Image;

            //9
            nType = fHoletype(msShuffle2, 81, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic91.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 82, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic92.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 83, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic93.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 84, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic94.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 85, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic95.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 86, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic96.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 87, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic97.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 88, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic98.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 89, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic99.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 90, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pic9a.Image = _pic.Image;

            //10
            nType = fHoletype(msShuffle2, 91, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pica1.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 92, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pica2.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 93, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pica3.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 94, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pica4.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 95, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pica5.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 96, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pica6.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 97, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pica7.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 98, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pica8.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 99, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            pica9.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 100, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            picaa.Image = _pic.Image;

            //11
            nType = fHoletype(msShuffle2, 101, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            picb1.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 102, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            picb2.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 103, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            picb3.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 104, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            picb4.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 105, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            picb5.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 106, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            picb6.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 107, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            picb7.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 108, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            picb8.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 109, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            picb9.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 110, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            picba.Image = _pic.Image;

            //12
            nType = fHoletype(msShuffle2, 111, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            picc1.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 112, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            picc2.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 113, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            picc3.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 114, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            picc4.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 115, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            picc5.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 116, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            picc6.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 117, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            picc7.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 118, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            picc8.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 119, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            picc9.Image = _pic.Image;
            nType = fHoletype(msShuffle2, 120, ref nRotate);
            fPeek(nType, nRotate, ref _pic);
            picca.Image = _pic.Image;

        }

        private int fHoletype(String sShuffle, int nSquare,ref int nRotate)
        {
            int nType = 0;

            nType = Convert.ToInt32(sShuffle.Substring(nSquare * 3 - 3, 3));
            nRotate = Convert.ToInt32(msRotate.Substring(nSquare * 3 - 3, 3));
            return nType;
        }


        private void fPlace(String sText, int nPos)
        {
            if (nPos == 120)
            {
                msShuffle2 = msShuffle2.Substring(0, nPos * 3 - 3) + sText;

            }
            else
            {
                msShuffle2 = msShuffle2.Substring(0, nPos * 3 - 3) + sText + msShuffle2.Substring(nPos * 3, (120 - nPos) * 3);

            }
        }
        private void fPlace2(String sText, int nPos)
        {
            if (nPos == 120)
            {
                msRotate = msRotate.Substring(0, nPos * 3 - 3) + sText;

            }
            else
            {
                msRotate = msRotate.Substring(0, nPos * 3 - 3) + sText + msRotate.Substring(nPos * 2, (120 - nPos) * 3);

            }
        }

        private void fFree(ref int nCol, ref int nRow)
        {
            Random rnd1 = new Random();
            bool bFound = false;
            String sData;
            int nValue;

            do
            {
                nCol = rnd1.Next(1, 13);
                nRow = rnd1.Next(1, 11);
                sData = fData(nCol, nRow);
                nValue = Convert.ToInt32(sData);
                if (nValue == 1)
                {
                    bFound = true;
                }
            } while (bFound == false);
        }

        private void btnQNext_Click(object sender, EventArgs e)
        {
            fReset();
        }

        private String fData(int nCol, int nRow)
        {
            int nPos = (nCol - 1) * 8 + nRow;
            String sThree = msShuffle2.Substring(nPos * 3 - 3, 3);

            return sThree;
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
                Image = Image.FromFile(@"F arrows.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture3 = new PictureBox
            {
                Name = "pictureBox3",
                Image = Image.FromFile(@"F cornerdiamonds.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture4 = new PictureBox
            {
                Name = "pictureBox4",
                Image = Image.FromFile(@"F cornerdiamonds2.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture5 = new PictureBox
            {
                Name = "pictureBox5",
                Image = Image.FromFile(@"F mines.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture6 = new PictureBox
            {
                Name = "pictureBox6",
                Image = Image.FromFile(@"F SafeSwitch.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture7 = new PictureBox
            {
                Name = "pictureBox7",
                Image = Image.FromFile(@"F spongeblock.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture8 = new PictureBox
            {
                Name = "pictureBox8",
                Image = Image.FromFile(@"F stoneblock.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture9 = new PictureBox
            {
                Name = "pictureBox9",
                Image = Image.FromFile(@"F thepits.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture10 = new PictureBox
            {
                Name = "pictureBox10",
                Image = Image.FromFile(@"F tree.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture11 = new PictureBox
            {
                Name = "pictureBox11",
                Image = Image.FromFile(@"F woodblock.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            PictureBox picture12 = new PictureBox
            {
                Name = "pictureBox12",
                Image = Image.FromFile(@"F woodblock2.png"),
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

        public fSub3()
        {
            InitializeComponent();
        }

        private void fSub3_Load(object sender, EventArgs e)
        {
            fReset();
        }
    }
}
