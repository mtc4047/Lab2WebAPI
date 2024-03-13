using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOModels
{
    public class OrderResponseDTO
    {
        public int Id { get; init; }
        public int UserId { get; init; }
        public DateTime Date { get; init; }
        public List<OrderPositionResponseDTO> OrderPositions { get; init; }

        public OrderResponseDTO(int id, int userId, DateTime date, List<OrderPositionResponseDTO> orderPositions)
        {
            Id = id;
            UserId = userId;
            Date = date;
            OrderPositions = orderPositions;
        }
    }
}
