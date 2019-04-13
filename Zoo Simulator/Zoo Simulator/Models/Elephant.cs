using System;
using System.Windows.Forms;
using Zoo_Simulator.Models.Enums;

namespace Zoo_Simulator.Models
{
    /// <summary>
    /// Represents a <see cref="Elephant"/>
    /// </summary>
    public class Elephant : BaseAnimal
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Elephant"/> class
        /// </summary>
        /// <param name="number">The number of the <see cref="Elephant"/></param>
        /// <param name="pbar">The <see cref="Elephant"/>s health bar</param>
        /// <param name="btn">The <see cref="Elephant"/>s feed buttn</param>
        /// <param name="lblStatus">The status <see cref="Label"/></param>
        /// <param name="lblHealth">The health <see cref="Label"/></param>
        public Elephant(
            int number,
            ProgressBar pbar,
            Button btn,
            Label lblStatus,
            Label lblHealth)
            : base(number, pbar, btn, lblStatus, lblHealth)
        {
        }

        /// <summary>
        /// Gets the <see cref="Elephant.HealthCapacity"/>
        /// </summary>
        public override double HealthCapacity => 1000.00;

        /// <summary>
        /// Gets the <see cref="AnimalType"/>
        /// </summary>
        public override AnimalType Type => AnimalType.Monkey;

        /// <summary>
        /// Gets a value indicating whether the <see cref="Elephant"/> is able to move
        /// </summary>
        public bool AbleToMove { get; private set; }

        /// <summary>
        /// Gets the seconds taken to finish eating
        /// </summary>
        protected override int SecondsToEat => 1200;

        /// <summary>
        /// Gets the second health ratio of the <see cref="Elephant"/>
        /// </summary>
        protected override double SecondHealthRatio => HealthCapacity / 70.0;

        /// <summary>
        /// Method for refreshing the <see cref="Elephant"/>s state
        /// </summary>
        /// <param name="gameTime">The current game time</param>
        public override void Refresh(DateTime gameTime)
        {
            if (!IsDead)
            {
                if (Health < SecondHealthRatio)
                {
                    if (AbleToMove)
                    {
                        GameTimeInNextHour = gameTime.AddHours(1);
                        HealthInNextHour = 0;
                        AbleToMove = false;
                    }

                    if (TurnsRemainingToEat == 0)
                    {
                        Status = AnimalStatus.UnableToMove;
                    }
                }
            }

            base.Refresh(gameTime);
        }
    }
}
