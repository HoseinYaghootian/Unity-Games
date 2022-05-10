using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_2048
{
    public partial class Form1 : Form
    {
        Label[,] grid;
        public Form1()
        {
            InitializeComponent();

            int n = 4;
            grid = new Label[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    grid[i, j] = new Label();

                    tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                    grid[i, j].Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

                    grid[i, j].Text = "2";
                    grid[i, j].Font = new Font("Clear Sans", 38, FontStyle.Bold);

                    tableLayoutPanel1.BackColor = Color.FromArgb(187, 173, 160);
                    grid[i, j].BackColor = Color.FromArgb(238, 228, 218);
                    grid[i, j].ForeColor = Color.FromArgb(119, 110, 101);

                    grid[i, j].BorderStyle = BorderStyle.None;
                    grid[i, j].TextAlign = ContentAlignment.MiddleCenter;

                    var margin = grid[i, j].Margin;
                    margin.All = 8;
                    grid[i, j].Margin = margin;

                    tableLayoutPanel1.Controls.Add(grid[i, j], i, j);
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Up:
                    MessageBox.Show("Up");
                    break;
                case Keys.Down:
                    MessageBox.Show("Down");
                    break;
                case Keys.Left:
                    MessageBox.Show("Left");
                    break;
                case Keys.Right:
                    MessageBox.Show("Right");
                    break;
            }
        }
    }
}
