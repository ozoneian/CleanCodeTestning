using CleanCodeTestning.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeTestningTest
{
    [TestFixture]
    public class BasicGameFactoryTest
    {
        private BasicGameFactory basicGameFactory;

        [SetUp]
        public void SetUp()
        {
            basicGameFactory = new BasicGameFactory();
        }

        [Test]
        public void CreateGame_Should_Create_Mastermind()
        {
            var game = basicGameFactory.CreateGame("mastermind");

            Assert.That(game, Is.TypeOf<MastermindGame>());
        }

        [Test]
        public void CreateGame_Should_Create_MooCow()
        {
            var game = basicGameFactory.CreateGame("moocow");

            Assert.That(game, Is.TypeOf<MooCowGame>());
        }

        [Test]
        public void CreateGame_Should_Throw_Exception_When_Game_Doesnt_Exist()
        {
            Assert.Throws<KeyNotFoundException>(
                () => basicGameFactory.CreateGame("notExist"));
        }

        [Test]
        public void ToString_Return_All_Keys_In_Dictionary_Seperated_By_Newline()
        {
            var gameNames = new List<string>()
            {
                "MooCow".ToLower(),
                "Mastermind".ToLower()
            };
            var expected = string.Join("\n", gameNames);

            var actual = basicGameFactory.ToString();

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
