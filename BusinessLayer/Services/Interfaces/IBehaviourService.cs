using ToyRobot.Common.Enums;

namespace ToyRobot.BusinessLayer.Services.Interfaces
{
    /// <summary>
    /// The service to implement a given behaviour.
    /// </summary>
    public interface IBehaviourService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xcoordinate"></param>
        /// <param name="ycoordinate"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        string PlaceBehaviour(int xcoordinate, int ycoordinate, CompassDirection direction);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Position NextMove();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rotationDirection"></param>
        /// <returns></returns>
        CompassDirection RotationBehaviour(string rotationDirection);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string ReportBehaviour();
    }
}