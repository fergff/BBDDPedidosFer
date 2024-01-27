using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BBDDPedidosFer.ViewModel
{
    internal class Command : ICommand
    {
        readonly Action<object> actionToExecute;
        public event EventHandler CanExecuteChanged;

        public Command(Action<object> action)
        {
            actionToExecute = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            actionToExecute(parameter);
        }
    }
}
