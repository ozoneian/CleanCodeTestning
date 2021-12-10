using System;
using System.Collections.Generic;
using System.IO;

namespace CleanCodeTestning
{
    internal class CsvRepository : IRepository
    {
        public List<PlayerData> GetAllPlayerData(string filePath)
        {
            using (StreamReader input = new StreamReader(filePath))
            {
                List<PlayerData> results = new List<PlayerData>();
                string line;
                while ((line = input.ReadLine()) != null)
                {
                    string[] nameAndScore = line.Split(new string[] { "," }, StringSplitOptions.None);
                    string name = nameAndScore[0];
                    int guesses = Convert.ToInt32(nameAndScore[1]);
                    PlayerData pd = new PlayerData(name, guesses);
                    int pos = results.IndexOf(pd);
                    if (pos < 0)
                    {
                        results.Add(pd);
                    }
                    else
                    {
                        results[pos].Update(guesses);
                    }
                }

                results.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));

                return results;
            }
        }

        public void Save(string filePath, PlayerData pd)
        {
            using (StreamWriter output = new StreamWriter(filePath, append: true))
            {
                output.WriteLine(pd.Name + "," + pd.TotalGuesses);
            }
        }
    }
}