using ToyRobot.Common.Enums;

namespace ToyRobot.BusinessLayer.Services
{
    /// <summary>
    /// The base position service.
    /// </summary>
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public CompassDirection Direction { get; set; }

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Position(int x, int y, CompassDirection direction)
        {
            this.X = x;
            this.Y = y;
            this.Direction = direction;
        }
    }
}