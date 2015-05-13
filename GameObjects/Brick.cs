using System;
using System.Collections.Generic;
using System.Drawing;

namespace GameObjects
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
            graphics.DrawImage(brickImage, theBrick);
        }
    }
}
