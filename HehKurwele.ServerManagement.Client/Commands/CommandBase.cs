using System;
using System.Windows.Input;

namespace HehKurwele.ServerManagement.Client.Commands
{
	public class CommandBase : ICommand
	{
		public event EventHandler CanExecuteChanged;

		private readonly Action<object> mExecute;
		private Func<object, bool> mCanExecute;

		public CommandBase(Action<object> execute, Func<object, bool> canExecute)
		{
			mExecute = execute;
			mCanExecute = canExecute;
		}

		public CommandBase(Action<object> execute) : this(execute, null) { }

		public bool CanExecute(object parameter)
		{
			if (mCanExecute is null) return true;
			return mCanExecute(parameter);
		}

		public void Execute(object parameter) => mExecute(parameter);
	}
}
