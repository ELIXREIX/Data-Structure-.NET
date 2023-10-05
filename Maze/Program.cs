using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[][] maze = new char[][]
            {
                "1E11111111111".ToCharArray(),
                "1011111111111".ToCharArray(),
                "10000000000S1".ToCharArray(),
                "1111111111111".ToCharArray()
            };

            int startRow = -1;
            int startCol = -1;

            for (int i = 0; i < maze.Length; i++)
            {
                for (int j = 0; j < maze[0].Length; j++)
                {
                    if (maze[i][j] == 's' || maze[i][j] == 'S')
                    {
                        startRow = i;
                        startCol = j;
                        break;
                    }
                }
            }

            if (startRow == -1 || startCol == -1)
            {
                Console.WriteLine("Start not found.");
                return;
            }

            bool found = FindPath(maze, startRow, startCol);

            if (found)
            {
                Console.WriteLine("Path found!");
            }
            else
            {
                Console.WriteLine("Cannot exit!");
            }
        }

        static bool FindPath(char[][] maze, int i, int j)
        {
            if (i < 0 || i >= maze.Length || j < 0 || j >= maze[0].Length || maze[i][j] == '1')
            {
                return false;
            }

            if (maze[i][j] == 'E')
            {
                return true;
            }

            maze[i][j] = '.';

            if (FindPath(maze, i - 1, j) || FindPath(maze, i + 1, j) || FindPath(maze, i, j - 1) || FindPath(maze, i, j + 1))
            {
                return true;
            }

            maze[i][j] = '0';
            return false;
        }
    }
}

