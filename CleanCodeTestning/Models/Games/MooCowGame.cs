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
        
        public string FilePath => "";

        public MooCowGame()
        {
            goal = makeGoal();
        }

        public void AddCounter()
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

        private void Code()
        {
                //StreamWriter output = new StreamWriter("result.txt", append: true);
                //output.WriteLine(name + "#&#" + nGuess);
                //output.Close();
                //showTopList();
                //Console.WriteLine("Correct, it took " + nGuess + " guesses\nContinue?");
                //string answer = Console.ReadLine();
                //if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
                //{
                //    playOn = false;
                //}
            //}

            //static void showTopList()
            //{
            //    StreamReader input = new StreamReader("result.txt");
            //    List<PlayerData> results = new List<PlayerData>();
            //    string line;
            //    while ((line = input.ReadLine()) != null)
            //    {
            //        string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
            //        string name = nameAndScore[0];
            //        int guesses = Convert.ToInt32(nameAndScore[1]);
            //        PlayerData pd = new PlayerData(name, guesses);
            //        int pos = results.IndexOf(pd);
            //        if (pos < 0)
            //        {
            //            results.Add(pd);
            //        }
            //        else
            //        {
            //            results[pos].Update(guesses);
            //        }


            //    }
            //    results.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));
            //    Console.WriteLine("Player   games average");
            //    foreach (PlayerData p in results)
            //    {
            //        Console.WriteLine(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.TotalGames, p.Average()));
            //    }
            //    input.Close();
            //}
        }
    }
}