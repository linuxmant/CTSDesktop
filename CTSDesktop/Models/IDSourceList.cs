using System.Collections.Generic;
using Fiehnlab.CTSDesktop.MVVM;
using System.Collections;

namespace Fiehnlab.CTSDesktop.Models
{
	public class IDSourceList : ViewModelBase, IEnumerable
	{
		#region properties
		private List<IDSource> names;
		public List<IDSource> Names
		{
			get { return names; }
			set
			{
				names = value;
				NotifyPropertyChanged();
			}
		}
		#endregion

		/// <summary>
		/// Generates a List<IDSource> From the List<IDSource>
		/// </summary>
		/// <returns>A list of IDSource objects</returns>
		public List<IDSource> ToList()
		{
			return new List<IDSource>(Names);
		}

		/// <summary>
		/// Adds the IDSource object to the internal collection
		/// </summary>
		/// <param name="item">IDSource objeect to add to the collection</param>
		public void Add(IDSource item)
		{
			Names.Add(item);
		}

		#region IEnumerable member
		/// <summary>
		/// Returns the object enumerator for the internal collection
		/// </summary>
		/// <returns>The Enumerator object from the internal collection</returns>
		public IEnumerator GetEnumerator()
		{
			return Names.GetEnumerator();
		}
		#endregion

	}
}
