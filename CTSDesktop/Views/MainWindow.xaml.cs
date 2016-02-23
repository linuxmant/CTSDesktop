using Fiehnlab.CTSDesktop.ViewModels;
using System.Windows;
using System.ComponentModel;
using Fiehnlab.CTSDesktop.Design;
using System.Windows.Controls;
using Fiehnlab.CTSDesktop.Data;
using System;

namespace Fiehnlab.CTSDesktop.Views
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
        private bool isClosing = false;

        public MainWindow() {
            InitializeComponent();

			//MainWindowViewModel mwvm;
			//if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
			//{
			//	MessageBox.Show("InDesign");
			//	mwvm = new MainWindowViewModel(new DesignDataServiceImpl());
			//}
			//else
			//{
			//	mwvm = new MainWindowViewModel(new CtsDataService());
			//}

			//DataContext = mwvm;
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			isClosing = true;
		}

		private void ToValues_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var box = (ListBox)sender;

			//box.SelectedItems.Count;

			MessageBox.Show("Selected: " + string.Join(", ", box.SelectedItems.Count));
		}
	}
}

