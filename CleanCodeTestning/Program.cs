using CleanCodeTestning.Controllers;
using CleanCodeTestning.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace CleanCodeTestning
{
    class Program
    {
		public static void Main(string[] args)
		{
			IUserInterface userInterface = new ConsoleUI();
			IGameFactory gameFactory = new BasicGameFactory();
			IStoreData storeData = new CsvStore();

			GameController gameController = new GameController(userInterface, gameFactory, storeData);

			gameController.Run();
		}
		
	}
}
