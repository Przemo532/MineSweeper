using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeper
{
    class Game: Panel
    {
        const int FieldSize=40;
        Random generator;
        ButtonField[,] board;
        public Game(int width,int height,int bombs) //x,y - dimensions, b - number of bombs
        {
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            //We can try to change either the panel or button padding later to try to get rid of uneven margins

            generator = new Random();
            board = new ButtonField[width, height];

            for(int x=0; x<width; x++)
            {
                for (int y=0; y<height; y++)
                {
                    board[x, y] = new ButtonField();
                    board[x, y].Size = new Size(FieldSize, FieldSize);
                    board[x, y].Location = new Point(x * FieldSize, y * FieldSize);

                    this.Controls.Add(board[x, y]);
                }
            }

            int tempX = 0;
            int tempY = 0;
            do
            {
                tempX = generator.Next(width);
                tempY = generator.Next(height);
                if (!board[tempX, tempY].IsBomb)
                {
                    board[tempX, tempY].IsBomb = true;
                    bombs--;
                    /*
                    if (tempX<width && tempY<height && tempX>0 && tempY>0 && !board[tempX,tempY].IsBomb)
                        board[tempX-1, tempY].SurroundingCount++;
                    if (tempX < width && tempY < height && tempX > 0 && tempY > 0 && !board[tempX, tempY].IsBomb)
                        board[tempX, tempY-1].SurroundingCount++;
                    if (tempX < width && tempY < height && tempX > 0 && tempY > 0 && !board[tempX, tempY].IsBomb)
                        board[tempX-1, tempY-1].SurroundingCount++;
                    if (tempX < width && tempY < height && tempX > 0 && tempY > 0 && !board[tempX, tempY].IsBomb)
                        board[tempX+1, tempY].SurroundingCount++;
                    if (tempX < width && tempY < height && tempX > 0 && tempY > 0 && !board[tempX, tempY].IsBomb)
                        board[tempX, tempY+1].SurroundingCount++;
                    if (tempX < width && tempY < height && tempX > 0 && tempY > 0 && !board[tempX, tempY].IsBomb)
                        board[tempX+1, tempY+1].SurroundingCount++;
                    if (tempX < width && tempY < height && tempX > 0 && tempY > 0 && !board[tempX, tempY].IsBomb)
                        board[tempX-1, tempY+1].SurroundingCount++;
                    if (tempX < width && tempY < height && tempX > 0 && tempY > 0 && !board[tempX, tempY].IsBomb)
                        board[tempX+1, tempY-1].SurroundingCount++;*/
                    foreach(ButtonField bf in ButtonFieldAround(board[tempX, tempY]))
                    {
                        bf.SurroundingCount++;
                    }
                }
            } while(bombs>0);

        }

        private List<ButtonField> ButtonFieldAround(ButtonField buttonField)
        {
            List<ButtonField> l = new List<ButtonField>();
            Point loc = GetLocation(buttonField);

            for (int x =loc.X - 1; x <=loc.X + 1; x++){
                for(int y=loc.Y - 1; y<=loc.Y + 1; y++)
                {
                    if (x >= 0 && y >= 0 && x < board.GetLength(0) && y < board.GetLength(1))
                    {
                        l.Add(board[x, y]);
                    }
                }
            }
            return l;
        }

        private Point GetLocation(ButtonField buttonField)
        {
            for(int x=0; x<board.GetLength(0); ++x)
            {
                for(int y=0; y<board.GetLength(1); ++y)
                {
                    if (board[x, y] == buttonField)
                        return new Point(x, y);
                }
            }
            return Point.Empty;
        }
    }
}