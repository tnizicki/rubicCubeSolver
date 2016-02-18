using RubicSolverEngine.Model.Enum;
using System.Collections.Generic;
using System.Windows.Media;
using System;

namespace RubicSolverEngine.Model
{
    public class Cube
    {
        public Dictionary<SideType, Surface> Surfaces { get; private set; } = new Dictionary<SideType, Surface>();

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
            Surfaces.Add(SideType.Front, Surface.GetFullColorLayer(Colors.Blue));
            Surfaces.Add(SideType.Bottom, Surface.GetFullColorLayer(Colors.Green));
            Surfaces.Add(SideType.Top, Surface.GetFullColorLayer(Colors.Orange));
            Surfaces.Add(SideType.Down, Surface.GetFullColorLayer(Colors.Red));
            Surfaces.Add(SideType.Right, Surface.GetFullColorLayer(Colors.White));
            Surfaces.Add(SideType.Left, Surface.GetFullColorLayer(Colors.Yellow));
        }

        public void PeformFMove()
        {
            
        }
    }
}
