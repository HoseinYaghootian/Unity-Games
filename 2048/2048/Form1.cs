using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048
{
    public partial class Form1 : Form
    {
        Label[,] grid;
        int length = 4;
        int tile_i, tile_j;

        public Form1()
        {
            InitializeComponent();

            grid = new Label[length, length];
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
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

            make_tile();
            make_tile();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            bool x = false;

            for (int k = 0; k < length - 1; k++)
                for (int i = 0; i < length; i++)
                    for (int j = 0; j < length; j++)
                        if (grid[i, j].Text != "")
                        {
                            int i_next = i;
                            int j_next = j;

                            switch (e.KeyCode)
                            {
                                case Keys.Up:
                                    if (j > 0)
                                    {
                                        j_next = j - 1;

                                        x = tile(grid, i, j, i_next, j_next, x);
                                    }
                                    break;

                                case Keys.Down:
                                    if (j < length - 1)
                                    {
                                        j_next = j + 1;

                                        x = tile(grid, i, j, i_next, j_next, x);
                                    }
                                    break;

                                case Keys.Left:
                                    if (i > 0)
                                    {
                                        i_next = i - 1;

                                        x = tile(grid, i, j, i_next, j_next, x);
                                    }
                                    break;

                                case Keys.Right:
                                    if (i < length - 1)
                                    {
                                        i_next = i + 1;

                                        x = tile(grid, i, j, i_next, j_next, x);
                                    }
                                    break;
                            }
                        }

            if (x == true)
                make_tile();

        }

        private void make_tile()
        {
            var rand = new Random();
            int[] num = { 2, 2, 2, 4 };

            bool empty;
            do
            {
                empty = true;

                tile_i = rand.Next(0, length);
                tile_j = rand.Next(0, length);

                if (grid[tile_i, tile_j].Text != "")
                    empty = false;
            } while (empty == false);

            grid[tile_i, tile_j].Text = (num[rand.Next(0, num.Length)]).ToString();
        }


        private bool tile(Label[,] grid, int i, int j, int i_next, int j_next, bool x)
        {
            if (grid[i_next, j_next].Text == "")
            {
                move_tile(grid, i, j, i_next, j_next);
                x = true;
            }

            else if (grid[i, j].Text == grid[i_next, j_next].Text)
            {
                combine_tile(grid, i, j, i_next, j_next);
                x = true;
            }

            return x;
        }

        private void move_tile(Label[,] grid, int i, int j, int i_next, int j_next)
        {
            grid[i_next, j_next].Text = grid[i, j].Text;
            grid[i, j].Text = "";
        }

        private void combine_tile(Label[,] grid, int i, int j, int i_next, int j_next)
        {
            int content = Int32.Parse(grid[i_next, j_next].Text);
            content *= 2;

            grid[i_next, j_next].Text = content.ToString();
            grid[i, j].Text = "";
        }
    }
}
