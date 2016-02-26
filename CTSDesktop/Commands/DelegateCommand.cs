using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;

namespace Fiehnlab.CTSDesktop.Commands {
	public class DelegateCommand : ICommand {
		private readonly Predicate<object> canExecute;
		private readonly Action<object> execute;

		public event EventHandler CanExecuteChanged {
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		public DelegateCommand(Action<object> execute)
					   : this(execute, null) {
		}

		public DelegateCommand(Action<object> execute,
					   Predicate<object> canExecute) {
			this.execute = execute;
			this.canExecute = canExecute;
		}

		[DebuggerStepThrough]
		public bool CanExecute(object parameter) {
			return canExecute == null ? true : canExecute(parameter);
		}

		public void Execute(object parameter) {
			execute(parameter);
		}
	}


	public class DelegateCommand<T> : ICommand
	{
		private readonly Predicate<T> canExecute;
		private readonly Action<T> execute;

		public event EventHandler CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		public DelegateCommand(Action<T> execute)
					   : this(execute, null)
		{
		}

		public DelegateCommand(Action<T> execute,
					   Predicate<T> canExecute)
		{
			this.execute = execute;
			this.canExecute = canExecute;
		}

		[DebuggerStepThrough]
		public bool CanExecute(object parameter)
		{
			return parameter == null ? true : canExecute((T)parameter);
		}

		public void Execute(object parameter)
		{
			execute((T)parameter);
		}
	}
}
