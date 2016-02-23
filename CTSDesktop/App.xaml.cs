using System.Windows;
using Fiehnlab.CTSDesktop.Views;

namespace Fiehnlab.CTSDesktop
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application {
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);
			MainWindow window = new MainWindow();

			window.ShowDialog();
		}
	}
}
