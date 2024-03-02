using System;

namespace CustomExtensions
{
      public static class StringExtensions
    {
        public static int Score(this string str)
        {
            int score = 0;
            foreach (char c in str)
            {
                if (char.IsLetter(c))
                {
                    score += Char.ToUpper(c) - 'A' + 1;
                }
            }
            return score;
        }
    }
}
