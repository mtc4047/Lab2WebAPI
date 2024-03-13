using BLL.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ServiceInterfaces
{
    public interface IBasketPositionService
    {
        void AddProductToBasket(BasketPositionRequestDTO request);
        void ChangeAmount(int userId,int productId, int newQuantity);
        void RemoveProductFromBasket(int userId, int productId);
        List<BasketPositionResponseDTO> GetBasketPositions(int userId);

    }
}
