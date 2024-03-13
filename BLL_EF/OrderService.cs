using BLL.DTOModels;
using BLL.ServiceInterfaces;
using DAL;
using Microsoft.EntityFrameworkCore;
using Model;
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

        public void GenerateOrder(int userId)
        {

            _context.Orders.Add(new Order()
            {
                UserID = userId,
                Date = DateTime.Now,
            });
            _context.SaveChanges();
        }

        public void PayOrder(int Id, int amount)
        {
            if(_context.Orders.Single(x => x.Id == Id).IsPaid == false)
            {
                double sum = 0.0;
                foreach (var orderPosition in _context.Orders.Single(x => x.Id == Id).OrderPositions)
                {
                    sum += orderPosition.Amount * orderPosition.Price;
                }

                if (amount == sum)
                    _context.Orders.Single(x => x.Id == Id).IsPaid = true;
                _context.SaveChanges();
            }

        }
    }
}
