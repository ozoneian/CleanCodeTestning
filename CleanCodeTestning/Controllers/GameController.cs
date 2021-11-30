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

        public GameController(IUserInterface ui)
        {
            _ui = ui;
        }

        public void Run()
        {
            PlayerSetUp();
            SelectGame();
            //too much responsibility?
            //game.play();
            //PlayGame();
            //SaveGame();
            //ShowScoreBoard();
        }

        private void PlayGame()
        {
            throw new NotImplementedException();
        }

        private void SelectGame()
        {
            throw new NotImplementedException();
        }

        private void PlayerSetUp()
        {
            throw new NotImplementedException();
        }
    }
}
