using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chess
{
    internal class board
    {
        private int[,] grid;

        public board(int setup)
        {
            setboard(setup);
        }

        public int[,] getboard() { return grid; }

        public int setboard(int setup)
        {
            /*
             * #0 = Base Game
             * 
             * 
            */

            /*
             * 01 = White Pawn
             * 02 = White King
             * 03 = White Queen
             * 04 = White Knight
             * 05 = White Rook
             * 06 = White Bishop
             *
             * 11 = Black Pawn
             * 12 = Black King
             * 13 = Black Queen
             * 14 = Black Knight
             * 15 = Black Rook
             * 16 = Black Bishop
            */


            int[,] base_game = { { 05,06,04,02,03,04,06,02 },
                                 { 01,01,01,01,01,01,01,01 },
                                 { 00,00,00,00,00,00,00,00 },
                                 { 00,00,00,00,00,00,00,00 },
                                 { 00,00,00,00,00,00,00,00 },
                                 { 00,00,00,00,00,00,00,00 },
                                 { 11,11,11,11,11,11,11,11 },
                                 { 15,16,14,12,13,14,16,12 } };


            switch (setup)
            {
                case 0:
                    grid = base_game;
                    return 1;
                default:
                    grid = base_game;
                    return -1;
            }

        }
    }


}
