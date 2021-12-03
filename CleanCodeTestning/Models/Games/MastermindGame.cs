using CleanCodeTestning.Controllers;
using System;

namespace CleanCodeTestning.Models
{
    internal class MastermindGame : IGame
    {
        const int MAX_NUMBER = 6666;
        const int MIN_NUMBER = 1111;
        const int MAX_INDIV_NUMBER = 6;
        const int MIN_INDIV_NUMBER = 1;

        int secretCode;
        string guessFeedback = "\nScore: ";
        public string FilePath => "Mastermind.csv";

        public int GuessCount => intGuesses;

        public MastermindGame()
        {
            secretCode = GenerateSecretCode();
        }

        int intGuesses = 0;


        bool[] guessAry = { false, false, false, false };
        bool[] answerAry = { false, false, false, false };

        public void IncrementGuess()
        {
            intGuesses++;
        }

        public bool CheckInput(string s)
        {
            int intUserGuess = 0;

            if (isGuessCorrectFormat(ref s, secretCode))
            {
                intUserGuess = Int32.Parse(s);

                if (intUserGuess == secretCode) //Game has been won.
                {
                    return true;
                }

                int inPlaceCount = getInPlaceCount(intUserGuess, guessAry, answerAry, secretCode);
                int outOfPlaceCount = getOutOfPlaceCount(intUserGuess, guessAry, answerAry, secretCode);

                string strFeedback = "";

                switch (inPlaceCount)
                {
                    case 0:
                        break;
                    case 1:
                        strFeedback += "+";
                        break;
                    case 2:
                        strFeedback += "++";
                        break;
                    case 3:
                        strFeedback += "+++";
                        break;
                }
                switch (outOfPlaceCount)
                {
                    case 0:
                        break;
                    case 1:
                        strFeedback += "-";
                        break;
                    case 2:
                        strFeedback += "--";
                        break;
                    case 3:
                        strFeedback += "---";
                        break;
                    case 4:
                        strFeedback += "----";
                        break;
                }

                guessFeedback = strFeedback;
            }
            else
                Console.WriteLine("Make sure your input is between 1111 and 6666, with each digit being no larger that 6.");

            return false;
        }

        public string GetInstructions()
        {
            return $"Welcome to Mastermind! Answer is {secretCode}";
        }

        public string Output()
        {
            return $"{guessFeedback}\nNumber of guesses: {intGuesses.ToString()} \nMake your guess: \n";
        }

        //private static bool EndGameDisplay()
        //{
        //    Console.WriteLine("\nWould you like to play again? (Y/N)\n");
        //    while (true)
        //    {
        //        string strPlayAgain = Console.ReadLine();
        //        if (strPlayAgain == "N" || strPlayAgain == "n" || strPlayAgain == "No" || strPlayAgain == "no")
        //        {
        //            return false;
        //        }
        //        else if (strPlayAgain == "Y" || strPlayAgain == "y" || strPlayAgain == "Yes" || strPlayAgain == "yes")
        //        {
        //            return true;
        //        }
        //        Console.WriteLine("\nPlease enter either a Y or a N.\n");
        //    }
        //}
        private static int GenerateSecretCode()
        {
            string strCraftedNum = "";
            Random srand = new Random((Int32)DateTime.Now.Ticks);
            for (int i = 0; i < 4; i++)
            {
                strCraftedNum = strCraftedNum.Insert(strCraftedNum.Length, srand.Next(MIN_INDIV_NUMBER, MAX_INDIV_NUMBER).ToString());
            }
            return Int32.Parse(strCraftedNum);
        }
        public static int getOutOfPlaceCount(int userGuess, bool[] guessAry, bool[] answerAry, int intSecretCode)
        {
            int outOfPlaceCount = 0;
            int guessDigit;
            int randDigit;
            int tempRand = intSecretCode;

            for (int i = 0; i < 4; i++)
            {
                guessDigit = userGuess % 10;
                userGuess = userGuess / 10;
                randDigit = tempRand % 10;
                tempRand = intSecretCode;
                if (guessAry[i] == false)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        randDigit = tempRand % 10;
                        tempRand = tempRand / 10;
                        if (answerAry[j] == false)
                        {
                            if (guessDigit == randDigit)
                            {
                                outOfPlaceCount++;
                                guessAry[i] = true;
                                answerAry[j] = true;
                                break;
                            }
                        }
                    }
                }
            }
            return outOfPlaceCount;
        }

        private static bool isGuessCorrectFormat(ref string strUserGuess, int intSecretCode)
        {
            int intUserGuess = 0;
            try
            {
                intUserGuess = Int32.Parse(strUserGuess);
                int guessDigit = 0;
                int tempGuess = intUserGuess;
                for (int i = 0; i < 4; i++)
                {
                    guessDigit = tempGuess % 10;
                    if (guessDigit > MAX_INDIV_NUMBER || guessDigit < MIN_INDIV_NUMBER || intUserGuess < MIN_NUMBER || intUserGuess > MAX_NUMBER)
                    {
                        throw (new Exception());
                    }
                }
            }
            catch
            {
                Console.WriteLine("\nMake sure your input is between 1111 and 6666, with each digit being no larger that 6.");
                System.Threading.Thread.Sleep(2000);
                Console.WriteLine("\nMake your guess:\n");
                strUserGuess = Console.ReadLine();
                if (isGuessCorrectFormat(ref strUserGuess, intSecretCode))
                    return true;
                return false;
            }
            return true;
        }
        private static int getInPlaceCount(int intUserGuess, bool[] guessAry, bool[] answerAry, int intSecretCode)
        {
            for (int i = 0; i < 4; i++)
            {
                guessAry[i] = false;
                answerAry[i] = false;
            }

            int inPlaceCount = 0;
            int guessDigit = 0;
            int randDigit = 0;
            int tempGuess = intUserGuess;
            int tempRand = intSecretCode;

            for (int i = 0; i < 4; i++)
            {
                guessDigit = tempGuess % 10;
                tempGuess = tempGuess / 10;
                randDigit = tempRand % 10;
                tempRand = tempRand / 10;

                if (guessDigit == randDigit)
                {
                    guessAry[i] = true;
                    answerAry[i] = true;
                    inPlaceCount++;
                }
            }
            return inPlaceCount;
        }
    }
}