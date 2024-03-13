using BLL.DTOModels;
using BLL.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_EF
{
    public class BasketPositionService : IBasketPositionService
    {
        public void AddProductToBasket(BasketPositionRequestDTO request)
        {
            throw new NotImplementedException();
        }

        public void ChangeAmount(int userId, int productId, int newQuantity)
        {
            throw new NotImplementedException();
        }

        public List<BasketPositionResponseDTO> GetBasketPositions(int userId)
        {
            throw new NotImplementedException();
        }

        public void RemoveProductFromBasket(int userId, int productId)
        {
            throw new NotImplementedException();
        }
    }
}
