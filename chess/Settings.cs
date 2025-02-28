﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    internal static class Settings
    {
        private static Color checkerOneColor = Color.Black; //Checker one color.
        private static Color CheckerTwoColor = Color.White; //Checker two color.

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
    }
}
