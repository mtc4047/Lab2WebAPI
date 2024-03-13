using BLL.DTOModels;
using DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ServiceInterfaces
{
    public interface IProductService
    {
        List<ProductResponseDTO> GetProducts(
        ProductSortColumn sortColumn = ProductSortColumn.Name,
        SortOrder sortOrder = SortOrder.Ascending,
        string filterName = null,
        string filterGroupName = null,
        int? filterGroupId = null,
        bool includeInactive = false);

        void AddProduct(ProductRequestDTO request);
        void DeactivateProduct(int productId);
        void DeleteProduct(int productId);
        void ActivateProduct(int productId);

        enum ProductSortColumn
        {
            Name,
            Price,
            GroupName
        }

        enum SortOrder
        {
            Ascending,
            Descending
        }
    }
}
