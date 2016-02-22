using Microsoft.Practices.Prism.Mvvm;
using System.Windows.Media;
using System.Windows.Input;
using RubicSolverEngine.Model;
using Microsoft.Practices.Prism.Commands;
using RubicSolverEngine.Model.Enum;
using RubicSolverEngine.Events;

namespace RubicCubeSolver.ControlViewModels
{
    public class SurfaceViewModel : BindableBase
    {
        private readonly Surface _side;
        private Color _topLeft;
        private Color _topMid;
        private Color _topRight;
        private Color _midLeft;
        private Color _mid;
        private Color _midRight;
        private Color _bottomLeft;
        private Color _bottomMid;
        private Color _bottomRight;

        public ICommand ChangeColorCommand { get; set; }

        public SurfaceViewModel(Surface side)
        {
            _side = side;
            side.SurfaceModified += Side_SurfaceModified;
            ChangeColorCommand = new DelegateCommand<string>(ChangeColor);
            Init();
        }

        private void Side_SurfaceModified(object sender, SurfaceModifiedEventArgs e)
        {
            Init();
        }

        private void Init()
        {
            TopLeft = _side[SurfacePosition.TopLeft];
            TopMid = _side[SurfacePosition.TopMid];
            TopRight = _side[SurfacePosition.TopRight];
            MidLeft = _side[SurfacePosition.MidLeft];
            Mid = _side[SurfacePosition.Mid];
            MidRight = _side[SurfacePosition.MidRight];
            BottomLeft = _side[SurfacePosition.BottomLeft];
            BottomMid = _side[SurfacePosition.BottomMid];
            BottomRight = _side[SurfacePosition.BottomRight];
        }

        private void ChangeColor(string parameter)
        {
            var property = GetType().GetProperty(parameter);
            var nextNode = _side.ColorsOrder.Find((Color)property.GetValue(this)).Next;
            var nextVal = nextNode != null ? nextNode.Value : _side.ColorsOrder.First.Value;
            property.SetValue(this, nextVal);
        }

        public Color TopLeft
        {
            get { return _topLeft; }
            set
            {
                if (_topLeft != value)
                {
                    SetProperty(ref _topLeft, value);
                    _side[SurfacePosition.TopLeft] = value;
                }
            }
        }

        public Color TopMid
        {
            get { return _topMid; }
            set
            {
                if (_topMid != value)
                {
                    SetProperty(ref _topMid, value);
                    _side[SurfacePosition.TopMid] = value;
                }
            }
        }
        public Color TopRight
        {
            get { return _topRight; }
            set
            {
                if (_topRight != value)
                {
                    SetProperty(ref _topRight, value);
                    _side[SurfacePosition.TopRight] = value;
                }
            }
        }

        public Color MidLeft
        {
            get { return _midLeft; }
            set
            {
                if (_midLeft != value)
                {
                    SetProperty(ref _midLeft, value);
                    _side[SurfacePosition.MidLeft] = value;
                }
            }
        }

        public Color Mid
        {
            get { return _mid; }
            set
            {
                if (_mid != value)
                {
                    SetProperty(ref _mid, value);
                    _side[SurfacePosition.Mid] = value;
                }
            }
        }

        public Color MidRight
        {
            get { return _midRight; }
            set
            {
                if (_midRight != value)
                {
                    SetProperty(ref _midRight, value);
                    _side[SurfacePosition.MidRight] = value;
                }
            }
        }

        public Color BottomLeft
        {
            get { return _bottomLeft; }
            set
            {
                if (_bottomLeft != value)
                {
                    SetProperty(ref _bottomLeft, value);
                    _side[SurfacePosition.BottomLeft] = value;
                }
            }
        }

        public Color BottomMid
        {
            get { return _bottomMid; }
            set
            {
                if (_bottomMid != value)
                {
                    SetProperty(ref _bottomMid, value);
                    _side[SurfacePosition.BottomMid] = value;
                }
            }
        }

        public Color BottomRight
        {
            get { return _bottomRight; }
            set
            {
                if (_bottomRight != value)
                {
                    SetProperty(ref _bottomRight, value);
                    _side[SurfacePosition.BottomRight] = value;
                }
            }
        }
    }
}
