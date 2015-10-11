namespace BattleField2.WpfGUI
{
    using System;
    using System.Windows.Input;

    public delegate void ExecuteDelegate(object obj);
    public delegate bool CanExecuteDelegate(object obj);

    /// <summary>
    /// This is an ICommand implementation for all the commands in the ViewModel.
    /// This class implements Command design pattern.
    /// </summary>
    public class RelayCommand : ICommand
    {
        private ExecuteDelegate execute;

        private CanExecuteDelegate canExecute;

        public RelayCommand(ExecuteDelegate execute)
            : this(execute, null)
        {
        }

        public RelayCommand(ExecuteDelegate execute,
            CanExecuteDelegate canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (this.canExecute == null)
            {
                return true;
            }
            return this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }

        public event EventHandler CanExecuteChanged;
    }
}

