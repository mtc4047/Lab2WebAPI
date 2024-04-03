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

            // Filter basket positions for the user
            var basketPositions = _context.BasketPositions
                .Include(bp => bp.Product)
                .Where(bp => bp.UserId == userId)
                .ToList();
            if (basketPositions == null) { throw new Exception("Koszyk pusty lub użytkownik nie istnieje"); }
            // Create a new order
            var newOrder = new Order
            {
                UserID = userId,
                Date = DateTime.Now,
                IsPaid = false,
                OrderPositions = new List<OrderPosition>()
            };

            // Create order positions for each basket position
            foreach (var basketPosition in basketPositions)
            {
                var orderPosition = new OrderPosition
                {
                    Order = newOrder,
                    Product = basketPosition.Product, // Use the Product navigation property
                    Amount = basketPosition.Amount,
                    Price = basketPosition.Product.Price // Assuming Product has a Price property
                };
                _context.OrdersPositions.Add(orderPosition);
            }

            // Add the new order and its positions to the context
            _context.Orders.Add(newOrder);

            // Save changes to the database
            _context.SaveChanges();


        }

        public void PayOrder(int Id, int amount)
        {
            if(_context.Orders.Single(x => x.Id == Id).IsPaid == false)
            {
                double sum = 0.0;
                foreach (var orderPosition in _context.Orders.Include(op => op.OrderPositions).Single(x => x.Id == Id).OrderPositions)
                {
                    sum += orderPosition.Amount * orderPosition.Price;
                }

                if (amount == sum)
                {
                    _context.Orders.Single(x => x.Id == Id).IsPaid = true;
                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception("nieprawidłowa kwota");
                }
                
            }

        }
    }
}
