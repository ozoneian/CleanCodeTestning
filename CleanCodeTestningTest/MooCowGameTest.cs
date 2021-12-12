using NUnit.Framework;
using CleanCodeTestning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanCodeTestning.Models;

namespace CleanCodeTestningTest
{
    [TestFixture]
    public class MooCowGameTest
    {
        [Test]
        public void ÏncrementGuess_Should_Increment_GuessCount_By_One()
        {
            var mooCow = new MooCowGame();
            Assert.That(0, Is.EqualTo(mooCow.GuessCount));

            mooCow.IncrementGuess();

            Assert.That(1, Is.EqualTo(mooCow.GuessCount));
        }

        [Test]
        public void CheckInput_Should()
        {

        }

        [Test]
        public void GetInstructions_Should()
        {

        }

        [Test]
        public void Output_Should()
        {

        }

        [Test]
        public void GenerateAnswer_Should()
        {

        }

        [Test]
        public void CheckGuess_Should()
        {

        }
    }
}
