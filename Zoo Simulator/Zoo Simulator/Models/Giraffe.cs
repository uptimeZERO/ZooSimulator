using System.Windows.Forms;
using Zoo_Simulator.Models.Enums;

namespace Zoo_Simulator.Models
{
    /// <summary>
    /// Represents a <see cref="Giraffe"/>
    /// </summary>
    public class Giraffe : BaseAnimal
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Giraffe"/> class
        /// </summary>
        /// <param name="number">The number of the <see cref="Giraffe"/></param>
        /// <param name="pbar">The <see cref="Giraffe"/>s health bar</param>
        /// <param name="btn">The <see cref="Giraffe"/>s feed buttn</param>
        /// <param name="lblStatus">The status <see cref="Label"/></param>
        /// <param name="lblHealth">The health <see cref="Label"/></param>
        public Giraffe(
            int number,
            ProgressBar pbar,
            Button btn,
            Label lblStatus,
            Label lblHealth)
            : base(number, pbar, btn, lblStatus, lblHealth)
        {
        }

        /// <summary>
        /// Gets the <see cref="Giraffe.HealthCapacity"/>
        /// </summary>
        public override double HealthCapacity => 500.00;

        /// <summary>
        /// Gets the <see cref="AnimalType"/>
        /// </summary>
        public override AnimalType Type => AnimalType.Giraffe;

        /// <summary>
        /// Gets the seconds taken to finish eating
        /// </summary>
        protected override int SecondsToEat => 600;
    }
}
