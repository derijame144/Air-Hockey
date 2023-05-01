using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Air_Hockey
{
    public partial class Form1 : Form
    {
        Pen bluePen = new Pen(Color.Blue, 2);
        SolidBrush yellowBrush = new SolidBrush(Color.Yellow);
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush purpleBrush = new SolidBrush(Color.Purple);

        Rectangle goal1 = new Rectangle(95, 0, 146, 6);
        Rectangle goal2 = new Rectangle(95, 455, 146, 6);
        Rectangle puck = new Rectangle(163, 85, 15, 15);

        // sets up player1 
        Rectangle player1 = new Rectangle(155, 37, 30, 30);
        Rectangle player1Top = new Rectangle(155, 37, 30, 2);
        Rectangle player1Bottom = new Rectangle(155, 65, 30, 2);
        Rectangle player1Left = new Rectangle(155, 37, 2, 30);
        Rectangle player1Right = new Rectangle(183, 37, 2, 30);

        Rectangle player2 = new Rectangle(155, 400, 30, 30);
        Rectangle player2Top = new Rectangle(155, 400, 30, 2);
        Rectangle player2Bottom = new Rectangle(155, 428, 30, 2);
        Rectangle player2Left = new Rectangle(155, 400, 2, 30);
        Rectangle player2Right = new Rectangle(183, 400, 2, 30);

        //sets up speeds of objects 
        int puckXSpeed = 0;
        int puckYSpeed = 0;
        int playerSpeed = 6;

        //timer
        int counter = 0;


        //score
        int p1Score = 0;
        int p2Score = 0;

        //bools for movement 
        bool wDown = false;
        bool sDown = false;
        bool dDown = false;
        bool aDown = false;
        bool upArrowDown = false;
        bool downArrowDown = false;
        bool rightArrowDown = false;
        bool leftArrowDown = false;

        bool playing = true;

        public Form1()
        {
            InitializeComponent();


        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    break;
                case Keys.A:
                    aDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
            }
        }


        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;
                case Keys.A:
                    aDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
            }
        }

        private void resetPlayers(int puckY, int goal)
        {

            if (goal == 1)
            {
                p2Score += 1;
            }
            else
            {
                p1Score += 1;
            }

            puckXSpeed = 0;
            puckYSpeed = 0;

            player1.Location = new Point(155, 37);
            player1Bottom.Location = new Point(155, 65);
            player1Top.Location = new Point(155, 37);
            player1Left.Location = new Point(155, 37);
            player1Right.Location = new Point(183, 37);

            player2.Location = new Point(155, 400);
            player2Bottom.Location = new Point(155, 426);
            player2Top.Location = new Point(155, 400);
            player2Left.Location = new Point(155, 400);
            player2Right.Location = new Point(183, 400);

            puck.Location = new Point(163, puckY);

        }

        private void gameEnd(string winner)
        {
            playing = false;
            resetButton.Visible = true;
            resetButton.Enabled = true;
            winLabel.Text = $" Player {winner} \n Wins!";
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (playing == true)
            {

                if (puckXSpeed > 25)
                {
                    puckXSpeed = 25;
                }

                if (puckYSpeed > 25)
                {
                    puckYSpeed = 25;
                }

                puck.X += puckXSpeed;
                puck.Y += puckYSpeed;

                counter++;

                if (counter == 10)
                {
                    counter = 0;
                    if (puckXSpeed > 0)
                    {
                        puckXSpeed -= 1;
                    }
                    else if (puckXSpeed < 0)
                    {
                        puckXSpeed += 1;
                    }

                    if (puckYSpeed > 0)
                    {
                        puckYSpeed -= 1;
                    }
                    else if (puckYSpeed < 0)
                    {
                        puckYSpeed += 1;
                    }
                }

                //puck collion with wall 
                if (puck.X < 5)
                {
                    puck.X = 5;
                    puckXSpeed *= -1;
                }

                if (puck.X - puck.Width > 305)
                {
                    puck.X = 305;
                    puckXSpeed *= -1;
                }

                if (puck.Y < 5)
                {
                    puck.Y = 5;
                    puckYSpeed *= -1;
                }

                if (puck.Y - puck.Height > 430)
                {
                    puck.Y = 433;
                    puckYSpeed *= -1;
                }

                //move player 1 
                if (wDown == true && player1.Y > 15)
                {
                    player1.Y -= playerSpeed;
                    player1Top.Y -= playerSpeed;
                    player1Bottom.Y -= playerSpeed;
                    player1Left.Y -= playerSpeed;
                    player1Right.Y -= playerSpeed;
                }

                if (sDown == true && player1.Y < 223 - player1.Height)
                {
                    player1.Y += playerSpeed;
                    player1Top.Y += playerSpeed;
                    player1Bottom.Y += playerSpeed;
                    player1Left.Y += playerSpeed;
                    player1Right.Y += playerSpeed;
                }

                if (dDown == true && player1.X < 325 - player1.Width)
                {
                    player1.X += playerSpeed;
                    player1Top.X += playerSpeed;
                    player1Bottom.X += playerSpeed;
                    player1Left.X += playerSpeed;
                    player1Right.X += playerSpeed;
                }

                if (aDown == true && player1.X > 15)
                {
                    player1.X -= playerSpeed;
                    player1Top.X -= playerSpeed;
                    player1Bottom.X -= playerSpeed;
                    player1Left.X -= playerSpeed;
                    player1Right.X -= playerSpeed;
                }

                //move player 2 
                if (upArrowDown == true && player2.Y > 233)
                {
                    player2.Y -= playerSpeed;
                    player2Top.Y -= playerSpeed;
                    player2Bottom.Y -= playerSpeed;
                    player2Left.Y -= playerSpeed;
                    player2Right.Y -= playerSpeed;
                }

                if (downArrowDown == true && player2.Y + player2.Height < 450)
                {
                    player2.Y += playerSpeed;
                    player2Top.Y += playerSpeed;
                    player2Bottom.Y += playerSpeed;
                    player2Left.Y += playerSpeed;
                    player2Right.Y += playerSpeed;
                }

                if (rightArrowDown == true && player2.X < 325 - player2.Width)
                {
                    player2.X += playerSpeed;
                    player2Top.X += playerSpeed;
                    player2Bottom.X += playerSpeed;
                    player2Left.X += playerSpeed;
                    player2Right.X += playerSpeed;

                }

                if (leftArrowDown == true && player2.X > 15)
                {
                    player2.X -= playerSpeed;
                    player2Top.X -= playerSpeed;
                    player2Bottom.X -= playerSpeed;
                    player2Left.X -= playerSpeed;
                    player2Right.X -= playerSpeed;
                }

                // player 1 collision
                if (puck.IntersectsWith(player1Top))
                {
                    puck.Y = player1.Y - puck.Width;
                    puckYSpeed *= -1;
                    puckYSpeed -= 7;

                    if (aDown == true)
                    {
                        puckXSpeed -= 7;
                    }

                    if (dDown == true)
                    {
                        puckXSpeed += 7;
                    }
                }

                if (puck.IntersectsWith(player1Bottom))
                {
                    puck.Y = player1.Y + player1.Height;
                    puckYSpeed *= -1;
                    puckYSpeed += 7;

                    if (aDown == true)
                    {
                        puckXSpeed -= 7;
                    }

                    if (dDown == true)
                    {
                        puckXSpeed += 7;
                    }
                }

                if (puck.IntersectsWith(player1Left))
                {
                    puck.X = player1.X - puck.Width;
                    puckXSpeed *= -1;
                    puckXSpeed -= 7;

                    if (wDown == true)
                    {
                        puckYSpeed -= 7;
                    }

                    if (sDown == true)
                    {
                        puckYSpeed += 7;
                    }
                }

                if (puck.IntersectsWith(player1Right))
                {
                    puck.X = player1.X + player1.Width;
                    puckXSpeed *= -1;
                    puckXSpeed += 7;

                    if (wDown == true)
                    {
                        puckYSpeed -= 7;
                    }

                    if (sDown == true)
                    {
                        puckYSpeed += 7;
                    }
                }

                //player 2 collision 
                if (puck.IntersectsWith(player2Top))
                {
                    puck.Y = player2.Y - puck.Width;
                    puckYSpeed *= -1;
                    puckYSpeed -= 7;

                    if (leftArrowDown == true)
                    {
                        puckXSpeed -= 7;
                    }

                    if (rightArrowDown == true)
                    {
                        puckXSpeed += 7;
                    }
                }

                if (puck.IntersectsWith(player2Bottom))
                {
                    puck.Y = player2.Y + player2.Height;
                    puckYSpeed *= -1;
                    puckYSpeed += 7;

                    if (leftArrowDown == true)
                    {
                        puckXSpeed -= 7;
                    }

                    if (rightArrowDown == true)
                    {
                        puckXSpeed += 7;
                    }
                }

                if (puck.IntersectsWith(player2Left))
                {
                    puck.X = player2.X - puck.Width;
                    puckXSpeed *= -1;
                    puckXSpeed -= 7;

                    if (upArrowDown == true)
                    {
                        puckYSpeed -= 7;
                    }

                    if (downArrowDown == true)
                    {
                        puckYSpeed += 7;
                    }
                }

                if (puck.IntersectsWith(player2Right))
                {
                    puck.X = player2.X + player2.Width;
                    puckXSpeed *= -1;
                    puckXSpeed += 7;

                    if (upArrowDown == true)
                    {
                        puckYSpeed -= 7;
                    }

                    if (downArrowDown == true)
                    {
                        puckYSpeed += 7;
                    }
                }

                if (puck.IntersectsWith(goal1))
                {
                    resetPlayers(85, 1);
                }

                if (puck.IntersectsWith(goal2))
                {
                    resetPlayers(352, 2);
                }

                p1ScoreLabel.Text = $"{p1Score}";
                p2ScoreLabel.Text = $"{p2Score}";

                if (p1Score == 3)
                {
                    gameEnd("One");
                }

                else if (p2Score == 3)
                {
                    gameEnd("Two");
                }
            }

            Refresh();

        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(bluePen, 5, 5, 327, 454);
            e.Graphics.DrawLine(bluePen, 5, 227, 333, 227);
            e.Graphics.FillRectangle(yellowBrush, goal1);
            e.Graphics.FillRectangle(yellowBrush, goal2);
            e.Graphics.FillRectangle(whiteBrush, puck);
            e.Graphics.FillRectangle(redBrush, player1);
            e.Graphics.FillRectangle(purpleBrush, player2);

        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            playing = true;
            resetPlayers(85, 1);
            p1Score = 0;
            p2Score = 0;
            winLabel.Text = "";
            resetButton.Visible = false;
            resetButton.Enabled = false;
        }
    }
}
