using Microsoft.Practices.Prism.Mvvm;
using System.Windows;
using System.Windows.Controls;

namespace RubicCubeSolver.Views
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class Cube3DView : UserControl, IView
    {
        public Cube3DView()
        {
            InitializeComponent();
        }

        private void Rectangle_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MessageBox.Show("dupa1");
        }

        private void Rectangle_MouseDown_1(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MessageBox.Show("dupa2");
        }
    }
}
