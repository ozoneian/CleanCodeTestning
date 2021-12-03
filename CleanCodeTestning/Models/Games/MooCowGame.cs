using CleanCodeTestning.Controllers;
using System;

namespace CleanCodeTestning.Models
{
    internal class MooCowGame : IGame
    {
        int totalGuesses = 0;
        string goal;
        string bbcc;
        const int MaxLength = 4;
        
        public string FilePath => "MooCowScore.csv";

        public int GuessCount => totalGuesses;

        public MooCowGame()
        {
            goal = makeGoal();
        }

        public void IncrementGuess()
        {
            totalGuesses++;
        }

        public bool CheckInput(string guess)
        {
            bbcc = checkBC(goal, guess);

            if (bbcc == "BBBB,")
            {
                return true;
            }
            return false;
        }

        public string GetInstructions()
        {
            return $"New game:\n\nFor practice, number is: {goal} \n";
        }

        public string Output()
        {
            return bbcc + "\n";
        }

        static string makeGoal()
        {
            Random randomGenerator = new Random();
            string goal = "";
            for (int i = 0; i < MaxLength; i++)
            {
                int random = randomGenerator.Next(10);
                string randomDigit = "" + random;
                while (goal.Contains(randomDigit))
                {
                    random = randomGenerator.Next(10);
                    randomDigit = "" + random;
                }
                goal = goal + randomDigit;
            }
            return goal;
        }

        static string checkBC(string goal, string guess)
        {
            int cows = 0, bulls = 0;
            guess += "    ";     // if player entered less than 4 chars
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (goal[i] == guess[j])
                    {
                        if (i == j)
                        {
                            bulls++;
                        }
                        else
                        {
                            cows++;
                        }
                    }
                }
            }
            return "BBBB".Substring(0, bulls) + "," + "CCCC".Substring(0, cows);
        }
    }
}