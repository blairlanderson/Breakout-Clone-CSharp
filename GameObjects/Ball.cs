using System;
using System.Collections.Generic;
using System.Drawing;

namespace GameObjects
{
    public class Ball
    {
        //properties
        public Rectangle theBall;
        public int xVel { get; set; }
        public int yVel { get; set; }

        Image ballImage = Properties.Resources.ball;


        //constructor
        public Ball(Rectangle gameScreen)
        {
            //set ball dimensions
            theBall.Height = 10;
            theBall.Width = 10;

            //set ball location
            theBall.X = (gameScreen.Width / 2) - (theBall.Width / 2);
            theBall.Y = (gameScreen.Bottom - 65) - theBall.Height;

            //set ball initial
            xVel = 15;
            yVel = -15;

        }

        //class methods
        public void Move()
        {
            theBall.X += xVel;
            theBall.Y += yVel;
        }

        public void Draw(Graphics graphics)
        {
            //using (SolidBrush brush = new SolidBrush(Color.White))
            //{
            //    graphics.FillRectangle(brush, theBall);
            //}
            graphics.DrawImage(ballImage, theBall);
        }
    }
}
