using System;
using System.Collections.Generic;
using System.IO;

namespace CleanCodeTestning
{
    internal class CsvRepository : IRepository
    {
        public List<PlayerData> GetAllPlayerData(string filePath)
        {
            List<PlayerData> results = GetPlayerDataFromFile(filePath);

            results.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));

            return results;
        }

        private List<PlayerData> GetPlayerDataFromFile(string filePath)
        {
            List<PlayerData> results = new List<PlayerData>();

            using (StreamReader input = new StreamReader(filePath))
            {
                string line;
                while ((line = input.ReadLine()) != null)
                {
                    var pd = CreatePlayerData(line);
                    int pos = results.IndexOf(pd);
                    if (pos < 0)
                    {
                        results.Add(pd);
                    }
                    else
                    {
                        results[pos].Update(pd.TotalGuesses);
                    }
                }
            }

            return results;
        }

        private PlayerData CreatePlayerData(string line)
        {
            string[] nameAndScore = line.Split(new string[] { "," }, StringSplitOptions.None);

            string name = nameAndScore[0];
            int guesses = Convert.ToInt32(nameAndScore[1]);

            return new PlayerData(name, guesses);
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