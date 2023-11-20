using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Collections;
using StackTest;

namespace Pacman
{
    public partial class Form1 : Form
    {
        private int[,] board;
        private int[] pacman;
        private int[] pacmanDir;
        private int[] dirBuffer;
        private LinkList<int> score;
        private int[,] ghosts;
        private int gameEnd;
        private Timer gameTimer;
        private bool[,] wallCells;
        private LinkedStack ghostMovements;


        public Form1()
        {
            InitializeGame();
            InitializeTimer();
            this.KeyDown += PacmanGame_KeyDown; // Handle key presses
            this.DoubleBuffered = true; // Enable double buffering
            this.ClientSize = new Size(1600, 1200);
            ghostMovements = new LinkedStack();

        }


        private void PacmanGame_KeyDown(object sender, KeyEventArgs e)
        {
            // Handle key presses
            if (e.KeyCode == Keys.Left)
            {
                SetDirection(0, -1);
            }
            else if (e.KeyCode == Keys.Right)
            {
                SetDirection(0, 1);
            }
            else if (e.KeyCode == Keys.Up)
            {
                SetDirection(-1, 0);
            }
            else if (e.KeyCode == Keys.Down)
            {
                SetDirection(1, 0);
            }
        }

        private void InitializeGame()
        {
            // Initialize your game variables here (board, pacman, ghosts, etc.)
            // ...

            // Example initialization:
            board = new int[,] {
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 0},
                {0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0},
                {0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0},
                {0, 0, 1, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 1, 0, 0, 1, 0, 0},
                {0, 0, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 0, 0},
                {0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0},
                {0, 0, 1, 0, 0, 1, 0, 1, 1, 1, 1, 1, 0, 1, 0, 0, 0, 0, 0},
                {0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0},
                {0, 0, 0, 0, 0, 1, 0, 1, 1, 1, 1, 1, 0, 1, 0, 0, 1, 0, 0},
                {0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 1, 0, 0, 1, 0, 0},
                {0, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 0},
                {0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0},
                {0, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 0, 0},
                {0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0},
                {0, 0, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 0, 0},
                {0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0},
                {0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            };
            pacman = new int[] { 17, 9 };
            pacmanDir = new int[] { 0, 1 };
            dirBuffer = new int[] { 0, 0 };
            score = new LinkList<int>();
            score.add(0);
            ghosts = new int[,] { { 7, 7, 0, 1 }, { 7, 11, 0, -1 }, { 11, 7, 0, -1 }, { 11, 11, 0, 1 } };
            gameEnd = 2;
            wallCells = new bool[19, 19];
            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 19; j++)
                {
                    wallCells[i, j] = (board[i, j] == 0); // true if it's a wall, false otherwise
                }
            }
            // Randomly generate cherries on the board
            Random rand = new Random();
            for (int i = 0; i < 5; i++) // Adjust the number of cherries as needed
            {
                int row = rand.Next(1, 18); // Avoid placing cherries on the borders
                int col = rand.Next(1, 18);
                while (board[row, col] != 1) // Keep generating until an empty cell is found
                {
                    row = rand.Next(1, 18);
                    col = rand.Next(1, 18);
                }
                board[row, col] = 3; // Represent cherries by the value 3
            }

        }

        private void InitializeTimer()
        {
            gameTimer = new Timer();
            gameTimer.Interval = 250; // Adjust this interval based on your needs
            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Start();
        }


        private void GameTimer_Tick(object sender, EventArgs e)
        {
            // Your game loop goes here
            // Handle user input, update game state, redraw the game board, etc.
            // ...

            // Example:
            MoveDirBufferToDir();
            Move();
            GhostsMove();

            // Check for game end conditions
            if (!score.isEmpty() && score.size() > 0 && score[0] == 160)
            {
                gameEnd = 0;
            }
            else
            {
                CheckEnd();
            }

            // If the game has ended, stop the timer
            if (gameEnd != 2)
            {
                gameTimer.Stop();
            }

            // Request a redraw of the form
            this.Invalidate();
        }

        private void Move()
        {
            int dir1 = pacman[0] + pacmanDir[0];
            int dir2 = pacman[1] + pacmanDir[1];

            if (board[dir1, dir2] != 0)
            {
                pacman[0] += pacmanDir[0];
                pacman[1] += pacmanDir[1];

                if (board[dir1, dir2] == 1) // Regular point
                {
                    UpdateScore(1); // Update the score
                    board[dir1, dir2] = 2; // Mark the path with 2 after collecting the point
                }
                else if (board[dir1, dir2] == 3) // Cherry
                {
                    UpdateScore(5); // Update the score for cherries
                    board[dir1, dir2] = 2; // Remove the cherry from the board
                }
            }
        }

        private void UpdateScore(int points)
        {
            // Initialize score if it's null
            if (score == null)
            {
                score = new LinkList<int>();
            }

            if (!score.isEmpty() && score.size() > 0)
            {
                // Update the score
                int currentScore = (int)score.get(0); // Cast to int
                score.set(0, currentScore + points);
            }
            else
            {
                score.add(points);
            }
        }


        private void MoveDirBufferToDir()
        {
            if ((dirBuffer[0] != 0 || dirBuffer[1] != 0) && (board[pacman[0] + dirBuffer[0], pacman[1] + dirBuffer[1]] != 0))
            {
                pacmanDir[0] = dirBuffer[0];
                pacmanDir[1] = dirBuffer[1];
                dirBuffer[0] = 0;
                dirBuffer[1] = 0;
            }
        }

        private void GhostsMove()
        {
            for (int i = 0; i < 4; i++)
            {
                int ghostRow = ghosts[i, 0];
                int ghostCol = ghosts[i, 1];

                // Generate all possible moves
                List<int[]> possibleMoves = new List<int[]>
        {
            new int[] { 0, -1 }, // Left
            new int[] { 0, 1 },  // Right
            new int[] { -1, 0 }, // Up
            new int[] { 1, 0 }   // Down
        };

                // Shuffle the possible moves to add randomness
                possibleMoves = possibleMoves.OrderBy(x => Guid.NewGuid()).ToList();

                foreach (var move in possibleMoves)
                {
                    int newRow = ghostRow + move[0];
                    int newCol = ghostCol + move[1];

                    if (IsMoveValid(newRow, newCol))
                    {
                        // Push ghost movements onto the stack
                        ghostMovements.push(new int[] { newRow, newCol });

                        ghosts[i, 0] = newRow;
                        ghosts[i, 1] = newCol;
                        ghosts[i, 2] = move[0];
                        ghosts[i, 3] = move[1];
                        break; // Exit the loop after successfully moving
                    }
                }
            }
        }


        private bool IsMoveValid(int row, int col)
        {
            return row >= 0 && row < 19 && col >= 0 && col < 19 && board[row, col] != 0;
        }

        public void SetDirection(int vertical, int horizontal)
        {
            dirBuffer[0] = vertical;
            dirBuffer[1] = horizontal;
        }

        private void CheckEnd()
        {
            for (int i = 0; i < 4; i++)
            {
                if ((ghosts[i, 0] == pacman[0]) && (ghosts[i, 1] == pacman[1]))
                {
                    gameEnd = 1;
                }
            }
        }

        private void DrawBoard(Graphics g)
        {
            // Draw the board
            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 19; j++)
                {
                    int x = j * 40; // Adjust the position based on your grid size
                    int y = i * 40; // Adjust the position based on your grid size

                    if (i == pacman[0] && j == pacman[1])
                    {
                        DrawCell(g, Brushes.Yellow, x, y);
                    }
                    else if (i == ghosts[0, 0] && j == ghosts[0, 1])
                    {
                        DrawCell(g, Brushes.Red, x, y);
                    }
                    else if (i == ghosts[1, 0] && j == ghosts[1, 1])
                    {
                        DrawCell(g, Brushes.Green, x, y);
                    }
                    else if (i == ghosts[2, 0] && j == ghosts[2, 1])
                    {
                        DrawCell(g, Brushes.Blue, x, y);
                    }
                    else if (i == ghosts[3, 0] && j == ghosts[3, 1])
                    {
                        DrawCell(g, Brushes.Magenta, x, y);
                    }
                    else
                    {
                        if (board[i, j] == 1) // Check if there is a point in the cell
                        {
                            DrawCell(g, Brushes.Cyan, x, y); // Draw the point
                        }
                        else if (board[i, j] == 3) // Check if there is a cherry in the cell
                        {
                            DrawCherry(g, x, y); // Draw the cherry
                        }
                        else if (board[i, j] == 2) // Check if the point has been collected
                        {
                            // Do not draw anything if the point has been collected
                        }
                        else
                        {
                            DrawCell(g, Brushes.Black, x, y);
                        }
                    }
                }
            }

            // Draw the score
            if (score != null && !score.isEmpty() && score.size() > 0)
            {
                g.DrawString($"Score: {score[0]}/160", Font, Brushes.White, new PointF(10, 10));
            }
            else
            {
                // Handle the case where the score is not initialized or is empty
                g.DrawString("Score: N/A", Font, Brushes.White, new PointF(10, 10));
            }
        }

        private void DrawCherry(Graphics g, int x, int y)
        {
            // Draw a cherry in the cell
            int cherrySize = 20; // Adjust the size of the cherry as needed
            int cherryX = x + (40 - cherrySize) / 2; // Adjust the position based on your grid size
            int cherryY = y + (40 - cherrySize) / 2; // Adjust the position based on your grid size
            g.FillEllipse(Brushes.Red, cherryX, cherryY, cherrySize, cherrySize);
        }

        private void DrawCell(Graphics g, Brush brush, int x, int y)
        {
            // Check if the cell is part of the wall
            if (brush != Brushes.Black)
            {
                // Draw a filled rectangle representing a cell
                g.FillRectangle(brush, x, y, 40, 40); // Adjust the size based on your grid size

                // Draw a point inside the cell if the board value is not 0
                if (board[y / 40, x / 40] != 0)
                {
                    int pointSize = 5; // Adjust the point size as needed
                    int pointX = x + (40 - pointSize) / 2; // Adjust the position based on your grid size
                    int pointY = y + (40 - pointSize) / 2; // Adjust the position based on your grid size
                    g.FillEllipse(Brushes.White, pointX, pointY, pointSize, pointSize);
                }
            }
            else
            {
                // Draw a filled rectangle representing a wall cell
                g.FillRectangle(Brushes.Black, x, y, 40, 40); // Adjust the size based on your grid size
            }
        }



        protected override void OnPaint(PaintEventArgs e)
        {
            // Handle the Paint event to redraw the game board
            base.OnPaint(e);
            DrawBoard(e.Graphics);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}