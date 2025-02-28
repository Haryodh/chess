using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chess
{
    public partial class SettingsPage : Form
    {

        public SettingsPage()
        {
            InitializeComponent();
        }

        

        private void SettingsPage_Load(object sender, EventArgs e)
        {
            this.Resize += settingsPageRezie;

            this.Controls.Add(Displays.checkerOneColor);
            this.Controls.Add(Displays.checkerTwoColor);

        }

        private void settingsPageRezie(object sender, EventArgs e)
        {
            updateDisplay();
        }

        private void updateDisplay()
        {
            Displays.checkerOneColor.Location = new Point(0, 0);
            Displays.checkerOneColor.Size = new Size(this.Width/10,this.Height/10);

            Displays.checkerTwoColor.Location = new Point(0, this.Height/10);
            Displays.checkerTwoColor.Size = new Size(this.Width/10,this.Height/10);

        }
    }
}
