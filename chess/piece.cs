using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    internal class piece
    {
        private string name = "Empty";
        private int type = 0; //0 = empty, 1 = Pawn, 2 = Knight, 3 = Bishop, 4 = Rook, 5 = Queen, 6 = King , +10 for white, +100 for Black

        

        public piece(int pieceNum)
        {

            switch (pieceNum)
            {
                case 0: type = pieceNum; name = "Empty"; break;

                case 11: type = pieceNum; name = "White Pawn"; break;

                case 12: type = pieceNum; name = "White Knight"; break;

                case 13: type = pieceNum; name = "White Bishop"; break;

                case 14: type = pieceNum; name = "White Rook"; break;

                case 15: type = pieceNum; name = "White Queen"; break;

                case 16: type = pieceNum; name = "White King"; break;

                case 101: type = pieceNum; name = "Black Pawn"; break;

                case 102: type = pieceNum; name = "Black Knight"; break;

                case 103: type = pieceNum; name = "Black Bishop"; break;

                case 104: type = pieceNum; name = "Black Rook"; break;

                case 105: type = pieceNum; name = "Black Queen"; break;

                case 106: type = pieceNum; name = "Black King"; break;

                default: type = 0; name = "Empty"; break;
            }
        }
        public piece(string pieceName)
        {
            switch (pieceName.ToLower())
            {
                case "empty": name = pieceName; type = 0; break;

                case "white pawn": name = pieceName; type = 11; break;

                case "white knight": name = pieceName; type = 12; break;

                case "white bishop": name = pieceName; type = 13; break;

                case "white rook": name = pieceName; type = 14; break;

                case "white queen": name = pieceName; type = 15; break;

                case "white king": name = pieceName; type = 16; break;

                case "black pawn": name = pieceName  ; type = 101; break;

                case "black knight": name = pieceName; type = 102; break;

                case "black bishop": name = pieceName; type = 103; break;

                case "black rook": name = pieceName; type = 104; break;

                case "black queen": name = pieceName; type = 105; break;

                case "black king": name = pieceName; type = 106; break;

                default: type = 0; name = "Empty"; break;
            }
        }
    }
}
