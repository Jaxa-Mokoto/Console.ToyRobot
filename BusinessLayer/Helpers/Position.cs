using ToyRobot.Common.Enums;

namespace ToyRobot.BusinessLayer.Helpers
{
    /// <summary>
    /// The position helper class.
    /// </summary>
    public class Position
    {
        /// <summary>
        /// The x-coordinate of the new position.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// The y-coordinate of the new position.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// The compass direction of the new position.
        /// </summary>
        public CompassDirection Direction { get; set; }

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="x">The given x-coordinate.</param>
        /// <param name="y">The given y-coordinate.</param>
        public Position(int x, int y, CompassDirection direction)
        {
            this.X = x;
            this.Y = y;
            this.Direction = direction;
        }
    }
}