using Microsoft.Practices.Prism.Mvvm;
using RubicSolverEngine.Model;

namespace RubicCubeSolver.ViewModels
{
    public class CubePlainViewViewModel : CubeViewModel
    {
        private readonly Cube _cube;

        public CubePlainViewViewModel(Cube cube)
            : base(cube)
        {
            _cube = cube;
        }
    }
}
