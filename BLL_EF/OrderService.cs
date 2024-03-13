using BLL.DTOModels;
using BLL.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_EF
{
    public class OrderService : IOrderService
    {
        private readonly WebshopContext _context;

        public OrderService(WebshopContext context)
        {
            _context = context;
        }

        public int GenerateOrder(int userId)
        {

            throw new NotImplementedException();
        }

        public int PayOrder(int Id, int amount)
        {
            throw new NotImplementedException();
        }
    }
}
