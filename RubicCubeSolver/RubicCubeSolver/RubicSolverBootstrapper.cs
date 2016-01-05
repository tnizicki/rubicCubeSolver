﻿using System.Windows;
using Autofac;
using Prism.AutofacExtension;
using RubicCubeSolver.ViewModels;
using RubicCubeSolver.Views;
using Microsoft.Practices.Prism.Mvvm;
using RubicSolverEngine.Model;

namespace RubicCubeSolver
{
    class RubicSolverBootstrapper : AutofacBootstrapper
    {
        protected override void ConfigureContainer(ContainerBuilder builder)
        {
            base.ConfigureContainer(builder);

            //var viewModelAssembly = typeof(ShellViewModel).Assembly;
            //builder.RegisterAssemblyTypes(viewModelAssembly).Where(x => x.Name != null && x.Name.EndsWith("ViewModel") && !x.Name.Contains("ShellViewModel"));

            builder.RegisterType<UserControl3ViewModel>().SingleInstance();
            builder.RegisterType<ShellViewModel>().SingleInstance();
            builder.RegisterType<CubeViewModel>().SingleInstance();
            builder.Register(x => new CubePlainViewViewModel(new Cube())).SingleInstance();
            builder.RegisterType<Shell>();
        }

        protected override DependencyObject CreateShell()
        {
            ViewModelLocationProvider.SetDefaultViewModelFactory(x => Container.Resolve(x));
            return Container.Resolve<Shell>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            Application.Current.MainWindow = (Shell)Shell;
            Application.Current.MainWindow.Show();
        }
    }
}
