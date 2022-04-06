using System;

namespace Workspace_1
{
    class PalamPoloomPlush
    {
        static void Main(string[] args)
        {
            int userScore = 0, computer1Score = 0, computer2Score = 0;
            int i = 0;

            while (userScore != 5 && computer1Score != 5 && computer2Score != 5)
            {
                string[] options = { "Ro", "Posht" };

                Random r1 = new Random();
                int cc1n = r1.Next(0, 2);
                string computer1Choice = options[cc1n];

                Random r2 = new Random();
                int cc2n = r2.Next(0, 2);
                string computer2Choice = options[cc2n];

                Console.WriteLine("Round " + (i + 1) + "\r\nPlease Write Number of Your Choice:\r\n1-Ro 2-Posht:");
                int ucn = Convert.ToInt32(Console.ReadLine()) - 1;
                string userChoice = options[ucn];

                if (ucn != cc1n && cc1n == cc2n)
                {
                    userScore++;
                }
                else if (cc1n != ucn && ucn == cc2n)
                {
                    computer1Score++;
                }
                else if (cc2n != ucn && ucn == cc1n)
                {
                    computer2Score++;
                }
                else
                {
                    /*Nothing*/
                }

                i++;

                Console.WriteLine("User Choice:       " + userChoice);
                Console.WriteLine("Computer 1 Choice: " + computer1Choice);
                Console.WriteLine("Computer 2 Choice: " + computer2Choice);

                Console.WriteLine("User Score:        " + userScore);
                Console.WriteLine("Computer 1 Score:  " + computer1Score);
                Console.WriteLine("Computer 2 Score:  " + computer2Score);
                Console.WriteLine("-----------------------------");
            }

            if (userScore == 5)
            {
                Console.WriteLine("User Win");
            }
            else if (computer1Score == 5)
            {
                Console.WriteLine("Computer 1 Win");
            }
            else
            {
                Console.WriteLine("Computer 2 Win");
            }
        }
    }
}

