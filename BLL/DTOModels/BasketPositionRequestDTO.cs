using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOModels
{
    public class BasketPositionRequestDTO
    {
        public int ProductId { get; private set; }
        public int UserId { get; private set; }
        public int Amount { get; private set; }

        public BasketPositionRequestDTO(int productId, int userId, int amount)
        {
            ProductId = productId;
            UserId = userId;
            Amount = amount;
        }
    }
}
