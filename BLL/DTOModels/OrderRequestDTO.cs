using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOModels
{
    public class OrderRequestDTO
    {
        public int UserId { get; init; } 
        public List<OrderPositionRequestDTO> OrderPositions { get; init; } 

        public OrderRequestDTO(int userId, List<OrderPositionRequestDTO> orderPositions)
        {
            UserId = userId;
            OrderPositions = orderPositions;
        }
    }
}
