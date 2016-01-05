using Microsoft.Practices.Prism.Mvvm;
using System.Windows.Media;
using System.Windows.Input;
using RubicSolverEngine.Model;
using Microsoft.Practices.Prism.Commands;
using RubicSolverEngine.Model.Enum;

namespace RubicCubeSolver.ControlViewModels
{
    public class SurfaceViewModel: BindableBase
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
            ChangeColorCommand = new DelegateCommand<string>(ChangeColor);
            Init();
        }

        private void Init()
        {
            TopLeft = _side.Positions[SurfacePosition.TopLeft];
            TopMid = _side.Positions[SurfacePosition.TopMid];
            TopRight = _side.Positions[SurfacePosition.TopRight];
            MidLeft = _side.Positions[SurfacePosition.MidLeft];
            Mid = _side.Positions[SurfacePosition.Mid];
            MidRight = _side.Positions[SurfacePosition.MidRight];
            BottomLeft = _side.Positions[SurfacePosition.BottomLeft];
            BottomMid = _side.Positions[SurfacePosition.BottomMid];
            BottomRight = _side.Positions[SurfacePosition.BottomRight];
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
            set { SetProperty(ref _topLeft, value); }
        }

        public Color TopMid
        {
            get { return _topMid; }
            set { SetProperty(ref _topMid, value); }
        }
        public Color TopRight
        {
            get { return _topRight; }
            set { SetProperty(ref _topRight, value); }
        }

        public Color MidLeft
        {
            get { return _midLeft; }
            set { SetProperty(ref _midLeft, value); }
        }

        public Color Mid
        {
            get { return _mid; }
            set { SetProperty(ref _mid, value); }
        }

        public Color MidRight
        {
            get { return _midRight; }
            set { SetProperty(ref _midRight, value); }
        }

        public Color BottomLeft
        {
            get { return _bottomLeft; }
            set { SetProperty(ref _bottomLeft, value); }
        }

        public Color BottomMid
        {
            get { return _bottomMid; }
            set { SetProperty(ref _bottomMid, value); }
        }

        public Color BottomRight
        {
            get { return _bottomRight; }
            set { SetProperty(ref _bottomRight, value); }
        }
    }
}
