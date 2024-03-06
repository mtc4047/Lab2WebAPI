using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class OrderPosition
    {
        public int Id { get; set; }
        public int OrderId {  get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }

        public Order Order { get; set; }
    }
}
