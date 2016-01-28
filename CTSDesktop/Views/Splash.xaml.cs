using System.Windows.Controls;
using Fiehnlab.CTSDesktop.ViewModels;

namespace Fiehnlab.CTSDesktop.Views {
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class SplashView : UserControl {

		public SplashView() {
            InitializeComponent();
            DataContext = new SplashViewModel();
        }
    }
}
