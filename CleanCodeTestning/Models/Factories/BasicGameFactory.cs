using CleanCodeTestning.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeTestning.Models
{
    public class BasicGameFactory : IGameFactory
    {
        Dictionary<string, Func<IGame>> games = new Dictionary<string, Func<IGame>>()
        {
            {"MooCow".ToLower(), () => new MooCowGame()},
            {"Mastermind".ToLower(), () => new MastermindGame()}
        };

        public IGame CreateGame(string name)
        {
            return games[name.ToLower()].Invoke();
        }

        public IGame CreateMooCow()
        {
            return new MooCowGame();
        }

        public override string ToString()
        {
            return string.Join("\n", games.Keys);
        }
    }
}
