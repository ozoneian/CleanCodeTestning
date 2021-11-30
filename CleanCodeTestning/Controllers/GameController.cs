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

        public GameController(IUserInterface ui, IGameFactory gameFactory, IStoreData storeData)
        {
            _ui = ui;
            _gameFactory = gameFactory;
            _storeData = storeData;
        }

        public void Run()
        {
            PlayerSetUp();
            var game = SelectGame();

            PlayGame(game);
            //too much responsibility?
            //game.play();
            //PlayGame();
            //SaveGame();
            //ShowScoreBoard();
        }

        private void PlayGame(IGame game)
        {
            game.Play();
        }

        private IGame SelectGame()
        {
            var input = _ui.Input();
            return _gameFactory.CreateGame(input);
        }

        private void PlayerSetUp()
        {
            throw new NotImplementedException();
        }
    }
}
