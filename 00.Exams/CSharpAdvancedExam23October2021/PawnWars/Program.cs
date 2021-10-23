using System;

namespace PawnWars
{
    class Program
    {
        public enum Rank { a = 0, b = 1, c = 2, d = 3, e = 4, f = 5, g = 6, h = 7 };
        static void Main(string[] args)
        {

            char[,] chessboard = new char[8, 8];

            ReadChessBoard(chessboard);

            (int row, int col) whitePawnPositon = GetWhitePawnPosition(chessboard);
            (int row, int col) blackPawnPositon = GetBlackPawnPosition(chessboard);

            int counter = 1;

            bool whiteWin = false;
            bool blackWin = false;
            bool isWhiteQueen = false;
            bool isBlackQueen = false;

            while (true)
            {
                if (counter % 2 != 0)
                {
                    chessboard[whitePawnPositon.row, whitePawnPositon.col] = '-';

                    if (IsBlackPoawn(chessboard, whitePawnPositon))
                    {
                        chessboard[blackPawnPositon.row, blackPawnPositon.col] = 'w';
                        whitePawnPositon = blackPawnPositon;
                        whiteWin = true;
                        break;
                    }

                    whitePawnPositon = WhitePawnMove(whitePawnPositon);
                    chessboard[whitePawnPositon.row, whitePawnPositon.col] = 'w';
                    counter++;
                }
                else
                {
                    chessboard[blackPawnPositon.row, blackPawnPositon.col] = '-';

                    if (IsWhitePoawn(chessboard, blackPawnPositon))
                    {
                        chessboard[whitePawnPositon.row, whitePawnPositon.col] = 'b';
                        blackPawnPositon = whitePawnPositon;
                        blackWin = true;
                        break;
                    }

                    blackPawnPositon = BlackPawnMove(blackPawnPositon);
                    chessboard[blackPawnPositon.row, blackPawnPositon.col] = 'b';
                    counter++;
                }

                if (whitePawnPositon.row == 0)
                {
                    isWhiteQueen = true;
                    break;
                }

                if (blackPawnPositon.row == chessboard.GetLength(0) - 1)
                {
                    isBlackQueen = true;
                    break;
                }
            }


            if (isWhiteQueen)
            {
                var col = (Rank)whitePawnPositon.col;
                Console.WriteLine($"Game over! White pawn is promoted to a queen at {col + (chessboard.GetLength(0) - whitePawnPositon.row).ToString()}.");
            }
            else if (isBlackQueen)
            {
                var col = (Rank)blackPawnPositon.col;
                Console.WriteLine($"Game over! Black pawn is promoted to a queen at {col + (chessboard.GetLength(0) - blackPawnPositon.row).ToString()}.");
            }

            if (whiteWin)
            {
                var col = (Rank)whitePawnPositon.col;
                Console.WriteLine($"Game over! White capture on {col + (chessboard.GetLength(0) - whitePawnPositon.row).ToString()}.");
            }
            else if (blackWin)
            {
                var col = (Rank)blackPawnPositon.col;
                Console.WriteLine($"Game over! Black capture on {col + (chessboard.GetLength(0) - blackPawnPositon.row).ToString()}.");
            }
        }

        private static (int, int) WhitePawnMove((int row, int col) whitePawnPositon)
        {
            (int row, int col) positon = whitePawnPositon;

            positon.row--;
            return positon;
        }

        private static (int, int) BlackPawnMove((int row, int col) blackPawnPositon)
        {
            (int row, int col) positon = blackPawnPositon;

            positon.row++;
            return positon;
        }

        private static bool IsWhitePoawn(char[,] chessboard, (int row, int col) blackPawnPositon)
        {
            if (blackPawnPositon.col - 1 >= 0 && blackPawnPositon.col + 1 < chessboard.GetLength(1))
            {
                return chessboard[blackPawnPositon.row + 1, blackPawnPositon.col - 1] == 'w'
                || chessboard[blackPawnPositon.row + 1, blackPawnPositon.col + 1] == 'w';
            }
            else if (blackPawnPositon.col - 1 < 0)
            {
                return chessboard[blackPawnPositon.row + 1, blackPawnPositon.col + 1] == 'w';
            }
            else
            {
                return chessboard[blackPawnPositon.row + 1, blackPawnPositon.col - 1] == 'w';
            }
        }

        private static bool IsBlackPoawn(char[,] chessboard, (int row, int col) whitePawnPositon)
        {
            if (whitePawnPositon.col - 1 >= 0 && whitePawnPositon.col + 1 < chessboard.GetLength(1))
            {
                return chessboard[whitePawnPositon.row - 1, whitePawnPositon.col - 1] == 'b'
                || chessboard[whitePawnPositon.row - 1, whitePawnPositon.col + 1] == 'b';
            }
            else if (whitePawnPositon.col - 1 < 0)
            {
                return chessboard[whitePawnPositon.row - 1, whitePawnPositon.col + 1] == 'b';
            }
            else 
            {
                return chessboard[whitePawnPositon.row - 1, whitePawnPositon.col - 1] == 'b';
            }
        }

        private static void ReadChessBoard(char[,] chessboard)
        {
            for (int row = 0; row < chessboard.GetLength(0); row++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();

                for (int col = 0; col < chessboard.GetLength(1); col++)
                {
                    chessboard[row, col] = currentRow[col];
                }
            }
        }

        private static (int row, int col) GetBlackPawnPosition(char[,] chessboard)
        {
            (int row, int col) position = (0, 0);

            for (int row = 0; row < chessboard.GetLength(0); row++)
            {
                for (int col = 0; col < chessboard.GetLength(1); col++)
                {
                    if (chessboard[row, col] == 'b')
                    {
                        position.row = row;
                        position.col = col;
                    }
                }
            }

            return position;
        }

        private static (int row, int col) GetWhitePawnPosition(char[,] chessboard)
        {
            (int row, int col) position = (0, 0);

            for (int row = 0; row < chessboard.GetLength(0); row++)
            {
                for (int col = 0; col < chessboard.GetLength(1); col++)
                {
                    if (chessboard[row, col] == 'w')
                    {
                        position.row = row;
                        position.col = col;
                    }
                }
            }

            return position;
        }
    }
}
