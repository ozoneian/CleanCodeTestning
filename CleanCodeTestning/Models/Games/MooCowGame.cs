using CleanCodeTestning.Controllers;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CleanCodeTestningTest")]
namespace CleanCodeTestning.Models
{
    internal class MooCowGame : IGame
    {
        public static string answer;
        internal string bbcc;
        internal const int MaxLength = 4;
        public string FilePath => "MooCowScore.csv";

        public int GuessCount { get; private set; }

        public MooCowGame()
        {
            GenerateAnswer();
        }

        public void IncrementGuess()
        {
            GuessCount++;
        }

        public bool CheckInput(string guess)
        {
            bbcc = CheckGuess(FormatInput(guess));

            if (bbcc == "BBBB,")
            {
                return true;
            }
            return false;
        }

        internal string FormatInput(string guess)
        {
            return (guess + "    ").Substring(0, 4);
        }

        public string GetInstructions()
        {
            return $"New game:\n\nFor practice, number is: {answer} \n";
        }

        public string Output()
        {
            return bbcc + "\n";
        }

        internal static void GenerateAnswer()
        {
            Random rnd = new Random();
            List<int> uniqueDigits = new();

            for (int i = 0; i < MaxLength; i++)
            {
                int rndDigit;
                do
                {
                    rndDigit = rnd.Next(0, 10);

                } while (uniqueDigits.Contains(rndDigit));

                uniqueDigits.Add(rndDigit);
            }

            answer = string.Join("", uniqueDigits);
        }

        internal static string CheckGuess(string guess)
        {
            int cows = 0, bulls = 0;
            for (int i = 0; i < answer.Length; i++)
            {
                for (int j = 0; j < answer.Length; j++)
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