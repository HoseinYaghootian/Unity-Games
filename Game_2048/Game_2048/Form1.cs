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

        int i_next, j_next;

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
            bool x = false;
            
            for (int k = 0; k < n-1; k++)
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        if(grid[i, j].Text != "")
                            switch (e.KeyCode)
                            {
                                case Keys.Up:
                                    if (j > 0)
                                    {
                                        i_next = i;
                                        j_next = j - 1;

                                        x = rn(grid, i, j, i_next, j_next, x);
                                    }
                                    break;

                                case Keys.Down:
                                    if (j < n - 1)
                                    {
                                        i_next = i;
                                        j_next = j + 1;

                                        x = rn(grid, i, j, i_next, j_next, x);
                                    }
                                    break;

                                case Keys.Left:
                                    if (i > 0)
                                    {
                                        i_next = i - 1;
                                        j_next = j;

                                        x = rn(grid, i, j, i_next, j_next, x);
                                    }
                                    break;

                                case Keys.Right:
                                    if (i < n - 1)
                                    {
                                        i_next = i + 1;
                                        j_next = j;

                                        x = rn(grid, i, j, i_next, j_next, x);
                                    }
                                    break;
                            }
            if (x == true)
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

                r_x = rand.Next(0, n);
                r_y = rand.Next(0, n);

                if (grid[r_x, r_y].Text != "")
                    empty = false;
            } while (empty == false);

            r = (num[rand.Next(0, num.Length)]).ToString();
            grid[r_x, r_y].Text = r;
        }

        private bool rn(Label[,] grid, int i, int j, int i_next, int j_next, bool x)
        {
            if (grid[i_next, j_next].Text == "")
            {
                move_rn(grid, i, j, i_next, j_next);
                x = true;
            }

            else if (grid[i, j].Text == grid[i_next, j_next].Text)
                combine_rn(grid, i, j, i_next, j_next);
                
            return x;
        }

        private void move_rn(Label[,] grid, int i, int j, int i_next, int j_next)
        {
            grid[i_next, j_next].Text = grid[i, j].Text;
            grid[i, j].Text = "";
        }

        private void combine_rn(Label[,] grid, int  i, int j, int i_next, int j_next)
        {
            int[] num = { 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2084 };
            
            for (int index = 0; (index < num.Length-1) && (grid[i, j].Text == num[index].ToString()); index++)
            {
                grid[i_next, j_next].Text = num[index + 1].ToString();
                grid[i, j].Text = "";
            }
        }
    }
}
