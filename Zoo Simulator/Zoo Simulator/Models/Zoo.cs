using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Zoo_Simulator.Enums;
using Zoo_Simulator.Extensions;
using Zoo_Simulator.Models.Interfaces;

namespace Zoo_Simulator.Models
{
    /// <summary>
    /// The zoo object containing all the animals.
    /// </summary>
    public class Zoo
    {
        private static string _gameTimeDaysText = "Day: ";
        private DateTime _gameTime;
        private Label _gameTimeLabel;
        private List<IAnimal> _animals;
        private int _hoursTicks;
        private int _statusTicks;
        private Random _random;

        /// <summary>
        /// Initializes a new instance of the <see cref="Zoo"/> class.
        /// </summary>
        /// <param name="gameTimeLabel">The <see cref="Label"/> for the game time.</param>
        public Zoo(Label gameTimeLabel)
        {
            _hoursTicks = 0;
            _statusTicks = 0;
            _gameTimeLabel = gameTimeLabel
                ?? throw new ArgumentNullException(nameof(_gameTimeLabel), "Cannot be null");

            _gameTime = new DateTime(1970, 1, 1, 0, 0, 0);
            _animals = new List<IAnimal>();
            _random = new Random();
        }

        /// <summary>
        /// Method for adding an animal to the <see cref="Zoo"/>.
        /// </summary>
        /// <param name="animalType">The type of animal being added to the <see cref="Zoo"/>.</param>
        /// <param name="animalHealthBar">The health bar of the animal.</param>
        /// <param name="animalStatusLabel">The status <see cref="Label"/> of the animal.</param>
        /// <param name="animalHealthLabel">The health <see cref="Label"/> of the animal.</param>
        public void AddAnimal(
            AnimalType animalType,
            Label animalHealthBar,
            Label animalStatusLabel,
            Label animalHealthLabel)
        {
            switch (animalType)
            {
                case AnimalType.Monkey:
                    if (_animals.Count(x => x.Type == AnimalType.Monkey) < 6)
                    {
                        _animals.Add(
                            new Monkey(
                                animalHealthBar,
                                animalStatusLabel,
                                animalHealthLabel,
                                _random));
                    }
                    else
                    {
                        throw new InvalidOperationException("The zoo cannot have more than 5 of each animal type");
                    }

                    break;

                case AnimalType.Elephant:
                    if (_animals.Count(x => x.Type == AnimalType.Elephant) < 6)
                    {
                        _animals.Add(
                            new Elephant(
                                animalHealthBar,
                                animalStatusLabel,
                                animalHealthLabel,
                                _random));
                    }
                    else
                    {
                        throw new InvalidOperationException("The zoo cannot have more than 5 of each animal type");
                    }

                    break;

                case AnimalType.Giraffe:
                    if (_animals.Count(x => x.Type == AnimalType.Giraffe) < 6)
                    {
                        _animals.Add(
                            new Giraffe(
                                animalHealthBar,
                                animalStatusLabel,
                                animalHealthLabel,
                                _random));
                    }
                    else
                    {
                        throw new InvalidOperationException("The zoo cannot have more than 5 of each animal type");
                    }

                    break;
            }
        }

        /// <summary>
        /// Method for feeding the <see cref="Zoo"/>.
        /// </summary>
        public void FeedZoo()
        {
            if (!IsZooDead())
            {
                var monkeyFood = _random.Next(10, 25);
                var elephantFood = _random.Next(10, 25);
                var giraffeFood = _random.Next(10, 25);

                _animals
                    .Where(x =>
                        !x.IsDead &&
                        x.Type == AnimalType.Monkey)
                    .ToList()
                    .ForEach(x => x.Eat(monkeyFood));

                _animals
                    .Where(x =>
                        !x.IsDead &&
                        x.Type == AnimalType.Elephant)
                    .ToList()
                    .ForEach(x => x.Eat(elephantFood));

                _animals
                    .Where(x =>
                        !x.IsDead &&
                        x.Type == AnimalType.Giraffe)
                    .ToList()
                    .ForEach(x => x.Eat(giraffeFood));

                _animals
                    .Where(x => !x.IsDead)
                    .ToList()
                    .ForEach(x => x.StatusString = AnimalStatus.Eating.GetString());

                _animals
                    .Where(x => !x.IsDead)
                    .ToList()
                    .ForEach(x => x.Status = AnimalStatus.Eating);

                _statusTicks = 0;
            }
        }

        /// <summary>
        /// Method for updating the game.
        /// </summary>
        public void TickUpdate()
        {
            if (!IsZooDead())
            {
                _gameTime = _gameTime.AddMinutes(3);
                UpdateStatus();
                TakeIdleDamage();

                _animals
                    .Where(x => !x.IsDead)
                    .ToList()
                    .ForEach(x => x.TickUpdate());
                _gameTimeLabel.Text = _gameTime.ToLongTimeString();
            }
        }

        /// <summary>
        /// Method for taking idle damage.
        /// </summary>
        private void TakeIdleDamage()
        {
            _hoursTicks++;
            if (_hoursTicks == 20)
            {
                _hoursTicks = 0;
                _animals
                    .Where(x => !x.IsDead)
                    .ToList()
                    .ForEach(x => x.TakeIdleDamage());
            }
        }

        /// <summary>
        /// Method for updating the status of the animals.
        /// </summary>
        private void UpdateStatus()
        {
            if (!IsZooDead())
            {
                _statusTicks++;
                if (_statusTicks == 4)
                {
                    _animals
                        .Where(x => !x.IsDead)
                        .ToList()
                        .ForEach(x => x.UpdateStatus());
                    _statusTicks = 0;
                }
            }
        }

        /// <summary>
        /// Method for checking to see if all the animals in the <see cref="Zoo"/> are dead.
        /// </summary>
        /// <returns>A value indicating whether all the animals in the <see cref="Zoo"/> are dead.</returns>
        private bool IsZooDead()
        {
            return _animals.TrueForAll(x => x.IsDead);
        }
    }
}
