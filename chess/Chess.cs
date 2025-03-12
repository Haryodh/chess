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

        board[] boards = new board[10]; //Array of boards
        int currentBoard = 0;
        

        //--------------------------------------------------------------------------------
        public Chess()
        {
            InitializeComponent();
        }

        private void Chess_Load(object sender, EventArgs e)
        {
            boards[currentBoard] = new board(8);
            

            
            this.Resize += resize; // Link to event handler for a form resize.
            this.MinimumSize = new Size(480, 270); // Set minimum size of the form

            displayUI(); //Update size and data for the board.
            this.Controls.Add(Displays.boardPanel); //Add panel to the form
            this.Controls.Add(Displays.resolutionDisplay); //Testing REMOVE

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
            NumericUpDown n = sender as NumericUpDown;
            int newGameNumber = Convert.ToInt32(n.Value);
            if (boards[newGameNumber] == null)
            {
                boards[newGameNumber] = new board(8 + newGameNumber);
            }
            currentBoard = newGameNumber;



            Displays.boardPanel.Controls.Clear(); //Clears all buttons from current panel.

            addButtons(boards[currentBoard]);
            

        }

        private void addButtons(board board)
        {

            int size = board.getSize();

            for (int i = 0; i < size; i++) //Each Row
            {
                for (int j = 0; j < size; j++) //Each item in the current row
                {

                    Button currentButton = board.GetButton(i, j); //Get the button as ref
                    currentButton = new Button(); //Make it a button
                    board.setButton(currentButton, i, j); //Set it for some reason? doesn't work without it.
                    Displays.boardPanel.Controls.Add(currentButton); //Add the button to the panel
                    //------
                    currentButton.Size = new Size(currentButton.Parent.Width / size, currentButton.Parent.Height / size); //Size the button appropriately
                    currentButton.Location = new Point((currentButton.Parent.Width / size) * j, (currentButton.Parent.Height / size) * i); //Place the button appropriately

                    currentButton.Tag = new int[] { i, j }; //For later use to reference which button is clicked.
                    //Console.WriteLine($"i:{(currentButton.Tag as int[])[0]}, j:{(currentButton.Tag as int[])[1]}"); //Testing
                }
            }
            displayUI();
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

            Displays.resolutionDisplay.Location = new Point(0, screenHeight - 70); //For testing REMOVE
            Displays.resolutionDisplay.Size = new Size(screenWidth * 1 / 5 * testScale / 100, screenHeight * 1 / 5 * testScale / 100); //For testing REMOVE
            Displays.resolutionDisplay.Text = ("Width:" + screenWidth + " Height:" + screenHeight + " Scale:" + Settings.getScale()); //For testing REMOVE


            Displays.boardPanel.Location = new Point(screenWidth / 2 - panelScaledWidth / 2, screenHeight / 2 - panelScaledHeight / 2); //Puts the panel in the center
            Displays.boardPanel.Size = new Size(panelScaledWidth, panelScaledHeight); //Sets the board size to take up the set resolution size. 
            Displays.boardPanel.BackColor = Color.Black;



            Displays.settingsButton.Size = new Size(panelScaledWidth * 1 / 3 * testScale / 100, panelScaledHeight * 1 / 3 * testScale / 100);
            Displays.settingsButton.Location = new Point(screenWidth - Displays.settingsButton.Width - 20, 0);

            //-------------------------BUTTONS--------------------------------

            int size = boards[currentBoard].getSize();


            for (int i = 0; i < size; i++) //Each Row
            {
                for (int j = 0; j < size; j++) //Each item in the current row.
                {

                    Button currentButton = boards[currentBoard].GetButton(i, j);
                    if (currentButton != null)
                    {
                        currentButton.Size = new Size(currentButton.Parent.Width / size, currentButton.Parent.Height / size); //Size the button appropriately
                        currentButton.Location = new Point((currentButton.Parent.Width / size) * j, (currentButton.Parent.Height / size) * i); //Place the button appropriately
                    }

                }


                //----------------------------------------------------------------
            }
        }
    }
}
