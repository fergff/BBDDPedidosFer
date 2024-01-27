using BBDDPedidosFer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BBDDPedidosFer.ViewModel
{
    internal class NewOrderViewModel : INotifyPropertyChanged
    {

        private Connection connection;
        public NewOrderViewModel()
        {
            // Setup the event handler
            PropertyChanged += EventHandler;

            // Setup commands
            NewOrderCommand = new Command(NewOrderAction);
            SaveCommand = new Command(SaveAction);

            // Setup other stuff
            EmptyFields();
            connection = new Connection();
            SaveBtnEnabled = false;

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName)
            );
            

        }

        private void UpdateSaveBtnEnabled() // lo inicializo por cada field y si todos estan completos lo habilito
        {
            SaveBtnEnabled = !string.IsNullOrEmpty(Client)
                            && !string.IsNullOrEmpty(DNI)
                            && !string.IsNullOrEmpty(Number)
                            && Cantidad != 0
                            && !string.IsNullOrEmpty(Date);
        }


        private void EventHandler(object sender, PropertyChangedEventArgs args)
        {
            switch (args.PropertyName)
            {
            }
        }
        
        private String client;
        public String Client
        {
            get => client;
            set
            {
                client = value;
                OnPropertyChanged(nameof(Client));
                UpdateSaveBtnEnabled();
            }
        }

        private String dni;
        public String DNI
        {
            get => dni;
            set
            {
                dni = value;
                OnPropertyChanged(nameof(DNI));
                UpdateSaveBtnEnabled();
            }
        }

        private String number;
        public String Number
        {
            get => number;
            set
            {
                number = value;
                OnPropertyChanged(nameof(Number));
                UpdateSaveBtnEnabled();
            }
        }

        private int cantidad;
        public int Cantidad
        {
            get => cantidad;
            set
            {
                cantidad = value;
                OnPropertyChanged(nameof(Cantidad));
                UpdateSaveBtnEnabled();
            }
        }

        private String date;
        public String Date
        {
            get => date;
            set
            {
                date = value;
                OnPropertyChanged(nameof(Date));
                UpdateSaveBtnEnabled();
            }
        }

        private void EmptyFields()
        {
            Client = "";
            DNI = "";
            Number = "";
            Cantidad = 0;
            Date = "";
        }

        public ICommand NewOrderCommand { get; set; }
        public ICommand SaveCommand { get; set; }

        private void NewOrderAction(object parameter) // boton nuevo pedido (borra los campos)
        {
            EmptyFields();
        }
        private void SaveAction(object parameter) // Boyon Guardar
        {   
            if (Client == ""|| DNI == "" || Number == "" || Cantidad == 0 || Date == "") {
                
                MessageBox.Show("Se necesita Rellenar todos los campos");

            }
            else { 
                connection.Add(new Order()
                {
                    Client = Client,
                    DNI = DNI,
                    NPedido = Number,
                    Cantidad = Cantidad,
                    Date = Date
                });
            }
        }

        private Boolean saveBtnEnabled;
        public Boolean SaveBtnEnabled
        {
            get => saveBtnEnabled;
            set
            {
                saveBtnEnabled = value;
                OnPropertyChanged(nameof(SaveBtnEnabled));
            }
        }
    }
}
