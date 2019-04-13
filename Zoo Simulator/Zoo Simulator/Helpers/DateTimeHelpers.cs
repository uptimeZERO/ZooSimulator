using System;
using Zoo_Simulator.Models;

namespace Zoo_Simulator.Helpers
{
    /// <summary>
    /// Helpers for <see cref="DateTime"/>
    /// </summary>
    public static class DateTimeHelpers
    {
        /// <summary>
        /// Method for getting the difference in turns for the given <see cref="DateTime"/>s
        /// </summary>
        /// <param name="currentGameTime">The current game time</param>
        /// <param name="gameTimeInNextHour">The game time in the next hour</param>
        /// <returns>The difference in turns</returns>
        public static int GetDifferenceInTurns(DateTime currentGameTime, DateTime gameTimeInNextHour)
        {
            var result = 0;
            while (currentGameTime != gameTimeInNextHour)
            {
                currentGameTime.AddSeconds(Zoo.SecondsPerTurn);
                result++;
            }

            return result;
        }
    }
}
