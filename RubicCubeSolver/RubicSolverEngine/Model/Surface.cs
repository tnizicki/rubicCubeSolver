using System.Collections.Generic;
using System.Windows.Media;
using RubicSolverEngine.Model.Enum;

namespace RubicSolverEngine.Model
{
    public class Surface
    {
        public Dictionary<SurfacePosition, Color> Positions { get; private set; }

        public LinkedList<Color> ColorsOrder { get; private set; } = new LinkedList<Color>(); //{ Colors.White, Colors.Yellow, Colors.Orange, Colors.Red, Colors.Green, Colors.Blue };
        
        public Surface()
        {
            ColorsOrder.AddLast(Colors.White);
            ColorsOrder.AddLast(Colors.Yellow);
            ColorsOrder.AddLast(Colors.Orange);
            ColorsOrder.AddLast(Colors.Red);
            ColorsOrder.AddLast(Colors.Green);
            ColorsOrder.AddLast(Colors.Blue);
        }

        public Surface(Dictionary<SurfacePosition, Color> content)
            : this()
        {
            Positions = content;
        }

        internal static Surface GetFullColorLayer(Color color)
        {
            return new Surface(new Dictionary<SurfacePosition, Color>
            {
                {SurfacePosition.BottomLeft, color },
                {SurfacePosition.BottomMid, color },
                {SurfacePosition.BottomRight, color },
                {SurfacePosition.MidLeft, color },
                {SurfacePosition.Mid, color },
                {SurfacePosition.MidRight, color },
                {SurfacePosition.TopLeft, color },
                {SurfacePosition.TopMid, color },
                {SurfacePosition.TopRight, color }
            });
        }
    }
}
