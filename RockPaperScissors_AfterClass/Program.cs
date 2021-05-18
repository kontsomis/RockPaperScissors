using RockPaperScissors_AfterClass.Enums;
using RockPaperScissors_AfterClass.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors_AfterClass
{
    class Program
    {
        // Couters to decide the outcome of the game
        public static int ties = 0;
        public static int playerWins = 0;
        public static int computerWins = 0;

        static void Main(string[] args)
        {
            // Initiate the application by showing the main menu
            GameService.Menu();
        }        
    }
}
