using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chess
{
    internal class board
    {
        private Button[,] gridButtons; //Create an empty 2D-Array of buttons.

        public board(int size) { gridButtons = new Button[size, size]; } //Initlaize the board.

        public ref Button GetButton(int i, int j) { return ref gridButtons[i, j]; } //Get a certain button (by ref)

        public void setButton(Button b, int i, int j) { gridButtons[i, j] = b; } //Set a certain button.

        public int getSize() { return gridButtons.GetLength(0); } //Return the size of the board.

        public void setButtonSize(int i, int j, Size size, Point point)
        {
            gridButtons[i,j].Size = size;
            gridButtons[i,j].Location = point;
        }

        public void orderButtons()
        {
            int size = gridButtons.GetLength(0);
            for (int i = 0; i < gridButtons.GetLength(0) - 1; i++) //Each Row
            {
                for (int j = 0; j < gridButtons.GetLength(1) - 1; j++) //Each item in the current row.
                {
                    
                    Button currentButton = gridButtons[i, j];
                    if (currentButton != null)
                    {
                        currentButton.Size = new Size(currentButton.Parent.Width / size, currentButton.Parent.Height / size); //Size the button appropriately
                        currentButton.Location = new Point((currentButton.Parent.Width / size) * j, (currentButton.Parent.Height / size) * i); //Place the button appropriately

                    }
                }

            }
        }

        
    }
}
