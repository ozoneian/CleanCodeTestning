using CleanCodeTestning.Controllers;
using System;

namespace CleanCodeTestning.Models
{
    internal class MooCowGame : IGame
    {
        int totalGuesses = 0;
        public static string answer;
        string bbcc;
        const int MaxLength = 4;
        
        public string FilePath => "MooCowScore.csv";

        public int GuessCount => totalGuesses;

        public MooCowGame()
        {
            answer = GenerateAnswer();
        }

        public void IncrementGuess()
        {
            totalGuesses++;
        }

        public bool CheckInput(string guess)
        {
            bbcc = CheckGuess(guess);

            if (bbcc == "BBBB,")
            {
                return true;
            }
            return false;
        }

        public string GetInstructions()
        {
            return $"New game:\n\nFor practice, number is: {answer} \n";
        }

        public string Output()
        {
            return bbcc + "\n";
        }

        static string GenerateAnswer()
        {
            Random randomGenerator = new Random();
            string answer = "";
            for (int i = 0; i < MaxLength; i++)
            {
                int random = randomGenerator.Next(10);
                string randomDigit = "" + random;
                while (answer.Contains(randomDigit))
                {
                    random = randomGenerator.Next(10);
                    randomDigit = "" + random;
                }
                answer = answer + randomDigit;
            }
            return answer;
        }

        static string CheckGuess(string guess)
        {
            int cows = 0, bulls = 0;
            guess += "    ";     // if player entered less than 4 chars
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (answer[i] == guess[j])
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