using RubicCubeSolver.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            FrontLayer = Layer.GetFullColorLayer(LayerColor.Blue);
            UpLayer = Layer.GetFullColorLayer(LayerColor.Green);
            DownLayer = Layer.GetFullColorLayer(LayerColor.Orange);
            BottomLayer = Layer.GetFullColorLayer(LayerColor.Red);
            RightLayer = Layer.GetFullColorLayer(LayerColor.White);
            LeftLayer = Layer.GetFullColorLayer(LayerColor.Yellow);
        }
    }
}
