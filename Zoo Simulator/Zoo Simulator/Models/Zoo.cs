using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Zoo_Simulator.Extensions;
using Zoo_Simulator.Models.Enums;

namespace Zoo_Simulator.Models
{
    /// <summary>
    /// Represents the <see cref="Zoo"/>
    /// </summary>
    public class Zoo
    {
        /// <summary>
        /// The <see cref="Label"/> displaying the <see cref="Zoo"/>'s time
        /// </summary>
        private readonly Label _lblZooTime;

        /// <summary>
        /// Initializes a new instance of the <see cref="Zoo"/> class
        /// </summary>
        /// <param name="lblZooTime">The <see cref="Label"/> that displays the <see cref="Zoo"/>'s <see cref="DateTime"/></param>
        public Zoo(Label lblZooTime)
        {
            _lblZooTime = lblZooTime
                ?? throw new ArgumentNullException(nameof(lblZooTime));
            Monkeys = new List<Monkey>();
            Elephants = new List<Elephant>();
            Giraffes = new List<Giraffe>();
        }

        /// <summary>
        /// Gets the seconds per turns
        /// </summary>
        public static int SecondsPerTurn => 30;

        /// <summary>
        /// Gets the <see cref="DateTime"/> the <see cref="Zoo"/> opens
        /// </summary>
        public static DateTime ZooOpeningDay => new DateTime(2019, 4, 6, 8, 0, 0);

        /// <summary>
        /// Gets the <see cref="Monkey"/>s in the <see cref="Zoo"/>
        /// </summary>
        public List<Monkey> Monkeys { get; private set; }

        /// <summary>
        /// Gets the <see cref="Elephant"/>s in the <see cref="Zoo"/>
        /// </summary>
        public List<Elephant> Elephants { get; private set; }

        /// <summary>
        /// Gets the <see cref="Giraffe"/>s in the <see cref="Zoo"/>
        /// </summary>
        public List<Giraffe> Giraffes { get; private set; }

        /// <summary>
        /// Method for adding a new <see cref="BaseAnimal"/> to the <see cref="Zoo"/>
        /// </summary>
        /// <param name="animal">The <see cref="BaseAnimal"/> to add to the <see cref="Zoo"/></param>
        public void AddAnimal(BaseAnimal animal)
        {
            animal.EnsureNotNull(nameof(animal));
            switch (animal.Type)
            {
                case AnimalType.Monkey:
                    Monkeys.Add((Monkey)animal);
                    break;
                case AnimalType.Elephant:
                    Elephants.Add((Elephant)animal);
                    break;
                case AnimalType.Giraffe:
                    Giraffes.Add((Giraffe)animal);
                    break;
            }
        }

        /// <summary>
        /// Method for refreshing the <see cref="Zoo"/> and all it's <see cref="BaseAnimal"/>s
        /// </summary>
        /// <param name="gameTime">The current game time</param>
        public void Refresh(DateTime gameTime)
        {
            _lblZooTime.Text = gameTime.ToString();
            Monkeys.ForEach(m => m.Refresh(gameTime));
            Elephants.ForEach(m => m.Refresh(gameTime));
            Giraffes.ForEach(m => m.Refresh(gameTime));
        }
    }
}
