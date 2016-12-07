using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperOld
{
    class Board
    {
        const int Mine = -1;
        int[,] board;
        int n, m;
        public Board(int n, int m, int mines)
        {
            this.n = n;
            this.m = m;
            board = new int[n, m];

            setMinesRandom(mines);
            setMarkers();
        }

        void setMinesRandom(int mines)
        {
            int count = n * m;
            Random rand = new Random();

            //var minePos = Enumerable.Range(0, mines)
            //    .Select(i => rand.Next(0, count - i));
            //foreach (int pos in minePos)
            //    board[pos % m, pos / m] = -1;

            for (int k = 0; k < mines; k++)
            {
                int r = rand.Next(0, count - k);

                for (int j = 0; j < m; j++)
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (board[i, j] == Mine)
                            r++;
                        if (j * m + i == r & board[i, j] != Mine)
                            goto end;
                    }
                }
            end:
                board[r % m, r / m] = Mine;
            }
        }

        void setMarkers()
        {
            for (int j = 0; j < m; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    if (board[i,j] != Mine)
                    {
                        board[i,j] = 
                          (i > 0   && j > 0   && board[i-1,j-1] == Mine ? 1 : 0)
                        + (i > 0   &&            board[i-1,j  ] == Mine ? 1 : 0)
                        + (i > 0   && j < m-1 && board[i-1,j+1] == Mine ? 1 : 0)
                        + (           j > 0   && board[i  ,j-1] == Mine ? 1 : 0)
                        + (                      board[i  ,j  ] == Mine ? 1 : 0)
                        + (           j < m-1 && board[i  ,j+1] == Mine ? 1 : 0)
                        + (i < n-1 && j > 0   && board[i+1,j-1] == Mine ? 1 : 0)
                        + (i < n-1 &&            board[i+1,j  ] == Mine ? 1 : 0)
                        + (i < n-1 && j < m-1 && board[i+1,j+1] == Mine ? 1 : 0)
                        ;
                    }
                }
            }
        }

        public void print()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    Console.Write(board[i, j] == Mine ? "*" : board[i, j].ToString());
                Console.WriteLine();
            }
        }
    }
}
