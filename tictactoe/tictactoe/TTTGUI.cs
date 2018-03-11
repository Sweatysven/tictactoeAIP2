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
        
        Board b; // create an object of our Board class
        List<Button> buttonList = new List<Button>(); //Creating new button list to be able to reference all buttons
        bool playerStart = false;
        bool AIStart = false;
        bool depthLevel0 = false;
        bool depthLevel1 = false;
        bool depthLevel2 = false;
        bool depthLevel3 = false;


        public TTTGUI()
        {
            
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            b = new TTTBoard(); //Load board
            DisplayBoard(); //Display the board squares, and their letters

            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            comboBox1.Enabled = true;


        }

        // Resets the gameboard - can it be done otherwise?
        private void DisplayBoard() 
        {

            // Adding buttons to list
            buttonList.Add(button1);
            buttonList.Add(button2);
            buttonList.Add(button3);
            buttonList.Add(button4);
            buttonList.Add(button5);
            buttonList.Add(button6);
            buttonList.Add(button7);
            buttonList.Add(button8);
            buttonList.Add(button9);


            // Nested foor loops for displaying column 1 letters
            for (int x = 0; x <= 0; x++)
            {
                for (int y = 0; y <= 2; y++)
                {
                    if (b[x, y] == Player.OpenSpace) //Open square - display no letters.. else display its letter, and disable it
                    {
                        buttonList[y].Text = "";
                    }
                    else
                    {
                        buttonList[y].Text = b[x, y].ToString();
                        buttonList[y].Enabled = false;
                    }
                }

            }

            // Nested foor loops for displaying column 2 letters
            for (int x = 1; x <= 1; x++)
            {
                for (int y = 0; y <= 2; y++)
                {
                    if (b[x, y] == Player.OpenSpace)
                    {
                        buttonList[y + 3].Text = "";
                    }
                    else
                    {
                        buttonList[y + 3].Text = b[x, y].ToString();
                        buttonList[y + 3].Enabled = false;
                    }
                }

            }

            // Nested foor loops for displaying column 3 letters
            for (int x = 2; x <= 2; x++)
            {
                for (int y = 0; y <= 2; y++)
                {
                    if (b[x, y] == Player.OpenSpace)
                    {
                        buttonList[y + 6].Text = "";
                    }
                    else
                    {
                        buttonList[y + 6].Text = b[x, y].ToString();
                        buttonList[y + 6].Enabled = false;
                    }
                }

            }
             
        }//End display board



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                
                playerStart = true;
                AIStart = false;
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                
                AIStart = true;
                playerStart = false;
                ChooseInitial();
                WinnerCheck();               
            }                      
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                
                depthLevel0 = true;
                depthLevel1 = false;
                depthLevel2 = false;
                depthLevel3 = false;
                //playerStart = true;
                //AIStart = false;
            }
            else if (comboBox2.SelectedIndex == 1)
            {
                depthLevel0 = false;
                depthLevel1 = true;
                depthLevel2 = false;
                depthLevel3 = false;
                //AIStart = true;
                //playerStart = false;
                //ChooseInitial();
                //WinnerCheck();
            }
            else if (comboBox2.SelectedIndex == 2)
            {

                //AIStart = true;
                //playerStart = false;
                //ChooseInitial();
                //WinnerCheck();
            }
            else if (comboBox2.SelectedIndex == 3)
            {

                //AIStart = true;
                //playerStart = false;
                //ChooseInitial();
                //WinnerCheck();
            }


        }


        //Choose initial square function If the AI is starting
        public void ChooseInitial()
        {
            if (depthLevel0)
            {
                if (b.OpenSquares.Count == b.BoardSize)
                {
                    BoardSpace bs;
                    Random r = new Random();
                    bs = new BoardSpace(r.Next(0, 3), r.Next(0, 3));
                    b[bs.X, bs.Y] = Player.O;
                    DisplayBoard();
                }

            }

            if (depthLevel1)
            {
                if (b.OpenSquares.Count == b.BoardSize)
                {
                    BoardSpace bs;
                    bs = DepthAI.Depth1Move(b, Player.O);
                    b[bs.X, bs.Y] = Player.O;
                    DisplayBoard();

                   
                }

            }
        }


    // Eventhandlers by clicking 
    private void BtnClick(object sender, EventArgs e) 
        {

            //If The player starts 
            if (playerStart)
            {              
                BoardSpace bs = (BoardSpace)sender; //creating new boardspace as object sender

                b[bs.X, bs.Y] = Player.X; //First turn is the player
                DisplayBoard(); //Display board after choosing

                if (WinnerCheck()) //Check if win, if so, then reload 
                {
                    Form1_Load(null, new EventArgs());                                          
                }

                if (depthLevel0)
                {
                    if (b.OpenSquares.Count != b.BoardSize)
                    {
                        bs = DepthAI.GetRandomMove(b, Player.O);
                        b[bs.X, bs.Y] = Player.O;
                        DisplayBoard();

                        if (WinnerCheck())
                        {
                            Form1_Load(null, new EventArgs());
                        }
                    }
                }

                if (depthLevel1)
                {
                    if (b.OpenSquares.Count != b.BoardSize)
                    {
                        bs = DepthAI.Depth1Move(b, Player.O);
                        b[bs.X, bs.Y] = Player.O;
                        DisplayBoard();

                        if (WinnerCheck())
                        {
                            Form1_Load(null, new EventArgs());
                        }
                    }
                }

                }// End playerStart


            //If the AI starts 
            if (AIStart)
            {
               
                BoardSpace bs = (BoardSpace)sender; //creating new boardspace as object sender              

                if (b.OSquares.Count == 0) //AI starts (if there is no opponents on the board choose initial
                    ChooseInitial();
                else
                {
                    //Player turn
                    b[bs.X, bs.Y] = Player.X; //First turn is the player
                    DisplayBoard(); //Display board after choosing

                    if (WinnerCheck()) //Check if win, if so, then reload 
                    {
                        Form1_Load(null, new EventArgs());
                    }

                    //AI turn
                    if (depthLevel0)
                    {
                        bs = DepthAI.GetRandomMove(b, Player.O);
                        b[bs.X, bs.Y] = Player.O;
                        DisplayBoard();

                        if (WinnerCheck())
                        {
                            Form1_Load(null, new EventArgs());
                            ChooseInitial(); // If The AI wins, select random square
                        }
                    }
                    else if (depthLevel1) //AI turn
                    {
                        bs = DepthAI.Depth1Move(b, Player.O);
                        b[bs.X, bs.Y] = Player.O;
                        DisplayBoard();

                        if (WinnerCheck())
                        {
                            Form1_Load(null, new EventArgs());
                            ChooseInitial(); // If The AI wins, select random square
                        }
                    }




                }
            }// End AIStart


        }// End button click


        // Check for a winner and output proper message
        public bool WinnerCheck() 
        {
            // Find winner, and assign to nullable type (Player?)
            Player? p = b.Winner;

            if (p == Player.O) 
            {
                MessageBox.Show("          Defeat!");
                return true;
            }

            if (p == Player.X)
            {
                MessageBox.Show("          Victory!");             
                return true;
            }

            if (b.IsComplete)
            {
                MessageBox.Show("  Draw... try again");               
                return true;
            }
            return false;
        }                              
    }
}
