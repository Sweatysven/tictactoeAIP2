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
                    if (p == Player.OpenSpace)
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

        //We find the open squares 
        public override List<BoardSpace> OpenSquares 
        {
            get 
            {
                List<BoardSpace> openSquares = new List<BoardSpace>();

                for (int x = 0; x <= 2; x++) 
                {
                    for (int y = 0; y <= 2; y++) 
                    {
                        if (squares[x, y] == Player.OpenSpace) // if the squares are open "0", then we add it to the board space
                        {
                            openSquares.Add(new BoardSpace(x, y));
                        }
                    }     
                }   
                return openSquares; //return the open squares 
            }   
        }

        //We find all the player O squares 
        public override List<BoardSpace> OSquares
        {
            get
            {
                List<BoardSpace> oSquares = new List<BoardSpace>();

                for (int x = 0; x <= 2; x++)
                {
                    for (int y = 0; y <= 2; y++)
                    {
                        if (squares[x, y] == Player.O) // if the squares are "1", then we add it to the board space
                        {
                            oSquares.Add(new BoardSpace(x, y));
                        }
                    }
                }
                return oSquares;
            }

        }

        //We find all the squares 
        public override List<BoardSpace> AllSquares
        {
            get
            {
                List<BoardSpace> allSquares = new List<BoardSpace>();

                for (int x = 0; x <= 2; x++)
                {
                    for (int y = 0; y <= 2; y++)
                    {
                        if (squares[x, y] == Player.OpenSpace || squares[x, y] == Player.X || squares[x, y] == Player.O) 
                        {
                            allSquares.Add(new BoardSpace(x, y));
                        }
                    }
                }
                return allSquares; 
            }
           
        }


        public override int possibilityToWin
        {
            get
            {
                List<string> count = new List<string>(new string[10]);
                int amountOfPos = 0;
                int addPos = 0;

                // Go through the coloums and add the numbers assigned to the spaces inside. 
                for (int x = 0; x < 3; x++)
                {
                    addPos = 0;

                    for (int y = 0; y < 3; y++)
                    {
                        addPos = 0;

                        count.Add(squares[x, y].ToString()); //Converting to ints for the count 
                        

                        if (count == null || count[0] == " " && count[1] == " " && count[2] == " " ||
                            count[0] == "O" && count[1] == " " && count[2] == " " ||
                            count[0] == "O" && count[1] == "O" && count[2] == " " ||
                            count[0] == "O" && count[1] == "O" && count[2] == "O")
                        {
                            addPos = 1;
                            amountOfPos += addPos;
                        }

                        if (count == null || count[3] == " " && count[4] == " " && count[5] == " " ||
                           count[3] == "O" && count[4] == " " && count[5] == " " ||
                           count[3] == "O" && count[4] == "O" && count[5] == " " ||
                           count[3] == "O" && count[4] == "O" && count[5] == "O")
                        {
                            addPos = 1;
                            amountOfPos += addPos;
                        }

                        if (count == null || count[6] == " " && count[7] == " " && count[8] == " " ||
                           count[6] == "O" && count[7] == " " && count[8] == " " ||
                           count[6] == "O" && count[7] == "O" && count[8] == " " ||
                           count[6] == "O" && count[7] == "O" && count[8] == "O")
                        {
                            addPos = 1;
                            amountOfPos += addPos;
                        }

                    }


                }

                // Go through the rows and add the numbers assigned to the spaces inside. 
                for (int x = 0; x < 3; x++)
                {
                    addPos = 0;

                    for (int y = 0; y < 3; y++)
                    {
                        addPos = 0;
                        count.Add(squares[y, x].ToString()); //Converting to ints for the count 


                        if (count[0] == " " && count[1] == " " && count[2] == " " ||
                           count[0] == "O" && count[1] == " " && count[2] == " " ||
                           count[0] == "O" && count[1] == "O" && count[2] == " " ||
                           count[0] == "O" && count[1] == "O" && count[2] == "O")
                        {
                            addPos = 1;
                            amountOfPos += addPos;
                        }

                        if (count[3] == " " && count[4] == " " && count[5] == " " ||
                           count[3] == "O" && count[4] == " " && count[5] == " " ||
                           count[3] == "O" && count[4] == "O" && count[5] == " " ||
                           count[3] == "O" && count[4] == "O" && count[5] == "O")
                        {
                            addPos = 1;
                            amountOfPos += addPos;
                        }

                        if (count[6] == " " && count[7] == " " && count[8] == " " ||
                           count[6] == "O" && count[7] == " " && count[8] == " " ||
                           count[6] == "O" && count[7] == "O" && count[8] == " " ||
                           count[6] == "O" && count[7] == "O" && count[8] == "O")
                        {
                            addPos = 1;
                            amountOfPos += addPos;
                        }

                    }
                   
                }

                return amountOfPos;              
            }
        }


        //Determine winner
        public override Player Winner 
        {
            get 
            {
                int count = 0;

                // Go through the coloums and add the numbers assigned to the spaces inside. 
               for (int x = 0; x < 3; x++) 
                {
                    count = 0;

                    for (int y = 0; y < 3; y++) 
                    {
                        count += (int)squares[x, y]; //Converting to ints for the count 
                    }

                    
                    if (count == 3)  //If the count in 1 column is 3, then player X wins
                    {
                        return Player.O;
                    }

                    if (count == -3)  //If the count in 1 column is -3, then player O wins
                    {
                        return Player.X;
                    }
                }

                // Go through the rows and add the numbers assigned to the spaces inside. 
                for (int x = 0; x < 3; x++) 
                {
                    count = 0;

                    for (int y = 0; y < 3; y++) 
                    {
                        count += (int)squares[y, x];   //Converting to ints for the count 
                    }

                    if (count == 3)  //If the count in 1 row is 3, then player X wins
                    {
                        return Player.O;
                    }

                    if (count == -3)  //If the count in 1 row is -3, then player O wins
                    {
                        return Player.X;
                    }
                }

                // right to left - diagonal
                count = 0;
                count += (int)squares[0, 0];
                count += (int)squares[1, 1];
                count += (int)squares[2, 2];

                if (count == 3) 
                {
                    return Player.O;
                }
                if (count == -3) 
                {
                    return Player.X;
                }

                // left to right - diagonal
                count = 0;
                count += (int)squares[0, 2];
                count += (int)squares[1, 1];
                count += (int)squares[2, 0];

                if (count == 3) 
                {
                    return Player.O;
                }
                if (count == -3) 
                {
                    return Player.X;
                }

                //else return openSpace
                return Player.OpenSpace;
            }
        }

        //In order for the TicTacToc board to inherit from the game board, we override the board clone, create a new board, 
        //and then we also clone the squares from "this" board
        public override Board Clone()
        {
            Board b = new TTTBoard();
            b.squares = (Player[,])this.squares.Clone();
           
            return b;
        }
    }
}
