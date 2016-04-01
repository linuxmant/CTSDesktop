using Fiehnlab.CTSDesktop.Data;
using Fiehnlab.CTSDesktop.Models;
using Fiehnlab.CTSDesktop.MVVM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;

namespace Fiehnlab.CTSDesktop.ViewModels {

    internal class SplashViewModel : ViewModelBase {
		#region Member vars
		private string appVersion = "{version}";
		private string status = "{status}";
        //private List<IDSource> fromValues;
        //private List<IDSource> toValues;
        private IDataService dataSource;
        #endregion

        #region Properties
        public string AppVersion
		{
			get { return appVersion; }
			set
			{
				appVersion = value;
				NotifyPropertyChanged();
			}
		}

		public string Status
		{
			get { return status; }
			set
			{
				status = value;
				NotifyPropertyChanged();
			}
		}

        //public List<IDSource> FromValues
        //{
        //    get { return fromValues; }
        //    set
        //    {
        //        fromValues = value;
        //        NotifyPropertyChanged();
        //    }
        //}

        //public List<IDSource> ToValues
        //{
        //    get { return toValues; }
        //    set
        //    {
        //        toValues = value;
        //        NotifyPropertyChanged();
        //    }
        //}
        #endregion

        /// <summary>
        /// Creates a new instance of a SplashViewModel
        /// </summary>
        //public SplashViewModel(IDataService ds) {
        public SplashViewModel() {
            AppVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            Status = "Initializing...";
            //dataSource = ds;

            //LoadToVals();
            //LoadFromVals();
        }

        //private void LoadFromVals() {
        //    try {
        //        Status = "Loading query From types...";
        //        fromValues = dataSource.GetFromNames();
        //    } catch (Exception ex) {
        //        MessageBox.Show("(Splash Init FV) Can't initialize application...\n" + ex.Message, "ERROR");
        //    }
        //}

        //private void LoadToVals() {
        //    try {
        //        Status = "Loading query To types...";
        //        toValues = dataSource.GetToNames();
        //    } catch (Exception ex) {
        //        MessageBox.Show("(Splash Init TV) Can't initialize application...\n" + ex.Message, "ERROR");
        //    }
        //}

    }
}
