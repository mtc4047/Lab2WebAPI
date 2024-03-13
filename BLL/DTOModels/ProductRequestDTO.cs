using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOModels
{
    public class ProductRequestDTO
    {
        public string Name { get; init; }
        public double Price { get; init; }
        public string Image { get; init; }
        public int? GroupId { get; init; }
        public ProductRequestDTO(string name, double price, string image, int? groupId)
        {
            Name = name;
            Price = price;
            Image = image;
            GroupId = groupId;
        }
    }
}
