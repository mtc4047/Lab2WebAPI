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
            _context.Products.First(x => x.Id == productId).IsActive = true;
            _context.SaveChanges();
        }

        public void AddProduct(ProductRequestDTO request)
        {
            int nextId = _context.Products.Max(x => x.Id) + 1;
            _context.Products.Add(new Product()
            {
                Id = nextId,
                Name = request.Name,
                Price = request.Price,
                GroupId = request.GroupId,
                Image= request.Image,
                IsActive = request.IsActive,
                BasketPositions = null,
                ProductGroup = null
            });
            _context.SaveChanges();
        }

        public void DeactivateProduct(int productId)
        {
            _context.Products.First(x => x.Id == productId).IsActive = false;
            _context.SaveChanges();
        }

        public void DeleteProduct(int productId)
        {
            var productToDelete = _context.Products.FirstOrDefault(x => x.Id == productId);
            if (productToDelete != null)
            {
                _context.Products.Remove(productToDelete);
                _context.SaveChanges();
            }

        }

        public List<ProductResponseDTO> GetProducts(IProductService.ProductSortColumn sortColumn = IProductService.ProductSortColumn.Name, IProductService.SortOrder sortOrder = IProductService.SortOrder.Ascending, string filterName = null, string filterGroupName = null, int? filterGroupId = null, bool includeInactive = false)
        {
            throw new NotImplementedException();
        }
    }
}