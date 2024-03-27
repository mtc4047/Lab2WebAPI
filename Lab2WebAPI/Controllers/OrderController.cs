using BLL.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace Lab2WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpPost("GenerateOrder")]
        public IActionResult GenerateOrder(int userId)
        {
            try
            {
                _orderService.GenerateOrder(userId);
                return Ok("Order generated successfully");
            }
            catch (Exception ex)
            {

                return StatusCode(500, "An error occurred while generating order: \r\nMessage:" +ex.Message+"\r\nInnerException" + ex.InnerException);
            }
        }

        [HttpPut("PayOrder")]
        public IActionResult PayOrder(int Id, int amount)
        {
            try
            {
                _orderService.PayOrder(Id, amount);
                return Ok("Order paid successfully");
            }
            catch (Exception ex)
            {

                return StatusCode(500, "An error occurred while paying for order: \r\n" + ex.Message);
            }
        }

    }
}
