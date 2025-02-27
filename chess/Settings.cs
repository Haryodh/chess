using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    internal class Settings
    {
        private Color checkerOneColor = Color.Black;
        private Color CheckerTwoColor = Color.White;

        private int scale = 50;

        public void setCheckerOneColor(int r, int g, int b)
        {
            checkerOneColor = Color.FromArgb(r, g, b);
        }
        public void setCheckerTwoColor(int r, int g, int b)
        {
            CheckerTwoColor = Color.FromArgb(r, g, b);
        }
    }
}
