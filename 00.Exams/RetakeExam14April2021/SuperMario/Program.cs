using System;

namespace SuperMario
{
    class Program
    {
        static void Main(string[] args)
        {
            int lives = int.Parse(Console.ReadLine());
            int numberOfRows = int.Parse(Console.ReadLine());

            char[][] maze = new char[numberOfRows][];

            for (int row = 0; row < maze.Length; row++)
            {
                char[] rowInfo = Console.ReadLine().ToCharArray();
                maze[row] = rowInfo;
            }

            (int row, int col) marioPositon = GetMarioPositon(maze);

            bool isSaved = false;
            bool isDead = false;

            while (true)
            {
                if (isSaved || isDead)
                {
                    break;
                }

                string command = Console.ReadLine();

                string[] commandArgs = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string direction = commandArgs[0];
                int row = int.Parse(commandArgs[1]);
                int col = int.Parse(commandArgs[2]);

                lives--;

                maze[row][col] = 'B';

                (int targetRow, int targetCol) targetPositon = GetTargetPositon(direction, marioPositon);

                if (targetPositon.targetRow < 0 || targetPositon.targetRow >= maze.Length
                    || targetPositon.targetCol < 0 || targetPositon.targetCol >= maze[targetPositon.targetRow].Length)
                {
                    if (lives <= 0)
                    {
                        maze[marioPositon.row][marioPositon.col] = 'X';
                        isDead = true;
                        break;
                    }

                    continue;
                }

                if (maze[targetPositon.targetRow][targetPositon.targetCol] == 'B')
                {
                    lives -= 2;

                    if (lives <= 0)
                    {
                        maze[targetPositon.targetRow][targetPositon.targetCol] = 'X';
                        maze[marioPositon.row][marioPositon.col] = '-';
                        marioPositon = targetPositon;
                        isDead = true;
                        break;
                    }

                    maze[targetPositon.targetRow][targetPositon.targetCol] = 'M';
                    maze[marioPositon.row][marioPositon.col] = '-';
                    marioPositon = targetPositon;
                }
                else if (maze[targetPositon.targetRow][targetPositon.targetCol] == 'P')
                {
                    maze[targetPositon.targetRow][targetPositon.targetCol] = '-';
                    maze[marioPositon.row][marioPositon.col] = '-';
                    isSaved = true;
                }
                else if (maze[targetPositon.targetRow][targetPositon.targetCol] == '-')
                {
                    maze[targetPositon.targetRow][targetPositon.targetCol] = 'M';
                    maze[marioPositon.row][marioPositon.col] = '-';
                    marioPositon = targetPositon;
                }

                if (lives <= 0)
                {
                    maze[marioPositon.row][marioPositon.col] = 'X';
                    marioPositon = targetPositon;
                    isDead = true;
                    break;
                }
            }

            if (isDead)
            {
                Console.WriteLine($"Mario died at {marioPositon.row};{marioPositon.col}.");
            }
            else
            {
                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
            }

            PrintMaze(maze);
        }

        private static (int targetRow, int targetCol) GetTargetPositon(string direction, (int row, int col) marioPositon)
        {
            (int, int) target = (marioPositon.row, marioPositon.col);

            if (direction == "W")
            {
                target.Item1--;
            }
            else if (direction == "S")
            {
                target.Item1++;
            }
            else if (direction == "A")
            {
                target.Item2--;
            }
            else if (direction == "D")
            {
                target.Item2++;
            }

            return target;
        }

        private static (int row, int col) GetMarioPositon(char[][] maze)
        {
            (int, int) postion = (0, 0);

            for (int row = 0; row < maze.Length; row++)
            {
                for (int col = 0; col < maze[row].Length; col++)
                {
                    if (maze[row][col] == 'M')
                    {
                        postion.Item1 = row;
                        postion.Item2 = col;
                    }
                }
            }

            return postion;
        }

        static void PrintMaze(char[][] maze)
        {
            for (int row = 0; row < maze.Length; row++)
            {
                Console.WriteLine(string.Join("", maze[row]));
            }
            Console.WriteLine();
        }
    }
}
