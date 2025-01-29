using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using storeAPIService.Data;
using storeAPIService.DTOs.Product;
using storeAPIService.Helpers;
using storeAPIService.Interfaces;
using storeAPIService.Models;

namespace storeAPIService.Reposotiry
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDBContext _context;
        public ProductRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateAsync(Product ProductModel)
        {
            await _context.Product.AddAsync(ProductModel);
            await _context.SaveChangesAsync();
            return ProductModel;
        }

        public async Task<Product?> DeleteAsync(int id)
        {
            var ProductModel =  await _context.Product.FirstOrDefaultAsync(x=> x.Id == id);
            if(ProductModel == null)
                return null;
            _context.Product.Remove(ProductModel);
            await _context.SaveChangesAsync();
            return ProductModel;
        }

        public async Task<List<Product>> GetAllAsync(QueryObject query)
        {
            var products = _context.Product.Include(c=>c.Comments).AsQueryable();

            if(!string.IsNullOrWhiteSpace(query.Description)){
                products = products.Where(p=>p.Description.Contains(query.Description));
            }
            if(!string.IsNullOrWhiteSpace(query.Name)){
                products = products.Where(p=>p.Name.Contains(query.Name));
            }
            if(!string.IsNullOrWhiteSpace(query.SortBy)){
                if(query.SortBy.Equals("Name",StringComparison.OrdinalIgnoreCase)){
                    products= query.decending? products.OrderByDescending(p=>p.Name):products.OrderBy(p=>p.Name);
                }
                if(query.SortBy.Equals("Description",StringComparison.OrdinalIgnoreCase)){
                    products= query.decending? products.OrderByDescending(p=>p.Description):products.OrderBy(p=>p.Description);
                }
            }
            var skipNumber = (query.page -1) * query.pageSize;
            
            return await products.Skip(skipNumber).Take(query.pageSize).ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Product.Include(c=>c.Comments).FirstOrDefaultAsync();
        }

        public Task GetByIdAsync(int? productId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ProductExist(int id)
        {
            return _context.Product.AnyAsync(p => p.Id == id);
        }

        public async Task<Product?> UpdateAsync(int id, UpdateProductRequest ProductDTO)
        {
            var ProductModel = await _context.Product.FirstOrDefaultAsync(x=> x.Id == id);
            if (ProductModel == null)
                return null;
            ProductModel.Name = (ProductDTO.Name!="")?ProductDTO.Name:ProductModel.Name;
            ProductModel.Description = (ProductDTO.Description!="")?ProductDTO.Description:ProductModel.Description;
            ProductModel.Model = (ProductDTO.Model!="")?ProductDTO.Model:ProductModel.Model;
            ProductModel.Color = (ProductDTO.Color!="")?ProductDTO.Color:ProductModel.Color;
            ProductModel.HexColor = (ProductDTO.HexColor!="")?ProductDTO.HexColor:ProductModel.HexColor;
            ProductModel.B64Image = (ProductDTO.B64Image!="")?ProductDTO.B64Image:ProductModel.B64Image;
            ProductModel.Properties = (ProductDTO.Properties!="")?ProductDTO.Properties:ProductModel.Properties;
            ProductModel.Price = (ProductDTO.Price!=0)?ProductDTO.Price:ProductModel.Price;
            ProductModel.Cost = (ProductDTO.Cost!=0)?ProductDTO.Cost:ProductModel.Cost;

            await _context.SaveChangesAsync();
            return ProductModel;
        }
    }
}