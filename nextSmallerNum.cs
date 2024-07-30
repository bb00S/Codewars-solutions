using System;

public class Kata
{
    public static long NextSmaller(long n)
    {
        char[] digits = n.ToString().ToCharArray();
        int length = digits.Length;

        // Step 1: Find the rightmost peak
        int i = length - 2;
        while (i >= 0 && digits[i] <= digits[i + 1])
        {
            i--;
        }

        if (i == -1)
        {
            return -1; // No peak found, no smaller number possible
        }

        // Step 2: Find the largest digit to the right of the peak that is smaller than the peak
        int j = length - 1;
        while (digits[j] >= digits[i])
        {
            j--;
        }

        // Step 3: Swap these two digits
        char temp = digits[i];
        digits[i] = digits[j];
        digits[j] = temp;

        // Step 4: Sort the digits to the right of the peak in descending order
        Array.Sort(digits, i + 1, length - (i + 1));
        Array.Reverse(digits, i + 1, length - (i + 1));

        // Convert the char array back to a long
        long result = long.Parse(new string(digits));

        // Step 5: Check for leading zeros
        if (result < n && digits[0] != '0')
        {
            return result;
        }

        return -1;
    }

    public static void Main()
    {
        Console.WriteLine(NextSmaller(21));    // Output: 12
        Console.WriteLine(NextSmaller(531));   // Output: 513
        Console.WriteLine(NextSmaller(2071));  // Output: 2017
        Console.WriteLine(NextSmaller(9));     // Output: -1
        Console.WriteLine(NextSmaller(111));   // Output: -1
        Console.WriteLine(NextSmaller(135));   // Output: -1
        Console.WriteLine(NextSmaller(1027));  // Output: -1
    }
}
