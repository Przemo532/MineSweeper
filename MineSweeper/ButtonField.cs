using System;
using System.Windows.Forms;

namespace MineSweeper
{
    internal class ButtonField: Button
    {
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
            if (IsBomb)
            {
                Text = "BB";
            }
            else if (SurroundingCount > 0)
            {
                Text = SurroundingCount.ToString();
            }
        }
        //bool wasClicked = false;
    }
}