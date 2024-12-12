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
        Panel panel = new Panel();
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
            boards[0] = new board(1);


            this.Controls.Add(panel);
            displayBoard();
        }

        private void resize(object sender, EventArgs e)
        {
            displayBoard();
        }

        private void displayBoard()
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

            panel.Location = new Point(screenwidth / 2 - scaledwidth / 2, screenheight / 2 - scaledheight / 2);
            panel.Size = new Size(scaledwidth, scaledheight);
            panel.BackColor = Color.Black;
        }
    }
}
