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

        public ref Button getButton(int i, int j) { return ref gridButtons[i, j]; } //Get a certain button (by ref)

        public void setButton(Button b, int i, int j) { gridButtons[i, j] = b; } //Set a certain button.

        public int getSize() { return gridButtons.GetLength(0); } //Return the size of the board.

        public void setButtonSize(int i, int j, Size size, Point point)
        {
            gridButtons[i,j].Size = size;
            gridButtons[i,j].Location = point;
        }


        private void boardCatalogue(int boardNum)
        {
            int size = 8; //Just in case default to 8. If forget to set in code this may cause a crash.
            switch (boardNum)
            {
                case 0: // Default Game setup
                    size = 8;
                    gridButtons = new Button[size, size]; pieces = new piece[size, size];

                    for (int i = 0; i < size; i++)
                    {
                        for (int j = 0; j < size; j++)
                        {
                            pieces[i, j] = new piece("Empty");
                        }
                    }

                    pieces[0, 0] = new piece("black rook");
                    pieces[0, 1] = new piece("black knight");
                    pieces[0, 2] = new piece("black bishop");
                    pieces[0, 3] = new piece("black queen");
                    pieces[0, 4] = new piece("black king");
                    pieces[0, 5] = new piece("black bishop");
                    pieces[0, 6] = new piece("black knight");
                    pieces[0, 7] = new piece("black rook");
                    for(int i = 0; i < size; i++)
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

                case 1: //Queen mayhem
                    size = 10;
                    gridButtons = new Button[size, size]; pieces = new piece[size, size];

                    for (int i = 0; i < size; i++)
                    {
                        for (int j = 0; j < size; j++)
                        {
                            pieces[i, j] = new piece("Empty");
                        }
                    }

                    for (int i = 0; i < size; i++)
                    {
                        pieces[0, i] = new piece("black queen");
                        pieces[1, i] = new piece("black queen");

                        pieces[size-2, i] = new piece("white queen");
                        pieces[size-1, i] = new piece("white queen");
                    }
                    break;



                default:
                    size = 8;
                    gridButtons = new Button[size, size]; pieces = new piece[size, size];

                    for (int i = 0; i < size; i++)
                    {
                        for (int j = 0; j < size; j++)
                        {
                            pieces[i, j] = new piece("Empty");
                        }
                    }

                    pieces[0, 0] = new piece("black rook");
                    pieces[0, 1] = new piece("black knight");
                    pieces[0, 2] = new piece("black bishop");
                    pieces[0, 3] = new piece("black queen");
                    pieces[0, 4] = new piece("black king");
                    pieces[0, 5] = new piece("black bishop");
                    pieces[0, 6] = new piece("black knight");
                    pieces[0, 7] = new piece("black rook");
                    for (int i = 0; i < size; i++)
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

        public ref piece getPiece(int row, int column)
        {
            return ref pieces[row, column];
        }

        public void setPiece(piece piece, int i, int j)
        {
            pieces[i, j] = piece;
        }
    }
}
