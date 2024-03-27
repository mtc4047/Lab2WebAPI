using System.Data.SqlClient;
using System.Data;
using BLL.DTOModels;
using BLL.ServiceInterfaces;

namespace BLL_DB
{
    public class BasketPositionService : IBasketPositionService
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Webshop;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

        public void AddProductToBasket(BasketPositionRequestDTO request)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("AddProductToBasket", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ProductId", request.ProductId);
                command.Parameters.AddWithValue("@UserId", request.UserId);
                command.Parameters.AddWithValue("@Amount", request.Amount);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void ChangeAmount(int userId, int productId, int newQuantity)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("ChangeAmount", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@UserId", userId);
                command.Parameters.AddWithValue("@ProductId", productId);
                command.Parameters.AddWithValue("@NewQuantity", newQuantity);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<BasketPositionResponseDTO> GetBasketPositions(int userId)
        {
            List<BasketPositionResponseDTO> basketPositions = new List<BasketPositionResponseDTO>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("GetBasketPositions", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@UserId", userId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    BasketPositionResponseDTO basketPosition = new BasketPositionResponseDTO(
                        (int)reader["Id"],
                        (int)reader["ProductId"],
                        (int)reader["UserId"],
                        (int)reader["Amount"]
                    );
                    basketPositions.Add(basketPosition);
                }

                reader.Close();
            }

            return basketPositions;
        }

        public void RemoveProductFromBasket(int userId, int productId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("RemoveProductFromBasket", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@UserId", userId);
                command.Parameters.AddWithValue("@ProductId", productId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}