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

        public void Resolve()
        {
            var result = IsFirstStepCrossReady();
            result = IsFirstLayerReady();
            Console.WriteLine(result);
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

            var tmpL = this[SideType.Top][SurfacePosition.TopLeft];
            var tmpM = this[SideType.Top][SurfacePosition.TopMid];
            var tmpR = this[SideType.Top][SurfacePosition.TopRight];

            this[SideType.Top][SurfacePosition.TopLeft] = this[SideType.Right][SurfacePosition.TopRight];
            this[SideType.Top][SurfacePosition.TopMid] = this[SideType.Right][SurfacePosition.MidRight];
            this[SideType.Top][SurfacePosition.TopRight] = this[SideType.Right][SurfacePosition.BottomRight];

            this[SideType.Right][SurfacePosition.TopRight] = this[SideType.Down][SurfacePosition.BottomRight];
            this[SideType.Right][SurfacePosition.MidRight] = this[SideType.Down][SurfacePosition.BottomMid];
            this[SideType.Right][SurfacePosition.BottomRight] = this[SideType.Down][SurfacePosition.BottomLeft];

            this[SideType.Down][SurfacePosition.BottomRight] = this[SideType.Left][SurfacePosition.BottomLeft];
            this[SideType.Down][SurfacePosition.BottomMid] = this[SideType.Left][SurfacePosition.MidLeft];
            this[SideType.Down][SurfacePosition.BottomLeft] = this[SideType.Left][SurfacePosition.TopLeft];

            this[SideType.Left][SurfacePosition.BottomLeft] = tmpL;
            this[SideType.Left][SurfacePosition.MidLeft] = tmpM;
            this[SideType.Left][SurfacePosition.TopLeft] = tmpR;
        }

        public void PerformUMove()
        {
            this[SideType.Top].Rotate();

            var tmpT = this[SideType.Left][SurfacePosition.TopLeft];
            var tmpM = this[SideType.Left][SurfacePosition.TopMid];
            var tmpB = this[SideType.Left][SurfacePosition.TopRight];

            this[SideType.Left][SurfacePosition.TopLeft] = this[SideType.Front][SurfacePosition.TopLeft];
            this[SideType.Left][SurfacePosition.TopMid] = this[SideType.Front][SurfacePosition.TopMid];
            this[SideType.Left][SurfacePosition.TopRight] = this[SideType.Front][SurfacePosition.TopRight];

            this[SideType.Front][SurfacePosition.TopLeft] = this[SideType.Right][SurfacePosition.TopLeft];
            this[SideType.Front][SurfacePosition.TopMid] = this[SideType.Right][SurfacePosition.TopMid];
            this[SideType.Front][SurfacePosition.TopRight] = this[SideType.Right][SurfacePosition.TopRight];

            this[SideType.Right][SurfacePosition.TopLeft] = this[SideType.Bottom][SurfacePosition.TopLeft];
            this[SideType.Right][SurfacePosition.TopMid] = this[SideType.Bottom][SurfacePosition.TopMid];
            this[SideType.Right][SurfacePosition.TopRight] = this[SideType.Bottom][SurfacePosition.TopRight];

            this[SideType.Bottom][SurfacePosition.TopLeft] = tmpT;
            this[SideType.Bottom][SurfacePosition.TopMid] = tmpM;
            this[SideType.Bottom][SurfacePosition.TopRight] = tmpB;
        }

        public void PerformDMove()
        {
            this[SideType.Down].Rotate();

            var tmpT = this[SideType.Left][SurfacePosition.BottomLeft];
            var tmpM = this[SideType.Left][SurfacePosition.BottomMid];
            var tmpB = this[SideType.Left][SurfacePosition.BottomRight];

            this[SideType.Left][SurfacePosition.BottomLeft] = this[SideType.Front][SurfacePosition.BottomLeft];
            this[SideType.Left][SurfacePosition.BottomMid] = this[SideType.Front][SurfacePosition.BottomMid];
            this[SideType.Left][SurfacePosition.BottomRight] = this[SideType.Front][SurfacePosition.BottomRight];

            this[SideType.Front][SurfacePosition.BottomLeft] = this[SideType.Right][SurfacePosition.BottomLeft];
            this[SideType.Front][SurfacePosition.BottomMid] = this[SideType.Right][SurfacePosition.BottomMid];
            this[SideType.Front][SurfacePosition.BottomRight] = this[SideType.Right][SurfacePosition.BottomRight];

            this[SideType.Right][SurfacePosition.BottomLeft] = this[SideType.Bottom][SurfacePosition.BottomLeft];
            this[SideType.Right][SurfacePosition.BottomMid] = this[SideType.Bottom][SurfacePosition.BottomMid];
            this[SideType.Right][SurfacePosition.BottomRight] = this[SideType.Bottom][SurfacePosition.BottomRight];

            this[SideType.Bottom][SurfacePosition.BottomLeft] = tmpT;
            this[SideType.Bottom][SurfacePosition.BottomMid] = tmpM;
            this[SideType.Bottom][SurfacePosition.BottomRight] = tmpB;
        }

        public void PerformRMove()
        {
            this[SideType.Right].Rotate();

            var tmpT = this[SideType.Bottom][SurfacePosition.TopLeft];
            var tmpM = this[SideType.Bottom][SurfacePosition.MidLeft];
            var tmpB = this[SideType.Bottom][SurfacePosition.BottomLeft];

            this[SideType.Bottom][SurfacePosition.BottomLeft] = this[SideType.Top][SurfacePosition.TopRight];
            this[SideType.Bottom][SurfacePosition.MidLeft] = this[SideType.Top][SurfacePosition.MidRight];
            this[SideType.Bottom][SurfacePosition.TopLeft] = this[SideType.Top][SurfacePosition.BottomRight];

            this[SideType.Top][SurfacePosition.TopRight] = this[SideType.Front][SurfacePosition.TopRight];
            this[SideType.Top][SurfacePosition.MidRight] = this[SideType.Front][SurfacePosition.MidRight];
            this[SideType.Top][SurfacePosition.BottomRight] = this[SideType.Front][SurfacePosition.BottomRight];

            this[SideType.Front][SurfacePosition.TopRight] = this[SideType.Down][SurfacePosition.TopRight];
            this[SideType.Front][SurfacePosition.MidRight] = this[SideType.Down][SurfacePosition.MidRight];
            this[SideType.Front][SurfacePosition.BottomRight] = this[SideType.Down][SurfacePosition.BottomRight];

            this[SideType.Down][SurfacePosition.TopRight] = tmpB;
            this[SideType.Down][SurfacePosition.MidRight] = tmpM;
            this[SideType.Down][SurfacePosition.BottomRight] = tmpT;
        }

        public void PerformLMove()
        {
            this[SideType.Left].Rotate();

            var tmpT = this[SideType.Front][SurfacePosition.TopLeft];
            var tmpM = this[SideType.Front][SurfacePosition.MidLeft];
            var tmpB = this[SideType.Front][SurfacePosition.BottomLeft];

            this[SideType.Front][SurfacePosition.TopLeft] = this[SideType.Top][SurfacePosition.TopLeft];
            this[SideType.Front][SurfacePosition.MidLeft] = this[SideType.Top][SurfacePosition.MidLeft];
            this[SideType.Front][SurfacePosition.BottomLeft] = this[SideType.Top][SurfacePosition.BottomLeft];

            this[SideType.Top][SurfacePosition.TopLeft] = this[SideType.Bottom][SurfacePosition.BottomRight];
            this[SideType.Top][SurfacePosition.MidLeft] = this[SideType.Bottom][SurfacePosition.MidRight];
            this[SideType.Top][SurfacePosition.BottomLeft] = this[SideType.Bottom][SurfacePosition.TopRight];

            this[SideType.Bottom][SurfacePosition.BottomRight] = this[SideType.Down][SurfacePosition.TopLeft];
            this[SideType.Bottom][SurfacePosition.MidRight] = this[SideType.Down][SurfacePosition.MidLeft];
            this[SideType.Bottom][SurfacePosition.TopRight] = this[SideType.Down][SurfacePosition.BottomLeft];

            this[SideType.Down][SurfacePosition.TopLeft] = tmpT;
            this[SideType.Down][SurfacePosition.MidLeft] = tmpM;
            this[SideType.Down][SurfacePosition.BottomLeft] = tmpB;
        }

        private bool IsFirstStepCrossReady()
        {
            var result = true;
            result &= this[SideType.Down][SurfacePosition.TopMid].Equals(this[SideType.Down][SurfacePosition.Mid]);
            result &= this[SideType.Down][SurfacePosition.BottomMid].Equals(this[SideType.Down][SurfacePosition.Mid]);
            result &= this[SideType.Down][SurfacePosition.MidLeft].Equals(this[SideType.Down][SurfacePosition.Mid]);
            result &= this[SideType.Down][SurfacePosition.MidRight].Equals(this[SideType.Down][SurfacePosition.Mid]);

            result &= this[SideType.Front][SurfacePosition.Mid].Equals(this[SideType.Front][SurfacePosition.BottomMid]);
            result &= this[SideType.Right][SurfacePosition.Mid].Equals(this[SideType.Right][SurfacePosition.BottomMid]);
            result &= this[SideType.Left][SurfacePosition.Mid].Equals(this[SideType.Left][SurfacePosition.BottomMid]);
            result &= this[SideType.Bottom][SurfacePosition.Mid].Equals(this[SideType.Bottom][SurfacePosition.BottomMid]);

            return result;
        }

        private bool IsFirstLayerReady()
        {
            var result = true;
            result &= this[SideType.Front][SurfacePosition.BottomRight].Equals(this[SideType.Front][SurfacePosition.Mid]);  //
            result &= this[SideType.Right][SurfacePosition.BottomLeft].Equals(this[SideType.Right][SurfacePosition.Mid]);   //front right corner
            result &= this[SideType.Down][SurfacePosition.TopRight].Equals(this[SideType.Down][SurfacePosition.Mid]);       //

            result &= this[SideType.Front][SurfacePosition.BottomLeft].Equals(this[SideType.Front][SurfacePosition.Mid]);  //
            result &= this[SideType.Left][SurfacePosition.BottomRight].Equals(this[SideType.Left][SurfacePosition.Mid]);   //front left corner
            result &= this[SideType.Down][SurfacePosition.TopLeft].Equals(this[SideType.Down][SurfacePosition.Mid]);       //

            result &= this[SideType.Bottom][SurfacePosition.BottomLeft].Equals(this[SideType.Bottom][SurfacePosition.Mid]);  //
            result &= this[SideType.Right][SurfacePosition.BottomRight].Equals(this[SideType.Right][SurfacePosition.Mid]);   //bottom right corner
            result &= this[SideType.Down][SurfacePosition.BottomRight].Equals(this[SideType.Down][SurfacePosition.Mid]);     //

            result &= this[SideType.Bottom][SurfacePosition.BottomRight].Equals(this[SideType.Bottom][SurfacePosition.Mid]);  //
            result &= this[SideType.Left][SurfacePosition.BottomLeft].Equals(this[SideType.Left][SurfacePosition.Mid]);       //bottom left corner
            result &= this[SideType.Down][SurfacePosition.BottomLeft].Equals(this[SideType.Down][SurfacePosition.Mid]);       //

            return result;
        }
    }
}
