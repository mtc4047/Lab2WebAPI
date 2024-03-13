using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOModels
{
    public class ProductRequestDTO
    {
        public string Name { get; private set; }
        public double Price { get; private set; }
        public string Image { get; private set; }
        public bool IsActive { get; private set; }
        public int? GroupId { get; private set; }
        public ProductRequestDTO(string name, double price, string image, bool isActive, int? groupId)
        {
            Name = name;
            Price = price;
            Image = image;
            IsActive = isActive;
            GroupId = groupId;
        }
    }
}
