﻿using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using RubicSolverEngine.Model;
using System.Windows;
using System.Windows.Input;

namespace RubicCubeSolver.ViewModels
{
    public class CubePlainViewViewModel : CubeViewModel
    {
        private readonly Cube _cube;

        public ICommand FMoveCommand { get; set; }
        public ICommand BMoveCommand { get; set; }
        public ICommand UMoveCommand { get; set; }
        public ICommand DMoveCommand { get; set; }
        public ICommand LMoveCommand { get; set; }
        public ICommand RMoveCommand { get; set; }

        public CubePlainViewViewModel(Cube cube)
            : base(cube)
        {
            _cube = cube;
            //FMoveCommand = new DelegateCommand(_cube.PeformFMove);
            FMoveCommand = new DelegateCommand(() =>
            {
                MessageBox.Show(cube.Surfaces[RubicSolverEngine.Model.Enum.SideType.Front].ToString());
            });
        }
    }
}
