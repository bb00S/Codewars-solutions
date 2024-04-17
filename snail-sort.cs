using System;
using System.Collections.Generic;

public class SnailSolution
{
    public static List<int> Snail(int[][] array)
    {
        List<int> result = new List<int>();

        if (array.Length == 1 && array[0].Length == 0)
        {
            // Empty matrix case
            return result;
        }

        int n = array.Length;
        int rowStart = 0, rowEnd = n - 1;
        int colStart = 0, colEnd = n - 1;

        while (rowStart <= rowEnd && colStart <= colEnd)
        {
            // Traverse right
            for (int i = colStart; i <= colEnd; i++)
            {
                result.Add(array[rowStart][i]);
            }
            rowStart++;

            // Traverse down
            for (int i = rowStart; i <= rowEnd; i++)
            {
                result.Add(array[i][colEnd]);
            }
            colEnd--;

            // Traverse left
            if (rowStart <= rowEnd)
            {
                for (int i = colEnd; i >= colStart; i--)
                {
                    result.Add(array[rowEnd][i]);
                }
                rowEnd--;
            }

            // Traverse up
            if (colStart <= colEnd)
            {
                for (int i = rowEnd; i >= rowStart; i--)
                {
                    result.Add(array[i][colStart]);
                }
                colStart++;
            }
        }

        return result;
    }

    public static void Main()
    {
        int[][] array = new int[][]
        {
            new int[] {1, 2, 3},
            new int[] {8, 9, 4},
            new int[] {7, 6, 5}
        };

        List<int> snailSorted = Snail(array);
        Console.WriteLine(string.Join(", ", snailSorted)); // Output: 1, 2, 3, 4, 5, 6, 7, 8, 9

        int[][] emptyArray = new int[][] { new int[] { } };
        List<int> snailSortedEmpty = Snail(emptyArray);
        Console.WriteLine(string.Join(", ", snailSortedEmpty)); // Output: (Empty list)
    }
}
