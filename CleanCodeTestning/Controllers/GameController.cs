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
        }

        private void PlayGame()
        {
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
            var results = _storeData.GetAllPlayerData(currentGame.FilePath);
            
            results.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));
            _ui.Output("Player   games average");
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
            _ui.Output("Select game: \nMooCow \nMastermind"); //TODO: 
            currentGame = _gameFactory.CreateGame(_ui.Input());
        }

        private void PlayerSetUp()
        {
            _ui.Output($"Enter your username:");
            currentPlayer = _ui.Input();
        }
    }
}
