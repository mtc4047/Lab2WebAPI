using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.ServiceInterfaces;

namespace BLL_DB
{
    public class OrderService : IOrderService
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Webshop;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
        public void GenerateOrder(int userId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("GenerateOrder", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@UserId", userId);


                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void PayOrder(int Id, int amount)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("PayOrder", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@OrderId", Id);
                command.Parameters.AddWithValue("@Amount", amount);


                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
