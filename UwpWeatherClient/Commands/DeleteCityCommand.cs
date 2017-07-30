using System;
using System.Windows.Input;

namespace UwpWeatherClient.Commands
{
	class DeleteCityCommand : ICommand
	{
		private Action<object> execute;
		private Func<object, bool> canExecute;

		public DeleteCityCommand(Action<object> execute)
		{
			this.execute = execute;
			canExecute = (x) => { return true; };
		}

		public DeleteCityCommand(Action<object> execute, Func<object, bool> canExecute)
		{
			this.execute = execute;
			this.canExecute = canExecute;
		}

		public bool CanExecute(object parameter)
		{
			return canExecute(parameter);
		}

		public event EventHandler CanExecuteChanged;

		public void RaiseCanExecuteChanged()
		{
			CanExecuteChanged?.Invoke(this, EventArgs.Empty);
		}

		public void Execute(object parameter)
		{
			execute(parameter);
		}
	}
}
