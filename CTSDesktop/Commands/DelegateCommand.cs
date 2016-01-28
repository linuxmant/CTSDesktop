using System;
using System.Diagnostics;
using System.Windows.Input;

namespace Fiehnlab.CTSDesktop.Commands {
	public class DelegateCommand : ICommand {
		private readonly Predicate<object> _canExecute;
		private readonly Action<object> _execute;

		public event EventHandler CanExecuteChanged {
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		public DelegateCommand(Action<object> execute)
					   : this(execute, null) {
		}

		public DelegateCommand(Action<object> execute,
					   Predicate<object> canExecute) {
			_execute = execute;
			_canExecute = canExecute;
		}

		[DebuggerStepThrough]
		public bool CanExecute(object parameter) {
			return _canExecute == null ? true : _canExecute(parameter);

			return _canExecute(parameter);
		}

		public void Execute(object parameter) {
			_execute(parameter);
		}
	}
}
