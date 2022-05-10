using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyApp
{
    public partial class Form1 : Form
    {
        Button character;
        int size = 1024;

        public Form1()
        {
            InitializeComponent();
            Width = size;
            Height = size;
            BackColor = Color.FromArgb(112, 108, 64);

            CreateCharacter();
        }
      
        private void CreateCharacter()
        {
            character = new Button();
            character.Name = "character";

            var rand = new Random();
            int x = rand.Next(0, size - 70);
            int y = rand.Next(0, size - 140);
            character.Location = new Point(x, y);

            character.Width = 53;
            character.Height = 95;

            character.FlatStyle = FlatStyle.Flat;
            character.FlatAppearance.BorderSize = 0;

            character.Image = Image.FromFile(@"C:\Users\Axiom\source\repos\KeyApp\KeyApp\Properties\Assets\Pic\image1.gif");
            //KeyApp.Properties.Resources.image1.gif

            Controls.Add(character);
            character.KeyDown += Character_KeyDown;
            character.KeyUp += Character_KeyUp;
            character.KeyPress += Character_KeyPress;
        }

        private void Character_KeyDown(object sender, KeyEventArgs e)
        {
            /*
            if (e.Shift)
            {
                if (e.KeyCode == Keys.W && e.Shift)
                {
                    character.Top -= 10;
                }
                else if (e.KeyCode == Keys.S && e.Shift)
                {
                    character.Top += 10;
                }
                else if (e.KeyCode == Keys.A && e.Shift)
                {
                    character.Left -= 10;
                }
                else if (e.KeyCode == Keys.D && e.Shift)
                {
                    character.Left += 10;
                }
            }
            */

            if (e.KeyCode == Keys.W && character.Location.Y > 0)
            {
                character.Top -= 5;
                character.ImageAlign = ContentAlignment.TopCenter;
            }
            else if (e.KeyCode == Keys.S && character.Location.Y < size - 140)
            {
                character.Top += 5;
                character.ImageAlign = ContentAlignment.BottomCenter;
            }
            else if (e.KeyCode == Keys.A && character.Location.X > 0)
            {
                character.Left -= 5;
                character.ImageAlign = ContentAlignment.MiddleLeft;
            }
            else if (e.KeyCode == Keys.D && character.Location.X < size - 70)
            {
                character.Left += 5;
                character.ImageAlign = ContentAlignment.MiddleRight;
            }
        }

        private void Character_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'Q' || e.KeyChar == 'q')
            {
                character.ImageAlign = ContentAlignment.TopLeft;
            }
        }

        private void Character_KeyUp(object sender, KeyEventArgs e)
        {
            character.ImageAlign = ContentAlignment.MiddleCenter;
        }
    }
}
