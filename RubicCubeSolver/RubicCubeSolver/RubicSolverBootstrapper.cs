using System.Windows;
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

            builder.RegisterType<Cube>().SingleInstance();

            builder.RegisterType<UserControl3ViewModel>().SingleInstance();
            builder.RegisterType<ShellViewModel>().SingleInstance();
            builder.RegisterType<CubeViewModel>().SingleInstance();
            builder.RegisterType<CubePlainViewViewModel>().SingleInstance();
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
