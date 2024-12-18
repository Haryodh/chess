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

    public partial class Chess : Form
    {
        //--------------------------------------------------------------------------------
        Displays display = new Displays();
        //--------------------------------------------------------------------------------
        public Chess()
        {
            InitializeComponent();
        }

        private void Chess_Load(object sender, EventArgs e)
        {
            int screenwidth = this.Width;
            int screenheight = this.Height;
            this.Resize += resize;
            this.MinimumSize = new Size(480, 270);


            board[] boards = new board[10];
            int currentboard = 0;
            boards[currentboard] = new board(1, ref display.panel);

            displayBoard(display.panel);
            this.Controls.Add(display.panel);
        }

        private void resize(object sender, EventArgs e)
        {
            displayBoard(display.panel);
        }

        private void displayBoard(Panel p)
        {
            int scale = 66;

            int screenwidth = this.Width;
            int screenheight = this.Height;

            int scaledwidth = (this.Width * scale / 100);
            int scaledheight = (this.Height * scale / 100);

            if (scaledwidth > scaledheight)
            {
                scaledwidth = scaledheight;
            }
            else
            {
                scaledheight = scaledwidth;
            }

            display.panel.Location = new Point(screenwidth / 2 - scaledwidth / 2, screenheight / 2 - scaledheight / 2);
            display.panel.Size = new Size(scaledwidth, scaledheight);
            display.panel.BackColor = Color.Black;
        }
    }
}
