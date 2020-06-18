using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryOfBao
{
    public class AlgorithmsHandle
    {
        // handle game caro
        public int HandleWinandLost(int m, int n, int lengtMT, int btn, int[,] matrix)
        {
            //call vertical location of  button click   hang doc X
            int vertical = m;
            int vertical2 = vertical;
            //call horizontal location of  button click hang ngang Y
            int horizontal = n;
            int horizontal2 = horizontal;
            int tren = 0, duoi = 0, trai = 0, phai = 0, cheotraitren = 0, cheophaitren = 0, dem = 1, cheotraiduoi = 0, cheophaiduoi = 0;

            // hander win from vertical
            for (int i = horizontal; i > 0; i--)
            {
                // check X from better to left
                if (matrix[vertical, i] == btn)
                {
                    trai++;
                }
                else
                    break;

            }

            for (int i = horizontal; i < lengtMT; i++)
            {
                // check X from better to right
                if (matrix[vertical, i] == btn)
                {
                    phai++;
                }
                else
                    break;
            }
            if (trai + phai >= 6)
                return btn;
            // hander win from horizontal
            for (int i = vertical; i > 0; i--)
            {
                // check X from better to top
                if (matrix[i, horizontal] == btn)
                {
                    tren++;
                }
                else
                    break;

            }

            for (int i = vertical; i < lengtMT; i++)
            {
                // check X from better to bottom
                if (matrix[i, horizontal] == btn)
                {
                    duoi++;
                }
                else
                    break;

            }
            if (tren + duoi >= 6)
            {

                tren = duoi = 0;
                return btn;
            }

            // hander win from cheotrai

            for (int i = 0; i <= vertical; i++)
            {
                if (vertical - i < 0 || horizontal - i < 0)
                    break;
                if (matrix[horizontal - i, vertical - i] == btn)
                {
                    cheotraitren++;
                }
                else
                    break;
            }

            for (int i = 1; i <= lengtMT - vertical; i++)
            {
                if (horizontal + i >= lengtMT || vertical + i >= lengtMT)
                    break;

                if (matrix[horizontal + i, vertical + i] == btn)
                {
                    cheophaiduoi++;
                }
                else
                    break;
            }

            if (cheophaiduoi + cheotraitren == 5)
            {

                cheophaiduoi = cheotraitren = 0;
                return btn;
            }




            for (int i = 0; i <= vertical; i++)
            {
                if (vertical + i > lengtMT || horizontal - i < 0)
                    break;

                if (matrix[horizontal - i, vertical + i] == btn)
                {
                    cheophaitren++;
                }
                else
                    break;
            }

            for (int i = 1; i <= lengtMT - vertical; i++)
            {
                if (horizontal + i >= lengtMT || vertical - i < 0)
                    break;

                if (matrix[horizontal + i, vertical - i] == btn)
                {
                    cheotraiduoi++;
                }
                else
                    break;
            }

            if (cheophaitren + cheotraiduoi >= 5)
            {

                cheophaitren = cheotraiduoi = 0;
                return btn;
            }

            //player1.Text = vertical.ToString();
            //player2.Text = horizontal.ToString();
            return -1;


        }


    }
}
