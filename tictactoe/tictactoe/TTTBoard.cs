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
                        if (squares[x, y] == Player.O) // if the squares are "5", then we add it to the board space
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

        //public static List<int[]> chanceToBlockSpaces = new List<int[]>();
       // public static List<int[]> tempSpacesP = new List<int[]>();

        public override int possibilityToWin
        {
            get
            {
                //player O variables              
                int OamountOfPos = 0;
                int OaddPosC = 0;
                int OaddPosR = 0;


                //player X variables            
                int XamountOfPos = 0;
                int XaddPosC = 0;
                int XaddPosR = 0;

                // Misc variables
                bool checkForPos = false;
                List<string> countC = new List<string>();
                List<string> countR = new List<string>();

                // Go through the coloums and add the strings assigned to the spaces inside. 
                for (int x = 0; x < 3; x++)
                {

                    for (int y = 0; y < 3; y++)
                    {

                        countC.Add(squares[x, y].ToString());  // Adding the strings to the count columns list 
                        countR.Add(squares[y, x].ToString()); // Adding the strings to the count rows list  


                        if (countC.Count == 8 && countR.Count == 8)
                            checkForPos = true;
                    }

                }


                if (checkForPos)
                {

                    //Check for Player O
                    //Column 1
                    if (countC[0] == "X" || countC[1] == "X" || countC[2] == "X")
                    {
                        OaddPosC = 0;
                        OamountOfPos += OaddPosC;
                    }
                    else
                    {
                        OaddPosC = 1;
                        OamountOfPos += OaddPosC;
                    }

                    //Column 2
                    if (countC[3] == "X" || countC[4] == "X" || countC[5] == "X")
                    {
                        OaddPosC = 0;
                        OamountOfPos += OaddPosC;
                    }
                    else
                    {
                        OaddPosC = 1;
                        OamountOfPos += OaddPosC;
                    }

                    //Column 3
                    if (countC[6] == "X" || countC[7] == "X" || countC[8] == "X")
                    {
                        OaddPosC = 0;
                        OamountOfPos += OaddPosC;
                    }
                    else
                    {
                        OaddPosC = 1;
                        OamountOfPos += OaddPosC;
                    }


                    //Row 1
                    if (countR[0] == "X" || countR[1] == "X" || countR[2] == "X")
                    {
                        OaddPosR = 0;
                        OamountOfPos += OaddPosR;
                    }
                    else
                    {
                        OaddPosR = 1;
                        OamountOfPos += OaddPosR;
                    }

                    //Row 2
                    if (countR[3] == "X" || countR[4] == "X" || countR[5] == "X")
                    {
                        OaddPosR = 0;
                        OamountOfPos += OaddPosR;
                    }
                    else
                    {
                        OaddPosR = 1;
                        OamountOfPos += OaddPosR;
                    }

                    //Row 3
                    if (countR[6] == "X" || countR[7] == "X" || countR[8] == "X")
                    {
                        OaddPosR = 0;
                        OamountOfPos += OaddPosR;
                    }
                    else
                    {
                        OaddPosR = 1;
                        OamountOfPos += OaddPosR;
                    }

                    //DiagonalLTR
                    if (countC[0] == "X" || countC[4] == "X" || countC[8] == "X")
                    {
                        OaddPosC = 0;
                        OamountOfPos += OaddPosC;
                    }
                    else
                    {
                        OaddPosC = 1;
                        OamountOfPos += OaddPosC;
                    }

                    //DiagonalRTL
                    if (countC[6] == "X" || countC[4] == "X" || countC[2] == "X")
                    {
                        OaddPosC = 0;
                        OamountOfPos += OaddPosC;
                    }
                    else
                    {
                        OaddPosC = 1;
                        OamountOfPos += OaddPosC;
                    }




                    //Check for player X
                    //Column 1
                    if (countC[0] == "O" || countC[1] == "O" || countC[2] == "O")
                    {
                        XaddPosC = 0;
                        XamountOfPos += XaddPosC;
                    }
                    else
                    {
                        XaddPosC = 1;
                        XamountOfPos += XaddPosC;
                    }

                    //Column 2
                    if (countC[3] == "O" || countC[4] == "O" || countC[5] == "O")
                    {
                        XaddPosC = 0;
                        XamountOfPos += XaddPosC;
                    }
                    else
                    {
                        XaddPosC = 1;
                        XamountOfPos += XaddPosC;
                    }

                    //Column 3
                    if (countC[6] == "O" || countC[7] == "O" || countC[8] == "O")
                    {
                        XaddPosC = 0;
                        XamountOfPos += XaddPosC;
                    }
                    else
                    {
                        XaddPosC = 1;
                        XamountOfPos += XaddPosC;
                    }


                    //Row 1
                    if (countR[0] == "O" || countR[1] == "O" || countR[2] == "O")
                    {
                        XaddPosR = 0;
                        XamountOfPos += XaddPosR;
                    }
                    else
                    {
                        XaddPosR = 1;
                        XamountOfPos += XaddPosR;
                    }

                    //Row 2
                    if (countR[3] == "O" || countR[4] == "O" || countR[5] == "O")
                    {
                        XaddPosR = 0;
                        XamountOfPos += XaddPosR;
                    }
                    else
                    {
                        XaddPosR = 1;
                        XamountOfPos += XaddPosR;
                    }

                    //Row 
                    if (countR[6] == "O" || countR[7] == "O" || countR[8] == "O")
                    {
                        XaddPosR = 0;
                        XamountOfPos += XaddPosR;
                    }
                    else
                    {
                        XaddPosR = 1;
                        XamountOfPos += XaddPosR;
                    }


                    //DiagonalLTR
                    if (countC[0] == "O" || countC[4] == "O" || countC[8] == "O")
                    {
                        XaddPosC = 0;
                        XamountOfPos += XaddPosC;
                    }
                    else
                    {
                        XaddPosC = 1;
                        XamountOfPos += XaddPosC;
                    }

                    //DiagonalRTL
                    if (countC[6] == "O" || countC[4] == "O" || countC[2] == "O")
                    {
                        XaddPosC = 0;
                        XamountOfPos += XaddPosC;
                    }
                    else
                    {
                        XaddPosC = 1;
                        XamountOfPos += XaddPosC;
                    }




                    //------------ Check for Block Possibility ------------- 

                    int blockCount = 0;

                    // Go through the coloums and check for blocking possibility. 
                    for (int x = 0; x < 3; x++)
                    {
                        blockCount = 0;

                        for (int y = 0; y < 3; y++)
                        {
                            blockCount += (int)squares[x, y]; // Add the present player integer representations together 

                        }


                        if (blockCount == -15)  //If the count is -15, then AI will prefer this move to block
                        {
                            OamountOfPos += 10;  // By adding +10 to possibility to win
                        }


                    }

                    // Go through the rows and check for blocking possibility.  
                    for (int x = 0; x < 3; x++)
                    {
                        blockCount = 0;

                        for (int y = 0; y < 3; y++)
                        {
                            blockCount += (int)squares[y, x];   // Add the present player integer representations together
                        }

                        if (blockCount == -15)  //If the count is -15, then AI will prefer this move to block
                        {
                            OamountOfPos += 10;  // By adding +10 to possibility to win
                        }


                    }

                    // Check for blocking possibility - right to left diagonal
                    blockCount = 0;
                    blockCount += (int)squares[0, 0];
                    blockCount += (int)squares[1, 1];
                    blockCount += (int)squares[2, 2];

                    if (blockCount == -15)  //If the count is -15, then AI will prefer this move to block
                    {
                        OamountOfPos += 10;
                    }


                    // Check for blocking possibility - left to right diagonal
                    blockCount = 0;
                    blockCount += (int)squares[0, 2];
                    blockCount += (int)squares[1, 1];
                    blockCount += (int)squares[2, 0];

                    if (blockCount == -15)  //If the count is -15, then AI will prefer this move to block
                    {
                        OamountOfPos += 10;
                    }




                    //------------ Check for Winner Possibility ------------- 

                    int winnerChance = 0;

                    // Go through the coloums and check for winner possibility. 
                    for (int x = 0; x < 3; x++)
                    {
                        winnerChance = 0;

                        for (int y = 0; y < 3; y++)
                        {
                            winnerChance += (int)squares[x, y]; // Add the present player integer representations together 

                        }


                        if (winnerChance == 15)  //If the count is 15, then AI will prefer this move to win
                        {
                            OamountOfPos += 20;  // By adding +20 to possibility to win
                        }


                    }

                    // Go through the rows and check for winner possibility.  
                    for (int x = 0; x < 3; x++)
                    {
                        winnerChance = 0;

                        for (int y = 0; y < 3; y++)
                        {
                            winnerChance += (int)squares[y, x];   // Add the present player integer representations together
                        }

                        if (winnerChance == 15)  //If the count is 15, then AI will prefer this move to block
                        {
                            OamountOfPos += 20;  // By adding +20 to possibility to win
                        }


                    }

                    // Check for winner possibility - right to left diagonal
                    winnerChance = 0;
                    winnerChance += (int)squares[0, 0];
                    winnerChance += (int)squares[1, 1];
                    winnerChance += (int)squares[2, 2];

                    if (winnerChance == 15)  //If the count is 15, then AI will prefer this move to block
                    {
                        OamountOfPos += 20;
                    }


                    // Check for winner possibility - left to right diagonal
                    winnerChance = 0;
                    winnerChance += (int)squares[0, 2];
                    winnerChance += (int)squares[1, 1];
                    winnerChance += (int)squares[2, 0];

                    if (winnerChance == 15)  //If the count is 15, then AI will prefer this move to block
                    {
                        OamountOfPos += 20;
                    }




                    return OamountOfPos - XamountOfPos;  // Return  AI win possibility - Players win possibility

    
                }
                

                return 0;  // else return 0
            }
        } // End possibility to win



        // Check for a winner
        public override Player Winner
        {
            get
            {
                int winnerCount = 0;

                // Go through the columns and check for a winner  
                for (int x = 0; x < 3; x++)
                {
                    winnerCount = 0;

                    for (int y = 0; y < 3; y++)
                    {
                        winnerCount += (int)squares[x, y]; // Add the present player integer representations together
                    }


                    if (winnerCount == 15)  //If the count is 15, then player O wins 
                    {
                        return Player.O;
                    }

                    if (winnerCount == -30)  //If the count is -30, then player X wins
                    {
                        return Player.X;
                    }
                }

                // Go through the rows and check for a winner 
                for (int x = 0; x < 3; x++)
                {
                    winnerCount = 0;

                    for (int y = 0; y < 3; y++)
                    {
                        winnerCount += (int)squares[y, x];  // Add the present player integer representations together
                    }



                    if (winnerCount == 15)  //If the count is 15, then player O wins
                    {
                        return Player.O;
                    }

                    if (winnerCount == -30)  //If the count is -30, then player X wins
                    {
                        return Player.X;
                    }
                }

                // Check for a winner - right to left diagonal
                winnerCount = 0;
                winnerCount += (int)squares[0, 0];
                winnerCount += (int)squares[1, 1];
                winnerCount += (int)squares[2, 2];

                if (winnerCount == 15)
                {
                    return Player.O;
                }
                if (winnerCount == -30)
                {
                    return Player.X;
                }

                // left to right - diagonal
                winnerCount = 0;
                winnerCount += (int)squares[0, 2];
                winnerCount += (int)squares[1, 1];
                winnerCount += (int)squares[2, 0];

                if (winnerCount == 15)
                {
                    return Player.O;
                }
                if (winnerCount == -30)
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
