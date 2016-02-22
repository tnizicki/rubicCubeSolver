using Microsoft.Practices.Prism.Mvvm;
using RubicCubeSolver.ControlViewModels;
using RubicSolverEngine.Model;
using RubicSolverEngine.Model.Enum;

namespace RubicCubeSolver.ViewModels
{
    public class CubeViewModel : BindableBase
    {
        private readonly Cube _cube;
        private SurfaceViewModel _topSurface;
        private SurfaceViewModel _downSurface;
        private SurfaceViewModel _leftSurface;
        private SurfaceViewModel _rightSurface;
        private SurfaceViewModel _frontSurface;
        private SurfaceViewModel _bottomSurface;
        
        public CubeViewModel(Cube cube)
        {
            _cube = cube;
            TopSurface = new SurfaceViewModel(_cube[SideType.Top]);
            DownSurface = new SurfaceViewModel(_cube[SideType.Down]);
            LeftSurface = new SurfaceViewModel(_cube[SideType.Left]);
            RightSurface = new SurfaceViewModel(_cube[SideType.Right]);
            FrontSurface = new SurfaceViewModel(_cube[SideType.Front]);
            BottomSurface = new SurfaceViewModel(_cube[SideType.Bottom]);
        }

        public SurfaceViewModel TopSurface
        {
            get { return _topSurface; }
            set { SetProperty(ref _topSurface, value); }
        }
        public SurfaceViewModel DownSurface
        {
            get { return _downSurface; }
            set { SetProperty(ref _downSurface, value); }
        }

        public SurfaceViewModel LeftSurface
        {
            get { return _leftSurface; }
            set { SetProperty(ref _leftSurface, value); }
        }
        public SurfaceViewModel RightSurface
        {
            get { return _rightSurface; }
            set { SetProperty(ref _rightSurface, value); }
        }
        public SurfaceViewModel FrontSurface
        {
            get { return _frontSurface; }
            set { SetProperty(ref _frontSurface, value); }
        }
        public SurfaceViewModel BottomSurface
        {
            get { return _bottomSurface; }
            set { SetProperty(ref _bottomSurface, value); }
        }
    }
}
