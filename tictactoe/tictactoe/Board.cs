using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tictactoe
{
    // User possibilities. This type consists of a set of named constants (enumerator list). 
    // X stand for the number 1. Open moves are the number 0 nad lastly, the move O has the number 2. 
    public enum Player
    {
        X = 1,
        O = 2,
        Open = 0,
    }

    // This class is the one creating new game boards for playing Tic Tac Toe. The information in this class implements
    // all the logic and methods that an AI needs to play the game of Tic Tac Toe.
    // The class is an abstract, since the class is intended only to be a base class of other classes. 
    // "Infomation" being included in an abstract class, must be implemented by classes that derive from the abstract class.
    public abstract class Board
    {
        // Array to which all sqaures on the board are assigned. These are the moved the players can make their moves.
        public Player[,] squares;

        // Getters and setters for setting a space on the game board
        public abstract Player this[int x, int y]
        {
            get;
            set;
        }

        // Are all spaces full? Define
        public abstract bool IsFull
        {
            get;
        }

        // Max size of the game board
        public abstract int Size
        {
            get;
        }

        // A list of the available spaces on the board
        public abstract List<Space> OpenSquares
        {
            get;
        }

        // Determine a possible winner
        public abstract Player Winner
        {
            get;
        }

        // Clone a copy of the board
        public abstract Board Clone();
    }

    // Informs of one space on the current board. Usage of a struct class, since it is usable when we
    // talk about poins, rectangles and colors. Does not have to be a struct, but is lightweight - and we are testing it out.
    public struct Space
    {
        public int X;
        public int Y;

        // Needs further investigation !!!! RANK !!!!
        public double Rank;

        // Constructor
        public Space(int x, int y)
        {
            this.X = x;
            this.Y = y;
            Rank = 0;
        }
    }
}
