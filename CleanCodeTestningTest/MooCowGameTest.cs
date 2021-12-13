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
        public void IncrementGuess_Should_Increment_GuessCount_By_One()
        {
            var mooCow = new MooCowGame();
            Assert.That(mooCow.GuessCount, Is.EqualTo(0));

            mooCow.IncrementGuess();

            Assert.That(mooCow.GuessCount, Is.EqualTo(1));
        }

        [Test]
        public void CheckInput_Should_Return_True_When_Input_Is_Correct()
        {
            var moocow = new MooCowGame();
            MooCowGame.answer = "1234";

            var result = moocow.CheckInput("1234");

            Assert.That(result, Is.True);
        }

        [Test]
        public void CheckInput_Should_Return_False_When_Input_Is_InCorrect()
        {
            var moocow = new MooCowGame();
            MooCowGame.answer = "1234";

            var result = moocow.CheckInput("2345");

            Assert.That(result, Is.False);
        }

        [Test]
        public void GetInstructions_Should_Return_Instructions()
        {
            var moocow = new MooCowGame();
            var output = $"New game:\n\nFor practice, number is: {MooCowGame.answer} \n";

            var actual = moocow.GetInstructions();

            Assert.That(actual, Is.EqualTo(output));
        }

        [Test]
        public void Output_Should_Return_BBCC()
        {
            var moocow = new MooCowGame();
            var output = moocow.bbcc + "\n";

            var actual = moocow.Output();

            Assert.That(actual, Is.EqualTo(output));
        }

        [Test]
        public void FormatInput_Should_Append_Whitespaces_Then_Return_The_First_Four_Chars()
        {
            var moocow = new MooCowGame();

            var actual = moocow.FormatInput("12");

            Assert.That(actual, Is.EqualTo("12  "));
        }

        [Test]
        public void GenerateAnswer_Should_Generate_Unique_Numbers()
        {
            MooCowGame.GenerateAnswer();

            Assert.That(MooCowGame.MaxLength, Is.EqualTo(4));
            Assert.That(MooCowGame.answer, Is.Unique);
        }

        [Test]
        public void CheckGuess_Should_Generate_Two_Bulls_And_One_Cow()
        {
            MooCowGame.answer = "1234";

            var result = MooCowGame.CheckGuess("3734");

            Assert.That(result, Is.EqualTo("BB,C"));
        }

        [Test]
        public void CheckGuess_Should_Generate_Four_Bulls()
        {
            MooCowGame.answer = "1234";

            var result = MooCowGame.CheckGuess("1234");

            Assert.That(result, Is.EqualTo("BBBB,"));
        }
    }
}
