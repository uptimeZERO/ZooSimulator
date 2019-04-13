using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Zoo_Simulator.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="ProgressBar"/>
    /// </summary>
    public static class ProgressBarExtensions
    {
        /// <summary>
        /// Method for setting the state on the given <see cref="ProgressBar"/>
        /// </summary>
        /// <param name="pBar">The <see cref="ProgressBar"/> to change the state for</param>
        /// <param name="state">The state to set the <see cref="ProgressBar"/> to</param>
        public static void SetState(this ProgressBar pBar, int state)
        {
            // States:
            // 1 = normal (green)
            // 2 = error (red)
            // 3 = warning (yellow)
            SendMessage(pBar.Handle, 1040, (IntPtr)state, IntPtr.Zero);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint msg, IntPtr w, IntPtr l);
    }
}
