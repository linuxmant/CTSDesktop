using System.Windows.Controls;
using Fiehnlab.CTSDesktop.ViewModels;

namespace Fiehnlab.CTSDesktop.Views {
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl {
        public HomeView() {
            InitializeComponent();
            //DataContext = new HomeViewModel();
        }
    }
}
