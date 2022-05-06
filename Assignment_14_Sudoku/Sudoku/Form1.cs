using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Sudoku
{
    public partial class Sudoku : Form
    {
        TextBox[,] cells;
        int n = 9;
        public Sudoku()
        {
            InitializeComponent();
            cells = new TextBox[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    cells[i, j] = new TextBox();
                    cells[i, j].Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom;
                    cells[i, j].MaxLength = 1;
                    cells[i, j].TextAlign = HorizontalAlignment.Center;
                    cells[i, j].Font = new Font("Tahoma", 14);
                    cells[i, j].BackColor = Color.White;
                    cells[i, j].Click += new EventHandler(textbox_click);

                    tableLayoutPanel1.Controls.Add(cells[i, j], i, j);
                    if (i < 3 && j < 3
                       ||
                       i > 5 && j > 5
                       ||
                       i < 3 && j > 5 || i > 5 && j < 3
                       ||
                       i > 4 && i < 6 && j > 4 && j < 6
                       ||
                       i > 3 && i < 6 && j > 4 && j < 6
                       ||
                       i > 2 && i < 6 && j > 4 && j < 6
                       ||
                       i > 4 && i < 6 && j > 3 && j < 6
                       ||
                       i > 4 && i < 6 && j > 2 && j < 6
                       ||
                       i > 3 && i < 6 && j > 2 && j < 6
                       ||
                       i > 2 && i < 6 && j > 2 && j < 6)
                    {

                        cells[i, j].BackColor = Color.SkyBlue;
                    }
                }
            }
        }

        private void textbox_click(object sender, EventArgs e)
        {
            //----------------------The user can only enter a number between 1 to 9------------------------
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int number;
                    if (Int32.TryParse(cells[i, j].Text, out number))
                    {
                        if ((number < 1) || (number > 9))
                        {
                            cells[i, j].Text = "";
                        }
                    }
                    else
                    {
                        cells[i, j].Text = "";
                    }
                }
            }
        }

        private void btn_newgame_Click(object sender, EventArgs e)
        {
            //------------------------Empty sudoku table-------------------
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    cells[i, j].ReadOnly = false;
                    cells[i, j].Text = "";
                    cells[i, j].BackColor = Color.White;
                    if (i < 3 && j < 3
                       ||
                       i > 5 && j > 5
                       ||
                       i < 3 && j > 5 || i > 5 && j < 3
                       ||
                       i > 4 && i < 6 && j > 4 && j < 6
                       ||
                       i > 3 && i < 6 && j > 4 && j < 6
                       ||
                       i > 2 && i < 6 && j > 4 && j < 6
                       ||
                       i > 4 && i < 6 && j > 3 && j < 6
                       ||
                       i > 4 && i < 6 && j > 2 && j < 6
                       ||
                       i > 3 && i < 6 && j > 2 && j < 6
                       ||
                       i > 2 && i < 6 && j > 2 && j < 6)
                    {

                        cells[i, j].BackColor = Color.SkyBlue;
                    }
                }
            }
            //--------------------------------End--------------------------

            btn_newgame.BackColor = Color.LightBlue;
            OpenFileDialog x = new OpenFileDialog();
            if (x.ShowDialog() == DialogResult.OK)
            {
                //MessageBox.Show("Yes");
                string file_path = x.FileName;
                //MessageBox.Show(file_path);
                StreamReader my_file = new StreamReader(file_path);
                string big_text = my_file.ReadToEnd();
                //MessageBox.Show(big_text);
                big_text = big_text.Replace("\n", "");
                string[] numbers = big_text.Split(); // size 81
                int index = 0;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (numbers[index] != "0")
                        {
                            cells[j, i].ReadOnly = true;
                            cells[j, i].Text = numbers[index];
                            cells[j, i].BackColor = Color.LightGreen;
                        }
                        index++;
                    }
                }
            }
        }

        private void check_btn_Click(object sender, EventArgs e)
        {
            // --------------------- row & col check -----------------------
            int x, y, f=0;
            for (int i = 0; i < n; i++)
            {
                int[] row = new int[n];
                int[] col = new int[n];

                for (int j = 0; j < n; j++)
                {
                    if (cells[i, j].Text != "" && cells[j, i].Text != "")
                    {
                        x = Convert.ToInt32(cells[i, j].Text);
                        y = Convert.ToInt32(cells[j, i].Text);

                        if (!row.Contains(x) && !col.Contains(y))
                        {
                            row[j] = x;
                            col[j] = y;
                        }
                        else
                        {
                            f++;
                        }
                    }

                    else
                    {
                        MessageBox.Show("! همه خانه ها باید پر شود");
                        return;
                    }
                }
            }

            // -------------------------- squre check ------------------------
            for (int k = 0; k < n - 2; k += 3)
            {
                for (int l = 0; l < n - 2; l += 3)
                {

                    int count = 0;
                    int[] sq = new int[n];

                    for (int m = k; m < k + 3; m++)
                    {
                        for (int p = l; p < l + 3; p++)
                        {
                            if (cells[m, p].Text != "" && cells[p, m].Text != "")
                            {
                                x = Convert.ToInt32(cells[m, p].Text);
                                if (x >= 1 && x <= n && !sq.Contains(x))
                                {
                                    sq[count] = x;
                                    count++;
                                }
                                else
                                {
                                    f++;
                                }
                            }
                            else
                            {
                                MessageBox.Show("! همه خانه ها باید پر شود");
                                return;
                            }
                        }
                    }
                }
            }

            if(f==0)
            {
                MessageBox.Show("! درست حل شد");
                return;
            }
                
            else
            {
                MessageBox.Show("! عدد تکراری وجود دارد");
                f = 0;
                return;
            }
        }
    }
}

