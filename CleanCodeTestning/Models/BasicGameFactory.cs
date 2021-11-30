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
        public IGame CreateGame(string name)
        {
            switch (name)
            {
                case "MooCow":
                    return new MooCowGame();
                case "Mastermind":
                    return new MastermindGame();
                default:
                    return null;
            }
        }
    }
}
