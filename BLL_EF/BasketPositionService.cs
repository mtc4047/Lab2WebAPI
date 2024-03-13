using Azure.Core;
using BLL.DTOModels;
using BLL.ServiceInterfaces;
using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_EF
{
    public class BasketPositionService : IBasketPositionService
    {
        private readonly WebshopContext _context;

        public BasketPositionService(WebshopContext context)
        {
            _context = context;
        }

        public void AddProductToBasket(BasketPositionRequestDTO request)
        {
            if(_context.Products.Single(x => x.Id == request.ProductId).IsActive){
                _context.BasketPositions.Add(new BasketPosition()
                {
                    ProductId = request.ProductId,
                    UserId = request.UserId,
                    Amount = request.Amount,
                });
                _context.SaveChanges();
            }

        }

        public void ChangeAmount(int userId, int productId, int newQuantity)
        {
            if(newQuantity > 0)
            {
                _context.BasketPositions.Single(x => x.ProductId == userId && x.ProductId == productId).Amount = newQuantity;
                _context.SaveChanges();
            }

        }

        public List<BasketPositionResponseDTO> GetBasketPositions(int userId)
        {
            var query = _context.BasketPositions.Where(x => x.UserId == userId);
            List<BasketPositionResponseDTO> basketPositionResponseDTOs = new List<BasketPositionResponseDTO>();
            foreach (var item in query)
            {
                basketPositionResponseDTOs.Add(
                    new BasketPositionResponseDTO(item.Id, item.ProductId, item.UserId, item.Amount)
                    );
            }
            return basketPositionResponseDTOs;
        }

        public void RemoveProductFromBasket(int userId, int productId)
        {
            var productToDelete = _context.BasketPositions.FirstOrDefault(x => x.UserId == userId && x.ProductId == productId);
            if (productToDelete != null)
            {
                _context.BasketPositions.Remove(productToDelete);
                _context.SaveChanges();
            }
        }
    }
}
