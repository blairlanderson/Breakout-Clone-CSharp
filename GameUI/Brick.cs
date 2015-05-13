using System;
using System.Collections.Generic;
using System.Drawing;

namespace BlairAnderson_PROG2200_Assignment03
{
    public class Brick
    {
        //properties
        public Rectangle theBrick;

        Image brickImage = Properties.Resources.red;

        //constructor
        public Brick(int xVal, int yVal)
        {
            //set brick dimensinos
            theBrick.Width = 50;
            theBrick.Height = 20;

            //set brick location
            theBrick.X = xVal;
            theBrick.Y = yVal;
        }

        //class methods
        public void Draw(Graphics graphics)
        {
            //using (SolidBrush brush = new SolidBrush(Color.Red))
            //{
            //    graphics.FillRectangle(brush, theBrick);
            //}

            graphics.DrawImage(brickImage, theBrick);
        }
    }
}
