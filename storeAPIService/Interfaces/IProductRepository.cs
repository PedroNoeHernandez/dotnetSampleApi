using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using storeAPIService.DTOs.Product;
using storeAPIService.Helpers;
using storeAPIService.Models;

namespace storeAPIService.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync(QueryObject query);
        Task<Product?> GetByIdAsync(int id);
        Task<Product> CreateAsync(Product ProductModel);
        Task<Product?> UpdateAsync(int id, UpdateProductRequest productDTO);
        Task<Product?> DeleteAsync(int id);
        Task GetByIdAsync(int? productId);
        Task <bool> ProductExist(int id);
    }
}