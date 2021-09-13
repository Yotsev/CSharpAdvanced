using System;

namespace Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int territorySize = int.Parse(Console.ReadLine());

            char[][] territory = new char[territorySize][];
            ReadTerritory(territory);

            (int row, int col) beePositon = GetBeePositon(territory);

            int minPolinatedFlowers = 5;
            int pollinatedFlowers = 0;

            string command = Console.ReadLine();

            bool isOut = false;

            while (command != "End")
            {
                (int targetRow, int targetCol) targetPostion = GetTargetPosioon(territory, beePositon, command);

                IsInside(targetPostion, territory);

                if (IsInside(targetPostion, territory))
                {
                    if (territory[targetPostion.targetRow][targetPostion.targetCol] == 'f')
                    {
                        pollinatedFlowers++;
                        territory[beePositon.row][beePositon.col] = '.';
                        territory[targetPostion.targetRow][targetPostion.targetCol] = 'B';
                        beePositon = targetPostion;
                    }
                    else if (territory[targetPostion.targetRow][targetPostion.targetCol] == 'O')
                    {
                        territory[targetPostion.targetRow][targetPostion.targetCol] = 'B';
                        territory[beePositon.row][beePositon.col] = '.';
                        beePositon = targetPostion;
                        continue;
                    }
                    else if (territory[targetPostion.targetRow][targetPostion.targetCol] == '.')
                    {
                        territory[targetPostion.targetRow][targetPostion.targetCol] = 'B';
                        territory[beePositon.row][beePositon.col] = '.';
                        beePositon = targetPostion;
                    }
                }
                else
                {
                    territory[beePositon.row][beePositon.col] = '.';
                    isOut = true;
                    break;
                }

                command = Console.ReadLine();
            }

            if (isOut)
            {
                Console.WriteLine("The bee got lost!");
            }

            if (pollinatedFlowers >= minPolinatedFlowers)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {pollinatedFlowers} flowers!");
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {minPolinatedFlowers - pollinatedFlowers} flowers more");
            }

            PrintTerritory(territory);
        }

        private static bool IsInside((int targetRow, int targetCol) targetPostion, char[][] territory)
        {
            if (targetPostion.targetRow >= 0
                && targetPostion.targetRow < territory.Length
                && targetPostion.targetCol >= 0
                && targetPostion.targetCol < territory[targetPostion.targetRow].Length)
            {
                return true;
            }

            return false;
        }

        private static (int targetRow, int targetCol) GetTargetPosioon(char[][] territory, (int row, int col) beePositon, string direction)
        {
            (int, int) positon = beePositon;
            if (direction == "up")
            {
                positon.Item1--;
            }
            else if (direction == "down")
            {
                positon.Item1++;
            }
            else if (direction == "left")
            {
                positon.Item2--;
            }
            else if (direction == "right")
            {
                positon.Item2++;
            }

            return positon;

        }
        private static (int row, int col) GetBeePositon(char[][] territory)
        {
            (int, int) postion = (0, 0);

            for (int row = 0; row < territory.Length; row++)
            {
                for (int col = 0; col < territory[row].Length; col++)
                {
                    if (territory[row][col] == 'B')
                    {
                        postion.Item1 = row;
                        postion.Item2 = col;
                    }
                }
            }

            return postion;
        }
        private static void ReadTerritory(char[][] territory)
        {
            for (int row = 0; row < territory.Length; row++)
            {
                char[] rowInfo = Console.ReadLine().ToCharArray();
                territory[row] = rowInfo;
            }
        }
        private static void PrintTerritory(char[][] territory)
        {
            for (int row = 0; row < territory.Length; row++)
            {
                Console.WriteLine(string.Join("", territory[row]));
            }
        }
    }
}
