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
        int n = 4;
        int r_x, r_y;
        string r;

        public Form1()
        {
            InitializeComponent();

            grid = new Label[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    grid[i, j] = new Label();

                    tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                    grid[i, j].Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

                    grid[i, j].Text = "";
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

            make_rn();
            make_rn();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Up:
                    for(int k = 0; k < 3; k++)
                        for (int i = 0; i < n; i++)
                        {
                            for (int j = 0; j < n; j++)
                            {
                                if (j > 0)
                                {
                                    if(grid[i, j - 1].Text == "")
                                    { 
                                        grid[i, j - 1].Text = grid[i, j].Text;
                                        grid[i, j].Text = "";
                                    }
                                 }
                            }
                        }
                break;

                case Keys.Down:
                    for (int k = 0; k < 3; k++)
                        for (int i = 0; i < n; i++)
                        {
                            for (int j = 0; j < n; j++)
                            {
                                if (j < n-1)
                                {
                                    if (grid[i, j + 1].Text == "")
                                    {
                                        grid[i, j + 1].Text = grid[i, j].Text;
                                        grid[i, j].Text = "";
                                    }
                                }
                            }
                        }
                    break;

                case Keys.Left:
                    for (int k = 0; k < 3; k++)
                        for (int i = 0; i < n; i++)
                        {
                            for (int j = 0; j < n; j++)
                            {
                                if (i > 0)
                                {
                                    if (grid[i - 1, j].Text == "")
                                    {
                                        grid[i - 1, j].Text = grid[i, j].Text;
                                        grid[i, j].Text = "";
                                    }
                                }
                            }
                        }
                    break;

                case Keys.Right:
                    for (int k = 0; k < 3; k++)
                        for (int i = 0; i < n; i++)
                        {
                            for (int j = 0; j < n; j++)
                            {
                                if (i < n - 1)
                                {
                                    if (grid[i + 1, j].Text == "")
                                    {
                                        grid[i + 1, j].Text = grid[i, j].Text;
                                        grid[i, j].Text = "";
                                    }
                                }
                            }
                        }
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            make_rn();
        }

        private void make_rn()
        {
            var rand = new Random();
            int[] num = { 2, 2, 2, 4 };

            bool empty;
            do
            {
                empty = true;

                r_x = rand.Next(0, n - 1);
                r_y = rand.Next(0, n - 1);

                if (grid[r_x, r_y].Text != "")
                    empty = false;
            } while (empty == false);

            r = (num[rand.Next(0, num.Length)]).ToString();
            grid[r_x, r_y].Text = r;
        }
    }
}
