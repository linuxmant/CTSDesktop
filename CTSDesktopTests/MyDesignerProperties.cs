namespace Fiehnlab.CTSDesktop.Tests
{
	public class MyDesignerProperties : IDesignerProperties
	{
		private bool isInDesignMode;
		
		public MyDesignerProperties(bool inDesigner = false)
		{
			IsInDesignMode = inDesigner;
		}

		public bool IsInDesignMode
		{
			get { return isInDesignMode; }
			set { IsInDesignMode = value; }
		}
	}
}
