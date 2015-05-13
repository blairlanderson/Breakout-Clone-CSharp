using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics.CodeAnalysis; 

using GameObjects;

namespace GameUI
{
    [ExcludeFromCodeCoverage]
    public partial class GameWindow : Form
    {
        //properties
        Paddle paddle;
        Ball ball;
        HashSet<Brick> bricks = new HashSet<Brick>();

        Brick brick;
        public Rectangle window;

        Font drawFont = new Font("Arial", 16);
        SolidBrush drawBrush = new SolidBrush(Color.White);

        int lives = 3;
        bool gameOver = false;
        bool win = false;
        bool died = false;
        bool caught = false;


        public GameWindow()
        {
            InitializeComponent();
            window = this.DisplayRectangle;
        }

        private void GameWindow_Load(object sender, EventArgs e)
        {
            paddle = new Paddle(this.DisplayRectangle);
            ball = new Ball(this.DisplayRectangle);

            LoadBricks();
        }

        private void GameWindow_Paint(object sender, PaintEventArgs e)
        {
            paddle.Draw(e.Graphics);
            ball.Draw(e.Graphics);
            
            foreach (Brick brick in bricks)
            {
                brick.Draw(e.Graphics);    
            }
            Font drawFont = new Font("Arial", 16);
            SolidBrush drawBrush = new SolidBrush(Color.White);

            e.Graphics.DrawString(String.Format("Lives: {0}", lives.ToString()), drawFont, drawBrush, 0, window.Bottom -25);

            
            if (gameOver)
            {
                e.Graphics.DrawString("Game Over",
                    drawFont,
                    drawBrush,
                    this.DisplayRectangle.Width / 2,
                    this.DisplayRectangle.Height / 2);
            }
            if(win)
            {
                e.Graphics.DrawString("You Win",
                    drawFont,
                    drawBrush,
                    this.DisplayRectangle.Width / 2,
                    this.DisplayRectangle.Height / 2);
                
                Reset();
            }

        }

        private void GameWindow_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData.ToString())
            {
                case "Left":
                    {

                        paddle.Move(Paddle.Direction.Left);
                        if (caught)
                        {
                            if (ball.theBall.X <= (window.Left))
                                ball.theBall.X = 0;
                            else
                                ball.theBall.X -= 50;
                        }
                        break;
                    }
                case "Right":
                    {
                        paddle.Move(Paddle.Direction.Right);
                        if (caught)
                        {
                            if (ball.theBall.X >= (window.Right - 15))
                                ball.theBall.X = window.Right - 15;
                            else
                                ball.theBall.X += 50;
                        }
                        break;
                    }
                case "Space":
                    {
                        if (!gameOver && !win)
                        {
                            animationTimer.Start();
                            died = false;
                        }
                        else
                        {
                            animationTimer.Stop();
                            Reset();

                            lives = 3;
                            gameOver = false;
                            win = false;
                            died = false;
                            Invalidate();
                        }
                            break;
                    }
                case "C":
                    {
                        if (caught)
                        {
                            ball.xVel = 15;
                            ball.yVel = -15;
                            caught = false;
                        }

                        if(ball.theBall.IntersectsWith(paddle.catchZone))
                        {
                            if(ball.xVel > 0 && ball.yVel > 0)
                            {
                                ball.xVel = 0;
                                ball.yVel = 0;
                                caught = true;
                            }                            
                        }
                        break;
                    }
            }
            Invalidate();
        }

        private void animationTimer_Tick(object sender, EventArgs e)
        {
            ball.Move();

            //check for bricks
            if(bricks.Count <= 0)
            {
                win = true;
            }
            
            //check if ball collides with the walls
            if (ball.theBall.Right >= this.DisplayRectangle.Right 
                || ball.theBall.Left <= this.DisplayRectangle.Left)
            {
                ball.xVel *= -1;
            }
            if(ball.theBall.Top <= this.DisplayRectangle.Top)
            {
                ball.yVel *= -1;
            }

            //check if ball collides with paddle
            if (ball.theBall.IntersectsWith(paddle.thePaddle))
            {
                ball.yVel *= -1;
            }

            //check if ball hits a brick
            foreach (Brick brick in bricks)
            {
                if(HitsBrick(brick))
                {
                    ball.yVel *= -1;
                    bricks.Remove(brick);
                    break;
                }
            }

            //check for miss
            if(ball.theBall.Top >= window.Bottom)
            {
                lives--;
                animationTimer.Stop();
                if (lives > 0)
                {
                    died = true;
                    Reset();
                }
                else
                    gameOver = true;
            }
            Invalidate();
        }

        private void LoadBricks()
        {
            int startX = window.Left + 25;
            int width = 50;//brick.theBrick.Width;
            int height = 20; // 
            int endX = (window.Right - width) - 20;
            int startY = window.Top + 20;
            int linesOfBricks = 5;
            int endY = startY + ((height + 2) * linesOfBricks - 1);

            //fill window with bricks
            while (startY <= endY)
            {
                while (startX <= endX)
                {
                    bricks.Add(new Brick(startX, startY));
                    startX += (width + 3);
                }
                startY += (height + 5);
                startX = window.Left + 25;
            }
        }//end loadBricks

        private bool HitsBrick(Brick brick)
        {
            return ball.theBall.IntersectsWith(brick.theBrick);
        }

        private void Reset()
        {
            animationTimer.Stop();
            if (gameOver || win)
            {
                LoadBricks();
            }

            ball = new Ball(this.DisplayRectangle);
            paddle = new Paddle(this.DisplayRectangle);

        }
        
    }//end class
}//end namespace
