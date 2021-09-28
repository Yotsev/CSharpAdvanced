using System;

namespace TheBattleOfTheFiveArmies
{
    class Program
    {
        static char[][] map;
        static void Main(string[] args)
        {
            int armyArmor = int.Parse(Console.ReadLine());
            int mapRows = int.Parse(Console.ReadLine());

            map = new char[mapRows][];

            for (int row = 0; row < map.Length; row++)
            {
                char[] rowInfo = Console.ReadLine().ToCharArray();

                map[row] = rowInfo;
            }

            (int row, int col) armyPositon = GetArmyPositon();

            bool isDead = false;
            bool hasWon = false;

            while (true)
            {
                string[] commadArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string direction = commadArgs[0];
                int spawnRow = int.Parse(commadArgs[1]);
                int spawnCol = int.Parse(commadArgs[2]);

                map[spawnRow][spawnCol] = 'O';

                (int targetRow, int targetCol) targetPositon = GetTargetPositon(direction, armyPositon);

                armyArmor--;

                if (IsInside(targetPositon))
                {
                    map[armyPositon.row][armyPositon.col] = '-';

                    if (map[targetPositon.targetRow][targetPositon.targetCol] == 'O')
                    {
                        armyArmor -= 2;

                        if (armyArmor <= 0)
                        {
                            map[targetPositon.targetRow][targetPositon.targetCol] = 'X';
                            armyPositon = targetPositon;
                            isDead = true;
                            break;
                        }
                    }
                    else if (map[targetPositon.targetRow][targetPositon.targetCol] == 'M')
                    {
                        armyPositon = targetPositon;
                        map[armyPositon.row][armyPositon.col] = '-';
                        hasWon = true;
                        break;
                    }

                    armyPositon = targetPositon;
                    map[armyPositon.row][armyPositon.col] = 'A';
                }

                if (armyArmor <= 0)
                {
                    map[armyPositon.row][armyPositon.col] = 'X';
                    isDead = true;
                    break;
                }
            }

            if (hasWon)
            {
                Console.WriteLine($"The army managed to free the Middle World! Armor left: {armyArmor}");
            }
            else if (isDead)
            {
                Console.WriteLine($"The army was defeated at {armyPositon.row};{armyPositon.col}.");
            }

            PrintMap();

        }

        private static bool IsInside((int targetRow, int targetCol) targetPositon)
        {
            return targetPositon.targetRow >= 0 && targetPositon.targetRow < map.Length
                && targetPositon.targetCol >= 0 && targetPositon.targetCol < map[targetPositon.targetRow].Length;
        }

        private static (int targetRow, int targetCol) GetTargetPositon(string direction, (int row, int col) armyPositon)
        {
            (int, int) positon = armyPositon;

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

        private static (int row, int col) GetArmyPositon()
        {
            (int, int) posiotn = (0, 0);

            for (int row = 0; row < map.Length; row++)
            {
                for (int col = 0; col < map[row].Length; col++)
                {
                    if (map[row][col] == 'A')
                    {
                        posiotn.Item1 = row;
                        posiotn.Item2 = col;
                    }
                }
            }

            return posiotn;
        }

        public static void PrintMap()
        {
            for (int row = 0; row < map.Length; row++)
            {
                Console.WriteLine(string.Join("", map[row]));
            }
        }
    }
}
