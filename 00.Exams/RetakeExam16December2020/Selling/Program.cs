using System;

namespace Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int bakerySize = int.Parse(Console.ReadLine());

            char[,] bakery = new char[bakerySize, bakerySize];
            ReadMatix(bakery);

            bool isOut = false;
            int rentMoney = 50;
            int money = 0;

            (int row, int col) yourPositon = GetPosition(bakery);
            (int pilarRow, int pilarCol)[] pillers = GetpillersPositon(bakery);

            while (true)
            {
                string diraction = Console.ReadLine();

                (int targetRow, int targetCol) targetPositon = GetTargetPostion(bakery, yourPositon, diraction);

                if (isInside(bakery, targetPositon.targetRow, targetPositon.targetCol))
                {
                    if (bakery[targetPositon.targetRow, targetPositon.targetCol] == 'O')
                    {
                        if (targetPositon.targetRow == pillers[0].pilarRow)
                        {
                            targetPositon.targetRow = pillers[1].pilarRow;
                            targetPositon.targetCol = pillers[1].pilarCol;
                        }
                        else
                        {
                            targetPositon.targetRow = pillers[0].pilarRow;
                            targetPositon.targetCol = pillers[0].pilarCol;
                        }

                        bakery[pillers[0].pilarRow, pillers[0].pilarCol] = '-';
                        bakery[pillers[1].pilarRow, pillers[1].pilarCol] = '-';
                        bakery[yourPositon.row, yourPositon.col] = '-';
                        bakery[targetPositon.targetRow, targetPositon.targetCol] = 'S';
                        yourPositon = targetPositon;
                    }
                    else if (char.IsDigit(bakery[targetPositon.targetRow, targetPositon.targetCol]))
                    {
                        money += int.Parse(bakery[targetPositon.targetRow, targetPositon.targetCol].ToString());
                        bakery[yourPositon.row, yourPositon.col] = '-';
                        bakery[targetPositon.targetRow, targetPositon.targetCol] = 'S';
                        yourPositon = targetPositon;
                    }
                    else
                    {
                        bakery[yourPositon.row, yourPositon.col] = '-';
                        bakery[targetPositon.targetRow, targetPositon.targetCol] = 'S';
                        yourPositon = targetPositon;
                    }
                }
                else
                {
                    isOut = true;
                    bakery[yourPositon.row, yourPositon.col] = '-';
                    break;
                }

                if (money >= 50)
                {
                    break;
                }
            }

            if (money >= rentMoney)
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }
            else if (isOut)
            {
                Console.WriteLine("Bad news, you are out of the bakery.");
            }

            Console.WriteLine($"Money: {money}");

            PrintBaker(bakery);
        }

        private static (int pilarRow, int pilarCol)[] GetpillersPositon(char[,] bakery)
        {
            (int row, int col)[] positons = new (int, int)[2];

            bool isFirst = true;

            for (int row = 0; row < bakery.GetLength(0); row++)
            {
                for (int col = 0; col < bakery.GetLength(1); col++)
                {
                    if (isFirst && bakery[row, col] == 'O')
                    {
                        positons[0].row = row;
                        positons[0].col = col;

                        isFirst = false;
                        continue;
                    }

                    if (bakery[row, col] == 'O')
                    {
                        positons[1].row = row;
                        positons[1].col = col;
                    }
                }
            }

            return positons;
        }
        private static (int targetRow, int targetCol) GetTargetPostion(char[,] bakery, (int, int) playerPositon, string direction)
        {
            (int row, int col) positon = playerPositon;

            if (direction == "up")
            {
                positon.row--;
            }
            else if (direction == "down")
            {
                positon.row++;
            }
            else if (direction == "left")
            {
                positon.col--;
            }
            else if (direction == "right")
            {
                positon.col++;
            }

            return positon;
        }
        private static bool isInside(char[,] bakery, int row, int col)
        {
            if (row >= 0 && row < bakery.GetLength(0) && col >= 0 && col < bakery.GetLength(1))
            {
                return true;
            }

            return false;
        }
        private static (int row, int col) GetPosition(char[,] bakery)
        {
            (int row, int col) positon = (0, 0);

            for (int row = 0; row < bakery.GetLength(0); row++)
            {
                for (int col = 0; col < bakery.GetLength(1); col++)
                {
                    if (bakery[row, col] == 'S')
                    {
                        positon.row = row;
                        positon.col = col;
                    }
                }
            }

            return positon;
        }
        private static void ReadMatix(char[,] bakery)
        {
            for (int row = 0; row < bakery.GetLength(0); row++)
            {
                char[] rowInfo = Console.ReadLine().ToCharArray();

                for (int col = 0; col < bakery.GetLength(1); col++)
                {
                    bakery[row, col] = rowInfo[col];
                }
            }
        }
        private static void PrintBaker(char[,] bakery)
        {
            for (int row = 0; row < bakery.GetLength(0); row++)
            {
                for (int col = 0; col < bakery.GetLength(1); col++)
                {
                    Console.Write(bakery[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
