using System;
using System.Windows.Forms;
using Zoo_Simulator.Enums;

namespace Zoo_Simulator.Models
{
    /// <summary>
    /// Represents a <see cref="Giraffe"/> in the zoo.
    /// </summary>
    public class Giraffe : BaseAnimal
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Giraffe"/> class.
        /// </summary>
        /// <param name="healthBar">The health bar of the <see cref="Giraffe"/>.</param>
        /// <param name="statusLabel">The status label of the <see cref="Giraffe"/>.</param>
        /// <param name="healthLabel">The health label of the <see cref="Giraffe"/>.</param>
        /// <param name="random">The random number generator.</param>
        public Giraffe(
            Label healthBar,
            Label statusLabel,
            Label healthLabel,
            Random random)
            : base(
                  healthBar,
                  statusLabel,
                  healthLabel,
                  random)
        {
        }

        /// <summary>
        /// Gets the health capacity of the <see cref="Giraffe"/>.
        /// </summary>
        public override double HealthCapacity => 500.0;

        /// <summary>
        /// Gets the type of animal.
        /// </summary>
        public override AnimalType Type => AnimalType.Giraffe;
    }
}
