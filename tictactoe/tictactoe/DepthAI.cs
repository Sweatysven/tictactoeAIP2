using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tictactoe
{

    // The minimax algorithm is used. This will determine the best move. But is this a decision tree?

    class DepthAI
    {
        public static BoardSpace GetBestMove(Board b, Player p)
        {
            BoardSpace? bestSpace = null;
            List<BoardSpace> openSpaces = b.OpenSquares;
            Board newBoard;

            for (int i = 0; i < openSpaces.Count; i++)
            {
                newBoard = b.Clone();
                BoardSpace newSpace = openSpaces[i];

                newBoard[newSpace.X, newSpace.Y] = p;

                if(newBoard.Winner == Player.Open && newBoard.OpenSquares.Count > 0)
                {
                    BoardSpace move = GetBestMove(newBoard, ((Player)(-(int)p)));
                    newSpace.Rank = move.Rank;
                }
                else
                {
                    if (newBoard.Winner == Player.Open)
                    {
                        newSpace.Rank = 0;
                    }
                    else if (newBoard.Winner == Player.X)
                    {
                        newSpace.Rank = 2;
                    }
                    else if (newBoard.Winner == Player.O)
                    {
                        newSpace.Rank = 1;
                    }
                }

                //If the new move is better than our previous move, take it
                if (bestSpace == null || 
                        (p == Player.X && newSpace.Rank < ((BoardSpace)bestSpace).Rank) ||
                        (p == Player.O && newSpace.Rank > ((BoardSpace)bestSpace).Rank))
                {
                    bestSpace = newSpace;
                }
            }

            return (BoardSpace)bestSpace;
        }
    }
}
