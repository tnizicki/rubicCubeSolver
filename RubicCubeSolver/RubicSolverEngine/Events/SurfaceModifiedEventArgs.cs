using RubicSolverEngine.Model.Enum;
using System;
using System.Windows.Media;

namespace RubicSolverEngine.Events
{
    public class SurfaceModifiedEventArgs: EventArgs
    {
        public SurfacePosition AffectedPosition { get; set; }
        public Color NewColor { get; set; }
    }
}
