namespace ToyRobot.Common
{
    /// <summary>
    /// A container for global application constants.
    /// </summary>
    public class ApplicationConstants
    {
        /// <summary>
        /// The maximum valid area the robot can travel to.
        /// </summary>
        public const int GameBoardValidMaxSpace = 6;

        /// <summary>
        /// The minimum valid area the robot can travel to.
        /// </summary>
        public const int GameBoardValidMinSpace = 0;

        /// <summary>
        /// The maximum area the robot can travel to outside of valid game play area.
        /// </summary>
        public const int GameBoardMaxOutOfBounds = 8;

        /// <summary>
        /// The minimum area the robot can travel to outside of valid game play area.
        /// </summary>
        public const int GameBoardMinOutOfBounds = -3;
    }
}
