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

        private void BtnClick(object sender, EventArgs e) 
        {

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
