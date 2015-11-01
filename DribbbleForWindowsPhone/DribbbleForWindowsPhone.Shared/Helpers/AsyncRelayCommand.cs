using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DribbbleForWindowsPhone.Helpers
{
    /// <summary>
    /// A implementation of ICommand that executes command asynchronously.
    /// </summary>
    public class AsyncRelayCommand: ICommand
    {
        #region Fields

        /// <summary>
        /// A predicate that returns if an task can be executed.
        /// </summary>
        protected readonly Predicate<object> _canExecute;

        /// <summary>
        /// The Func to execute an task asynchronously.
        /// </summary>
        protected Func<object, Task> _asyncExecute;

        #endregion Fields

        #region Events

        /// <summary>
        /// Event that occurs when the can execute field has changed.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }

        #endregion Events

        #region Constructors

        /// <summary>
        /// The default constructor.
        /// </summary>
        /// <param name="execute">A Func to execute a task.</param>
        public AsyncRelayCommand(Func<object, Task> execute)
            : this(execute, null)
        { }

        /// <summary>
        /// The constructor that initializes the _canExecute field too.
        /// </summary>
        /// <param name="asyncExecute">A Func to execute a task.</param>
        /// <param name="canExecute">The condition to execute the Func.</param>
        public AsyncRelayCommand(Func<object, Task> asyncExecute, Predicate<object> canExecute)
        {
            _asyncExecute = asyncExecute;
            _canExecute = canExecute;
        }

        #endregion Constructors

        #region Methods

        #region Public

        /// <summary>
        /// Checks if the Func can be executed.
        /// </summary>
        /// <remarks>If has a Predicate so this method execute it.</remarks>
        /// <param name="parameter">A parameter to help to check the "_canExecute" return.</param>
        /// <returns>True if can execute, otherwise, false.</returns>
        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
                return true;

            return _canExecute(parameter);
        }

        /// <summary>
        /// Execute an action asynchronously.
        /// </summary>
        /// <param name="parameter">The parameter to pass to the Func.</param>
        public async void Execute(object parameter)
        {
            await ExecuteAsync(parameter);
        }

        #endregion Public

        #region Protected

        /// <summary>
        /// Execute an action asynchronously.
        /// </summary>
        /// <param name="parameter">Parameter to pass to the Func.</param>
        /// <returns>Returns the Task.</returns>
        protected virtual async Task ExecuteAsync(object parameter)
        {
            await _asyncExecute(parameter);
        }

        #endregion Protected

        #endregion Methods
    }
}