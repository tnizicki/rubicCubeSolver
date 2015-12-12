using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using System.Windows.Input;

namespace RubicCubeSolver.ViewModels
{
    public class ShellViewModel : BindableBase
    {
        private ShellViews _shallViewIndex;

        public ShellViews ShellViewIndex
        {
            get { return _shallViewIndex; }
            set { SetProperty(ref _shallViewIndex, value); }
        }

        public ICommand Open1Cmd { get; set; }
        public ICommand Open2Cmd { get; set; }
        public ICommand Open3Cmd { get; set; }

        public ShellViewModel()
        {
            Open1Cmd = new DelegateCommand(() => { ShellViewIndex = ShellViews.UserCtrl1; });
            Open2Cmd = new DelegateCommand(() => { ShellViewIndex = ShellViews.UserCtrl2; });
            Open3Cmd = new DelegateCommand(() => { ShellViewIndex = ShellViews.UserCtrl3; });
        }
    }

    public enum ShellViews
    {
        UserCtrl1 = 0,
        UserCtrl2 = 1,
        UserCtrl3 = 2
    }
}
