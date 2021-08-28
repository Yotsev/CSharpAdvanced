using System;

namespace _07.KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfBoard = int.Parse(Console.ReadLine());

            char[,] board = new char[sizeOfBoard,sizeOfBoard];

            for (int row = 0; row < board.GetLength(0); row++)
            {
                char[] cols = Console.ReadLine().ToCharArray();

                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col] = cols[col];
                }
            }

            int removedKnights = 0;

            while (true)
            {
                int maxAttacks = 0;
                int maxRow = -1;
                int maxCol = -1;

                for (int row = 0; row < board.GetLength(0); row++)
                {
                    for (int col = 0; col < board.GetLength(1); col++)
                    {
                        char currentSquare = board[row, col];
                        int currentAttacks = 0;

                        if (currentSquare == 'K')
                        {
                            if (IsOnBoard(board, row+1,col+2)&& board[row + 1, col + 2] == 'K')
                            {
                                currentAttacks++;
                            }

                            if (IsOnBoard(board, row + 1, col - 2) && board[row + 1, col - 2] == 'K')
                            {
                                currentAttacks++;
                            }

                            if (IsOnBoard(board, row - 1, col + 2) && board[row - 1, col + 2] == 'K')
                            {
                                currentAttacks++;
                            }

                            if (IsOnBoard(board, row - 1, col - 2) && board[row - 1, col - 2] == 'K')
                            {
                                currentAttacks++;
                            }

                            if (IsOnBoard(board, row + 2, col + 1) && board[row + 2, col + 1] == 'K')
                            {
                                currentAttacks++;
                            }

                            if (IsOnBoard(board, row + 2, col - 1) && board[row + 2, col - 1] == 'K')
                            {
                                currentAttacks++;
                            }

                            if (IsOnBoard(board, row - 2, col + 1) && board[row - 2, col + 1] == 'K')
                            {
                                currentAttacks++;
                            }

                            if (IsOnBoard(board, row - 2, col - 1) && board[row - 2, col - 1] == 'K')
                            {
                                currentAttacks++;
                            }

                            if (currentAttacks>maxAttacks)
                            {
                                maxAttacks = currentAttacks;
                                maxRow = row;
                                maxCol = col;
                            }
                        }
                    }
                }

                if (maxAttacks>0)
                {
                    board[maxRow, maxCol] = '0';
                    removedKnights++;
                }
                else
                {
                    Console.WriteLine(removedKnights);
                    break;
                }

            }
        }

        static bool IsOnBoard(char[,] chessBoard, int targetRow, int targetCol)
        {
            return targetRow >= 0 && targetRow < chessBoard.GetLength(0)
            && targetCol >= 0 && targetCol < chessBoard.GetLength(1);
        }
    }
}
