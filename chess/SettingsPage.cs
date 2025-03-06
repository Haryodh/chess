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
            this.Resize += settingsPageRezie; // When resized run the function assigned.

            this.Controls.Add(Displays.checkerOneColor); //Add checker one color button to the form.
            this.Controls.Add(Displays.checkerTwoColor); //Add checker two color button to the form.

            this.Controls.Add(Displays.scaleSelect); //Add scale select trackbar to form

            Displays.checkerOneColor.Click += checkerOneButtonClick; //When clicked run function.
            Displays.checkerTwoColor.Click += checkerTwoButtonClick; //When clicked run function.

            Displays.scaleSelect.Maximum = 75;
            Displays.scaleSelect.Minimum = 25;
            Displays.scaleSelect.Value = Settings.getScale();
            Displays.scaleSelect.ValueChanged += scaleChanged;

            


            updateDisplay(); // Update scaling.

            this.FormClosing += closing; // When closing run closing function.
        }

        public void scaleChanged(object sender, EventArgs e)
        {
            TrackBar scaleBar = sender as TrackBar;
            Settings.setScale(scaleBar.Value);
            settingChanged();
        }

        private void closing(object sender, FormClosingEventArgs e) //Prevents this form from fully closing and just hides it.
        {
            this.Hide();
            e.Cancel = true;
        }

        private void checkerOneButtonClick(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.ShowDialog(); //Opens color picker dialogue
            Button b = (sender as Button);
            Settings.setCheckerOneColor(dlg.Color); //Set checker one color to the picked color.
            b.BackColor = Settings.getCheckerOneColor(); //Set background color of button to picked color.
            settingChanged(); //Call to update the display
        }

        private void checkerTwoButtonClick(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.ShowDialog(); //Opens Color picker dialogue
            Button b = (sender as Button);
            Settings.setCheckerTwoColor(dlg.Color); //Set checker two color to the picked color.
            b.BackColor = Settings.getCheckerTwoColor(); //Set background color of button to picked color.
            settingChanged();
        }



        private void settingsPageRezie(object sender, EventArgs e) // Runs when page is resized
        {
            updateDisplay();
        }

        private void updateDisplay() //Scales properly.
        {
            Displays.checkerOneColor.Location = new Point(0, 0); //ALL TEMP
            Displays.checkerOneColor.Size = new Size(this.Width/10,this.Height/10);

            Displays.checkerTwoColor.Location = new Point(0, this.Height/10);
            Displays.checkerTwoColor.Size = new Size(this.Width/10,this.Height/10);

            Displays.scaleSelect.Location = new Point(0, (this.Height / 10) * 2);
            Displays.scaleSelect.Size = new Size(this.Width / 10, this.Height / 10);
        }

        private void settingChanged()
        {
            FormCollection fc = Application.OpenForms;
            foreach (Form f in fc)
            {
                f.Size = new Size(f.Size.Width + 1, f.Size.Height);
                f.Size = new Size(f.Size.Width - 1, f.Size.Height);
            }
        }

    }
}
