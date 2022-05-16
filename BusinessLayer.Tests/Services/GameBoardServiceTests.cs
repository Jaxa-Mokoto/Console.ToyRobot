using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot.BusinessLayer.Services;
using Assert = NUnit.Framework.Assert;

namespace BusinessLayer.Services.Tests
{
    [TestClass]
    public class GameBoardServiceTests
    {
        [DataTestMethod]
        public void isValidInitialPlaceCommand_WithNoUserCommandProvided_ReturnsFalse()
        {
            // ARRANGE
            GameBoardService _gameBoardService = new GameBoardService();

            // ACT
            bool result = _gameBoardService.isValidInitialPlaceCommand(string.Empty);

            // ASSERT
            Assert.IsFalse(result);
        }

        [DataTestMethod]
        [DataRow("PLACE 1,1 EAST")]
        [DataRow("PLACE 1,2 WEST")]
        public void isValidInitialPlaceCommand_WithValidhUserCommand_ReturnsTrue(string userCommand)
        {
            // ARRANGE
            GameBoardService _gameBoardService = new GameBoardService();

            // ACT
            bool result = _gameBoardService.isValidInitialPlaceCommand(userCommand);

            // ASSERT
            Assert.IsTrue(result);
        }

        [DataTestMethod]
        [DataRow("PLACE 1")]
        public void isValidInitialPlaceCommand_WithInvalidUserCommand_ReturnsFalse(string userCommand)
        {
            // ARRANGE
            GameBoardService _gameBoardService = new GameBoardService();

            // ACT
            bool result = _gameBoardService.isValidInitialPlaceCommand(userCommand);

            // ASSERT
            Assert.IsFalse(result);
        }

        [DataTestMethod]
        [DataRow("TESTING")]
        public void isValidCompassDirection_WithInvalidCompassDirection_ReturnsFalse(string compassDirection)
        {
            // ARRANGE
            GameBoardService _gameBoardService = new GameBoardService();

            // ACT
            bool result = _gameBoardService.isValidCompassDirection(compassDirection);

            // ASSERT
            Assert.IsFalse(result);
        }

        [DataTestMethod]
        [DataRow("NORTH")]
        [DataRow("SOUTH")]
        [DataRow("EAST")]
        [DataRow("WEST")]
        public void isValidCompassDirection_WithValidCompassDirection_ReturnsTrue(string compassDirection)
        {
            // ARRANGE
            GameBoardService _gameBoardService = new GameBoardService();

            // ACT
            bool result = _gameBoardService.isValidCompassDirection(compassDirection);

            // ASSERT
            Assert.IsTrue(result);
        }

        [DataTestMethod]
        [DataRow(1,2)]
        [DataRow(0,0)]
        public void isValidCoordinate_WithValidCoordinationSetsInAndOutOfGame_ReturnsTrue(int x, int y)
        {
            // ARRANGE
            GameBoardService _gameBoardService = new GameBoardService();

            // ACT
            bool result = _gameBoardService.isValidCoordinate(x, y);

            // ASSERT
            Assert.IsTrue(result);
        }

        [DataTestMethod]
        [DataRow(100, 100)]
        [DataRow(-20, -4)]
        public void isValidCoordinate_WithInvalidCoordinationSets_ReturnsFalse(int x, int y)
        {
            // ARRANGE
            GameBoardService _gameBoardService = new GameBoardService();

            // ACT
            bool result = _gameBoardService.isValidCoordinate(x, y);

            // ASSERT
            Assert.IsFalse(result);
        }
    }
}