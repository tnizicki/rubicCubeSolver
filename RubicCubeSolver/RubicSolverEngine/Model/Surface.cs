using System.Collections.Generic;
using System.Windows.Media;
using RubicSolverEngine.Model.Enum;
using System.Text;
using RubicSolverEngine.Events;
using System;

namespace RubicSolverEngine.Model
{
    public class Surface
    {
        private Dictionary<SurfacePosition, Color> Positions { get; set; }

        public Color this[SurfacePosition surfacePosition]
        {
            get
            {
                return Positions[surfacePosition];
            }
            set
            {
                Positions[surfacePosition] = value;
                FireSurfaceModified(surfacePosition, value);
            }
        }

        public event EventHandler<SurfaceModifiedEventArgs> SurfaceModified;

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

        internal void Rotate()
        {
            var tmpT = this[SurfacePosition.TopRight];
            var tmpM = this[SurfacePosition.MidRight];
            var tmpB = this[SurfacePosition.BottomRight];

            this[SurfacePosition.BottomRight] = this[SurfacePosition.TopRight];
            this[SurfacePosition.MidRight] = this[SurfacePosition.TopMid];
            this[SurfacePosition.TopRight] = this[SurfacePosition.TopLeft];
            this[SurfacePosition.TopMid] = this[SurfacePosition.MidLeft];
            this[SurfacePosition.TopLeft] = this[SurfacePosition.BottomLeft];
            this[SurfacePosition.MidLeft] = this[SurfacePosition.BottomMid];
            this[SurfacePosition.BottomLeft] = tmpB;
            this[SurfacePosition.BottomMid] = tmpM;
            this[SurfacePosition.BottomRight] = tmpT;
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

        public override string ToString()
        {
            var builder = new StringBuilder();
            foreach (var item in Positions)
            {
                builder.AppendLine($"{item.Key}: {item.Value}");
            }
            return builder.ToString();
        }

        private void FireSurfaceModified(SurfacePosition surfacePosition, Color value)
        {
            if (SurfaceModified != null)
            {
                SurfaceModified(this, new SurfaceModifiedEventArgs() { AffectedPosition = surfacePosition, NewColor = value });
            }
        }
    }
}
