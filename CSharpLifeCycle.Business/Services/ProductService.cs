using CSharpLifeCycle.Data;
using CSharpLifeCycle.Business.DTOs;
using CSharpLifeCycle.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CSharpLifeCycle.Business.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _db;
        public ProductService(AppDbContext db)
        {
            _db = db;
        }
        public async Task<List<ProductResponse>> GetAllAsync()
        {
            return await _db.Products
                .Select(p => new ProductResponse
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Stock = p.Stock,
                    Description = p.Description
                }).ToListAsync();
        }
        public async Task<ProductResponse?> GetByIdAsync(int id)
        {
            var p = await _db.Products.FindAsync(id);
            if (p == null) return null;
            return new ProductResponse
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Stock = p.Stock,
                Description = p.Description
            };
        }
        public async Task<ProductResponse> CreateAsync(ProductCreateUpdateDto dto)
        {
            var p = new Product
            {
                Name = dto.Name,
                Price = dto.Price,
                Stock = dto.Stock,
                Description = dto.Description
            };
            _db.Products.Add(p);
            await _db.SaveChangesAsync();
            return new ProductResponse
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Stock = p.Stock,
                Description = p.Description
            };
        }
        public async Task<ProductResponse?> UpdateAsync(int id, ProductCreateUpdateDto dto)
        {
            var p = await _db.Products.FindAsync(id);
            if (p == null) return null;
            p.Name = dto.Name;
            p.Price = dto.Price;
            p.Stock = dto.Stock;
            p.Description = dto.Description;
            await _db.SaveChangesAsync();
            return new ProductResponse
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Stock = p.Stock,
                Description = p.Description
            };
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var p = await _db.Products.FindAsync(id);
            if (p == null) return false;
            _db.Products.Remove(p);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}