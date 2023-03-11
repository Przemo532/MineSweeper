using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeper
{
    public partial class Form1 : Form
    {
        Game myGame;
        public Form1()
        {
            InitializeComponent();
            myGame = new Game(8,8,10);
            this.Controls.Add(myGame);
        }
    }
}
