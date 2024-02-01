using System;
using System.Windows.Input;

namespace WpfAppIntermodular.rsc
{
    public class RelayCommand : ICommand
    {
        private readonly Action execute;
        private readonly Func<bool> canExecute;
        private Action<bool, string, int, double, int, string> insertRoom;

        public RelayCommand(Action<bool, string, int, double, int, string> insertRoom)
        {
            this.insertRoom = insertRoom;
        }

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute();
        }

        public void Execute(object parameter)
        {
            execute();
        }
    }
}
