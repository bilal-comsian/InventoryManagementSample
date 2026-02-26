using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InventoryManagement.Models;

namespace InventoryManagement.Services
{
    public interface IInventoryService
    {
        event Action? OnChange;

        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(Guid id);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Guid id);
        Task AdjustStockAsync(Guid id, int delta);
    }
}