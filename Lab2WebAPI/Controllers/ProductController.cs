using Azure.Core;
using BLL.DTOModels;
using BLL.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab2WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("GetProducts")]
        public IActionResult GetProducts(IProductService.ProductSortColumn sortColumn = IProductService.ProductSortColumn.Name, IProductService.SortOrder sortOrder = IProductService.SortOrder.Ascending, string filterName = null, string filterGroupName = null, int? filterGroupId = null, bool includeInactive = false)
        {
            try
            {
                var products = _productService.GetProducts(sortColumn,sortOrder, filterName, filterGroupName, filterGroupId, includeInactive);
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while getting product list: \r\n" + ex.Message);
            }


        }

        [HttpPost("AddProducts")]
        public IActionResult AddProduct([FromBody] ProductRequestDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _productService.AddProduct(request);
                return Ok("Product added successfully");
            }
            catch (Exception ex)
            {

                return StatusCode(500, "An error occurred while adding the product: \r\n" + ex.Message);
            }
        }

        [HttpPut("DeactivateProduct")]
        public IActionResult DeactivateProduct(int productId)
        {
            try
            {
                _productService.DeactivateProduct(productId);
                return Ok("Product deactivated successfully");
            }
            catch (Exception ex)
            {

                return StatusCode(500, "An error occurred while deactivating the product: \r\n" + ex.Message);
            }
        }
        [HttpPut("ActivateProduct")]
        public IActionResult ActivateProduct(int productId)
        {
            try
            {
                _productService.ActivateProduct(productId);
                return Ok("Product activated successfully");
            }
            catch (Exception ex)
            {

                return StatusCode(500, "An error occurred while deactivating the product: \r\n" + ex.Message);
            }
        }
    }
}
