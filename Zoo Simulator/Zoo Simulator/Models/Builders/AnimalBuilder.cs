using System.Windows.Forms;
using Zoo_Simulator.Extensions;
using Zoo_Simulator.Models.Enums;

namespace Zoo_Simulator.Models.Builders
{
    /// <summary>
    /// Builder for building a <see cref="BaseAnimal"/>
    /// </summary>
    public class AnimalBuilder
    {
        private AnimalType _type;

        private int _number;

        private ProgressBar _pBar;

        private Button _btn;

        private Label _lblStatus;

        private Label _lblHealth;

        /// <summary>
        /// Method for setting the <see cref="AnimalType"/> of the <see cref="BaseAnimal"/>
        /// </summary>
        /// <param name="type">The <see cref="AnimalType"/> to set</param>
        /// <returns>This <see cref="AnimalBuilder"/></returns>
        public AnimalBuilder SetType(AnimalType type)
        {
            _type = type;
            return this;
        }

        /// <summary>
        /// Method for setting the number of the <see cref="BaseAnimal"/>
        /// </summary>
        /// <param name="number">The number to set</param>
        /// <returns>This <see cref="AnimalBuilder"/></returns>
        public AnimalBuilder SetNumber(int number)
        {
            _number = number;
            return this;
        }

        /// <summary>
        /// Method for setting the <see cref="ProgressBar"/> of the <see cref="BaseAnimal"/>
        /// </summary>
        /// <param name="pBar">The <see cref="ProgressBar"/> to set</param>
        /// <returns>This <see cref="AnimalBuilder"/></returns>
        public AnimalBuilder SetProgressBar(ProgressBar pBar)
        {
            _pBar = pBar;
            return this;
        }

        /// <summary>
        /// Method for setting the <see cref="Button"/> of the <see cref="BaseAnimal"/>
        /// </summary>
        /// <param name="btn">The <see cref="Button"/> to set</param>
        /// <returns>This <see cref="AnimalBuilder"/></returns>
        public AnimalBuilder SetButton(Button btn)
        {
            _btn = btn;
            return this;
        }

        /// <summary>
        /// Method for setting the status <see cref="Label"/> of the <see cref="BaseAnimal"/>
        /// </summary>
        /// <param name="lblStatus">The <see cref="Label"/> to set</param>
        /// <returns>This <see cref="AnimalBuilder"/></returns>
        public AnimalBuilder SetStatusLabel(Label lblStatus)
        {
            _lblStatus = lblStatus;
            return this;
        }

        /// <summary>
        /// Method for setting the health <see cref="Label"/> of the <see cref="BaseAnimal"/>
        /// </summary>
        /// <param name="lblHealth">The <see cref="Label"/> to set</param>
        /// <returns>This <see cref="AnimalBuilder"/></returns>
        public AnimalBuilder SetHealthLabel(Label lblHealth)
        {
            _lblHealth = lblHealth;
            return this;
        }

        /// <summary>
        /// Builds and returns the <see cref="BaseAnimal"/>
        /// </summary>
        /// <returns>A built <see cref="BaseAnimal"/></returns>
        public BaseAnimal Build()
        {
            Validate();
            var result = default(BaseAnimal);

            switch (_type)
            {
                case AnimalType.Elephant:
                    result = new Elephant(
                        _number,
                        _pBar,
                        _btn,
                        _lblStatus,
                        _lblHealth);
                    break;
                case AnimalType.Monkey:
                    result = new Monkey(
                        _number,
                        _pBar,
                        _btn,
                        _lblStatus,
                        _lblHealth);
                    break;
                case AnimalType.Giraffe:
                    result = new Giraffe(
                        _number,
                        _pBar,
                        _btn,
                        _lblStatus,
                        _lblHealth);
                    break;
            }

            return result;
        }

        /// <summary>
        /// Ensures that the <see cref="AnimalBuilder"/> is in the correct state to build
        /// </summary>
        private void Validate()
        {
            _pBar.EnsureNotNull(nameof(_pBar));
            _btn.EnsureNotNull(nameof(_btn));
            _lblStatus.EnsureNotNull(nameof(_lblStatus));
            _lblHealth.EnsureNotNull(nameof(_lblHealth));
        }
    }
}
