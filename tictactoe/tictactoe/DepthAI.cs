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

        // -----  GetRandomMove ------- (depth level 0)
        public static BoardSpace GetRandomMove(Board b, Player p) //Takes the board, and a player
        {
            BoardSpace? bestSpace = null;
            List<BoardSpace> openSpaces = b.OpenSquares;          
           
            Random r = new Random();
            int randomIndex = r.Next(0, openSpaces.Count);
            BoardSpace newSpace = openSpaces[randomIndex];

            bestSpace = newSpace;

            return (BoardSpace)bestSpace;
        }// End Random Move



        public static List<BoardSpace> exploredSpaces = new List<BoardSpace>();
        public static List<int> ColPosToWin = new List<int>();
        public static BoardSpace finalMove;

        // ------ Depth1move ------ (depth level 1)
        public static BoardSpace Depth1Move(Board b, Player p) //Takes the board, and a player
        {

            BoardSpace? bestSpace = null;
            List<BoardSpace> openSpaces = b.OpenSquares;
            Board newBoard;
            finalMove = new BoardSpace();

            int count = 0;
            int maxIndex = 0;


            for (int i = 0; i < openSpaces.Count; i++)
            {
                newBoard = b.Clone();
                BoardSpace newSpace = openSpaces[i];

                newBoard[newSpace.X, newSpace.Y] = p;

                count += newBoard.possibilityToWin;
                ColPosToWin.Add(count);
                exploredSpaces.Add(newSpace);
                

                if (newBoard.Winner == Player.OpenSpace && newBoard.OpenSquares.Count > 0)
                {
                    Depth1Move(newBoard, p);
                }
                else if(newBoard.OpenSquares.Count <= 0)
                    {
                   
                    maxIndex = ColPosToWin.IndexOf(ColPosToWin.Max());
                    finalMove = exploredSpaces[maxIndex];
                 
                
                }
               
               bestSpace = finalMove;  
                
            }
           
            return (BoardSpace)bestSpace;
        }// End Depth1Move

    }// End DepthAi

}
