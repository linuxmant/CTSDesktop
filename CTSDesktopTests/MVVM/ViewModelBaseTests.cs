using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fiehnlab.CTSDesktop.MVVM;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CTSDesktopTests.MVVM
{
	[TestClass]
	public class ViewModelBaseTests
	{
		[TestMethod]
		public void IsAbstractBaseClass()
		{
			Type t = typeof(ViewModelBase);
			Assert.IsTrue(t.IsAbstract);
		}

		[TestMethod]
		public void ViewModelBaseIsObservableObject()
		{
			Assert.IsTrue(typeof(ViewModelBase).BaseType == typeof(ObservableObject));
		}

		[TestMethod]
		public void IsIDataErrorInfo()
		{
			Assert.IsTrue(typeof(IDataErrorInfo).IsAssignableFrom(typeof(ViewModelBase)));
		}

		[TestMethod]
		[ExpectedException(typeof(NotSupportedException))]
		public void IDataError_ErrorProperty_IsNotSupported() {
			var vm = new StubViewModel();
			var val = vm.Error;
		}

		[TestMethod]
		public void IndexerPropertyValidatesPropertyNameWithInvalidValue()
		{
			var vm = new StubViewModel();
			Assert.IsNotNull(vm["RequiredProperty"]);
		}

		[TestMethod]
		public void IndexerPropertyValidatesPropertyNameWithValidValue()
		{
			var vm = new StubViewModel() { RequiredProperty="good"};

			Assert.IsNull(vm["RequiredProperty"]);
		}

		class StubViewModel : ViewModelBase
		{
			[Required]
			public string RequiredProperty { get; set; }
		}
	}

}
