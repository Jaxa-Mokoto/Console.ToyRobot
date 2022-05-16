using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ToyRobot.BusinessLayer.Helpers;
using ToyRobot.BusinessLayer.Services;
using ToyRobot.Common.Enums;

namespace BusinessLayer.Services.Tests
{
    [TestClass]
    public class RuleServiceTests
    {
        [DataTestMethod]
        [DataRow(1, 2,CompassDirection.EAST)]
        [DataRow(5, 5, CompassDirection.SOUTH)]
        public void PlaceBehvaiour_WithValidPlaceCommand_ReturnsValidPlacement(int x, int y, CompassDirection compassDirection)
        {
            // ARRANGE
            RuleService _ruleService = new RuleService();
            Position nextPosition = new Position(x, y, compassDirection);

            // ACT
            string result = _ruleService.PlaceBehaviour(x, y, compassDirection);
            string expected = nextPosition.ToString();

            // ASSERT
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow(5, 2, CompassDirection.NORTH)]
        [DataRow(1, 5, CompassDirection.WEST)]
        public void PlaceBehvaiour_WithValidPlaceCommandAndEmptyHelper_ReturnsValidPlacement(int x, int y, CompassDirection compassDirection)
        {
            // ARRANGE
            RuleService _ruleService = new RuleService();
            _ruleService.Position = null;

            Position nextPosition = new Position(x, y, compassDirection);

            // ACT
            string result = _ruleService.PlaceBehaviour(x, y, compassDirection);
            string expected = nextPosition.ToString();

            // ASSERT
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow(1, 2, CompassDirection.EAST, "LEFT")]
        [DataRow(2, 2, CompassDirection.WEST, "RIGHT")]
        public void RotationBehvaiour_WithValidRotationCommand_ReturnsValidPlacement(int x, int y, CompassDirection direction, string rotationDirection)
        {
            // ARRANGE
            RuleService _ruleService = new RuleService();
            Position nextPosition = new Position(x, y, direction);
            _ruleService.Position = nextPosition;

            // ACT
            CompassDirection result = _ruleService.RotationBehaviour(rotationDirection);

            // ASSERT
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(CompassDirection));
        }
    }
}