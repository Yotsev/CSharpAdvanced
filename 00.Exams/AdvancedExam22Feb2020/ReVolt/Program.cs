using System;

namespace ReVolt
{
    class Program
    {
        static char[,] field;
        static void Main(string[] args)
        {
            int sizeOfMatrix = int.Parse(Console.ReadLine());
            int commandsCount = int.Parse(Console.ReadLine());

            field = new char[sizeOfMatrix, sizeOfMatrix];

            for (int row = 0; row < field.GetLength(0); row++)
            {
                char[] rowInfo = Console.ReadLine().ToCharArray();

                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = rowInfo[col];
                }
            }

            (int row, int col) playerPositon = GetPlayerPositon();
            bool hasWon = false;

            for (int i = 0; i < commandsCount; i++)
            {
                string direction = Console.ReadLine();

                field[playerPositon.row, playerPositon.col] = '-';

                (int targetRow, int targetCol) targetpositon = GetTargetPositon(direction, playerPositon);

                if (!IsInside(targetpositon))
                {
                    targetpositon = PlayerTeleport(targetpositon);
                }

                if (field[targetpositon.targetRow, targetpositon.targetCol] == 'B')
                {
                    targetpositon = BonusPlayerPositon(direction, targetpositon);
                    if (!IsInside(targetpositon))
                    {
                        targetpositon = PlayerTeleport(targetpositon);
                    }
                }
                if (field[targetpositon.targetRow, targetpositon.targetCol] == 'T')
                {
                    continue;
                }
                if (field[targetpositon.targetRow, targetpositon.targetCol] == 'F')
                {
                    hasWon = true;
                }

                playerPositon = targetpositon;
                field[playerPositon.row, playerPositon.col] = 'f';

                if (hasWon)
                {
                    break;
                }
            }

            if (hasWon)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }

            PrintField();
        }

        private static (int row, int col) BonusPlayerPositon(string direction, (int targetRow, int targetCol) targetpositon)
        {
            targetpositon = GetTargetPositon(direction, targetpositon);

            return targetpositon;
        }

        private static (int targetRow, int targetCol) PlayerTeleport((int targetRow, int targetCol) targetpositon)
        {
            (int row, int col) newPositon = targetpositon;

            if (newPositon.row < 0)
            {
                newPositon.row = field.GetLength(0) - 1;
            }
            else if (newPositon.row >= field.GetLength(0))
            {
                newPositon.row = 0;
            }
            else if (newPositon.col < 0)
            {
                newPositon.col = field.GetLength(1) - 1;
            }
            else if (newPositon.col >= field.GetLength(1))
            {
                newPositon.col = 0;
            }

            return newPositon;
        }

        private static bool IsInside((int targetRow, int targetCol) targetpositon)
        {
            return targetpositon.targetRow >= 0 && targetpositon.targetRow < field.GetLength(0) &&
                targetpositon.targetCol >= 0 && targetpositon.targetCol < field.GetLength(1);
        }

        private static (int targetRow, int targetCol) GetTargetPositon(string direction, (int row, int col) playerPositon)
        {
            (int targetRow, int targetCol) positon = playerPositon;

            if (direction == "up")
            {
                positon.targetRow--;
            }
            else if (direction == "down")
            {
                positon.targetRow++;
            }
            else if (direction == "left")
            {
                positon.targetCol--;
            }
            else if (direction == "right")
            {
                positon.targetCol++;
            }

            return positon;
        }

        private static (int row, int col) GetPlayerPositon()
        {
            (int row, int col) positon = (0, 0);

            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    if (field[row, col] == 'f')
                    {
                        positon.row = row;
                        positon.col = col;
                    }
                }
            }

            return positon;
        }

        public static void PrintField()
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1) - 1; col++)
                {
                    Console.Write(field[row, col]);
                }

                Console.WriteLine(field[row, field.GetLength(1) - 1]);
            }
        }
    }
}
