namespace ToyRobot.Common.Dtos
{
    /// <summary>
    /// The base game board DTO.
    /// </summary>
    public class GameBoardDto
    {
        /// <summary>
        /// The ending row or column on the game board.
        /// </summary>
        public int endingRowAndColumn { get; set; } = ApplicationConstants.GameBoardValidMaxSpace;

        /// <summary>
        /// The starting row or column on the game board.
        /// </summary>
        public int startingRowAndColumn { get; set; } = ApplicationConstants.GameBoardValidMinSpace;
    }
}
