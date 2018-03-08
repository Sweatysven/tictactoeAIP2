using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tictactoe
{
    public partial class TTTGUI : Form
    {
        // create an object of our Board class
        Board b;

        public TTTGUI()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            b = new TTTBoard();
            ReadyBoard();

            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
        }

        // Resets the gameboard - can it be done otherwise?
        private void ReadyBoard() 
        {
            // ---------------------
            // | [0,0] [0,1] [0,2] |
            // |                   |
            // |                   |
            // | [1,0] [1,1] [1,2] |
            // |                   |
            // |                   |
            // | [2,0] [2,1] [2,2] |
            // ---------------------

            
            if (b[0, 0] == Player.Open) 
            {
                button1.Text = "";
            }
            else
            {
                button1.Text = b[0, 0].ToString();
                button1.Enabled = false;
            }
            
            if (b[0, 1] == Player.Open) 
            {
                button2.Text = "";
            }
            else
            {
                button2.Text = b[0, 1].ToString();
                button2.Enabled = false;
            }

            if (b[0, 2] == Player.Open) 
            {
                button3.Text = "";
            }
            else
            {
                button3.Text = b[0, 2].ToString();
                button3.Enabled = false;
            }

            if (b[1, 0] == Player.Open) 
            {
                button4.Text = "";
            }
            else
            {
                button4.Text = b[1, 0].ToString();
                button4.Enabled = false;
            }

            if (b[1, 1] == Player.Open) 
            {
                button5.Text = "";
            }
            else
            {
                button5.Text = b[1, 1].ToString();
                button5.Enabled = false;
            }

            if (b[1, 2] == Player.Open) 
            {
                button6.Text = "";
            }
            else
            {
                button6.Text = b[1, 2].ToString();
                button6.Enabled = false;
            }

            if (b[2, 0] == Player.Open) 
            {
                button7.Text = "";
            }
            else
            {
                button7.Text = b[2, 0].ToString();
                button7.Enabled = false;
            }

            if (b[2, 1] == Player.Open) 
            {
                button8.Text = "";
            }
            else
            {
                button8.Text = b[2, 1].ToString();
                button8.Enabled = false;
            }

            if (b[2, 2] == Player.Open) 
            {
                button9.Text = "";
            }
            else
            {
                button9.Text = b[2, 2].ToString();
                button9.Enabled = false;
            }
            
        }

        // Eventhandlers by clicking 
        private void BtnClick(object sender, EventArgs e) 
        {
            BoardSpace bs = (BoardSpace)sender;

            b[bs.X, bs.Y] = Player.O;
            ReadyBoard();

            if (WinnerCheck())
            {
                Form1_Load(null, new EventArgs());
            }

            if (b.OpenSquares.Count == b.BoardSize)
            {
                Random r = new Random();
                bs = new BoardSpace(r.Next(0, 3), r.Next(0, 3));
            }
            else
            {
                bs = DepthAI.GetBestMove(b, Player.X);
            }

            b[bs.X, bs.Y] = Player.X;
            ReadyBoard();

            if (WinnerCheck())
            {
                Form1_Load(null, new EventArgs());
            }

        }

        // Check for a winner and output proper message
        public bool WinnerCheck() 
        {
            // The questionmark checks for... 
            Player? p = b.Winner;

            if (p == Player.X) 
            {
                MessageBox.Show("AI Wins");
                return true;
            }
            else if (p == Player.O)
            {
                MessageBox.Show("Player Wins");
                return true;
            }
            else if (b.IsComplete)
            {
                MessageBox.Show("Draw");
                return true;
            }
            return false;
        }                              
    }
}
