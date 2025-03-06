using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chess
{
    internal static class Displays
    {
        public static Panel boardPanel = new Panel(); //Panel to contain board.
        public static Button settingsButton = new Button(); //Button to go to settings
        public static Label resolutionDisplay = new Label(); //Testing REMOVE


        public static Button checkerOneColor = new Button(); //Button to change checker one color
        public static Button checkerTwoColor = new Button(); //Button to change checker two color

        public static TrackBar scaleSelect = new TrackBar(); //Trackbar to select scale
    
    }
}
