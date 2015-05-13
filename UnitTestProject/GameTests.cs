using System;
using System.Drawing;
using System.Diagnostics.CodeAnalysis; 
using Microsoft.VisualStudio.TestTools.UnitTesting;

using GameUI;
using GameObjects;

namespace UnitTestProject
{

    [TestClass]
    [ExcludeFromCodeCoverage]
    public class GameTests
    {
        static GameWindow gw = new GameWindow();
        Rectangle gameScreen = gw.window;
        
        [TestMethod]
        public void PaddleCreationTest()
        {
            Paddle paddle = new Paddle(gameScreen);

            Assert.AreEqual(100, paddle.thePaddle.Width);
            Assert.AreEqual(15, paddle.thePaddle.Height);

            int startX, startY;
            startX = (gameScreen.Width / 2) - (paddle.thePaddle.Width / 2);
            startY = gameScreen.Bottom - 60;

            Assert.AreEqual(startX, paddle.thePaddle.X);
            Assert.AreEqual(startY, paddle.thePaddle.Y);
        }

        [TestMethod]
        public void PaddleMoveTests()
        {
            Paddle paddle = new Paddle(gameScreen);

            int xPos = paddle.thePaddle.X;
            paddle.Move(Paddle.Direction.Right);

            int newX = paddle.thePaddle.X;
            Assert.AreEqual(xPos + 50, newX);

            xPos = paddle.thePaddle.X;
            paddle.Move(Paddle.Direction.Left);

            newX = paddle.thePaddle.X;
            Assert.AreEqual(xPos - 50, newX);
        }

        [TestMethod]
        public void AlignCatchAreaTest()
        {
            Paddle paddle = new Paddle(gameScreen);

            paddle.AlignCatchZone();
            Assert.AreEqual((paddle.thePaddle.X - 5),paddle.catchZone.X);
            Assert.AreEqual((paddle.thePaddle.Y - 20), paddle.catchZone.Y);
        }

        [TestMethod]
        public void BallCreationTest()
        {
            Ball ball = new Ball(gameScreen);
            int startX, startY;
            startX = (gameScreen.Width / 2) - (ball.theBall.Width / 2);
            startY = (gameScreen.Bottom - 65) - ball.theBall.Height;
            Assert.AreEqual(15, ball.xVel);
            Assert.AreEqual(-15, ball.yVel);
            Assert.AreEqual(startX, ball.theBall.X);
            Assert.AreEqual(startY, ball.theBall.Y);
            Assert.AreEqual(10, ball.theBall.Height);
            Assert.AreEqual(10, ball.theBall.Width);


        }
        
        [TestMethod]
        public void BallMoveTest()
        {
            Ball ball = new Ball(gameScreen);

            int xPos, yPos, newX, newY;
            xPos = ball.theBall.X;
            yPos = ball.theBall.Y;
            ball.Move();

            newX= ball.theBall.X;
            newY= ball.theBall.Y;

            Assert.AreEqual(xPos += ball.xVel, newX);
            Assert.AreEqual(yPos += ball.yVel, newY);
        }

        [TestMethod]
        public void BrickCreationTest()
        {
            Brick brick = new Brick(20, 30);

            Assert.AreEqual(20, brick.theBrick.X);
            Assert.AreEqual(30, brick.theBrick.Y);

            Assert.AreEqual(50, brick.theBrick.Width);
            Assert.AreEqual(20, brick.theBrick.Height);
        }
    }
}
