using RockPaperScissors_AfterClass.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors_AfterClass.Services
{
    class GameService
    {
        // User decides either to proceed or to terminate the application
        public static void Menu()
        {
            Console.WriteLine("Welcome. Please press 1 to play a game or 0 to EXIT the application.\n");
            if (int.Parse(Console.ReadLine()) == 1) NewRound();
            FinishGame();
        }

        // Ask the user to decide if they want to continue, before each round
        private static void NewRound()
        {
            Console.Clear();
            Console.WriteLine("Play a new round (Y/N) ?");
            string str = Console.ReadLine();
            
            // Check if the input is empty
            if (string.IsNullOrWhiteSpace(str))
            {
                Console.Clear();
                Console.WriteLine("The answer cannot be empty");
                Console.ReadKey();
                NewRound();
            }
            char answer = Convert.ToChar(str.ToUpper());

            // Check if the user's input is correct and take appropriate actions
            if (answer == 'Y')
            {
                Round();
            }
            else if (answer != 'N')
            {
                Console.Clear();
                Console.WriteLine("Answer not acceptable");
                Console.ReadKey();
                NewRound();
            }
        }

        // Get user's choice and a random choice for the computer
        private static void Round()
        {
            // Show the available choices menu
            var playerChoice = Submenu();

            var computerChoice = Choice(new Random().Next(0, 3));

            CheckRoundWin(playerChoice, computerChoice);

        }

        // Get player's choice
        private static RPS Submenu()
        {
            Console.Clear();
            Console.WriteLine("Please press: ");
            Console.WriteLine("1 for Rock");
            Console.WriteLine("2 for Paper");
            Console.WriteLine("3 for Scissors");
            Console.WriteLine("Press any other key for random choice\n");

            int choice = int.Parse(Console.ReadLine());
            return PlayerChoice(choice);
        }

        // Gets an integer as player's choice checks if it responds to an appropriate enum value
        private static RPS PlayerChoice(int choice)
        {
            if (choice < 1 || choice > 3) return Choice(new Random().Next(0, 3));

            return Choice(choice - 1);
        }

        // Gets an integer and returns the respective enum value
        private static RPS Choice(int choice)
        {
            if (choice == 0)
            {
                return RPS.Rock;
            }
            else if (choice == 1)
            {
                return RPS.Paper;
            }
            else
            {
                return RPS.Scissors;
            }
        }

        // Compares two choices and returns the round winner
        private static void CheckRoundWin(RPS player, RPS computer)
        {
            Console.Clear();
            Console.WriteLine($"{player}(Player) VS {computer}(Computer)");
            if (player == computer)
            {
                Console.WriteLine("Nobody wins the round\n");
                Program.ties += 1;
            }
            else if ((player == RPS.Rock && computer == RPS.Paper) || (player == RPS.Paper && computer == RPS.Scissors))
            {
                Console.WriteLine("Computer wins the round\n");
                Program.computerWins += 1;
            }
            else
            {
                Console.WriteLine("Player wins the round\n");
                Program.playerWins += 1;
            }
            Console.ReadKey();
            NewRound();
        }

        // Compares the counters and determines who won the game
        private static void FinishGame()
        {
            Console.Clear();
            // Checks if at least one round was played
            if (Program.ties == 0 && Program.playerWins == 0 && Program.computerWins == 0)
            {
                Console.WriteLine("No rounds were played");
            }
            else
            {
                // Prints the total rounds played and the amount of each possible outcome
                Console.WriteLine($"{"Total Rounds Played:",-25}{Program.playerWins + Program.computerWins + Program.ties}\n" +
                                    $"{"Player wins:",-25}{Program.playerWins}\n{"Computer wins:",-25}{Program.computerWins}\n" +
                                    $"{"Ties:",-25}{Program.ties}\n");

                // Prints the final winner, if one exists
                if (Program.playerWins > Program.computerWins)
                {
                    Console.WriteLine("Player wins the game!");
                }
                else if (Program.playerWins < Program.computerWins)
                {
                    Console.WriteLine("Computer wins the game!");
                }
                else
                {
                    Console.WriteLine("The game ended with a tie!");
                }
            }
            Console.ReadKey();
            Exit();
        }

        // Exits the application
        private static void Exit()
        {
            Console.Clear();
            Console.WriteLine("Goodbye\n");
        }
    }
}
