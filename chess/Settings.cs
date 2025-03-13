using chess.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    internal static class Settings
    {
        private static Color checkerOneColor = Color.White; //Checker one color.
        private static Color CheckerTwoColor = Color.Black; //Checker two color.

        private static int scale = 50; //Scale of the program.

        public static void setCheckerOneColor(Color c) //Setter for color one.
        {
            checkerOneColor = c;
        }
        public static void setCheckerTwoColor(Color c) //Setter for color two.
        {
            CheckerTwoColor = c;
        }

        public static Color getCheckerOneColor() { return checkerOneColor; } //Getter for color one.
        public static Color getCheckerTwoColor() { return CheckerTwoColor; } //Getter for color two.

        public static int getScale() { return scale; } 
        public static void setScale(int newScale) { scale = newScale; }

        public static readonly Dictionary<int, Image> pieceImages = new Dictionary<int, Image>
        {
            {0, null },
            {11, Resources.pawn },
            {12, Resources.knight },
            {13, Resources.bishop },
            {14, Resources.rook },
            {15, Resources.queen },
            {16, Resources.king },
            {101, Resources.black_pawn },
            {102, Resources.black_knight },
            {103, Resources.black_bishop },
            {104, Resources.black_rook },
            {105, Resources.black_queen },
            {106, Resources.black_king },
        };

    }
}
