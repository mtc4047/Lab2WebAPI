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
            var basketPositions = _context.BasketPositions
              .Include(bp => bp.Product)
              .Where(bp => bp.UserId == userId)
              .ToList();

            var order = new Order
            {
                UserID = userId,
                Date = DateTime.Now,
                IsPaid = false
            };

            _context.Orders.Add(order);
            _context.SaveChanges();
            int orderId = order.Id;
            var orderPositions = new List<OrderPosition>();
            foreach (var basketPosition in basketPositions)
            {
                orderPositions.Add(new OrderPosition
                {
                    Amount = basketPosition.Amount,
                    Price = basketPosition.Product.Price,
                    Product = basketPosition.Product,
                    OrderId=orderId
                });
            }


            _context.OrdersPositions.AddRange(orderPositions);
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
