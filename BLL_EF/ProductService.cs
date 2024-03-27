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
            var product = _context.Products.Single(x => x.Id == productId);
            if (product == null) return;
            var basketPosition = product.BasketPositions?.Single(x => x.ProductId == productId);
            if(basketPosition != null)
            {
                
                var order = _context.Orders.Single(x => x.UserID == basketPosition.UserId);
                if (order != null)
                {
                    if (order.IsPaid)
                    {
                        _context.Products.Single(x => x.Id == productId).IsActive = false;
                        _context.SaveChanges();
                    }
                }
            }
            else
            {
                _context.Products.Single(x => x.Id == productId).IsActive = false;
                _context.SaveChanges();
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
            List<ProductResponseDTO> productResponseDTOs = new List<ProductResponseDTO>();
            var query = _context.Products;
            if (filterName != null)
            {
                query.Where(x => x.Name == filterName);
            }
            if (filterGroupName != null)
            {
                query.Where(x => x.ProductGroup.Name == filterGroupName);
            }
            if (filterGroupId != null)
            {
                query.Where(x => x.GroupId == filterGroupId);
            }
            if (!includeInactive)
            {
                query.Where(x => x.IsActive == true);
            }
            switch (sortColumn)
            {
                case IProductService.ProductSortColumn.Name:

                    if (sortOrder == IProductService.SortOrder.Ascending)
                    {
                        query.OrderBy(x => x.Name);
                    }
                    else
                    {
                        query.OrderByDescending(x => x.Name);
                    }
                    break;
                case IProductService.ProductSortColumn.Price:
                    if (sortOrder == IProductService.SortOrder.Ascending)
                    {
                        query.OrderBy(x => x.Price);
                    }
                    else
                    {
                        query.OrderByDescending(x => x.Price);
                    }
                    break;
                case IProductService.ProductSortColumn.GroupName:
                    if (sortOrder == IProductService.SortOrder.Ascending)
                    {
                        query.OrderBy(x => x.ProductGroup.Name);
                    }
                    else
                    {
                        query.OrderByDescending(x => x.ProductGroup.Name);
                    }
                    break;
            }
            foreach (var product in query)
            {
                productResponseDTOs.Add(new ProductResponseDTO()
                {
                    Id = product.Id,
                    GroupName = product.ProductGroup != null ? product.ProductGroup.Name : "",
                    Image = product.Image,
                    GroupId = product.GroupId,
                    IsActive = product.IsActive,
                    Name = product.Name,
                    Price = product.Price
                });
            }
            return productResponseDTOs;
        }
    

    }
  }