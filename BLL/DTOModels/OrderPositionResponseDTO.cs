using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOModels
{
    public class OrderPositionResponseDTO
    {
        public int Id { get; private set; }
        public int OrderId { get; private set; }
        public int ProductId { get; private set; }
        public int Amount { get; private set; }
        public double Price { get; private set; }

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
