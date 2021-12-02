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
        private readonly IStoreData _storeData;

        private bool playing;
        private IGame currentGame;
        private string currentPlayer;

        public GameController(IUserInterface ui, IGameFactory gameFactory, IStoreData storeData)
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
                currentGame.AddCounter();

                if (currentGame.CheckInput(_ui.Input()))
                {
                    playing = false;
                    _ui.Output("You won");
                }
            }
        }

        private void ShowScoreBoard()
        {
            _storeData.GetAllPlayerData(currentGame.FilePath);
        }

        private void SaveGame()
        {
            _storeData.Save(currentGame.FilePath);
        }

        private void SelectGame()
        {
            playing = true;
            _ui.Output("Select game: \nMooCow \nMastermind");
            currentGame = _gameFactory.CreateGame(_ui.Input());
        }

        private void PlayerSetUp()
        {
            _ui.Output($"Enter your username:");
            currentPlayer = _ui.Input();
        }
    }
}
