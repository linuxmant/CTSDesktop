using System.Collections.Generic;
using System.Collections.ObjectModel;
using Fiehnlab.CTSDesktop.MVVM;
using System.Collections;

namespace Fiehnlab.CTSDesktop.Models
{
	class NameList : ViewModelBase, IEnumerable
	{
		private ObservableCollection<IDSource> names;
		public ObservableCollection<IDSource> Names
		{
			get { return names; }
			set
			{
				names = value;
				NotifyPropertyChanged();
			}
		}

		internal List<IDSource> ToList()
		{
			return new List<IDSource>(Names);
		}

		public void Add(IDSource item)
		{
			Names.Add(item);
		}

		public IEnumerator GetEnumerator()
		{
			return Names.GetEnumerator();
		}
	}
}
