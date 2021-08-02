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

        [TestMethod]
        public void TestMethodMissmatch()
        {
            //Arrange
            Farbe?[] wellplaced = {Farbe.Blau, Farbe.Braun};
            Farbe?[] missplaced = {Farbe.Blau};

            //Act and Assert
            StringAssert.Contains(MastermindGameLogic.GetGameResult(wellplaced, missplaced), MissmatchError);
        }

        [TestMethod]
        public void TestMethodNoInput()
        {
            //Arrange
            Farbe?[] wellplaced = { };
            Farbe?[] missplaced = { };

            //Act and Assert
            StringAssert.Contains(MastermindGameLogic.GetGameResult(wellplaced, missplaced), NoInputError);
        }

        [TestMethod]
        public void TestMethodNoMatches()
        {
            //Arrange
            Farbe?[] wellplaced = {Farbe.Blau, Farbe.Braun};
            Farbe?[] missplaced = {Farbe.Grün, Farbe.Gelb};
            string excpected = $"no {nameof(wellplaced)} and no {nameof(missplaced)}";

            //Act
            string actual = MastermindGameLogic.GetGameResult(wellplaced, missplaced);

            //Assert
            Assert.AreEqual(excpected, actual);
        }

        [TestMethod]
        public void TestMethodOnlyMissplaced()
        {
            //Arrange
            Farbe?[] wellplaced = {Farbe.Blau, Farbe.Braun, Farbe.Rot};
            Farbe?[] missplaced = {Farbe.Braun, Farbe.Grün, Farbe.Blau};
            string excpected = $"0 {nameof(wellplaced)} and 2 {nameof(missplaced)}";

            //Act
            string actual = MastermindGameLogic.GetGameResult(wellplaced, missplaced);

            //Assert
            Assert.AreEqual(excpected, actual);
        }

        [TestMethod]
        public void TestMethodOnlyWellplaced()
        {
            //Arrange
            Farbe?[] wellplaced = {Farbe.Blau, Farbe.Braun};
            Farbe?[] missplaced = {Farbe.Grün, Farbe.Braun};
            string excpected = $"1 {nameof(wellplaced)} and 0 {nameof(missplaced)}";

            //Act
            string actual = MastermindGameLogic.GetGameResult(wellplaced, missplaced);

            //Assert
            Assert.AreEqual(excpected, actual);
        }

        [TestMethod]
        public void TestMethodPartialNoInput()
        {
            //Arrange
            Farbe?[] wellplaced = {Farbe.Blau, Farbe.Blau, Farbe.Schwarz};
            Farbe?[] missplaced = { };

            //Act and Assert
            StringAssert.Contains(MastermindGameLogic.GetGameResult(wellplaced, missplaced), NoInputError);
        }

        [TestMethod]
        public void TestMethodWellplacedAndMissplaced()
        {
            //Arrange
            Farbe?[] wellplaced = {Farbe.Blau, Farbe.Braun, Farbe.Rot};
            Farbe?[] missplaced = {Farbe.Grün, Farbe.Braun, Farbe.Blau};
            string excpected = $"1 {nameof(wellplaced)} and 1 {nameof(missplaced)}";

            //Act
            string actual = MastermindGameLogic.GetGameResult(wellplaced, missplaced);

            //Assert
            Assert.AreEqual(excpected, actual);
        }

        [TestMethod]
        public void TestMethodWellplacedAndMultipleMissplaced()
        {
            //Arrange
            Farbe?[] wellplaced = {Farbe.Blau, Farbe.Braun, Farbe.Rot, Farbe.Grün, Farbe.Grün};
            Farbe?[] missplaced = {Farbe.Grün, Farbe.Braun, Farbe.Blau, Farbe.Rot, Farbe.Grün};
            string excpected = $"2 {nameof(wellplaced)} and 3 {nameof(missplaced)}";

            //Act
            string actual = MastermindGameLogic.GetGameResult(wellplaced, missplaced);

            //Assert
            Assert.AreEqual(excpected, actual);
        }

        #endregion

        #endregion
    }
}