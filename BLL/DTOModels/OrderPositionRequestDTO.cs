using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOModels
{
    public class OrderPositionRequestDTO
    {
        public int ProductId { get; private set; }
        public int Amount { get; private set; }
        public double Price { get; private set; }

        public OrderPositionRequestDTO(int productId, int amount, double price)
        {
            ProductId = productId;
            Amount = amount;
            Price = price;
        }
    }
}
