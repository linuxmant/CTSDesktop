using Fiehnlab.CTSDesktop.ViewModels;
using System.Windows;
using System.ComponentModel;
using Fiehnlab.CTSDesktop.Design;
using Fiehnlab.CTSDesktop.Data;
using System.Diagnostics;

namespace Fiehnlab.CTSDesktop.Views
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow2 : Window {
        private bool isClosing = false;

        public MainWindow2() {
            InitializeComponent();

			MainWindowViewModel mwvm;
			if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
			{
				Debug.WriteLine("InDesign - creating fake data source");
				mwvm = new MainWindowViewModel(new DesignDataServiceImpl());
			}
			else
			{
				Debug.WriteLine("Runtime - creating real data source");
				mwvm = new MainWindowViewModel(new CtsDataServiceClient());
			}

			DataContext = mwvm;
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			if(e.Cancel)
			{
				return;
			}

			isClosing = true;
		}
	}
}
