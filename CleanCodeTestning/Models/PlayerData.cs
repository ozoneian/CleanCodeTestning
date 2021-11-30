using System;

namespace CleanCodeTestning
{
    class PlayerData
	{
		public string Name { get; private set; }
		public int TotalGames { get; private set; }
		int totalGuess;


		public PlayerData(string name, int guesses)
		{
			this.Name = name;
			TotalGames = 1;
			totalGuess = guesses;
		}

		public void Update(int guesses)
		{
			totalGuess += guesses;
			TotalGames++;
		}

		public double Average()
		{
			return (double)totalGuess / TotalGames;
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
