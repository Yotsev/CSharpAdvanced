using System;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int territorySize = int.Parse(Console.ReadLine());

            char[][] territory = new char[territorySize][];
            ReadTerritory(territory);

            (int row, int col) snakePositon = GetSnakePositon(territory);
            (int row, int col)[] burrowPositon = GetBurrowsPostion(territory);
            bool isOut = false;
            int neededFood = 10;
            int foodEaten = 0;
           
            while (true)
            {
                string moveCommands = Console.ReadLine();

                (int row, int col) targetPositon = GetTargetPositon(moveCommands, snakePositon, territory);
                IsInTerritory(targetPositon, territory);

                if (IsInTerritory(targetPositon, territory))
                {
                    if (territory[targetPositon.row][targetPositon.col] == '*')
                    {
                        foodEaten++;
                        territory[targetPositon.row][targetPositon.col] = 'S';
                        territory[snakePositon.row][snakePositon.col] = '.';
                        snakePositon = targetPositon;
                    }
                    else if (territory[targetPositon.row][targetPositon.col] == 'B')
                    {
                        territory[targetPositon.row][targetPositon.col] = '.';
                        if (targetPositon.row == burrowPositon[0].row)
                        {
                            targetPositon.row = burrowPositon[1].row;
                            targetPositon.col = burrowPositon[1].col;
                        }
                        else
                        {
                            targetPositon.row = burrowPositon[0].row;
                            targetPositon.col = burrowPositon[0].col;
                        }

                        territory[snakePositon.row][snakePositon.col] = '.';
                        territory[targetPositon.row][targetPositon.col] = 'S';
                        snakePositon = targetPositon;
                    }
                    else if (territory[targetPositon.row][targetPositon.col] == '-')
                    {
                        territory[targetPositon.row][targetPositon.col] = 'S';
                        territory[snakePositon.row][snakePositon.col] = '.';
                        snakePositon = targetPositon;
                    }
                }
                else
                {
                    isOut = true;
                    territory[snakePositon.row][snakePositon.col] = '.';
                    break;
                }

                if (foodEaten == neededFood)
                {
                    break;
                }
            }

            if (isOut)
            {
                Console.WriteLine("Game over!");
            }
            else if (foodEaten == neededFood)
            {
                Console.WriteLine("You won! You fed the snake.");
            }

            Console.WriteLine($"Food eaten: {foodEaten}");

            PrintTerritory(territory);
        }

        private static bool IsInTerritory((int row, int col) targetPositon, char[][] territory)
        {
            if (targetPositon.row >= 0 
                && targetPositon.row < territory.Length 
                && targetPositon.col >= 0 
                && targetPositon.col < territory[targetPositon.row].Length)
            {
                return true;
            }

            return false;
        }

        private static (int row, int col)[] GetBurrowsPostion(char[][] territory)
        {
            (int, int)[] positon = new (int, int)[2];

            bool isFirst = true;

            for (int row = 0; row < territory.Length; row++)
            {
                for (int col = 0; col < territory[row].Length; col++)
                {
                    if (territory[row][col] == 'B' && isFirst)
                    {
                        positon[0].Item1 = row;
                        positon[0].Item2 = col;
                        isFirst = false;
                    }

                    if (territory[row][col] == 'B')
                    {
                        positon[1].Item1 = row;
                        positon[1].Item2 = col;
                    }
                }
            }

            return positon;
        }

        private static (int row, int col) GetTargetPositon(string moveCommands, (int row, int col) snakePositon, char[][] territory)
        {
            (int, int) positon = snakePositon;

            if (moveCommands == "up")
            {
                positon.Item1--;
            }
            else if (moveCommands == "down")
            {
                positon.Item1++;
            }
            else if (moveCommands == "left")
            {
                positon.Item2--;
            }
            else if (moveCommands == "right")
            {
                positon.Item2++;
            }

            return positon;
        }

        private static (int row, int col) GetSnakePositon(char[][] territory)
        {
            (int, int) positon = (0, 0);
            for (int row = 0; row < territory.Length; row++)
            {
                for (int col = 0; col < territory[row].Length; col++)
                {
                    if (territory[row][col] == 'S')
                    {
                        positon.Item1 = row;
                        positon.Item2 = col;
                    }
                }
            }

            return positon;
        }

        private static void PrintTerritory(char[][] territory)
        {
            for (int row = 0; row < territory.Length; row++)
            {
                Console.WriteLine(string.Join("", territory[row]));
            }
        }

        private static void ReadTerritory(char[][] territory)
        {
            for (int row = 0; row < territory.Length; row++)
            {
                char[] rowInfo = Console.ReadLine().ToCharArray();

                territory[row] = rowInfo;
            }
        }
    }
}
