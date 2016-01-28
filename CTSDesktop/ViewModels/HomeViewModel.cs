using Fiehnlab.CTSDesktop.MVVM;
using Fiehnlab.CTSDesktop.Commands;
using System.Windows;

namespace Fiehnlab.CTSDesktop.ViewModels {
    class HomeViewModel : ViewModelBase {

        private MainWindowViewModel parentVM;
        private DelegateCommand wizardCommand;
        public DelegateCommand WizardCommand
        {
            get { return wizardCommand ?? (wizardCommand = new DelegateCommand(ShowWizard)); }
            private set {
                wizardCommand = value;
                NotifyPropertyChanged();
            }
        }

        public HomeViewModel(MainWindowViewModel owner) {
            parentVM = owner;
        }

        private void ShowWizard(object window) {
            MessageBox.Show("Wizard Step 2");

            if(window != null) {
                ((Window)window).Close();
            }

        }
        private bool CanShowWizard() { return true; }

        private void ShowExpert(object window) {
            MessageBox.Show("Full Conversion Form");

            if (window != null) {
                ((Window)window).Close();
            }
        }

        private bool CanShowExpert() { return true; }
    }
}
