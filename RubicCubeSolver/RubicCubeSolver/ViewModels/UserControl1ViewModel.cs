using Microsoft.Practices.Prism.Mvvm;

namespace RubicCubeSolver.ViewModels
{
    public class UserControl1ViewModel : BindableBase
    {
        private string _strValue;

        public string StrValue
        {
            get { return _strValue; }
            set { SetProperty(ref _strValue, value); }
        }

        public UserControl1ViewModel()
        {
            StrValue = "value1";
        }
    }
}
