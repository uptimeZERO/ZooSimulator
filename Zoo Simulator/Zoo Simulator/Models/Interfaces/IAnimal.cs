using Zoo_Simulator.Enums;

namespace Zoo_Simulator.Models.Interfaces
{
    /// <summary>
    /// Interface for all animals.
    /// </summary>
    public interface IAnimal
    {
        /// <summary>
        /// Gets the Type of the <see cref="IAnimal"/>.
        /// </summary>
        AnimalType Type { get; }

        /// <summary>
        /// Gets or sets the status of the <see cref="IAnimal"/>.
        /// </summary>
        string StatusString { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the <see cref="IAnimal"/> is dead or not.
        /// </summary>
        bool IsDead { get; set; }

        /// <summary>
        /// Gets or sets the status of the <see cref="IAnimal"/>.
        /// </summary>
        AnimalStatus Status { get; set; }

        /// <summary>
        /// Updates the animal and their UI components, called after each in-game tick.
        /// </summary>
        void TickUpdate();

        /// <summary>
        /// Method for reducing the health of the <see cref="IAnimal"/> by a randomly generated value between 0-20.
        /// </summary>
        void TakeIdleDamage();

        /// <summary>
        /// Method for updating the status of the <see cref="IAnimal"/>.
        /// </summary>
        void UpdateStatus();

        /// <summary>
        /// Method for restoring the <see cref="IAnimal"/>s health by the given foodValue.
        /// </summary>
        /// <param name="foodValue">The percentage of health to restore.</param>
        void Eat(int foodValue);
    }
}
