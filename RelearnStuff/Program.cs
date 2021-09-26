using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Relearn
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tic Tac Toe?");

            Console.WriteLine();

            Console.ReadKey();
            var play = true;
            while (play == true)
            {
                string[] board = { "_", "_", "_", "_", "_", "_", "_", "_", "_" };
                PlayGame(board);
                Console.ReadKey();
                play = PlayAgain();

            }

        }

        static void ShowBoard(string[] board)
        {

            Console.WriteLine();
            Console.WriteLine($"Current Board");
            Console.WriteLine("--------------");
            Console.WriteLine($"| {board[0]} | {board[1]} | {board[2]} |");
            Console.WriteLine($"| {board[3]} | {board[4]} | {board[5]} |");
            Console.WriteLine($"| {board[6]} | {board[7]} | {board[8]} |");

        }
        static void PositionSelect()
        {
            Console.WriteLine($"| 1 | 2 | 3 |");
            Console.WriteLine($"| 4 | 5 | 6 |");
            Console.WriteLine($"| 7 | 8 | 9 |");
        }

        static void TakeTurnPlayerX(string[] board)
        {
            
            Selection:
                Console.Clear();
                Console.WriteLine("Player X your turn");
                ShowBoard(board);
                Console.WriteLine();
                Console.WriteLine("Select space");
                Console.WriteLine();
                PositionSelect();
                Console.WriteLine();
                var key = Console.ReadLine();

                string input = Convert.ToString(key);

            if(ValidateInput(input) == false)
            {
                Console.Clear();
                Console.WriteLine("Please select valid input");
                Console.ReadKey();
                goto Selection;
            }
            else
            if (SpaceEmpty(board, input) == false)
            {
                Console.Clear();
                Console.WriteLine("Please select valid input");
                Console.ReadKey();
                goto Selection;
            }
            else

                BoardUpdate(board, input, "X");
            
        }
        static void TakeTurnPlayerO(string[] board)
        {
            
        Selection:
            Console.Clear();
            Console.WriteLine("Player O your turn");
            ShowBoard(board);
            Console.WriteLine();
            Console.WriteLine("Select space");
            Console.WriteLine();
            PositionSelect();
            Console.WriteLine();
            var key = Console.ReadLine();

            string input = Convert.ToString(key);

            if (ValidateInput(input) == false)
            {
                Console.Clear();
                Console.WriteLine("Please select valid input");
                Console.ReadKey();
                goto Selection;
            }
            if (SpaceEmpty(board,input) == false)
            {
                Console.Clear();
                Console.WriteLine("Please select valid input");
                Console.ReadKey();
                goto Selection;
            }
            else

                BoardUpdate(board, input, "O");

        }
        public static bool SpaceEmpty(string[] board, string input)
        {
            if ( board[Convert.ToInt32(input)-1] == "_")
            {
                return true;
            }
            else
            return false;
        }
        static void BoardUpdate(string[] board, string input, string player)
        {
            if (input == "1" && board[0] == "_")
            {
                board[0] = player;
            }
            if (input == "2" && board[1] == "_")
            {
                board[1] = player;
            }
            if (input == "3" && board[2] == "_")
            {
                board[2] = player;
            }
            if (input == "4" && board[3] == "_")
            {
                board[3] = player;
            }
            if (input == "5" && board[4] == "_")
            {
                board[4] = player;
            }
            if (input == "6" && board[5] == "_")
            {
                board[5] = player;
            }
            if (input == "7" && board[6] == "_")
            {
                board[6] = player;
            }
            if (input == "8" && board[7] == "_")
            {
                board[7] = player;
            }
            if (input == "9" && board[8] == "_")
            {
                board[8] = player;
            }
        }
        
        static public bool ValidateInput(string input)
        {
            Regex rx = new Regex(@"^[1-9]$");

            if (rx.IsMatch(input))
            {
                return true;
            }
            else return false;
        }

        static public string CheckForWinner(string[] board)
        {
            string winner = "_";
            Queue<int[]> wins = new Queue<int[]>();

            wins.Enqueue(new int[] { 0, 1, 2 });
            wins.Enqueue(new int[] { 3, 4, 5 });
            wins.Enqueue(new int[] { 6, 7, 8 });
            wins.Enqueue(new int[] { 0, 4, 8 });
            wins.Enqueue(new int[] { 1, 4, 7 });
            wins.Enqueue(new int[] { 2, 4, 6 });
            wins.Enqueue(new int[] { 0, 3, 6 });
            wins.Enqueue(new int[] { 2, 5, 8 });

            foreach (var win in wins)
            {
                int tracker = 0;
                foreach (var spot in win)
                {
                    if(board[spot] == "X")
                    {
                        tracker = tracker + 1;
                    }
                    if (board[spot] == "O")
                    {
                        tracker = tracker - 1;
                    }
                }
                if(tracker == 3)
                {
                    winner = "X";
                    return winner;
                }
                if(tracker == -3)
                {
                    winner = "O";
                    return winner;
                }

            }

            

            return winner;
        }

        static public bool CheckForTie(string[] board)
        {
            var counter = 9;
            foreach (var spot in board)
            {
                if ( spot != "_")
                {
                    counter--;
                }
            }
            if (counter == 0)
            {
                return true;
            }
            else return false;
        }

        public static void PlayGame(string[] board)
        {
            var counter = 1;
            var winner = "_";
            while (winner == "_")
            {
                TurnDistribution(board, TurnPicker(counter));
                winner = CheckForWinner(board);
                if (CheckForTie(board) == true)
                {
                    winner = "Cat's Game";
                }
                counter++;
            }

            if (winner == "Cat's Game")
            {
                Console.Clear();
                Console.WriteLine(winner);
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"{CheckForWinner(board)} Wins");
            }
            
            
        }

        public static int TurnPicker(int counter)
        {
            if (counter % 2 == 0)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }

        public static void TurnDistribution(string[] board, int turn)
        {
            if (turn == 1)
            {
                TakeTurnPlayerX(board);
            }
            if (turn == 2)
            {
                TakeTurnPlayerO(board);
            }
        }

        public static bool PlayAgain()
        {
            Console.Clear();
            Console.WriteLine("Play again? Y/N");
            string input = Console.ReadLine();

            if (input.ToLower() == "y")
            {
                return true;
            }
            if (input.ToLower() == "yes")
            {
                return true;
            }
            else return false;
        }

        

    }
}
