using System;

public class TicTacToe
{
    public int IsSolved(int[,] board)
    {
        // Check rows and columns
        for (int i = 0; i < 3; i++)
        {
            if (board[i, 0] != 0 && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
            {
                return board[i, 0];
            }

            if (board[0, i] != 0 && board[0, i] == board[1, i] && board[1, i] == board[2, i])
            {
                return board[0, i];
            }
        }

        // Check diagonals
        if (board[0, 0] != 0 && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
        {
            return board[0, 0];
        }

        if (board[0, 2] != 0 && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
        {
            return board[0, 2];
        }

        // Check if board is finished or cat's game
        bool hasEmptySpot = false;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (board[i, j] == 0)
                {
                    hasEmptySpot = true;
                    break;
                }
            }
        }

        return hasEmptySpot ? -1 : 0;
    }

    public static void Main()
    {
        TicTacToe game = new TicTacToe();

        int[,] board1 = new int[,]
        {
            { 0, 0, 1 },
            { 0, 1, 2 },
            { 2, 1, 0 }
        };
        Console.WriteLine(game.IsSolved(board1));  // Output: -1

        int[,] board2 = new int[,]
        {
            { 1, 0, 1 },
            { 0, 1, 2 },
            { 2, 1, 0 }
        };
        Console.WriteLine(game.IsSolved(board2));  // Output: 1 (X won)

        int[,] board3 = new int[,]
        {
            { 1, 2, 1 },
            { 2, 2, 1 },
            { 1, 1, 2 }
        };
        Console.WriteLine(game.IsSolved(board3));  // Output: 2 (O won)

        int[,] board4 = new int[,]
        {
            { 1, 2, 1 },
            { 1, 2, 2 },
            { 2, 1, 1 }
        };
        Console.WriteLine(game.IsSolved(board4));  // Output: 0 (Cat's game)
    }
}
