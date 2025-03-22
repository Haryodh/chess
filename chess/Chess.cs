﻿using chess.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chess
{

    public partial class Chess : Form
    {
        //--------------------------------------------------------------------------------

        SettingsPage settings = new SettingsPage();

        Board[] boards = new Board[10]; //Array of boards
        int currentBoard = 0;
        

        //--------------------------------------------------------------------------------
        public Chess()
        {
            InitializeComponent();
        }

        private void Chess_Load(object sender, EventArgs e)
        {

            boards[currentBoard] = new Board(0); //Initialise the first board
            

            
            this.Resize += resize; // Link to event handler for a form resize.
            this.MinimumSize = new Size(480, 270); // Set minimum size of the form

            displayUI(); //Update size and data for the board.
            this.Controls.Add(Displays.boardPanel); //Add panel to the form
            //this.Controls.Add(Displays.resolutionDisplay); //Testing REMOVE

            this.Controls.Add(Displays.gameSelector);
            Displays.gameSelector.Maximum = boards.Length-1;
            Displays.gameSelector.Minimum = 0;
            Displays.gameSelector.Value = 0;
            Displays.gameSelector.ValueChanged += gameChange;

            this.Controls.Add(Displays.settingsButton); //Add settings button to the form
            Displays.settingsButton.BackgroundImage = Resources.settings_button; //Set image of settings button.
            Displays.settingsButton.BackgroundImageLayout = ImageLayout.Stretch; //Make image fit in the box.
            Displays.settingsButton.Click += settingsClicked; //Event handler for click on settings button

            addButtons(boards[currentBoard]);
        }

        private void gameChange(object sender, EventArgs e)
        {
            boards[currentBoard].possibleMoves.Clear(); //Clears all possible moves to prevent errors.

            Settings.lastPressed = new int[] { int.MaxValue, int.MaxValue }; //Resets last pressed to prevent errors.

            NumericUpDown n = sender as NumericUpDown; //Get the sender as a number selector.
            int newGameNumber = Convert.ToInt32(n.Value); //Get the value of the number selector.
            if (boards[newGameNumber] == null) //If the board doesn't exist then create it.
            {
                boards[newGameNumber] = new Board(newGameNumber);
            }
            else if (boards[newGameNumber].gameOver)
            {
                boards[newGameNumber] = new Board(newGameNumber);
            }
            currentBoard = newGameNumber; //Set the current board to the new board.



            Displays.boardPanel.Controls.Clear(); //Clears all buttons from current panel.

            addButtons(boards[currentBoard]); //Adds buttons to the panel.
            

        }

        private void addButtons(Board board)
        {

            int size = board.getSize();

            for (int i = 0; i < size; i++) //Each Row
            {
                for (int j = 0; j < size; j++) //Each item in the current row
                {

                    Button currentButton = board.getButton(i, j); //Get the button as ref
                    currentButton = new Button(); //Make it a button
                    board.setButton(currentButton, i, j); //Set it for some reason? doesn't work without it.
                    Displays.boardPanel.Controls.Add(currentButton); //Add the button to the panel
                    //------
                    currentButton.Size = new Size(currentButton.Parent.Width / size, currentButton.Parent.Height / size); //Size the button appropriately
                    currentButton.Location = new Point((currentButton.Parent.Width / size) * j, (currentButton.Parent.Height / size) * i); //Place the button appropriately

                    currentButton.Tag = new int[] { i, j }; //For later use to reference which button is clicked.
                    //Console.WriteLine($"i:{(currentButton.Tag as int[])[0]}, j:{(currentButton.Tag as int[])[1]}"); //Testing

                    currentButton.FlatStyle = FlatStyle.Flat;

                    currentButton.Click += checkerClick;
                }
            }
            displayUI();
        }

        private void checkerClick(object sender, EventArgs e)
        {
            
            Button button = sender as Button; //Get the sender as a button
            bool moveMade = false; //Bool to check if a move has been made.
            int[] pos = button.Tag as int[]; //Get the position of the button clicked.


            if (!boards[currentBoard].gameOver)
            {
                foreach (int[] move in boards[currentBoard].possibleMoves) //Check if the clicked square is a movement option.
                {
                    if (pos[0] == move[0] && pos[1] == move[1]) //If clicked square is a movement option.
                    {
                        boards[currentBoard].getPiece(Settings.lastPressed[0], Settings.lastPressed[1]).addMove(); //Add a move to moving piece
                        boards[currentBoard].setPiece(boards[currentBoard].getPiece(Settings.lastPressed[0], Settings.lastPressed[1]), pos[0], pos[1]); //Move the piece
                        boards[currentBoard].setPiece(new Piece(0), Settings.lastPressed[0], Settings.lastPressed[1]); //Clear the original position of the piece
                        moveMade = true; //Move has been made
                        boards[currentBoard].whiteTurn = !boards[currentBoard].whiteTurn; //Change turns
                        break;
                    }
                }
                boards[currentBoard].possibleMoves.Clear(); //Clear all possible moves to prevent errors.
                if (!moveMade) //If no move has been made then show possible moves for the new piece.
                {
                    boards[currentBoard].pieceMoves(pos[0], pos[1]);
                }


                Settings.lastPressed[0] = pos[0]; Settings.lastPressed[1] = pos[1]; //Set the last pressed to the current square.
                boards[currentBoard].isGameOver(); //Check if king was captured.
                displayUI(); //Update the display.
            }
        }
        

        private void resize(object sender, EventArgs e) //When the page is resized.
        {
            displayUI();
        }

        private void settingsClicked(object sender, EventArgs e) //Settings Button is clicked.
        {
            settings.Show(); //Open the settings page.
        }

        private void displayUI()
        {

            int testScale = Settings.getScale(); //ignore REMOVE


            int screenWidth = this.Width;
            int screenHeight = this.Height;


            int panelScaledWidth = (this.Width * testScale / 100); //Scaled width for the panel, just to stop repeating the same calculation lots.
            int panelScaledHeight = (this.Height * testScale / 100); //Same thing.
            //----------------------------------------------------

            if (panelScaledWidth > panelScaledHeight) //Make the panel a square.
            {
                panelScaledWidth = panelScaledHeight;
            }
            else
            {
                panelScaledHeight = panelScaledWidth;
            }

            //Displays.resolutionDisplay.Location = new Point(0, screenHeight - 70); //For testing REMOVE
            //Displays.resolutionDisplay.Size = new Size(screenWidth * 1 / 5 * testScale / 100, screenHeight * 1 / 5 * testScale / 100); //For testing REMOVE
            //Displays.resolutionDisplay.Text = ("Width:" + screenWidth + " Height:" + screenHeight + " Scale:" + Settings.getScale()); //For testing REMOVE


            Displays.boardPanel.Location = new Point(screenWidth / 2 - panelScaledWidth / 2, screenHeight / 2 - panelScaledHeight / 2); //Puts the panel in the center
            Displays.boardPanel.Size = new Size(panelScaledWidth, panelScaledHeight); //Sets the board size to take up the set resolution size. 
            Displays.boardPanel.BackColor = Color.Black;



            Displays.settingsButton.Size = new Size(panelScaledWidth * 1 / 3 * testScale / 100, panelScaledHeight * 1 / 3 * testScale / 100); //Scales the settings button
            Displays.settingsButton.Location = new Point(screenWidth - Displays.settingsButton.Width - 20, 0); // Puts the settings button in the top right.

            //-------------------------BUTTONS--------------------------------

            int size = boards[currentBoard].getSize();


            for (int i = 0; i < size; i++) //Each Row
            {
                for (int j = 0; j < size; j++) //Each item in the current row.
                {

                    Button currentButton = boards[currentBoard].getButton(i, j); //set currentButton as current button
                    Piece currentPiece = boards[currentBoard].getPiece(i, j); //set currentPiece as the current piece
                    if (currentButton != null)
                    {
                        currentButton.Size = new Size(currentButton.Parent.Width / size, currentButton.Parent.Height / size); //Size the button appropriately
                        currentButton.Location = new Point((currentButton.Parent.Width / size) * j, (currentButton.Parent.Height / size) * i); //Place the button appropriately

                        if ((i + j) % 2 == 0) //Checker Pattern
                        {
                            currentButton.BackColor = Settings.getCheckerOneColor();
                        }
                        else
                        {
                            currentButton.BackColor = Settings.getCheckerTwoColor();
                        }


                        if (currentPiece != null) //If there is a piece on the square then set the image of the button to the piece image.
                        {
                            
                            currentButton.BackgroundImage = Settings.pieceImages[currentPiece.getType()];
                            currentButton.BackgroundImageLayout = ImageLayout.Stretch; 
                        }
                        
                    }
                }
            }

            if (Settings.lastPressed[0] < boards[currentBoard].getSize() && Settings.lastPressed[1] < boards[currentBoard].getSize()) //If the last pressed button is on the board, then highlight it.
            {
                Button matchingButton = boards[currentBoard].getButton(Settings.lastPressed[0], Settings.lastPressed[1]);
                if (matchingButton.BackColor != Color.Red) //If it's not already red then make it red.
                {
                    matchingButton.BackColor = Color.Red;
                }
                else { matchingButton.BackColor = Color.Green; } //If it is red then make it green.
            }

            foreach (int[] move in boards[currentBoard].possibleMoves) //Highlight all possible moves.
            {
                Button matchingButton = boards[currentBoard].getButton(move[0], move[1]);

                if (matchingButton.BackColor != Color.Blue) //If it's not already blue then make it blue.
                {
                    matchingButton.BackColor = Color.Blue;
                }
                else { matchingButton.BackColor = Color.Pink; } //If it is blue then make it pink.
            }

            //----------------------------------------------------------------
        }
    }
}
