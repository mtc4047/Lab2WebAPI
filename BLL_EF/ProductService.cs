﻿using Azure;
using BLL.DTOModels;
using BLL.ServiceInterfaces;
using DAL;
using DTOModels;
using Microsoft.EntityFrameworkCore;
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
            var product = _context.Products.Single(x => x.Id == productId);
            if (product == null) return;
            var basketPosition = product.BasketPositions?.Single(x => x.ProductId == productId);
            if (basketPosition != null)
            {

                var order = _context.Orders.Single(x => x.UserID == basketPosition.UserId);
                if (order != null)
                {
                    _context.Products.Single(x => x.Id == productId).IsActive = false;
                    if (order.IsPaid)
                    {
                        _context.Products.Remove(product);
                    }
                    _context.SaveChanges();
                }
            }
            else
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }

        }

        public List<ProductResponseDTO> GetProducts(IProductService.ProductSortColumn sortColumn = IProductService.ProductSortColumn.Name, IProductService.SortOrder sortOrder = IProductService.SortOrder.Ascending, string filterName = null, string filterGroupName = null, int? filterGroupId = null, bool includeInactive = false)
        {
            List<ProductResponseDTO> productResponseDTOs = new List<ProductResponseDTO>();
            IQueryable<Product> query = _context.Products.Include(pg => pg.ProductGroup);
            if (filterName != null)
            {
                query = query.Where(x => x.Name == filterName);
            }
            if (filterGroupName != null)
            {
                query = query.Where(x => x.ProductGroup.Name == filterGroupName);
            }
            if (filterGroupId != null)
            {
                query = query.Where(x => x.GroupId == filterGroupId);
            }
            if (!includeInactive)
            {
                query = query.Where(x => x.IsActive == true);
            }
            switch (sortColumn)
            {
                case IProductService.ProductSortColumn.Name:

                    if (sortOrder == IProductService.SortOrder.Ascending)
                    {
                        query = query.OrderBy(x => x.Name);
                    }
                    else
                    {
                        query = query.OrderByDescending(x => x.Name);
                    }
                    break;
                case IProductService.ProductSortColumn.Price:
                    if (sortOrder == IProductService.SortOrder.Ascending)
                    {
                        query = query.OrderBy(x => x.Price);
                    }
                    else
                    {
                        query = query.OrderByDescending(x => x.Price);
                    }
                    break;
                case IProductService.ProductSortColumn.GroupName:
                    if (sortOrder == IProductService.SortOrder.Ascending)
                    {
                        query = query.OrderBy(x => x.ProductGroup.Name);
                    }
                    else
                    {
                        query = query.OrderByDescending(x => x.ProductGroup.Name);
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