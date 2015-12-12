using Microsoft.Practices.Prism.Mvvm;

namespace RubicCubeSolver.ViewModels
{
    public class UserControl2ViewModel : BindableBase
    {
        private string _strValue;

        public string StrValue
        {
            get { return _strValue; }
            set { SetProperty(ref _strValue, value); }
        }

        public UserControl2ViewModel()
        {
            StrValue = "value2";
        }
    }
}
