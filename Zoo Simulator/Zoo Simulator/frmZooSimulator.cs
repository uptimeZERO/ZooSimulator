using System;
using System.Windows.Forms;
using Zoo_Simulator.Enums;
using Zoo_Simulator.Models;

namespace Zoo_Simulator
{
    public partial class frmZooSimulator : Form
    {
        private readonly Zoo _zoo;
        public frmZooSimulator()
        {
            InitializeComponent();
            _zoo = new Zoo(lblZooTime);
            _zoo.AddAnimal(AnimalType.Monkey, pbrMonkey1, lblMonkeyStatus1, lblMonkeyHealth1);
            _zoo.AddAnimal(AnimalType.Monkey, pbrMonkey2, lblMonkeyStatus2, lblMonkeyHealth2);
            _zoo.AddAnimal(AnimalType.Monkey, pbrMonkey3, lblMonkeyStatus3, lblMonkeyHealth3);
            _zoo.AddAnimal(AnimalType.Monkey, pbrMonkey4, lblMonkeyStatus4, lblMonkeyHealth4);
            _zoo.AddAnimal(AnimalType.Monkey, pbrMonkey5, lblMonkeyStatus5, lblMonkeyHealth5);

            _zoo.AddAnimal(AnimalType.Elephant, pbrElephant1, lblElephantStatus1, lblElephantHealth1);
            _zoo.AddAnimal(AnimalType.Elephant, pbrElephant2, lblElephantStatus2, lblElephantHealth2);
            _zoo.AddAnimal(AnimalType.Elephant, pbrElephant3, lblElephantStatus3, lblElephantHealth3);
            _zoo.AddAnimal(AnimalType.Elephant, pbrElephant4, lblElephantStatus4, lblElephantHealth4);
            _zoo.AddAnimal(AnimalType.Elephant, pbrElephant5, lblElephantStatus5, lblElephantHealth5);

            _zoo.AddAnimal(AnimalType.Giraffe, pbrGiraffe1, lblGiraffeStatus1, lblGiraffeHealth1);
            _zoo.AddAnimal(AnimalType.Giraffe, pbrGiraffe2, lblGiraffeStatus2, lblGiraffeHealth2);
            _zoo.AddAnimal(AnimalType.Giraffe, pbrGiraffe3, lblGiraffeStatus3, lblGiraffeHealth3);
            _zoo.AddAnimal(AnimalType.Giraffe, pbrGiraffe4, lblGiraffeStatus4, lblGiraffeHealth4);
            _zoo.AddAnimal(AnimalType.Giraffe, pbrGiraffe5, lblGiraffeStatus5, lblGiraffeHealth5);
        }

        private void frmZooSimulator_Load(object sender, EventArgs e)
        {
            tmrSimulationTimer.Enabled = true;
        }

        private void PnlMonkey3_Paint(object sender, PaintEventArgs e)
        {
            // unused
        }

        private void Label11_Click(object sender, EventArgs e)
        {
            // unused
        }

        private void Label12_Click(object sender, EventArgs e)
        {
            // unused
        }

        private void Label14_Click(object sender, EventArgs e)
        {
            // unused
        }

        private void LblGiraffeStatus5_Click(object sender, EventArgs e)
        {
            // unused
        }

        private void LblGiraffeStatus3_Click(object sender, EventArgs e)
        {
            // unused
        }

        private void PnlGiraffe2_Paint(object sender, PaintEventArgs e)
        {
            // unused
        }

        private void PnlGiraffe5_Paint(object sender, PaintEventArgs e)
        {
            // unused
        }

        private void Label3_Click(object sender, EventArgs e)
        {
            // unused
        }

        private void TmrSimulationTimer_Tick(object sender, EventArgs e)
        {
            _zoo.TickUpdate();
        }

        private void BtnFeedZoo_Click(object sender, EventArgs e)
        {
            _zoo.FeedZoo();
        }
    }
}
