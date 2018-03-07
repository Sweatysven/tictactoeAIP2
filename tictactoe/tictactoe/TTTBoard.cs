using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tictactoe
{

    // Inherits classes from the abstract class: Board

    class TTTBoard : Board
    {
        // We set the size of the table in this constructor. Where each space is assigned the number 0.
        // As mentioned earlier, the number 0 stands for an open space.
        public TTTBoard()
        {
            squares = new Player[3, 3]
            {
                {0, 0, 0},
                {0, 0, 0},
                {0, 0, 0}
            };
        }

        public override Player this[int x, int y]
        {
            get
            {
                return squares[x, y];
            }
            set
            {
                squares[x, y] = value;
            }
        }

        // We overwrite with the following
        public override bool IsComplete
        {
            get
            {
                foreach (Player p in squares)
                {
                    if (p == Player.Open)
                    {
                        return false;
                    }
                }
                    return true;
            }
        }

        // 9 spaces is the size of the board. Would be weird to have more options in this kind of game. 
        public override int BoardSize
        {
            get
            {
                return 9;
            }
        }

        public override List<BoardSpace> OpenSquares 
        {
            get 
            {
                List<BoardSpace> openSquares = new List<BoardSpace>();

                for (int x = 0; x <= 2; x++) 
                {
                    for (int y = 0; y <= 2; y++) 
                    {
                        if (squares[x, y] == Player.Open) 
                        {
                            openSquares.Add(new BoardSpace(x, y));
                        }
                    }     
                }   
                return OpenSquares;
            }   
        }

        public override Player Winner 
        {
            get 
            {
                int count = 0;

                // for the coloums
                for (int x = 0; x < 3; x++) 
                {
                    count = 0;

                    for (int y = 0; y < 3; y++) 
                    {
                        count += (int)squares[y, x];
                    }

                    if (count == 3) 
                    {
                        return Player.X;
                    }
                    if (count == -3) 
                    {
                        return Player.O;
                    }
                }

                // for the rows
                for (int x = 0; x < 3; x++) 
                {
                    count = 0;

                    for (int y = 0; y < 3; y++) 
                    {
                        count += (int)squares[y, x];
                    }

                    if (count == 3) 
                    {
                        return Player.X;
                    }
                    if (count == -3) 
                    {
                        return Player.O;
                    }
                }

                // right to left - diagonal
                count = 0;
                count += (int)squares[0, 0];
                count += (int)squares[1, 1];
                count += (int)squares[2, 2];

                if (count == 3) 
                {
                    return Player.X;
                }
                if (count == -3) 
                {
                    return Player.O;
                }

                // left to right - diagonal
                count = 0;
                count += (int)squares[0, 2];
                count += (int)squares[1, 1];
                count += (int)squares[2, 0];

                if (count == 3) 
                {
                    return Player.X;
                }
                if (count == -3) 
                {
                    return Player.O;
                }

                return Player.Open;
            }
        }

        public override Board Recreate()
        {
            Board b = new TTTBoard();
            b.squares = (Player[,])this.squares.Recreate();
            return b;
        }
    }
}
