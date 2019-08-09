namespace Zoo_Simulator.Extensions
{
    /// <summary>
    /// Extension methods for calculating percentages.
    /// </summary>
    public static class PercentageExtensions
    {
        /// <summary>
        /// Extension method for calculating the percentage of the given numeric value.
        /// </summary>
        /// <param name="value">The value to get the percentage of.</param>
        /// <param name="percentage">The percentage to get from the value.</param>
        /// <returns>The given percentage of the given value.</returns>
        public static int GetPercentage(this int value, int percentage)
        {
            return (value / 100) * percentage;
        }

        /// <summary>
        /// Extension method for calculating the percentage of the given numeric value.
        /// </summary>
        /// <param name="value">The value to get the percentage of.</param>
        /// <param name="percentage">The percentage to get from the value.</param>
        /// <returns>The given percentage of the given value.</returns>
        public static double GetPercentage(this double value, double percentage)
        {
            return (value / 100) * percentage;
        }
    }
}
