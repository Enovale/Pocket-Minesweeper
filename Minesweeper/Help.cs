using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Menu : Form
    {

        public MenuHandler menu;
        public ComboBox difficulty;
        public NumericUpDown widthField;
        public NumericUpDown heightField;
        public NumericUpDown bombsField;

        public Menu()
        {
            InitializeComponent();
            difficulty = this.difficultyBox;
            widthField = this.customWidthField;
            heightField = this.customHeightField;
            bombsField = this.customBombsField;
            menu = new MenuHandler(this);
        }

        private void Menu_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Up))
            {
                // Up
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Down))
            {
                // Down
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Left))
            {
                // Left
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Right))
            {
                // Right
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                // Enter
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            menu.RunGame();
        }
    }
}