using RubicSolverEngine.Model.Enum;
using System.Collections.Generic;
using System.Windows.Media;
using System;

namespace RubicSolverEngine.Model
{
    public class Cube
    {
        private Dictionary<SideType, Surface> _surfaces { get; set; } = new Dictionary<SideType, Surface>();

        public Surface this[SideType sideType]
        {
            get
            {
                return _surfaces[sideType];
            }
            set
            {
                _surfaces[sideType] = value;
            }
        }

        public Cube()
        {
            Init();
        }

        public bool IsValid()
        {
            return true; //TODO
        }

        private void Init()
        {
            this[SideType.Front] = Surface.GetFullColorLayer(Colors.Blue);
            this[SideType.Bottom] = Surface.GetFullColorLayer(Colors.Green);
            this[SideType.Top] = Surface.GetFullColorLayer(Colors.Orange);
            this[SideType.Down] = Surface.GetFullColorLayer(Colors.Red);
            this[SideType.Right] = Surface.GetFullColorLayer(Colors.White);
            this[SideType.Left] = Surface.GetFullColorLayer(Colors.Yellow);
        }

        public void PeformFMove()
        {
            this[SideType.Front].Rotate();

            var tmpT = this[SideType.Right][SurfacePosition.TopLeft];
            var tmpM = this[SideType.Right][SurfacePosition.MidLeft];
            var tmpB = this[SideType.Right][SurfacePosition.BottomLeft];

            this[SideType.Right][SurfacePosition.BottomLeft] = this[SideType.Top][SurfacePosition.BottomRight];
            this[SideType.Right][SurfacePosition.MidLeft] = this[SideType.Top][SurfacePosition.BottomMid];
            this[SideType.Right][SurfacePosition.TopLeft] = this[SideType.Top][SurfacePosition.BottomLeft];

            this[SideType.Top][SurfacePosition.BottomRight] = this[SideType.Left][SurfacePosition.TopRight];
            this[SideType.Top][SurfacePosition.BottomMid] = this[SideType.Left][SurfacePosition.MidRight];
            this[SideType.Top][SurfacePosition.BottomLeft] = this[SideType.Left][SurfacePosition.BottomRight];

            this[SideType.Left][SurfacePosition.TopRight] = this[SideType.Down][SurfacePosition.TopLeft];
            this[SideType.Left][SurfacePosition.MidRight] = this[SideType.Down][SurfacePosition.TopMid];
            this[SideType.Left][SurfacePosition.BottomRight] = this[SideType.Down][SurfacePosition.TopRight];

            this[SideType.Down][SurfacePosition.TopLeft] = tmpB;
            this[SideType.Down][SurfacePosition.TopMid] = tmpM;
            this[SideType.Down][SurfacePosition.TopRight] = tmpT;
        }

        public void PerformBMove()
        {
            this[SideType.Bottom].Rotate();
        }

        public void PerformUMove()
        {
            this[SideType.Top].Rotate();
        }

        public void PerformDMove()
        {
            this[SideType.Down].Rotate();
        }

        public void PerformRMove()
        {
            this[SideType.Right].Rotate();
        }

        public void PerformLMove()
        {
            this[SideType.Left].Rotate();
        }
    }
}
