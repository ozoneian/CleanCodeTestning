using CleanCodeTestning;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeTestningTest
{
    [TestFixture]
    public class PlayerDataTest
    {
        private PlayerData playerData;

        [SetUp]
        public void SetUp()
        {
            playerData = new PlayerData("Kurt", 3);
        }

        [Test]
        public void Update_Should_Add_Guesses_To_TotalGuesses_And_Increment_TotalGames_By_One()
        {
            playerData.Update(2);

            Assert.That(5, Is.EqualTo(playerData.TotalGuesses));
            Assert.That(2, Is.EqualTo(playerData.TotalGames));
        }

        [Test]
        public void Average_Should_Return_TotalGuesses_Divided_By_TotalGames()
        {
            var actual = playerData.Average();

            Assert.That(3, Is.EqualTo(actual).Within(0.1));
        }

        [Test]
        public void Equals_Should_Check_Equality_On_Name()
        {
            var equalResult = playerData.Equals(new PlayerData("Kurt", 2));

            Assert.That(equalResult, Is.True);
        }

        [Test]
        public void GetHashCode_Should_Hash_On_Name()
        {
            var result = playerData.GetHashCode();

            Assert.That(result, Is.EqualTo(new PlayerData("Kurt", 2).GetHashCode()));
        }
    }
}
