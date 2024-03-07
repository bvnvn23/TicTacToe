using System;
using System.Numerics;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("****Welcome to Tic Tac Toe!****");
                Console.WriteLine("1. Start Game");
                Console.WriteLine("2. Exit");
                Console.Write("Select an option: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        StartGame();
                        break;
                    case "2":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }
     
        static void StartGame()
        {
            GameBoard board = new GameBoard();
            Player player1 = new Player('O');
            Player player2 = new Player('X');
            Player currentPlayer = player1;
            bool isGameRunning = true;

            while (isGameRunning)
            {
                Console.Clear();
                board.DisplayBoard();

                Console.WriteLine($"Player {currentPlayer.Symbol}'s turn.");
                Console.WriteLine("Enter row and column (0, 1, 2): ");

                try
                {
                    int row = int.Parse(Console.ReadLine());
                    int column = int.Parse(Console.ReadLine());


                    if (board.PlaceMark(row, column, currentPlayer))
                    {
                        if (board.CheckForWinner(currentPlayer.Symbol))
                        {
                            Console.Clear();
                            board.DisplayBoard();
                            Console.WriteLine($"Player {currentPlayer.Symbol} wins!");
                            Console.WriteLine("Press any key to return to the main menu...");
                            Console.ReadKey();
                            break;
                        }
                        else if (board.IsBoardFull())
                        {
                            Console.Clear();
                            board.DisplayBoard();
                            Console.WriteLine("It's a tie!");
                            Console.WriteLine("Press any key to return to the main menu...");
                            Console.ReadKey();
                            break;
                        }
                    }
                
                    else
                    {
                        Console.WriteLine("That spot is already taken. Try again.");
                        Console.ReadKey();
                        currentPlayer = currentPlayer == player1 ? player2 : player1;
                    }
                }
                catch (Exception ex) { Console.WriteLine("Wrong input! Pick from [0,1,2]!"); }
                currentPlayer = currentPlayer == player1 ? player2 : player1;


            }
        }

    }
}