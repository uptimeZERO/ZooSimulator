using Zoo_Simulator.Enums;

namespace Zoo_Simulator.Extensions
{
    /// <summary>
    /// Extension methods for enums.
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Method for getting the string format of the <see cref="AnimalStatus"/>.
        /// </summary>
        /// <param name="status">The status of the animal to ge tthe string format for.</param>
        /// <returns>The string format for the <see cref="AnimalStatus"/>.</returns>
        public static string GetString(this AnimalStatus status)
        {
            var returnResult = string.Empty;
            switch (status)
            {
                case AnimalStatus.Dead:
                    returnResult = "Dead";
                    break;
                case AnimalStatus.Eating:
                    returnResult = "Eating";
                    break;
                case AnimalStatus.Hungry:
                    returnResult = "Hungry";
                    break;
                case AnimalStatus.Starving:
                    returnResult = "Starving";
                    break;
                case AnimalStatus.Idle:
                    returnResult = "Idle";
                    break;
                case AnimalStatus.GettingLit:
                    returnResult = "Getting lit 😂👌";
                    break;
                case AnimalStatus.Playing:
                    returnResult = "Playing";
                    break;
                case AnimalStatus.Sitting:
                    returnResult = "Sitting";
                    break;
                case AnimalStatus.SmokeBreak:
                    returnResult = "Smoke break";
                    break;
                case AnimalStatus.UnableToWalk:
                    returnResult = "Unable to walk";
                    break;
                case AnimalStatus.Walking:
                    returnResult = "Walking";
                    break;
            }

            return returnResult;
        }
    }
}
