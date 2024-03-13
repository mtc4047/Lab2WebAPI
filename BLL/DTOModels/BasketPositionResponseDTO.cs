using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOModels
{
    public class BasketPositionResponseDTO
    {
        public int Id { get; init; }
        public int ProductId { get; init; }
        public int UserId { get; init; }
        public int Amount { get; init; }


        public BasketPositionResponseDTO(int id, int productId, int userId, int amount)
        {
            Id = id;
            ProductId = productId;
            UserId = userId;
            Amount = amount;
        }
    }
}
