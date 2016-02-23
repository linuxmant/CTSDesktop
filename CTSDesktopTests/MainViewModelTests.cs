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

		[TestMethod]
		public void IdNamesShouldContainDesignItemsAfterClassCreationWithoutParams()
		{
			var viewModel = new MainWindowViewModel();
			Thread.Sleep(1000);

			Assert.IsTrue(viewModel.ToValuesList.Count > 0);
			CollectionAssert.AllItemsAreInstancesOfType(viewModel.ToValuesList, typeof(string));
			Thread.Sleep(1000);

			Assert.IsTrue(viewModel.FromValuesList.Count > 0);
			CollectionAssert.AllItemsAreInstancesOfType(viewModel.FromValuesList, typeof(string));
		}

	}
}
