using CleanCodeTestning.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeTestning.Controllers
{
    public class GameController
    {
        private readonly IUserInterface _ui;
        private readonly IGameFactory _gameFactory;
        private readonly IRepository _storeData;

        private bool playing;
        private IGame currentGame;
        private string currentPlayer;
        PlayerData playerData;

        public GameController(IUserInterface ui, IGameFactory gameFactory, IRepository storeData)
        {
            _ui = ui;
            _gameFactory = gameFactory;
            _storeData = storeData;
        }

        public void Run()
        {
            PlayerSetUp();
            SelectGame();
            PlayGame();
            SaveGame();
            ShowScoreBoard();
            PlayAgain();
        }

        private void PlayAgain()
        {
            _ui.Output("\n\nWould you like to play again? Y/N");
            var playAgain = _ui.Input();

            if (playAgain.ToLower() == "y")
            {
                _ui.Clear();
                Run();
            }

            _ui.Quit();
        }

        private void PlayGame()
        {
            _ui.Clear();
            _ui.Output(currentGame.GetInstructions());

            while (playing)
            {
                _ui.Output(currentGame.Output());
                currentGame.IncrementGuess();

                if (currentGame.CheckInput(_ui.Input()))
                {
                    playing = false;
                    _ui.Output("You won");
                }
            }
        }

        private void ShowScoreBoard()
        {
            _ui.Clear();

            var results = _storeData.GetAllPlayerData(currentGame.FilePath);

            PrintHighscore(results);
        }

        private void PrintHighscore(List<PlayerData> results)
        {
            _ui.Output($"HighSore\n");

            _ui.Output(string.Format("{0,-9}{1,5}{2,9:F2}\n", "Player", "Games", "Average"));

            foreach (PlayerData p in results)
            {
                _ui.Output(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.TotalGames, p.Average()));
            }
        }

        private void SaveGame()
        {
            playerData = new(currentPlayer, currentGame.GuessCount);
            _storeData.Save(currentGame.FilePath, playerData);
        }

        private void SelectGame()
        {
            playing = true;
            _ui.Output($"Select game: \n{ _gameFactory.ToString()} \nEnter the name of the game: ");

            CreateGame();
        }

        private void CreateGame()
        {
            bool isPicking = true;
            do
            {
                try
                {
                    currentGame = _gameFactory.CreateGame(_ui.Input());
                    isPicking = false;
                }
                catch (KeyNotFoundException)
                {
                    _ui.Output(Validator.GameNameInvalid);
                }

            } while (isPicking);
        }

        private void PlayerSetUp()
        {
            _ui.Output($"Enter your username:");
            currentPlayer = _ui.Input();
        }
    }
}
