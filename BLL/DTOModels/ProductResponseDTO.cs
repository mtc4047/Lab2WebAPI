using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOModels
{
    public class ProductResponseDTO
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public double Price { get; private set; }
        public string Image {  get; private set; }
        public bool IsActive { get; private set; }
        public int? GroupId { get; private set; }

        public string GroupName { get; private set; }
    }
}
