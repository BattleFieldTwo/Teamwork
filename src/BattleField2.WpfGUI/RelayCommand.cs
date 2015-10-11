namespace BattleField2.WpfGUI
{
    using System;
    using System.Windows.Input;

    /// <summary>
    /// A delegate containing the method to be executed after validation
    /// </summary>
    public delegate void ExecuteDelegate(object obj);

    /// <summary>
    /// Delegate passed to validate if the command should be executed
    /// </summary>
    public delegate bool CanExecuteDelegate(object obj);

    /// <summary>
    /// This is an ICommand implementation for all the commands in the ViewModel.
    /// This class implements Command design pattern.
    /// </summary>
    public class RelayCommand : ICommand
    {
        private ExecuteDelegate execute;

        private CanExecuteDelegate canExecute;

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand" /> class.
        /// Command constructor.
        /// Takes one argument - a delegate to be executed in case the command is triggered.
        /// </summary>
        public RelayCommand(ExecuteDelegate execute)
            : this(execute, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand" /> class.
        /// Takes arguments - a delegate to executed and
        /// a validation to check if the delegate execution would be valid
        /// </summary>
        public RelayCommand(ExecuteDelegate execute,
            CanExecuteDelegate canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        /// <summary>
        /// Validation for valid state, so the the delegate execution would be valid
        /// </summary>
        public bool CanExecute(object parameter)
        {
            if (this.canExecute == null)
            {
                return true;
            }
            return this.canExecute(parameter);
        }

        /// <summary>
        /// Method to be executed in case this command is triggered and the state is valid.
        /// </summary>
        public void Execute(object parameter)
        {
            this.execute(parameter);
        }

        /// <summary>
        /// Event holding information if there is change
        /// in the conditions that must be validated in order to execute the command
        /// It is not used but it is implemented as it comes from ICommand interface
        /// </summary>
        public event EventHandler CanExecuteChanged;
    }
}

