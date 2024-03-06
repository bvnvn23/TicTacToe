using System;

namespace TicTacToe
{
    public class GameBoard
    {
        private char[,] board = new char[3, 3];

        public GameBoard()
        {
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int columns = 0; columns < 3; columns++)
                {
                    board[row, columns] = ' ';
                }
            }
        }

        public void DisplayBoard()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int columns = 0; columns < 3; columns++)
                {
                    Console.Write(board[row, columns]);
                    if (columns < 2) Console.Write("|");
                }
                Console.WriteLine();
                if (row < 2) Console.WriteLine("-+-+-");
            }
        }

        public bool PlaceMark(int row, int column, Player player)
        {
            if (row >= 0 && row < 3 && column >= 0 && column < 3 && board[row, column] == ' ')
            {
                board[row, column] = player.Symbol;
                return true;
            }
            return false;
        }

        public bool CheckForWinner(char symbol)
        {
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == symbol && board[i, 1] == symbol && board[i, 2] == symbol)
                {
                    return true;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                if (board[0, i] == symbol && board[1, i] == symbol && board[2, i] == symbol)
                {
                    return true;
                }
            }
            if (board[0, 0] == symbol && board[1, 1] == symbol && board[2, 2] == symbol)
            {
                return true;
            }
            if (board[0, 2] == symbol && board[1, 1] == symbol && board[2, 0] == symbol)
            {
                return true;
            }

            return false;
        }

        public bool IsBoardFull()
        {
            for (int row = 0; row < board.GetLength(0); row++) 
            {
                for (int column = 0; column < board.GetLength(1); column++) 
                {
                    if (board[row, column] == ' ')
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
