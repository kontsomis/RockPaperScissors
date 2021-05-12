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
        public static void Menu()
        {
            Console.WriteLine("Welcome. Please press 1 to play a game or 0 to EXIT the application.\n");
            if (int.Parse(Console.ReadLine()) == 1) NewRound();
            Exit();
        }

        private static void NewRound()
        {
            Console.Clear();
            Console.WriteLine("Play a new round (Y/N) ?");
            string str = Console.ReadLine();
            char answer = Convert.ToChar(str.ToUpper());
            if (answer == 'Y')
            {
                Round();
            }
            else if (answer == 'N')
            {
                FinishGame();
            }
            else
            {
                Console.WriteLine("Answer not acceptable");
                NewRound();
            }
        }

        private static void Round()
        {
            var playerChoice = Submenu();

            var computerChoice = Choice(new Random().Next(0, 3));

            CheckWin(playerChoice, computerChoice);

        }

        private static RPS Submenu()
        {
            Console.Clear();
            Console.WriteLine("Please press: ");
            Console.WriteLine("1 for Rock");
            Console.WriteLine("2 for Paper");
            Console.WriteLine("3 for Scissors\n");

            return Choice(int.Parse(Console.ReadLine()) - 1);
        }


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

        private static void CheckWin(RPS player, RPS computer)
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

        private static void FinishGame()
        {
            Console.Clear();
            if (Program.ties == 0 && Program.playerWins == 0 && Program.computerWins == 0)
            {
                Console.WriteLine("No rounds were played");
            }
            else
            {
                Console.WriteLine($"{"Total Rounds Played:",-25}{Program.playerWins + Program.computerWins + Program.ties}\n{"Player wins:",-25}{Program.playerWins}\n{"Computer wins:",-25}{Program.computerWins}\n{"Ties:",-25}{Program.ties}\n");
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

        private static void Exit()
        {
            Console.Clear();
            Console.WriteLine("Goodbye\n");
        }
    }
}
