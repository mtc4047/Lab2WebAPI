using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTOModels;
using BLL.ServiceInterfaces;
using DTOModels;

namespace BLL_DB
{
    public class ProductService : IProductService
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Webshop;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public void ActivateProduct(int productId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("ActivateProduct", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ProductId", productId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void AddProduct(ProductRequestDTO request)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("AddProduct", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Name", request.Name);
                command.Parameters.AddWithValue("@Price", request.Price);
                command.Parameters.AddWithValue("@GroupId", request.GroupId);
                command.Parameters.AddWithValue("@Image", request.Image);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeactivateProduct(int productId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("DeactivateProduct", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ProductId", productId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteProduct(int productId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("DeleteProduct", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ProductId", productId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<ProductResponseDTO> GetProducts(IProductService.ProductSortColumn sortColumn = IProductService.ProductSortColumn.Name, IProductService.SortOrder sortOrder = IProductService.SortOrder.Ascending, string filterName = null, string filterGroupName = null, int? filterGroupId = null, bool includeInactive = false)
        {
            List<ProductResponseDTO> products = new List<ProductResponseDTO>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Name, Price, Image, IsActive, GroupId, GroupName FROM Products WHERE 1=1";

                // Apply filters
                if (!string.IsNullOrEmpty(filterName))
                    query += $" AND Name LIKE '%{filterName}%'";

                if (!string.IsNullOrEmpty(filterGroupName))
                    query += $" AND GroupName = '{filterGroupName}'";

                if (filterGroupId.HasValue)
                    query += $" AND GroupId = {filterGroupId}";

                if (!includeInactive)
                    query += " AND IsActive = 1";

                switch (sortColumn)
                {
                    case IProductService.ProductSortColumn.Name:
                        query += $" ORDER BY Name {(sortOrder == IProductService.SortOrder.Ascending ? "ASC" : "DESC")}";
                        break;
                    case IProductService.ProductSortColumn.Price:
                        query += $" ORDER BY Price {(sortOrder == IProductService.SortOrder.Ascending ? "ASC" : "DESC")}";
                        break;
                }

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ProductResponseDTO product = new ProductResponseDTO
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Name"].ToString(),
                        Price = (double)reader["Price"],
                        Image = reader["Image"].ToString(),
                        IsActive = (bool)reader["IsActive"],
                        GroupId = reader["GroupId"] != DBNull.Value ? (int?)reader["GroupId"] : null,
                        GroupName = reader["GroupName"].ToString()
                    };
                    products.Add(product);
                }

                reader.Close();
            }

            return products;
        }
    }
}
