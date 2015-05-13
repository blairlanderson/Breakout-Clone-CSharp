using System;
using System.Collections.Generic;
using System.Drawing;

namespace GameObjects
{
    public class Paddle
    {
        //properties
        public Rectangle thePaddle;
        public Rectangle catchZone;
        public int leftSide, rightSide;

        public static readonly int paddleHeight = 15;
        public static readonly int moveAmount = 50;
        public enum Direction { Left, Right }

        Image paddleImage = Properties.Resources.paddle;

        //test constructor

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

            //set catchable area
            catchZone.Height = thePaddle.Height + 20;
            catchZone.Width = thePaddle.Width + 10;

            //align catchzone
            AlignCatchZone();
        }

        public void AlignCatchZone()
        {
            catchZone.X = thePaddle.X - 5;
            catchZone.Y = thePaddle.Y - 20;
        }

        //class methods
        public void Move(Direction direction)
        {
            //move based on input from user
            switch (direction)
            {
                case Direction.Left:
                    {
                        //make sure the paddle doesn't move off the screen
                        if (thePaddle.X < thePaddle.Width)
                        {
                            thePaddle.X = 0;
                            AlignCatchZone();
                        }
                        else
                        {
                            thePaddle.X -= moveAmount;
                            AlignCatchZone();
                        }
                        break;
                    }
                case Direction.Right:
                    {
                        //make sure paddle doesn't move off the screen
                        if ((thePaddle.X + thePaddle.Width + moveAmount) >= rightSide)//thePaddle.X >= rightSide - thePaddle.Width)
                        {
                            thePaddle.X = rightSide - thePaddle.Width;
                            AlignCatchZone();
                        }
                        else
                        {
                            thePaddle.X += moveAmount;
                            AlignCatchZone();
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
