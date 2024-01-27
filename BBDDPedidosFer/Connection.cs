using BBDDPedidosFer.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BBDDPedidosFer.Model
{

    public class Connection
    {
        private string cadenaConexion = "Server=tcp:ferdam2023.database.windows.net,1433;Initial Catalog=prueba di;Persist Security Info=False;User ID=usuario;Password=Dam-2023;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        private SqlConnection CN;
        private SqlCommand CMD;
        private SqlDataReader RDR;

        public ObservableCollection<Order> Get()
        {
            CN = new SqlConnection(cadenaConexion);
            CMD = new SqlCommand("SELECT * FROM TPedidos", CN);
            CMD.CommandType = CommandType.Text;

            ObservableCollection<Order> ListaOrder = new ObservableCollection<Order>();

            try
            {
                CN.Open();
                RDR = CMD.ExecuteReader();

                while (RDR.Read())
                {
                    Order orderactual = new Order();
                    orderactual.NPedido = (RDR["NPedido"]).ToString();
                    orderactual.Client = (RDR["Cliente"]).ToString();
                    orderactual.DNI = (RDR["DNI"]).ToString();
                    orderactual.Cantidad = (int)RDR["Cantidad"];
                    orderactual.Date = (RDR["Fecha"]).ToString();
                    ListaOrder.Add(orderactual);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CN.Close();
            }

            return ListaOrder;
        }

        public void Add(Order nuevoOrder)
        {
            CN = new SqlConnection(cadenaConexion);
            CMD = new SqlCommand();
            CMD.Connection = CN;
            CMD.CommandType = CommandType.Text;

            CMD.CommandText = "INSERT INTO TPedidos (NPedido,Cliente,DNI,Cantidad,Fecha) VALUES (@p1, @p2, @p3, @p4, @p5);";

            CMD.Parameters.AddWithValue("@p1", nuevoOrder.NPedido);
            CMD.Parameters.AddWithValue("@p2", nuevoOrder.Client);
            CMD.Parameters.AddWithValue("@p3", nuevoOrder.DNI);
            CMD.Parameters.AddWithValue("@p4", nuevoOrder.Cantidad);
            CMD.Parameters.AddWithValue("@p5", nuevoOrder.Date);

            CN.Open();
            CMD.ExecuteNonQuery();
            MessageBox.Show("Registro agregado");
            CN.Close();
        }

        public int Remove(string Number)
        {
            
            CN = new SqlConnection(cadenaConexion);
            CMD = new SqlCommand("DELETE FROM TPedidos WHERE NPedido = @p0", CN);
            CMD.CommandType = CommandType.Text;
            CMD.Parameters.AddWithValue("@p0", Number);

            try
            {
                MessageBox.Show("Registro Borrado");
                CN.Open();
                return CMD.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CN.Close();
            }
        }

        public int Update(Order nuevoOrder)
        {
            CN = new SqlConnection(cadenaConexion);
            CMD.CommandType = CommandType.Text;

            CMD = new SqlCommand("UPDATE TPedidos SET Cliente = @p2,DNI = @p3,Cantidad = @p4,Fecha = @p5 WHERE NPedido = @p1", CN);

            CMD.Parameters.AddWithValue("@p1", nuevoOrder.NPedido);
            CMD.Parameters.AddWithValue("@p2", nuevoOrder.Client);
            CMD.Parameters.AddWithValue("@p3", nuevoOrder.DNI);
            CMD.Parameters.AddWithValue("@p4", nuevoOrder.Cantidad);
            CMD.Parameters.AddWithValue("@p5", nuevoOrder.Date);

            //CMD = new SqlCommand("UPDATE Concesionario SET Number = '" + Number + "', Client = '" + Client + "', DNI = '" + DNI + "', Cantidad = '" + Cantidad + "', Fecha = '" + Fecha + "' WHERE Number ='" + Number + "'", CN);

            try
            {
                CN.Open();
                MessageBox.Show("Registro Actualizado");
                return CMD.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CN.Close();
            }
        }



    }
}
