using BBDDPedidosFer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BBDDPedidosFer.View
{
    /// <summary>
    /// Lógica de interacción para EditOrRemoveOrderWindow.xaml
    /// </summary>
    public partial class EditOrRemoveOrderWindow : Window
    {
        public EditOrRemoveOrderWindow()
        {
            InitializeComponent();
            DataContext = new EditOrRemoveOrderViewModel();
        }
    }
}
