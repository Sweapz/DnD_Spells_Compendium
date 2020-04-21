using System;
using System.Windows.Input;

namespace DnDSpellsCompendium.ViewModels
{
	public class RelayCommand : ICommand
	{
		private Action action;
		public event EventHandler CanExecuteChanged = (sender, e) => { };

		public RelayCommand(Action action)
		{
			this.action = action;
		}

		public bool CanExecute(object parameter) => true;

		public void Execute(object parameter)
		{
			action();
		}
	}

    public class RelayCommand<T> : ICommand
    {
        private readonly Predicate<T> _canExecute;
        private readonly Action<T> _execute;

        public RelayCommand(Action<T> execute)
           : this(execute, null)
        {
            _execute = execute;
        }

        public RelayCommand(Action<T> execute, Predicate<T> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute((T)parameter);
        }

        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
