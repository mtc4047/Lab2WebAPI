using Azure.Core;
using BLL.DTOModels;
using BLL.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace Lab2WebAPI.Controllers
{
    public class BasketPositionController : Controller
    {
        private readonly IBasketPositionService _basketPositionService;
        public BasketPositionController(IBasketPositionService _basketPositionService)
        {
            _basketPositionService = _basketPositionService;
        }

        [HttpPost("AddProductToBasket")]
        public IActionResult AddProductToBasket([FromBody]BasketPositionRequestDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _basketPositionService.AddProductToBasket(request);
                return Ok("Product added to basket successfully");
            }
            catch (Exception ex)
            {

                return StatusCode(500, "An error occurred while adding the product to basket: \r\n" + ex.Message);
            }
        }

        [HttpPost("ChangeAmount")]
        public IActionResult ChangeAmount(int userId, int productId, int newQuantity)
        {
            try
            {
                _basketPositionService.ChangeAmount(userId,productId,newQuantity);
                return Ok("Amount changed successfully");
            }
            catch (Exception ex)
            {

                return StatusCode(500, "An error occurred while changing amount: \r\n" + ex.Message);
            }
        }

        [HttpDelete("RemoveProductFromBasket")] 
        public IActionResult RemoveProductFromBasket(int userId, int productId) 
        {
            try
            {
                _basketPositionService.RemoveProductFromBasket(userId, productId);
                return Ok("Product removed from basket successfully");
            }
            catch (Exception ex)
            {

                return StatusCode(500, "An error occurred while removing product from basket: \r\n" + ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetBasketPositions(int userId)
        {
            try
            {
                var basketPositions = _basketPositionService.GetBasketPositions(userId);
                return Ok(basketPositions);
            }
            catch (Exception ex)
            {

                return StatusCode(500, "An error occurred while getting basket positions: \r\n" + ex.Message);
            }
        }
    }
}
