
using System;
using System.Windows.Input;

namespace ApsoDemo.ViewModels
{
    /// <summary>
    /// A basic command that runs an Action
    /// </summary>
    public class RelayCommand : ICommand
    {
        #region Private Members
        /// <summary>
        /// Action to run
        /// </summary>
        private Action mAction;
        #endregion

        #region Public Events
        /// <summary>
        /// Event thats fired when the <see cref="CanExecute(object)" /> value has changed
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) => { };
        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="action"></param>
        public RelayCommand(Action action)
        {
            mAction = action;
        }
        #endregion

        /// <summary>
        /// A relay command can always execute
        /// </summary>
        public bool CanExecute(object parameter) => true;

        /// <summary>
        /// Executes the commands Action
        /// </summary>
        public void Execute(object parameter)
        {
            mAction();
        }
    }
}
