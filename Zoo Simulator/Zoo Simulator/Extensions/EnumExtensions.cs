using Zoo_Simulator.Models.Enums;

namespace Zoo_Simulator.Extensions
{
    /// <summary>
    /// Extension methods for the enums used in this project
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Method for getting the string format of the <see cref="AnimalType"/>
        /// </summary>
        /// <param name="type">The <see cref="AnimalType"/> to get the string format for</param>
        /// <returns>The string format of the given <see cref="AnimalType"/></returns>
        public static string GetString(this AnimalType type)
        {
            var result = string.Empty;
            switch (type)
            {
                case AnimalType.Elephant:
                    result = nameof(AnimalType.Elephant);
                    break;
                case AnimalType.Giraffe:
                    result = nameof(AnimalType.Giraffe);
                    break;
                case AnimalType.Monkey:
                    result = nameof(AnimalType.Monkey);
                    break;
            }

            return result;
        }

        /// <summary>
        /// Method for getting the string format of the <see cref="AnimalStatus"/>
        /// </summary>
        /// <param name="status">The <see cref="AnimalStatus"/> to ge the string format for</param>
        /// <returns>The string format of the <see cref="AnimalStatus"/></returns>
        public static string GetString(this AnimalStatus status)
        {
            var result = string.Empty;
            switch (status)
            {
                case AnimalStatus.Dead:
                    result = nameof(AnimalStatus.Dead);
                    break;
                case AnimalStatus.Dying:
                    result = nameof(AnimalStatus.Dying);
                    break;
                case AnimalStatus.Happy:
                    result = nameof(AnimalStatus.Happy);
                    break;
                case AnimalStatus.Hungry:
                    result = nameof(AnimalStatus.Hungry);
                    break;
                case AnimalStatus.Idle:
                    result = nameof(AnimalStatus.Idle);
                    break;
                case AnimalStatus.Moving:
                    result = nameof(AnimalStatus.Moving);
                    break;
                case AnimalStatus.Sad:
                    result = nameof(AnimalStatus.Sad);
                    break;
                case AnimalStatus.Satisfied:
                    result = nameof(AnimalStatus.Satisfied);
                    break;
                case AnimalStatus.Socialising:
                    result = nameof(AnimalStatus.Socialising);
                    break;
                case AnimalStatus.Starving:
                    result = nameof(AnimalStatus.Starving);
                    break;
                case AnimalStatus.Eating:
                    result = nameof(AnimalStatus.Eating);
                    break;
                case AnimalStatus.UnableToMove:
                    result = "Unable to move";
                    break;
            }

            return result;
        }
    }
}
