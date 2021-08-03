using MastermindLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static MastermindLibrary.Enums;
using static MastermindLibrary.Constants;

namespace MastermindLibraryTest
{
    [TestClass]
    public class MastermindGameLogicUnitTest
    {
        #region methods

        #region public methods

        /// <summary>
        /// testmethod with different amount of colors in both arrays
        /// </summary>
        [TestMethod]
        public void TestMethodMissmatch()
        {
            //Arrange
            Farbe?[] secret = {Farbe.Blau, Farbe.Braun};
            Farbe?[] guess = {Farbe.Blau};

            //Act and Assert
            StringAssert.Contains(MastermindGameLogic.GetGameResult(secret, guess), MissmatchError);
        }

        /// <summary>
        /// testmethod with no colors in both arrays
        /// </summary>
        [TestMethod]
        public void TestMethodNoInput()
        {
            //Arrange
            Farbe?[] secret = { };
            Farbe?[] guess = { };

            //Act and Assert
            StringAssert.Contains(MastermindGameLogic.GetGameResult(secret, guess), NoInputError);
        }

        /// <summary>
        /// testmethod without matches in both arrays
        /// </summary>
        [TestMethod]
        public void TestMethodNoMatches()
        {
            //Arrange
            Farbe?[] secret = {Farbe.Blau, Farbe.Braun};
            Farbe?[] guess = {Farbe.Grün, Farbe.Gelb};
            string excpected = $"no {nameof(wellplaced)} and no {nameof(missplaced)}";

            //Act
            string actual = MastermindGameLogic.GetGameResult(secret, guess);

            //Assert
            Assert.AreEqual(excpected, actual);
        }

        /// <summary>
        /// testmethod with only missplaced colors
        /// </summary>
        [TestMethod]
        public void TestMethodOnlyMissplaced()
        {
            //Arrange
            Farbe?[] secret = {Farbe.Blau, Farbe.Braun, Farbe.Rot};
            Farbe?[] guess = {Farbe.Braun, Farbe.Grün, Farbe.Blau};
            string excpected = $"0 {nameof(wellplaced)} and 2 {nameof(missplaced)}";

            //Act
            string actual = MastermindGameLogic.GetGameResult(secret, guess);

            //Assert
            Assert.AreEqual(excpected, actual);
        }

        /// <summary>
        /// testmethod with only wellplaced colors
        /// </summary>
        [TestMethod]
        public void TestMethodOnlyWellplaced()
        {
            //Arrange
            Farbe?[] secret = {Farbe.Blau, Farbe.Braun};
            Farbe?[] guess = {Farbe.Grün, Farbe.Braun};
            string excpected = $"1 {nameof(wellplaced)} and 0 {nameof(missplaced)}";

            //Act
            string actual = MastermindGameLogic.GetGameResult(secret, guess);

            //Assert
            Assert.AreEqual(excpected, actual);
        }

        /// <summary>
        /// testmethod without guesses
        /// </summary>
        [TestMethod]
        public void TestMethodPartialNoInput()
        {
            //Arrange
            Farbe?[] secret = {Farbe.Blau, Farbe.Blau, Farbe.Schwarz};
            Farbe?[] guess = { };

            //Act and Assert
            StringAssert.Contains(MastermindGameLogic.GetGameResult(secret, guess), NoInputError);
        }

        /// <summary>
        /// testmethod with wellplaced and missplaced colors
        /// </summary>
        [TestMethod]
        public void TestMethodWellplacedAndMissplaced()
        {
            //Arrange
            Farbe?[] secret = {Farbe.Blau, Farbe.Braun, Farbe.Rot};
            Farbe?[] guess = {Farbe.Grün, Farbe.Braun, Farbe.Blau};
            string excpected = $"1 {nameof(wellplaced)} and 1 {nameof(missplaced)}";

            //Act
            string actual = MastermindGameLogic.GetGameResult(secret, guess);

            //Assert
            Assert.AreEqual(excpected, actual);
        }

        /// <summary>
        /// testmethod with wellplaced und multiple missplaced colors
        /// </summary>
        [TestMethod]
        public void TestMethodWellplacedAndMultipleMissplaced()
        {
            //Arrange
            Farbe?[] secret = {Farbe.Blau, Farbe.Braun, Farbe.Rot, Farbe.Grün, Farbe.Grün};
            Farbe?[] guess = {Farbe.Grün, Farbe.Braun, Farbe.Blau, Farbe.Rot, Farbe.Grün};
            string excpected = $"2 {nameof(wellplaced)} and 3 {nameof(missplaced)}";

            //Act
            string actual = MastermindGameLogic.GetGameResult(secret, guess);

            //Assert
            Assert.AreEqual(excpected, actual);
        }

        #endregion

        #endregion
    }
}
