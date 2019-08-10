using System;
using System.Windows.Forms;
using Zoo_Simulator.Enums;

namespace Zoo_Simulator.Models
{
    /// <summary>
    /// Represents a <see cref="Monkey"/> in the zoo.
    /// </summary>
    public class Monkey : BaseAnimal
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Monkey"/> class.
        /// </summary>
        /// <param name="healthBar">The health bar of the <see cref="Monkey"/>.</param>
        /// <param name="statusLabel">The status label of the <see cref="Monkey"/>.</param>
        /// <param name="healthLabel">The health label of the <see cref="Monkey"/>.</param>
        /// <param name="random">The random number generator.</param>
        public Monkey(
            Label healthBar,
            Label statusLabel,
            Label healthLabel,
            Random random)
            : base (
                  healthBar,
                  statusLabel,
                  healthLabel,
                  random)
        {
        }

        /// <summary>
        /// Gets the health capacity of the <see cref="Monkey"/>.
        /// </summary>
        public override double HealthCapacity => 700.0;

        /// <summary>
        /// Gets the type of animal.
        /// </summary>
        public override AnimalType Type => AnimalType.Monkey;
    }
}
