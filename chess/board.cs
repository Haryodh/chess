using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chess
{
    internal class board
    {
        private Button[,] gridButtons; //Create an empty 2D-Array of buttons.
        private piece[,] pieces;

        public board(int boardNum) { boardCatalogue(boardNum); } //Initlaize the board.

        public ref Button GetButton(int i, int j) { return ref gridButtons[i, j]; } //Get a certain button (by ref)

        public void setButton(Button b, int i, int j) { gridButtons[i, j] = b; } //Set a certain button.

        public int getSize() { return gridButtons.GetLength(0); } //Return the size of the board.

        public void setButtonSize(int i, int j, Size size, Point point)
        {
            gridButtons[i,j].Size = size;
            gridButtons[i,j].Location = point;
        }


        private void boardCatalogue(int boardNum)
        {
            switch (boardNum)
            {
                case 0: // Default Game setup
                    gridButtons = new Button[8, 8]; pieces = new piece[8, 8];
                    pieces[0, 0] = new piece("black rook");
                    pieces[0, 1] = new piece("black knight");
                    pieces[0, 2] = new piece("black bishop");
                    pieces[0, 3] = new piece("black queen");
                    pieces[0, 4] = new piece("black king");
                    pieces[0, 5] = new piece("black bishop");
                    pieces[0, 6] = new piece("black knight");
                    pieces[0, 7] = new piece("black rook");
                    for(int i = 0; i < 8; i++)
                    {
                        pieces[1, i] = new piece("black pawn");
                        pieces[6, i] = new piece("white pawn");
                    }
                    pieces[7, 0] = new piece("white rook");
                    pieces[7, 1] = new piece("white knight");
                    pieces[7, 2] = new piece("white bishop");
                    pieces[7, 3] = new piece("white queen");
                    pieces[7, 4] = new piece("white king");
                    pieces[7, 5] = new piece("white bishop");
                    pieces[7, 6] = new piece("white knight");
                    pieces[7, 7] = new piece("white rook");
                    break;

                default:
                    gridButtons = new Button[8, 8]; pieces = new piece[8, 8];
                    pieces[0, 0] = new piece("black rook");
                    pieces[0, 1] = new piece("black knight");
                    pieces[0, 2] = new piece("black bishop");
                    pieces[0, 3] = new piece("black queen");
                    pieces[0, 4] = new piece("black king");
                    pieces[0, 5] = new piece("black bishop");
                    pieces[0, 6] = new piece("black knight");
                    pieces[0, 7] = new piece("black rook");
                    for (int i = 0; i < 8; i++)
                    {
                        pieces[1, i] = new piece("black pawn");
                        pieces[6, i] = new piece("white pawn");
                    }
                    pieces[7, 0] = new piece("white rook");
                    pieces[7, 1] = new piece("white knight");
                    pieces[7, 2] = new piece("white bishop");
                    pieces[7, 3] = new piece("white queen");
                    pieces[7, 4] = new piece("white king");
                    pieces[7, 5] = new piece("white bishop");
                    pieces[7, 6] = new piece("white knight");
                    pieces[7, 7] = new piece("white rook");
                    break;
            }
        }

        public piece GetPiece(int row, int column)
        {
            return pieces[row, column];
        }

        public piece
    }
}
