using System;

namespace _07.PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            long[][] triangle = new long[rows][];

            for (int i = 0; i < triangle.Length; i++)
            {

                long[] row = new long[i + 1];
                row[0] = 1;
                row[row.Length - 1] = 1;

                for (int j  = 1; j < row.Length-1; j++)
                {
                    row[j] = triangle[i - 1][j] + triangle[i - 1][j - 1];
                }

                triangle[i] = row;
            }

            for (int i = 0; i < triangle.Length; i++)
            {
                Console.WriteLine(string.Join(" ",triangle[i]));
            }
        }
    }
}
