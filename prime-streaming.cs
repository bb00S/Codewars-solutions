using System;
using System.Collections.Generic;

public class Primes
{
    public static IEnumerable<int> Stream()
    {
        List<int> primes = new List<int>() { 2 }; // Initialize with the first prime number
        yield return 2; // Yield the first prime number

        for (int candidate = 3; ; candidate += 2) // Start with the next odd number
        {
            bool isPrime = true;
            int candidateSqrt = (int)Math.Sqrt(candidate);

            foreach (int prime in primes)
            {
                if (prime > candidateSqrt)
                    break;

                if (candidate % prime == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            if (isPrime)
            {
                primes.Add(candidate); // Add prime to the list
                yield return candidate; // Yield the prime number
            }
        }
    }

    public static void Main(string[] args)
    {
        // Test the prime number stream
        int count = 0;
        foreach (int prime in Stream())
        {
            Console.Write(prime + " ");
            count++;
            if (count >= 1000000) // Print the first million primes
                break;
        }
    }
}
