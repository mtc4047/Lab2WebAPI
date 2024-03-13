using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOModels
{
    public class OrderPositionResponseDTO
    {
        public int Id { get; init; }
        public int OrderId { get; init; }
        public int ProductId { get; init; }
        public int Amount { get; init; }
        public double Price { get; init; }

        public OrderPositionResponseDTO(int id, int orderId, int productId, int amount, double price)
        {
            Id = id;
            OrderId = orderId;
            ProductId = productId;
            Amount = amount;
            Price = price;
        }
    }
}
