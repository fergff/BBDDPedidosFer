using BBDDPedidosFer.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BBDDPedidosFer.ViewModel
{
    internal class EditOrRemoveOrderViewModel : INotifyPropertyChanged
    {
        int n =0;
        private Connection connection;
        public EditOrRemoveOrderViewModel()
        {
            // por cada cmabio seria el handler
            PropertyChanged += EventHandler;

            
            RemoveCommand = new Command(RemoveAction);
            UpdateCommand = new Command(UpdateAction);
            SearchCommand = new Command(SearchAction);
            
            EmptyFields();//campos en blanco
            connection = new Connection();
            orders = connection.Get();

            
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName )
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName)

            );

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
            }
        }

        private String number;
        public String Number
        {
            get => number;
            set
            {
                if (number != value)
                {
                    n = 1;
                    number = value;
                    OnPropertyChanged(nameof(Number));
                }
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
            }
        }

        private ObservableCollection<Order> orders;
        public ObservableCollection<Order> Orders
        {
            get => orders;
            set
            {
                orders = value;
                OnPropertyChanged(nameof(Orders));
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

        public ICommand RemoveCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand SearchCommand { get; set; }

        private void RemoveAction(object parameter)
        {
            ObservableCollection<Order> orders = connection.Get();
            Boolean existe = false;
            foreach (var item in orders)// va viendo pedido x pedido si existe el numero k el PK
            {
                if (Number == item.NPedido)// si exsiste lo borra
                {

                    connection.Remove(Number);
                    EmptyFields();
                    existe= true;
                }
            }
            if (!existe)
            {
                MessageBox.Show("Ese registro no existe en la Base De Datos");
            }


        }
        private void UpdateAction(object parameter)// actulizar
        {
            Boolean existe = false;
            if (Client == "" || DNI == "" || Number == "" || Cantidad == 0 || Date == "")// comprueba que los datos esten rellenos si no los cambiara a vacio
            {

                MessageBox.Show("Necesitas Rellenar todos los campos");

            }
            else
            {
                foreach (var item in orders) // va viendo pedido x pedido si existe el numero k el PK
                {
                    if (Number == item.NPedido)// si exsiste lo acatuliza
                    {

                        connection.Update(new Order()
                        {
                            Client = Client,
                            DNI = DNI,
                            NPedido = item.NPedido,
                            Cantidad = Cantidad,
                            Date = Date
                        });
                        EmptyFields();
                        existe = true;
                    }
                }
                if (!existe)
                {
                    MessageBox.Show("Ese registro no existe en la Base De Datos");
                }
               
            }
        }

        private void SearchAction(object parameter)
        {
            ObservableCollection<Order> orders = connection.Get();
            
            Boolean esta = false;
                foreach (var item in orders)
                {
                    if (Number == item.NPedido)
                    {
                        Client = item.Client;
                        DNI = item.DNI;
                        Cantidad = item.Cantidad;
                        Date = item.Date;
                        esta = true;
                    }
                    
                }
                if (!esta)
                {
                    Client = "";
                    DNI = "";
                    Cantidad = 0;
                    Date = "";
                }
        }
    }
}
