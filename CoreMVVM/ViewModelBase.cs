using System;
using System.ComponentModel;
using System.Diagnostics;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;

namespace Fiehnlab.CTSDesktop.MVVM
{
	/// <summary>
	/// Base class for all ViewModel classes in the application.
	/// It provides support for property change notifications 
	/// and has a DisplayName property. This class is abstract.
	/// </summary>
	public abstract class ViewModelBase : ObservableObject, IDisposable, IDataErrorInfo
	{
		#region Constructor
		protected ViewModelBase() { }
		#endregion // Constructor

		#region DisplayName
		/// <summary>
		/// Returns the user-friendly name of this object.
		/// Child classes can set this property to a new value,
		/// or override it to determine the value on-demand.
		/// </summary>
		public virtual string DisplayName { get; protected set; }
		#endregion // DisplayName

		#region IDisposable Members
		/// <summary>
		/// Invoked when this object is being removed from the application
		/// and will be subject to garbage collection.
		/// </summary>
		public void Dispose()
		{
			this.OnDispose();
		}

		/// <summary>
		/// Child classes can override this method to perform 
		/// clean-up logic, such as removing event handlers.
		/// </summary>
		protected virtual void OnDispose() { }

		#if DEBUG
		/// <summary>
		/// Useful for ensuring that ViewModel objects are properly garbage collected.
		/// </summary>
		~ViewModelBase()
		{
			string msg = string.Format("{0} ({1}) ({2}) Finalized", this.GetType().Name, this.DisplayName, this.GetHashCode());
			Debug.WriteLine(msg);
		}
		#endif
		#endregion // IDisposable Members

		#region IDataErrorInfo members
		public string Error
		{
			get
			{
				throw new NotSupportedException();
			}
			private set { }
		}

		public string this[string columnName]
		{
			get { return OnValidate(columnName); }
		}
		#endregion

		protected virtual string OnValidate(string property)
		{
			var context = new ValidationContext(this)
			{
				MemberName = property
			};

			var results = new Collection<ValidationResult>();
			var isValid = Validator.TryValidateObject(this, context, results, true);

			return !isValid ? results[0].ErrorMessage : null;
		}
	}

}