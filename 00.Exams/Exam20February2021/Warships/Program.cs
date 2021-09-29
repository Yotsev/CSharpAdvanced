using System;
using System.Linq;

namespace Warships
{
    class Program
    {
        static char[,] field;
        static void Main(string[] args)
        {
            int sizeOfField = int.Parse(Console.ReadLine());
            string[] attackCoordinates = Console.ReadLine()
                .Split(",", StringSplitOptions.RemoveEmptyEntries);

            field = new char[sizeOfField, sizeOfField];

            ReadField();

            (int firstPayerShips, int seconPlayerShips) playerShips = GetPlayersShips();
            int totalShips = playerShips.firstPayerShips + playerShips.seconPlayerShips;

            bool isDraw = true;

            for (int i = 0; i < attackCoordinates.Length; i++)
            {
                string[] currentCoordinates = attackCoordinates[i]
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int rowCoordinates = int.Parse(currentCoordinates[0]);
                int colCoordinates = int.Parse(currentCoordinates[1]);

                if (!IsValidIndices(rowCoordinates, colCoordinates))
                {
                    continue;
                }

                if (field[rowCoordinates, colCoordinates] == '#')
                {
                    playerShips = Explosion(playerShips, rowCoordinates, colCoordinates);
                }
                else if (field[rowCoordinates, colCoordinates] == '<')
                {
                    field[rowCoordinates, colCoordinates] = 'X';
                    playerShips.firstPayerShips--;
                }
                else if (field[rowCoordinates, colCoordinates] == '>')
                {
                    field[rowCoordinates, colCoordinates] = 'X';
                    playerShips.seconPlayerShips--;
                }

                if (playerShips.firstPayerShips <= 0 || playerShips.seconPlayerShips <= 0)
                {
                    isDraw = false;
                    break;
                }
            }

            playerShips = GetPlayersShips();
            int destroiedShips = totalShips - playerShips.firstPayerShips - playerShips.seconPlayerShips;
            string winner = playerShips.firstPayerShips > 0 ? "One" : "Two";

            if (isDraw)
            {
                Console.WriteLine($"It's a draw! Player One has {playerShips.firstPayerShips} ships left. Player Two has {playerShips.seconPlayerShips} ships left.");
            }
            else
            {
                Console.WriteLine($"Player {winner} has won the game! {destroiedShips} ships have been sunk in the battle.");
            }
        }

        private static (int, int) Explosion((int firstPayerShips, int seconPlayerShips) playerShips, int rowCoordinates, int colCoordinates)
        {
            (int first, int second) newShipsCount = playerShips;

            field[rowCoordinates, colCoordinates] = 'X';

            if (IsValidIndices(rowCoordinates - 1, colCoordinates) && IsShip(rowCoordinates - 1, colCoordinates))
            {
                newShipsCount = DestoiedShop(rowCoordinates - 1, colCoordinates, newShipsCount);
            }

            if (IsValidIndices(rowCoordinates - 1, colCoordinates + 1) && IsShip(rowCoordinates - 1, colCoordinates + 1))
            {
                newShipsCount = DestoiedShop(rowCoordinates - 1, colCoordinates + 1, newShipsCount);
            }

            if (IsValidIndices(rowCoordinates, colCoordinates + 1) && IsShip(rowCoordinates, colCoordinates + 1))
            {
                newShipsCount = DestoiedShop(rowCoordinates, colCoordinates + 1, newShipsCount);
            }

            if (IsValidIndices(rowCoordinates + 1, colCoordinates + 1) && IsShip(rowCoordinates + 1, colCoordinates + 1))
            {
                newShipsCount = DestoiedShop(rowCoordinates + 1, colCoordinates + 1, newShipsCount);
            }

            if (IsValidIndices(rowCoordinates + 1, colCoordinates) && IsShip(rowCoordinates + 1, colCoordinates))
            {
                newShipsCount = DestoiedShop(rowCoordinates + 1, colCoordinates, newShipsCount);
            }

            if (IsValidIndices(rowCoordinates + 1, colCoordinates - 1) && IsShip(rowCoordinates + 1, colCoordinates - 1))
            {
                newShipsCount = DestoiedShop(rowCoordinates + 1, colCoordinates - 1, newShipsCount);
            }

            if (IsValidIndices(rowCoordinates, colCoordinates - 1) && IsShip(rowCoordinates, colCoordinates - 1))
            {
                newShipsCount = DestoiedShop(rowCoordinates, colCoordinates - 1, newShipsCount);
            }

            if (IsValidIndices(rowCoordinates - 1, colCoordinates - 1) && IsShip(rowCoordinates - 1, colCoordinates - 1))
            {
                newShipsCount = DestoiedShop(rowCoordinates - 1, colCoordinates - 1, newShipsCount);
            }

            return newShipsCount;
        }

        private static (int, int) DestoiedShop(int rowCoordinates, int colCoordinates, (int first, int secon) newShipsCount)
        {
            (int, int) ships = newShipsCount;

            if (field[rowCoordinates, colCoordinates] == '<')
            {
                ships.Item1--;
            }
            else
            {
                ships.Item2--;
            }

            field[rowCoordinates, colCoordinates] = 'X';

            return ships;
        }

        private static bool IsShip(int row, int col)
        {
            return field[row, col] == '<' || field[row, col] =='>';
        }

        private static bool IsValidIndices(int row, int col)
        {
            return row >= 0 && row < field.GetLength(0)
                && col >= 0 && col < field.GetLength(1);
        }

        private static (int firstPayerShips, int seconPlayerShips) GetPlayersShips()
        {
            (int first, int second) ships = (0, 0);

            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    if (field[row, col] == '<')
                    {
                        ships.first++;
                    }
                    else if (field[row, col] == '>')
                    {
                        ships.second++;
                    }
                }
            }

            return ships;
        }

        private static void ReadField()
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                char[] rowInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = rowInfo[col];
                }
            }
        }
    }
}
