using System;

namespace Zoo_Simulator.Extensions
{
    /// <summary>
    /// Extension methods for objects
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Method for ensuring that the given object is not null.
        /// </summary>
        /// <param name="obj">The object to check</param>
        /// <param name="paramName">The name of the parameter being checked</param>
        public static void EnsureNotNull(this object obj, string paramName)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(paramName);
            }
        }
    }
}
