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

        //
        Panel checkerOnePanel = new Panel();
        Panel checkerTwoPanel = new Panel();

        TrackBar checkerOneR = new TrackBar();
        TrackBar checkerOneG = new TrackBar();
        TrackBar checkerOneB = new TrackBar();

        TrackBar checkerTwoR = new TrackBar();
        TrackBar checkerTwoG = new TrackBar();
        TrackBar checkerTwoB = new TrackBar();
        //

        private void SettingsPage_Load(object sender, EventArgs e)
        {

            this.Controls.Add(checkerOnePanel);
            this.Controls.Add(checkerTwoPanel);

            checkerOnePanel.BackColor = Chess.;
            checkerTwoPanel.BackColor = Color.Green;

            checkerOnePanel.Location = new Point(0, 0);
            checkerTwoPanel.Location = new Point(0,checkerOnePanel.Height);

            checkerOnePanel.Controls.Add(checkerOneR);
            checkerOnePanel.Controls.Add(checkerOneG);
            checkerOnePanel.Controls.Add(checkerOneB);

            checkerTwoPanel.Controls.Add(checkerTwoR);
            checkerTwoPanel.Controls.Add(checkerTwoG);
            checkerTwoPanel.Controls.Add(checkerTwoB);

        }
    }
}
