using Microsoft.Practices.Prism.Mvvm;
using RubicCubeSolver.Model;

namespace RubicCubeSolver.ViewModels
{
    public class CubePlainViewViewModel : BindableBase
    {
        private Cube _cubeVM;

        public CubePlainViewViewModel()
        {
            CubeVM = new Cube();
            CubeVM.Randomize();
        }

        public Cube CubeVM
        {
            get { return _cubeVM; }
            set { SetProperty(ref _cubeVM, value); }
        }
    }
}
