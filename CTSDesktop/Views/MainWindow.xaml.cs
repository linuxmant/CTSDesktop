using Fiehnlab.CTSDesktop.ViewModels;
using System;
using System.Windows;
using System.ComponentModel;
using Fiehnlab.CTSDesktop.design;
using System.Windows.Controls;

namespace Fiehnlab.CTSDesktop.Views
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
        private bool isClosing = false;

        public MainWindow() {
            InitializeComponent();

			MainWindowViewModel mwvm = new MainWindowViewModel(new DesignDataServiceImpl());
			//DataContext = mwvm;
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			isClosing = true;
		}
	}
}

