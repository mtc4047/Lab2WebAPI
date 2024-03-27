using BLL.DTOModels;
using BLL.ServiceInterfaces;
using DAL;
using DTOModels;
using Model;

namespace BLL_EF
{
    public class ProductService : IProductService
    {
        private readonly WebshopContext _context;

        public ProductService(WebshopContext context)
        {
            _context = context;
        }
        public void ActivateProduct(int productId)
        {
            _context.Products.Single(x => x.Id == productId).IsActive = true;
            _context.SaveChanges();
        }

        public void AddProduct(ProductRequestDTO request)
        {
            if (request.Price > 0)
            {
                _context.Products.Add(new Product()
                {
                    Name = request.Name,
                    Price = request.Price,
                    GroupId = request.GroupId,
                    Image = request.Image,
                    IsActive = true,
                }); ;
                _context.SaveChanges();
            }

        }

        public void DeactivateProduct(int productId)
        {
            var userId = _context.Products.Single(x => x.Id == productId)
                 .BasketPositions.Single(x => x.ProductId == productId).UserId;
            var order = _context.Orders.Single(x => x.UserID == userId);
            if (order != null)
            {
                if (order.IsPaid)
                {
                    _context.Products.Single(x => x.Id == productId).IsActive = false;
                    _context.SaveChanges();
                }
            }


        }

        public void DeleteProduct(int productId)
        {
            var userId = _context.Products.Single(x => x.Id == productId)
                .BasketPositions.Single(x => x.ProductId == productId).UserId;
            var order = _context.Orders.Single(x => x.UserID == userId);
            if (order.IsPaid)
            {
                var productToDelete = _context.Products.FirstOrDefault(x => x.Id == productId);
                if (productToDelete != null)
                {
                    _context.Products.Remove(productToDelete);
                    _context.SaveChanges();
                }
            }
        }

        public List<ProductResponseDTO> GetProducts(IProductService.ProductSortColumn sortColumn = IProductService.ProductSortColumn.Name, IProductService.SortOrder sortOrder = IProductService.SortOrder.Ascending, string filterName = null, string filterGroupName = null, int? filterGroupId = null, bool includeInactive = false)
        {
            throw new NotImplementedException();
        }
    }
  }