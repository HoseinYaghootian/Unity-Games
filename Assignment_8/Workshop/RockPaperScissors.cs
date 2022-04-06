using System;

namespace Workspace
{
    class RockPaperScissors
    {
        static void Main(string[] args)
        {
            int userScore = 0, computerScore = 0;
            int roundNumber = 5;

            for (int i = 0; i < roundNumber; i++)
            {
                string[] options = { "Rock", "Paper", "Scissor" };

                Random r = new Random();
                int ccn = r.Next(0, 3);
                string computerChoice = options[ccn];

                Console.WriteLine("Round " + (i + 1) + "\r\nPlease Write Number of Your Choice:\r\n1-Rock 2-Paper 3-Scissor:");
                int ucn = Convert.ToInt32(Console.ReadLine());
                string userChoice = options[ucn - 1];

                if (userChoice == "Rock" && computerChoice == "Scissor" || userChoice == "Paper" && computerChoice == "Rock" || userChoice == "Scissor" && computerChoice == "Paper")
                {
                    userScore++;
                }
                else if (userChoice == computerChoice)
                {
                    /*Nothing*/
                }
                else
                {
                    computerScore++;
                }

                Console.WriteLine("User Choice:     " + userChoice);
                Console.WriteLine("Computer Choice: " + computerChoice);
                Console.WriteLine("User Score:      " + userScore);
                Console.WriteLine("Computer Score:  " + computerScore);
                Console.WriteLine("-----------------------------");

                //Early Win!
                if (roundNumber - i < userScore || roundNumber - i < computerScore)
                {
                    break;
                }
            }

            if (userScore > computerScore)
            {
                Console.WriteLine("User Win");
            }
            else if (userScore < computerScore)
            {
                Console.WriteLine("Computer Win");
            }
            else
            {
                Console.WriteLine("Draw");
            }
        }
    }
}

