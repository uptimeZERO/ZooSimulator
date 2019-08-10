using System;
using System.Windows.Forms;
using Zoo_Simulator.Enums;
using Zoo_Simulator.Extensions;

namespace Zoo_Simulator.Models
{
    /// <summary>
    /// Represents a <see cref="Elephant"/> in the zoo.
    /// </summary>
    public class Elephant : BaseAnimal
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Elephant"/> class.
        /// </summary>
        /// <param name="healthBar">The health bar of the <see cref="Elephant"/>.</param>
        /// <param name="statusLabel">The status label of the <see cref="Elephant"/>.</param>
        /// <param name="healthLabel">The health label of the <see cref="Elephant"/>.</param>
        /// <param name="random">The random number generator.</param>
        public Elephant(
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
            TicksUnableToWalk = 0;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <see cref="Elephant"/> is unable to walk.
        /// </summary>
        public bool IsUnableToWalk { get; set; }

        /// <summary>
        /// Gets or sets the number of ticks that the <see cref="Elephant"/> has been unable to walk for.
        /// </summary>
        public int TicksUnableToWalk { get; set; }

        /// <summary>
        /// Gets the health capacity of the <see cref="Elephant"/>.
        /// </summary>
        public override double HealthCapacity => 1000.0;

        /// <summary>
        /// Gets the type of animal.
        /// </summary>
        public override AnimalType Type => AnimalType.Elephant;

        /// <summary>
        /// Updates the <see cref="Elephant"/> and its UI components, called after each in-game tick.
        /// </summary>
        public override void TickUpdate()
        {
            if (!IsDead)
            {
                base.TickUpdate();
                if (IsUnableToWalk)
                {
                    TicksUnableToWalk++;
                }

                if (TicksUnableToWalk == 20)
                {
                    Die();
                }
            }
        }

        /// <summary>
        /// Method for updating the status of the <see cref="Elephant"/>.
        /// </summary>
        public override void UpdateStatus()
        {
            if (!IsDead)
            {
                if (IsUnableToWalk)
                {
                    Status = AnimalStatus.UnableToWalk;
                    StatusString = AnimalStatus.UnableToWalk.GetString();
                }
                else
                {
                    base.UpdateStatus();
                }
            }
        }

        /// <summary>
        /// Method for restoring health to the <see cref="Elephant"/>.
        /// </summary>
        /// <param name="foodValue">The percentage of health to restore to the <see cref="Elephant"/>s health.</param>
        public override void Eat(int foodValue)
        {
            if (!IsDead)
            {
                base.Eat(foodValue);
                IsUnableToWalk = Health < HealthCapacity.GetPercentage(70);
            }
        }

        /// <summary>
        /// Method for taking idle damage.
        /// </summary>
        public override void TakeIdleDamage()
        {
            if (!IsDead)
            {
                base.TakeIdleDamage();
                IsUnableToWalk = Health < HealthCapacity.GetPercentage(70);
            }
        }
    }
}
