using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOModels
{
    public class BasketPositionResponseDTO
    {
        public int Id { get; private set; }
        public int ProductId { get; private set; }
        public int UserId { get; private set; }
        public int Amount { get; private set; }


        public BasketPositionResponseDTO(int id, int productId, int userId, int amount)
        {
            Id = id;
            ProductId = productId;
            UserId = userId;
            Amount = amount;
        }
    }
}
