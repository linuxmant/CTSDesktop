using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fiehnlab.CTSDesktop.MVVM;

namespace CTSDesktopTests.MVVM
{
	[TestClass]
	public class ObservableObjectTests
	{
		[TestMethod]
		public void PropertyChangedEventHandlerIsRaised()
		{
			var obj = new StubObservableObject();

			bool raised = false;
			obj.PropertyChanged += (sender, e) => {
				Assert.IsTrue(e.PropertyName == "ChangedProperty");
				raised = true; };

			obj.ChangedProperty = "I changed";

			Assert.IsTrue(raised);
		}

		class StubObservableObject : ObservableObject
		{
			private string changedProperty;
			public string ChangedProperty {
				get { return changedProperty; }
				set {
					changedProperty = value;
					NotifyPropertyChanged();
				}
			}
		}
	}
}
