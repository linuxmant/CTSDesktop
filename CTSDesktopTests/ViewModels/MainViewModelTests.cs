using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fiehnlab.CTSDesktop.ViewModels;
using Fiehnlab.CTSDesktop.MVVM;
using Fiehnlab.CTSDesktop.Models;
using System.Threading;

namespace Fiehnlab.CTSDesktop.Tests
{
	[TestClass]
	public class MainViewModelTests
	{
		[TestMethod]
		public void MainViewModelIsBaseViewModel()
		{
			Assert.IsTrue(typeof(MainWindowViewModel).IsSubclassOf(typeof(ViewModelBase)));
		}

		//[TestMethod]
		//public void MainWindowViewModelCanBeCreatedWithCustomDataSource()
		//{
		//	var ds = new DesignDataServiceImpl();
		//}

	}
}
