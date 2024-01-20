using System;
using System.Windows.Input;

namespace DepthSearchApp.Commands
{
    public class RelayCommand : ICommand
    {
        public RelayCommand(Action<object> _Execute, Func<object, bool> _CanExecute)
        {
            this._Execute = _Execute;
            this._CanExecute = _CanExecute;
        }

        # region ICommand implement
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        private Func<object, bool> _CanExecute;
        public bool CanExecute(object parameter)
        {
            return this._CanExecute == null || this._CanExecute(parameter);
        }

        private Action<object> _Execute;
        public void Execute(object parameter)
        {
            this._Execute(parameter);
        }
        #endregion
    }
}
