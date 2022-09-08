using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UI.Base
{
    public class DelegateCommand : IDelegateCommand
    {
        public event EventHandler CanExecuteChanged;
        private Action execute;
        private Func<bool> canExecute;

        public DelegateCommand(Action execute)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this.canExecute = () => true;
        }

        public DelegateCommand(Action execute, Func<bool> canExecute) : this(execute)
        {
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute.Invoke();
        }

        public void Execute(object parameter)
        {
            execute();
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public class DelegateCommand<T> : IDelegateCommand<T>
    {
        public event EventHandler CanExecuteChanged;
        private Action<T> execute;
        private Func<T, bool> canExecute;

        public DelegateCommand(Action<T> execute)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this.canExecute = (t) => true;
        }

        public DelegateCommand(Action<T> execute, Func<T, bool> canExecute) : this(execute)
        {
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute((T)parameter ?? default(T));
        }

        public void Execute(object parameter)
        {
            execute((T)parameter ?? default(T));
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public interface IDelegateCommand : ICommand
    {
        void RaiseCanExecuteChanged();
    }

    public interface IDelegateCommand<T> : IDelegateCommand
    {
    }
}
