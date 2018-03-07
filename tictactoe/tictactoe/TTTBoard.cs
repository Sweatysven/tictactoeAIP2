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
        public override bool IsFull
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
        public override int Size
        {
            get
            {
                return 9;
            }
        }

        public override List<Space> OpenSquares => throw new NotImplementedException();

        public override Player Winner => throw new NotImplementedException();

        public override Board Clone()
        {
            throw new NotImplementedException();
        }
    }
}
