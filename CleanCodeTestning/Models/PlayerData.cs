using System;

namespace CleanCodeTestning
{
    public class PlayerData
	{
		public string Name { get; private set; }
		public int TotalGames { get; private set; }
		public int TotalGuesses;

		public PlayerData(string name, int guesses)
		{
			this.Name = name;
			TotalGames = 1;
			TotalGuesses = guesses;
		}

		public void Update(int guesses)
		{
			TotalGuesses += guesses;
			TotalGames++;
		}

		public double Average()
		{
			return (double)TotalGuesses / TotalGames;
		}

		public override bool Equals(Object p)
		{
			return Name.Equals(((PlayerData)p).Name);
		}

		public override int GetHashCode()
		{
			return Name.GetHashCode();
		}
	}
}
