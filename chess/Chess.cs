using chess.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chess
{

    public partial class Chess : Form
    {
        //--------------------------------------------------------------------------------

        Settings settingsOptions = new Settings();
        //--------------------------------------------------------------------------------
        public Chess()
        {
            InitializeComponent();
        }

        private void Chess_Load(object sender, EventArgs e)
        {

            this.Resize += resize; // Link to event handler for a form resize.
            this.MinimumSize = new Size(480, 270); // Set minimum size of the form

            displayBoard(); //Update size and data for the board.
            this.Controls.Add(Displays.boardPanel); //Add panel to the form
            this.Controls.Add(Displays.resolutionDisplay); //Testing REMOVE

            this.Controls.Add(Displays.settingsButton); //Add settings button to the form
            Displays.settingsButton.BackgroundImage = Resources.settings_button; //Set image of settings button.
            Displays.settingsButton.BackgroundImageLayout = ImageLayout.Stretch; //Make image fit in the box.
            Displays.settingsButton.Click += settingsClicked; //Event handler for click on settings button


            
        }

        private void resize(object sender, EventArgs e)
        {
            displayBoard();
        }

        private void settingsClicked(object sender, EventArgs e)
        {
            SettingsPage settings = new SettingsPage();
            settings.Show();
        }

        private void displayBoard()
        {
            //----------------------------------------------------
            int testScale = 66; //ignore REMOVE


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
            Displays.resolutionDisplay.Text = ("Width:" + screenWidth + " Height:" + screenHeight); //For testing REMOVE


            Displays.boardPanel.Location = new Point(screenWidth / 2 - panelScaledWidth / 2, screenHeight / 2 - panelScaledHeight / 2); //Puts the panel in the center
            Displays.boardPanel.Size = new Size(panelScaledWidth, panelScaledHeight); //Sets the board size to take up the set resolution size. 
            Displays.boardPanel.BackColor = Color.Black;



            Displays.settingsButton.Size = new Size(panelScaledWidth * 1 / 5 * testScale/100, panelScaledHeight * 1 / 5 * testScale/100);
            Displays.settingsButton.Location = new Point(screenWidth - Displays.settingsButton.Width - 20, 0);
        }
    }
}
