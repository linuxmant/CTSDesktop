using Fiehnlab.CTSDesktop.MVVM;
using Fiehnlab.CTSDesktop.ViewModels;
using System;
using System.Windows;
using System.ComponentModel;
using System.Diagnostics;

namespace Fiehnlab.CTSDesktop.Views {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private bool isClosing = false;

        public MainWindow() {
            InitializeComponent();
            MainWindowViewModel mwvm = new MainWindowViewModel();
            DataContext = mwvm;

            if (mwvm.CloseAction == null) {
                mwvm.CloseAction = new Action(() => {
                    if (!isClosing) {
                        isClosing = true;
                        this.Close();
                    }
                });
            }
        }

        protected override void OnClosing(CancelEventArgs e) {
            isClosing = true;
        }
    }
}

