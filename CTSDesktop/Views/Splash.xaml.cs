using Fiehnlab.CTSDesktop.ViewModels;
using System.Windows;

namespace Fiehnlab.CTSDesktop.Views {
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class SplashView : Window {

		public SplashView() {
            InitializeComponent();
            DataContext = new SplashViewModel();
        }
    }
}
