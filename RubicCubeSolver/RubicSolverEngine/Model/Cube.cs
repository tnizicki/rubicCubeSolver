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
