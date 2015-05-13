using System;
using System.Collections.Generic;
using System.Drawing;


namespace BlairAnderson_PROG2200_Assignment03
{
    
    public class Paddle
    {
        //properties
        public Rectangle thePaddle;
        private int leftSide, rightSide;

        private static readonly int paddleHeight = 15;
        private static readonly int moveAmount = 50;
        public enum Direction { Left, Right }

        Image paddleImage = Properties.Resources.paddle;


        //constructor
        public Paddle(Rectangle gameScreen)
        {
            
            //set dimension for paddle
            thePaddle.Width = 100;
            thePaddle.Height = paddleHeight; 

            //set starting location in the center near the bottom
            thePaddle.X = (gameScreen.Width / 2) - (thePaddle.Width / 2);
            thePaddle.Y = gameScreen.Bottom - 60;

            //set world bounds
            this.leftSide = gameScreen.Left;
            this.rightSide = gameScreen.Right;
        }

        //class methods
        public void Move(Direction direction)
        {
            //move based on input from user
            switch (direction)
            {
                case Direction.Left:
                    {
                        if (thePaddle.X < thePaddle.Width)
                        {
                            thePaddle.X = 0;
                        }
                        else
                        {
                            thePaddle.X -= moveAmount;
                        }
                        break;
                    }
                case Direction.Right:
                    {
                        if ((thePaddle.X + thePaddle.Width + moveAmount) >= rightSide)//thePaddle.X >= rightSide - thePaddle.Width)
                        {
                            thePaddle.X = rightSide - thePaddle.Width;
                        }
                        else
                        {
                            thePaddle.X += moveAmount;
                        }
                        break;
                    }
            }

        }

        public void Draw(Graphics graphics)
        {
            /*using (SolidBrush brush = new SolidBrush(Color.White))
            {
                graphics.FillRectangle(brush, thePaddle);
            }*/
            graphics.DrawImage(paddleImage, thePaddle);
        }

    }
}
