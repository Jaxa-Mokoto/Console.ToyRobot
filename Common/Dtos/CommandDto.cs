namespace ToyRobot.Common.Dtos
{
    /// <summary>
    /// The base commands DTO.
    /// </summary>
    public class CommandDto
    {
        /// <summary>
        /// The direction the robot should move in.
        /// </summary>
        public string CompassDirectionName { get; set; }

        /// <summary>
        /// The flag indicating if the robot should report the given commands.
        /// </summary>
        public bool Report { get; set; }

        /// <summary>
        /// The X coordinate of the place command.
        /// </summary>
        public int PlaceXCoordinate { get; set; }

        /// <summary>
        /// The Y coordinate of the place command.
        /// </summary>
        public int PlaceYCoordinate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool isFirstPlaceCommand { get; set; } = true;
    }
}
