using System.Windows.Media;

namespace RubicCubeSolver.Model
{
    public class Cube
    {
        public Layer FrontLayer { get; private set; }
        public Layer UpLayer { get; private set; }
        public Layer DownLayer { get; private set; }
        public Layer BottomLayer { get; private set; }
        public Layer RightLayer { get; private set; }
        public Layer LeftLayer { get; private set; }

        public Cube()
        {

        }

        public bool IsValid()
        {
            return true; //TODO
        }

        public void Randomize()
        {
            FrontLayer = Layer.GetFullColorLayer(Colors.Blue);
            UpLayer = Layer.GetFullColorLayer(Colors.Green);
            DownLayer = Layer.GetFullColorLayer(Colors.Orange);
            BottomLayer = Layer.GetFullColorLayer(Colors.Red);
            RightLayer = Layer.GetFullColorLayer(Colors.White);
            LeftLayer = Layer.GetFullColorLayer(Colors.Yellow);
        }
    }
}
