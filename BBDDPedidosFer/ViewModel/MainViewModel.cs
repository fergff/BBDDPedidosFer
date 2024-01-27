using BBDDPedidosFer.View;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace BBDDPedidosFer.ViewModel
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private NewOrderWindow newOrderWindow;
        private EditOrRemoveOrderWindow editOrRemoveOrderWindow;

        public MainViewModel()
        {
            // Setup commands
            NewOrderCommand = new Command(NewOrderAction);
            EditOrRemoveOrderCommand = new Command(EditOrRemoveOrderAction);

            // Setup other stuff
            newOrderWindow = new NewOrderWindow();
            newOrderWindow.Closing += WindowClosingHandler; // Maneja el evento Closing
            editOrRemoveOrderWindow = new EditOrRemoveOrderWindow();
            editOrRemoveOrderWindow.Closing += WindowClosingHandler; // Maneja el evento Closing
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand NewOrderCommand { get; set; }
        public ICommand EditOrRemoveOrderCommand { get; set; }

        private void NewOrderAction(object parameter)
        {
            if (newOrderWindow == null)
            {
                newOrderWindow = new NewOrderWindow();
                newOrderWindow.Closing += WindowClosingHandler; // Maneja el evento Closing
            }

            newOrderWindow.Show();
        }

        private void EditOrRemoveOrderAction(object parameter)
        {
            if (editOrRemoveOrderWindow == null)
            {
                editOrRemoveOrderWindow = new EditOrRemoveOrderWindow();
                editOrRemoveOrderWindow.Closing += WindowClosingHandler; // Maneja el evento Closing
            }

            editOrRemoveOrderWindow.Show();
        }

        private void WindowClosingHandler(object sender, CancelEventArgs e)
        {
            // Evita que la ventana se cierre, simplemente la oculta
            e.Cancel = true;
            ((Window)sender).Hide();
        }
    }
}

