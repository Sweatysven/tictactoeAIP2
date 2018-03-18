using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tictactoe
{

    // This is the class for the depth AI. GetRandomMove = random selection, Depth1Move = depth 1,  Depth2Move = depth 2,  Depth3Move = depth 3
    class DepthAI
    {

        //General variables employed for multiple functions in the DepthAiClass
        public static BoardSpace bestSpace;
        public static BoardSpace finalSpace;

        // Variables for the Depth moves
        public static List<BoardSpace> exploredSpaces = new List<BoardSpace>();
        public static List<int> ColPosToWin = new List<int>();



        // -----  GetRandomMove ------- (depth level 0)
        public static BoardSpace GetRandomMove(Board b, Player p) //Takes the board, and a player
        {
                     
            List<BoardSpace> openSpaces = b.OpenSquares;

            Random r = new Random();
            int randomIndex = r.Next(0, openSpaces.Count);
            BoardSpace newSpace = openSpaces[randomIndex];

            bestSpace = newSpace;

            return (BoardSpace)bestSpace;
        }// ------End Random Move

        

        // ------ Depth1move ------ (depth level 1)
        public static BoardSpace Depth1Move(Board b, Player p) //Takes the board, and a player
        {

            int count = 0;
            int maxIndex = 0;

            List<BoardSpace> openSpaces = b.OpenSquares;
            Board newBoard;

            newBoard = b.Clone();

            for (int i = 0; i < openSpaces.Count; i++)
            {
                count = 0;
                BoardSpace newSpace = openSpaces[i];
                newBoard[newSpace.X, newSpace.Y] = p;

                count += newBoard.possibilityToWin;
                ColPosToWin.Add(count);
                exploredSpaces.Add(newSpace);

                if (i != openSpaces.Count - 1)
                {
                    newBoard = b.Clone();
                }
                else
                {

                    maxIndex = ColPosToWin.IndexOf(ColPosToWin.Max());
                    finalSpace = exploredSpaces[maxIndex];

                    count = 0;
                    maxIndex = 0;
                    exploredSpaces.Clear();
                    ColPosToWin.Clear();

                    bestSpace = finalSpace;
                }

            }

            return (BoardSpace)bestSpace;

        }// End Depth1Move



        // Variable(s) for Depth 2 move        
        public static Board tempBoard;
        
        // ------ Depth2move ------ (depth level 2)
        public static BoardSpace Depth2Move(Board b, Player p) //Takes the board, and a player
        {

            int count = 0;
            int countSeveralBoards = 0;
            int maxIndex = 0;

            List<BoardSpace> openSpaces = b.OpenSquares;
            Board newBoard;
            newBoard = b.Clone();


            for (int i = 0; i < openSpaces.Count; i++)
            {
                newBoard = b.Clone();
                count = 0;
                countSeveralBoards = 0;
                BoardSpace newSpace = openSpaces[i];
                newBoard[newSpace.X, newSpace.Y] = p;
                exploredSpaces.Add(newSpace);
                List<BoardSpace> tempOpenSpaces = newBoard.OpenSquares;
                tempBoard = newBoard.Clone();

                if (!newBoard.IsComplete)
                {
                    for (int j = 0; j < tempOpenSpaces.Count; j++)
                    {
                        count = 0;
                        BoardSpace tempNewSpace = tempOpenSpaces[j];
                        tempBoard[tempNewSpace.X, tempNewSpace.Y] = Player.X;
                        count += tempBoard.possibilityToWin;
                        countSeveralBoards += count;
                        tempBoard = newBoard.Clone();

                        if (j == tempOpenSpaces.Count - 1)
                        {
                            ColPosToWin.Add(countSeveralBoards);
                        }

                    }
                }
                else
                {
                    ColPosToWin.Add(5);
                }


                if (i == openSpaces.Count - 1)
                {
                    maxIndex = ColPosToWin.IndexOf(ColPosToWin.Max());
                    finalSpace = exploredSpaces[maxIndex];

                    count = 0;
                    maxIndex = 0;
                    exploredSpaces.Clear();
                    ColPosToWin.Clear();

                    bestSpace = finalSpace;
                }
              
            }

            return (BoardSpace)bestSpace;

        }// End Depth2Move



        // Variable(s) for Depth 3 move
        public static Board tempBoard2;

        // ------ Depth3move ------ (depth level 3)
        public static BoardSpace Depth3Move(Board b, Player p) //Takes the board, and a player
        {

            int count = 0;
            int countSeveralBoards = 0;
            int maxIndex = 0;

            List<BoardSpace> openSpaces = b.OpenSquares;
            Board newBoard;
            newBoard = b.Clone();


            for (int i = 0; i < openSpaces.Count; i++)
            {
                newBoard = b.Clone();
                count = 0;
                countSeveralBoards = 0;
                BoardSpace newSpace = openSpaces[i];
                newBoard[newSpace.X, newSpace.Y] = p;
                exploredSpaces.Add(newSpace);
                List<BoardSpace> tempOpenSpaces = newBoard.OpenSquares;
                tempBoard = newBoard.Clone();

                if (!newBoard.IsComplete)
                {
                    for (int j = 0; j < tempOpenSpaces.Count; j++)
                    {
                        tempBoard = newBoard.Clone();
                        count = 0;
                        BoardSpace tempNewSpace = tempOpenSpaces[j];
                        tempBoard[tempNewSpace.X, tempNewSpace.Y] = Player.X;

                        List<BoardSpace> tempOpenSpaces2 = tempBoard.OpenSquares;
                        tempBoard2 = tempBoard.Clone();

                        if (!tempBoard.IsComplete)
                        {
                            for (int k = 0; k < tempOpenSpaces2.Count; k++)
                            {                                
                                count = 0;
                                BoardSpace tempNewSpace2 = tempOpenSpaces2[k];
                                tempBoard2[tempNewSpace2.X, tempNewSpace2.Y] = Player.O;
                                count += tempBoard2.possibilityToWin;
                                countSeveralBoards += count;
                                tempBoard2 = tempBoard.Clone();

                            }

                        }
                        if (j == tempOpenSpaces.Count - 1)
                        {
                            count += tempBoard.possibilityToWin;
                            countSeveralBoards += count;                          
                            ColPosToWin.Add(countSeveralBoards);

                        }                       

                    }


                }
                else
                {
                    ColPosToWin.Add(5);
                }

                if (i == openSpaces.Count - 1)
                {                  
                        maxIndex = ColPosToWin.IndexOf(ColPosToWin.Max());
                        finalSpace = exploredSpaces[maxIndex];

                        count = 0;
                        maxIndex = 0;
                        exploredSpaces.Clear();
                        ColPosToWin.Clear();

                        bestSpace = finalSpace;
                }


            }

            return (BoardSpace)bestSpace;

        }// End Depth2Move







    }// End DepthAi

}// End script
