using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBDDPedidosFer.Model
{
    public class Order
    {
        public String NPedido { get; set; }
        public String Client { get; set; }
        public String DNI { get; set; }
        public int Cantidad { get; set; }
        public String Date { get; set; }
    }
}
