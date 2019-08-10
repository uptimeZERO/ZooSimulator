using System;
using System.Windows.Forms;
using Zoo_Simulator.Enums;
using Zoo_Simulator.Extensions;
using Zoo_Simulator.Models.Interfaces;

namespace Zoo_Simulator.Models
{
    /// <summary>
    /// Base class for all animal objects.
    /// </summary>
    public abstract class BaseAnimal : IAnimal
    {
        private static string _healthLabelText = "Health: ";
        private static string _statusLabelText = "Status: ";
        private Label _healthBar;
        private Label _statusLabel;
        private Label _healthLabel;
        private Random _random;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseAnimal"/> class.
        /// </summary>
        /// <param name="healthBar">The health bar of the <see cref="BaseAnimal"/>.</param>
        /// <param name="statusLabel">The status <see cref="Label"/> of the <see cref="BaseAnimal"/>.</param>
        /// <param name="healthLabel">The health <see cref="Label"/> of the <see cref="BaseAnimal"/>.</param>
        /// <param name="random">The random number generator.</param>
        protected BaseAnimal(
            Label healthBar,
            Label statusLabel,
            Label healthLabel,
            Random random)
        {
            _healthBar = healthBar
                ?? throw new ArgumentNullException(nameof(healthBar), "Cannot be null");
            _statusLabel = statusLabel
                ?? throw new ArgumentNullException(nameof(statusLabel), "Cannot be null");
            _healthLabel = healthLabel
                ?? throw new ArgumentNullException(nameof(healthLabel), "Cannot be null");
            _random = random
                ?? throw new ArgumentNullException(nameof(random), "Cannot be null");

            Health = HealthCapacity;
            TickUpdate();
            UpdateStatus();
        }

        /// <summary>
        /// Gets or sets the status of the <see cref="BaseAnimal"/>.
        /// </summary>
        public string StatusString
        {
            get => _statusLabel.Text;
            set => _statusLabel.Text = $"{_statusLabelText}{value}";
        }

        /// <summary>
        /// Gets or sets the health of the <see cref="BaseAnimal"/>.
        /// </summary>
        public double Health { get; protected set; }

        /// <summary>
        /// Gets the health capacity of the <see cref="BaseAnimal"/>.
        /// </summary>
        public abstract double HealthCapacity { get; }

        /// <summary>
        /// Gets the type of <see cref="BaseAnimal"/>.
        /// </summary>
        public abstract AnimalType Type { get; }

        /// <summary>
        /// Gets or sets a value indicating whether the <see cref="BaseAnimal"/> is dead or not.
        /// </summary>
        public bool IsDead { get; set; }

        /// <summary>
        /// Gets or sets the status of the <see cref="BaseAnimal"/>.
        /// </summary>
        public AnimalStatus Status { get; set; }

        /// <summary>
        /// Method for killing the animal.
        /// </summary>
        /// <remarks>
        /// You monster!
        /// </remarks>
        public void Die()
        {
            Health = 0;
            _healthBar.Text = string.Empty;
            _healthLabel.Text = $"{_healthLabelText}0";
            IsDead = true;
            Status = AnimalStatus.Dead;
            StatusString = AnimalStatus.Dead.GetString();
        }

        /// <summary>
        /// Updates the animal and their UI components, called after each in-game tick.
        /// </summary>
        public virtual void TickUpdate()
        {
            if (!IsDead)
            {
                _healthBar.Text = GetProgressBarString((int)((Health / HealthCapacity) * 100.0));
                _healthLabel.Text = $"{_healthLabelText}{Math.Round(Health, 2)}";
                if (Health <= 0)
                {
                    Die();
                }
            }
        }

        /// <summary>
        /// Method for reducing the health of the <see cref="BaseAnimal"/> by a randomly generated value between 0-20.
        /// </summary>
        public virtual void TakeIdleDamage()
        {
            if (!IsDead)
            {
                var damagePercentage = _random.Next(0, 20);
                var damage = Health.GetPercentage(damagePercentage);
                Health -= damage;
            }
        }

        /// <summary>
        /// Method for updating the status of the <see cref="BaseAnimal"/>.
        /// </summary>
        public virtual void UpdateStatus()
        {
            if (!IsDead)
            {
                var randomStatus = _random.Next(10, 15);
                if ((Health / HealthCapacity) * 100.0 < 50.0
                    && (Health / HealthCapacity) * 100.0 > 30.0)
                {
                    Status = AnimalStatus.Hungry;
                    StatusString = AnimalStatus.Hungry.GetString();
                }
                else if ((Health / HealthCapacity) * 100.0 < 30.0)
                {
                    Status = AnimalStatus.Starving;
                    StatusString = AnimalStatus.Starving.GetString();
                }
                else
                {
                    StatusString = ((AnimalStatus)randomStatus).GetString();
                }
            }
        }

        /// <summary>
        /// Method for restoring the <see cref="BaseAnimal"/>s health by the given foodValue.
        /// </summary>
        /// <param name="foodValue">The percentage of health to restore.</param>
        public virtual void Eat(int foodValue)
        {
            if (!IsDead)
            {
                var restore = Health.GetPercentage(foodValue);
                Health = (Health + restore) > HealthCapacity
                    ? HealthCapacity
                    : Health + restore;
            }
        }

        /// <summary>
        /// Method for getting the progress bar string.
        /// </summary>
        /// <param name="value">The percentage (0-100) to set the progress bar string</param>
        /// <returns>A progress bar string of the given percentage of the value.</returns>
        private string GetProgressBarString(int value)
        {
            if (value > 100 ||
                value < 0)
            {
                throw new IndexOutOfRangeException("The value of the progress bar string must be between 0-100");
            }

            var returnResult = string.Empty;
            for (int i = 0; i < value; i++)
            {
                returnResult = $"{returnResult}#";
            }

            return returnResult;
        }
    }
}
