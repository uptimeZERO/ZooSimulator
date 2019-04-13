using System;
using System.Windows.Forms;
using Zoo_Simulator.Extensions;
using Zoo_Simulator.Helpers;
using Zoo_Simulator.Models.Enums;

namespace Zoo_Simulator.Models
{
    /// <summary>
    /// Base class for all animals
    /// </summary>
    public abstract class BaseAnimal
    {
        private const string StatuslblText = "Status: ";

        private const string HealthPercentageLblText = "Health: ";

        private const string FeedBtnText = "Feed";

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseAnimal"/> class
        /// </summary>
        /// <param name="number">The number of the <see cref="BaseAnimal"/></param>
        /// <param name="pbar">The <see cref="BaseAnimal"/>s health bar</param>
        /// <param name="btn">The <see cref="BaseAnimal"/>s feed buttn</param>
        /// <param name="lblStatus">The status <see cref="Label"/></param>
        /// <param name="lblHealth">The health <see cref="Label"/></param>
        public BaseAnimal(
            int number,
            ProgressBar pbar,
            Button btn,
            Label lblStatus,
            Label lblHealth)
        {
            Number = number;
            Rnd = new Random();
            Pbar = pbar
                ?? throw new ArgumentNullException(nameof(pbar));
            FeedBtn = btn
                ?? throw new ArgumentNullException(nameof(btn));
            StatusLbl = lblStatus
                ?? throw new ArgumentNullException(nameof(lblStatus));
            HealthPercentageLbl = lblHealth
                ?? throw new ArgumentNullException(nameof(lblHealth));
            Health = HealthCapacity;
        }

        /// <summary>
        /// Gets the health of the <see cref="BaseAnimal"/>
        /// </summary>
        public double Health { get; private set; }

        /// <summary>
        /// Gets the health capacity of the <see cref="BaseAnimal"/>
        /// </summary>
        public abstract double HealthCapacity { get; }

        /// <summary>
        /// Gets the <see cref="AnimalType"/> of the <see cref="BaseAnimal"/>
        /// </summary>
        public abstract AnimalType Type { get; }

        /// <summary>
        /// Gets the number of the <see cref="BaseAnimal"/>
        /// </summary>
        public int Number { get; private set; }

        /// <summary>
        /// Gets or sets the <see cref="AnimalStatus"/> of the <see cref="BaseAnimal"/>
        /// </summary>
        public AnimalStatus Status { get; protected set; }

        /// <summary>
        /// Gets a value indicating whether the <see cref="BaseAnimal"/> is dead or not
        /// </summary>
        public bool IsDead { get; private set; }

        /// <summary>
        /// Gets the turns taken for the <see cref="BaseAnimal"/> to eat
        /// </summary>
        public int TurnsTakenToEat => SecondsToEat / Zoo.SecondsPerTurn;

        /// <summary>
        /// Gets the seconds taken for the <see cref="BaseAnimal"/> to eat
        /// </summary>
        protected abstract int SecondsToEat { get; }

        /// <summary>
        /// Gets the turns remaining for the <see cref="BaseAnimal"/> to eat
        /// </summary>
        protected int TurnsRemainingToEat { get; private set; }

        /// <summary>
        /// Gets the turns to next hour
        /// </summary>
        protected int TurnsToNextHour { get; private set; }

        /// <summary>
        /// Gets the turns to next status
        /// </summary>
        protected int TurnsToNextStatus { get; private set; }

        /// <summary>
        /// Gets the random number generator
        /// </summary>
        protected Random Rnd { get; private set; }

        /// <summary>
        /// Gets the <see cref="ProgressBar"/> representing the <see cref="Health"/>
        /// </summary>
        protected ProgressBar Pbar { get; private set; }

        /// <summary>
        /// Gets or sets the game time in the next hour
        /// </summary>
        protected DateTime GameTimeInNextHour { get; set; }

        /// <summary>
        /// Gets the <see cref="DateTime"/> that the <see cref="BaseAnimal"/> is healing until
        /// </summary>
        protected DateTime HealingUntil { get; private set; }

        /// <summary>
        /// Gets the current game time
        /// </summary>
        protected DateTime CurrentGameTime { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the hour has elapsed
        /// </summary>
        protected bool HourElapsed { get; private set; }

        /// <summary>
        /// Gets or sets the <see cref="Health"/> in the next hour
        /// </summary>
        protected double HealthInNextHour { get; set; }

        /// <summary>
        /// Gets the feed <see cref="Button"/> of the <see cref="BaseAnimal"/>
        /// </summary>
        protected Button FeedBtn { get; private set; }

        /// <summary>
        /// Gets the status <see cref="Label"/> of the <see cref="BaseAnimal"/>
        /// </summary>
        protected Label StatusLbl { get; private set; }

        /// <summary>
        /// Gets the health <see cref="Label"/> of the <see cref="BaseAnimal"/>
        /// </summary>
        protected Label HealthPercentageLbl { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the <see cref="BaseAnimal"/> is healing or not
        /// </summary>
        protected bool Healing => HealingUntil == GameTimeInNextHour;

        /// <summary>
        /// Gets a value indicating whether the <see cref="BaseAnimal"/> is taking idle damage or not
        /// </summary>
        protected bool TakingIdleDamage => Health < HealthInNextHour;

        /// <summary>
        /// Gets the first health ratio (Used for changing the colour of the health bar)
        /// </summary>
        protected virtual double FirstHealthRatio => HealthCapacity / 20.0;

        /// <summary>
        /// Gets the second health ratio (Used for changing the colour of the health bar)
        /// </summary>
        protected virtual double SecondHealthRatio => HealthCapacity / 50.0;

        /// <summary>
        /// Gets the health percentage
        /// </summary>
        /// <returns>Health percentage</returns>
        public double GetHealthPercentage()
        {
            return (Health / HealthCapacity) * 100.000;
        }

        /// <summary>
        /// Method for feeding the <see cref="BaseAnimal"/>
        /// </summary>
        /// <param name="gameTime">The current game time</param>
        public void Feed(DateTime gameTime)
        {
            CurrentGameTime = gameTime;
            GameTimeInNextHour = CurrentGameTime.AddHours(1);
            HealingUntil = GameTimeInNextHour;
            HealthInNextHour = Health + Rnd.Next(10, 25);
            Status = AnimalStatus.Eating;
            TurnsRemainingToEat = TurnsTakenToEat;
            DisableFeedBtn();
        }

        /// <summary>
        /// Method for refreshing the state of the <see cref="BaseAnimal"/>
        /// </summary>
        /// <param name="gameTime">The current game time</param>
        public virtual void Refresh(DateTime gameTime)
        {
            if (IsDead)
            {
                Pbar.Value = Pbar.Value == 100
                    ? 0 : 100;
            }
            else
            {
                CurrentGameTime = gameTime;
                HourElapsed = CurrentGameTime == GameTimeInNextHour;
                GameTimeInNextHour = CurrentGameTime == GameTimeInNextHour
                    ? CurrentGameTime.AddHours(1) : GameTimeInNextHour;
                TurnsToNextHour = DateTimeHelpers.GetDifferenceInTurns(gameTime, GameTimeInNextHour);

                RefreshAction();
                RefreshEating();
                UpdateGUIComponents();
                RefreshHealth();

                HourElapsed = false;
            }
        }

        /// <summary>
        /// Method for refreshing the health of the <see cref="BaseAnimal"/>
        /// </summary>
        private void RefreshHealth()
        {
            Health += (HealthInNextHour - Health) / TurnsToNextHour;
            if (Health > HealthCapacity)
            {
                Health = HealthCapacity;
            }
            else if (Health <= 0)
            {
                Die();
            }
        }

        /// <summary>
        /// Method for taking idle damage
        /// </summary>
        private void TakeIdleDamage()
        {
            HealthInNextHour = Health - Rnd.Next(0, 20);
        }

        /// <summary>
        /// Method for refreshing the hour actions
        /// </summary>
        private void RefreshAction()
        {
            if (HourElapsed)
            {
                if (Healing)
                {
                    HealingUntil = new DateTime(0, 0, 0);
                }

                TakeIdleDamage();
            }
        }

        /// <summary>
        /// Method for refreshing the eating state
        /// </summary>
        private void RefreshEating()
        {
            if (Status == AnimalStatus.Eating)
            {
                TurnsRemainingToEat--;
                if (TurnsRemainingToEat == 0)
                {
                    Status = AnimalStatus.Satisfied;
                    EnableFeedBtn();
                }
            }
        }

        /// <summary>
        /// Method for updating the GUI components
        /// </summary>
        private void UpdateGUIComponents()
        {
            StatusLbl.Text = $"{StatuslblText}{Status.GetString()}";
            HealthPercentageLbl.Text = $"{HealthPercentageLblText}{GetHealthPercentage()}%";
            if (Health > SecondHealthRatio)
            {
                Pbar.SetState(1);
            }
            else if (
                Health < SecondHealthRatio &&
                Health > FirstHealthRatio)
            {
                Pbar.SetState(3);
            }
            else if (Health < FirstHealthRatio)
            {
                Pbar.SetState(2);
            }

            Pbar.Value = (int)GetHealthPercentage();
            RefreshFeedBtn();
        }

        /// <summary>
        /// Method for enabling the feed <see cref="Button"/>
        /// </summary>
        private void EnableFeedBtn()
        {
            FeedBtn.Enabled = true;
            RefreshFeedBtn();
        }

        /// <summary>
        /// Method for disabling the feed <see cref="Button"/>
        /// </summary>
        private void DisableFeedBtn()
        {
            FeedBtn.Enabled = false;
            RefreshFeedBtn();
        }

        /// <summary>
        /// Method for refreshing the feed <see cref="Button"/>
        /// </summary>
        private void RefreshFeedBtn()
        {
            FeedBtn.Text = Healing
                ? $"{FeedBtnText} ({TurnsToNextHour})" : FeedBtnText;
        }

        /// <summary>
        /// Method for setting the <see cref="BaseAnimal"/> to die
        /// </summary>
        private void Die()
        {
            Health = 0;
            IsDead = true;
            Pbar.SetState(2);
        }
    }
}
