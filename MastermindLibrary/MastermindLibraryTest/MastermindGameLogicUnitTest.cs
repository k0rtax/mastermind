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
            StringAssert.Contains(MastermindGameLogic.GetGameResult(secret, guess), MismatchError);
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
            string excpected = $"no wellplaced and no misplaced";

            //Act
            string actual = MastermindGameLogic.GetGameResult(secret, guess);

            //Assert
            Assert.AreEqual(excpected, actual);
        }

        /// <summary>
        /// testmethod with only misplaced colors
        /// </summary>
        [TestMethod]
        public void TestMethodOnlyMisplaced()
        {
            //Arrange
            Farbe?[] secret = {Farbe.Blau, Farbe.Braun, Farbe.Rot};
            Farbe?[] guess = {Farbe.Braun, Farbe.Grün, Farbe.Blau};
            string excpected = $"0 wellplaced and 2 misplaced";

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
            string excpected = $"1 wellplaced and 0 misplaced";

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
        /// testmethod with wellplaced and misplaced colors
        /// </summary>
        [TestMethod]
        public void TestMethodWellplacedAndMisplaced()
        {
            //Arrange
            Farbe?[] secret = {Farbe.Blau, Farbe.Braun, Farbe.Rot};
            Farbe?[] guess = {Farbe.Grün, Farbe.Braun, Farbe.Blau};
            string excpected = $"1 wellplaced and 1 misplaced";

            //Act
            string actual = MastermindGameLogic.GetGameResult(secret, guess);

            //Assert
            Assert.AreEqual(excpected, actual);
        }

        /// <summary>
        /// testmethod with wellplaced und multiple misplaced colors
        /// </summary>
        [TestMethod]
        public void TestMethodWellplacedAndMultipleMisplaced()
        {
            //Arrange
            Farbe?[] secret = {Farbe.Blau, Farbe.Braun, Farbe.Rot, Farbe.Grün, Farbe.Grün};
            Farbe?[] guess = {Farbe.Grün, Farbe.Braun, Farbe.Blau, Farbe.Rot, Farbe.Grün};
            string excpected = $"2 wellplaced and 3 misplaced";

            //Act
            string actual = MastermindGameLogic.GetGameResult(secret, guess);

            //Assert
            Assert.AreEqual(excpected, actual);
        }

        #endregion

        #endregion
    }
}
