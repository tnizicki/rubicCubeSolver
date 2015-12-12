using System.Windows;
using Autofac;
using Prism.AutofacExtension;
using RubicCubeSolver.ViewModels;
using RubicCubeSolver.Views;
using Microsoft.Practices.Prism.Mvvm;

namespace RubicCubeSolver
{
    class RubicSolverBootstrapper : AutofacBootstrapper
    {
        protected override void ConfigureContainer(ContainerBuilder builder)
        {
            base.ConfigureContainer(builder); //TODO: auto register view model

            //builder.RegisterType<DetectionServiceV2>().As<IDetectionService>();
            //builder.RegisterType<GlueBondMeasureService>().As<IGlueBondMeasureService>();
            //builder.RegisterType<DataExtractor>().As<IDataExtractor>();
            //builder.RegisterType<BasicDemoReportService>().As<IReportService>();
            //builder.RegisterType<ApplicationController>().As<IApplicationController>().SingleInstance();
            //builder.RegisterType<PultrusionViewModel>().SingleInstance();
            //builder.RegisterType<Rulers>().SingleInstance();
            //builder.RegisterType<CursorsValues>().SingleInstance();



            var viewModelAssembly = typeof(ShellViewModel).Assembly;
            builder.RegisterAssemblyTypes(viewModelAssembly).Where(x => x.Name != null && x.Name.EndsWith("ViewModel") && !x.Name.Contains("ShellViewModel"));

            builder.RegisterType<ShellViewModel>().SingleInstance();

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
