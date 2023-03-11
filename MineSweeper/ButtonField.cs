using System;
using System.Drawing;
using System.Windows.Forms;

namespace MineSweeper
{
    internal class ButtonField : Button
    {
        public ButtonField()
        {
            WasClicked = false;
            IsBomb = false;
            SurroundingCount = 0;
        }

        private bool isBomb;
        public bool IsBomb
        {
            get => isBomb;
            set
            {
                isBomb = value;
                prepareView();
                //Text = "BB";
            }
        }


        private int surroudingCount;

        public int SurroundingCount
        {
            get => surroudingCount;
            set
            {
                surroudingCount = value;
                prepareView();
                //Text = surroudingCount.ToString();
            }
        }
        private void prepareView()
        {
            if (!WasClicked)
            {
                Text = "";
                BackColor = Color.Gray;
            }
            else
            {
                BackColor = Color.White;
                if (IsBomb)
                {
                    Text = "BB";
                    BackColor = Color.Red;
                }
                else if (SurroundingCount > 0)
                {
                    Text = SurroundingCount.ToString();
                    BackColor = Color.Green;
                }
                else
                {
                    BackColor = Color.White;
                }
            }
        }

        private bool wasClicked = false;

        public bool WasClicked
        {
            get => wasClicked;
            set 
            {
                wasClicked = value;
                if (wasClicked)
                {
                    Enabled = false;
                }
                prepareView();
            }
        }
        
    }
}