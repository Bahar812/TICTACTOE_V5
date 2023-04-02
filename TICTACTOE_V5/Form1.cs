using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TICTACTOE_V5
{
    public partial class Form1 : Form
    {
        private Button[,] buttons = new Button[3, 3];
        private bool player1Turn = true;
        private int player1Score = 0;
        private int player2Score = 0;
        public Form1()
        {
            InitializeComponent();
            // Set up the game board
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Button button = new Button();
                    button.Size = new Size(120, 120);
                    button.Location = new Point(120 * col + 200, 120 * row + 50);
                    button.Font = new Font("Arial", 24);
                    button.Tag = new Point(row, col);
                    button.Click += Button_Click;
                    buttons[row, col] = button;
                    Controls.Add(button);
                }
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Point location = (Point)button.Tag;

            if (button.Text != "") // Check if the button has already been clicked
            {
                MessageBox.Show("This button has already been clicked!");
                return;
            }

            if (player1Turn)
            {
                button.Text = "X";
            }
            else
            {
                button.Text = "O";
            }

            // Check for a winner
            if (CheckForWinner())
            {
                if (player1Turn)
                {
                    MessageBox.Show("Player 1 wins!");
                    player1Score++;
                    label1.Text = "Player 1 : X | Score: " + player1Score;
                }
                else
                {
                    MessageBox.Show("Player 2 wins!");
                    player2Score++;
                    label2.Text = "Player 1 : X | Score: " + player2Score;
                }

                // Reset the game board
                ResetGameBoard();
                //UpdateScores();
                return;
            }

            // Check for a tie game
            if (CheckForTie())
            {
                MessageBox.Show("Tie game!");
                ResetGameBoard();
                //UpdateScores();
                return;
            }

            // Switch turns
            player1Turn = !player1Turn;
        }

        //private void UpdateScores(string player)
        //{
        //    // Update score based on player
        //    if (player == "X")
        //    {
        //        player1Score++;
        //       // playerXScoreLabel.Text = "Player X: " + playerXScore.ToString();
        //    }
        //    else if (player == "O")
        //    {
        //        playe2Score++;
        //        playerOScoreLabel.Text = "Player O: " + playerOScore.ToString();
        //    }
        //}

        private void ResetGameBoard()
        {
            // Clear all button texts
            foreach (Button button in buttons)
            {
                button.Text = "";
                button.Enabled = true;
            }

            

            //// Reset scores
            //player1Score = 0;
            //player2Score = 0;

           
        }

        private bool CheckForWinner()
        {
            // Check rows
            for (int row = 0; row < 3; row++)
            {
                if (buttons[row, 0].Text == buttons[row, 1].Text && buttons[row, 1].Text == buttons[row, 2].Text && buttons[row, 0].Text != "")
                {
                    return true;
                }
            }

            // Check columns
            for (int col = 0; col < 3; col++)
            {
                if (buttons[0, col].Text == buttons[1, col].Text && buttons[1, col].Text == buttons[2, col].Text && buttons[0, col].Text != "")
                {
                    return true;
                }
            }

            // Check diagonals
            if (buttons[0, 0].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[2, 2].Text && buttons[0, 0].Text != "")
            {
                return true;
            }
            if (buttons[0, 2].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[2, 0].Text && buttons[0, 2].Text != "")
            {
                return true;
            }

            // No winner
            return false;
        }

        private bool CheckForTie()
        {
            // Check if all buttons are clicked
            foreach (Button button in buttons)
            {
                if (button.Text == "")
                {
                    return false;
                }
            }

            // It's a tie
            return true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
