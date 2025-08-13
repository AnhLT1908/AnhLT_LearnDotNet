using CSharpLifeCycle.DTOs; 
using CSharpLifeCycle.Models; 

namespace CSharpLifeCycle.Services 
{
    public interface IProductService
    {
        Task<List<ProductResponse>> GetAllAsync(); 
        Task<ProductResponse?> GetByIdAsync(int id); 
        Task<ProductResponse> CreateAsync(ProductCreateUpdateDto dto); 
        Task<ProductResponse?> UpdateAsync(int id, ProductCreateUpdateDto dto); 
        Task<bool> DeleteAsync(int id); 
    }
}