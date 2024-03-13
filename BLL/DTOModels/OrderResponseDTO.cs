using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOModels
{
    public class OrderResponseDTO
    {
        public int Id { get; private set; }
        public int UserId { get; private set; }
        public DateTime Date { get; private set; }
        public List<OrderPositionResponseDTO> OrderPositions { get; private set; }

        public OrderResponseDTO(int id, int userId, DateTime date, List<OrderPositionResponseDTO> orderPositions)
        {
            Id = id;
            UserId = userId;
            Date = date;
            OrderPositions = orderPositions;
        }
    }
}
