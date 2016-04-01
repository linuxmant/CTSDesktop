using System.Windows;
using System.ComponentModel;

namespace Fiehnlab.CTSDesktop.Views {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow2 : Window {
        private bool isClosing = false;

        public MainWindow2() {
            InitializeComponent();
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			if(e.Cancel) {
				return;
			}

			isClosing = true;
		}
	}
}
