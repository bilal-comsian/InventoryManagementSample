using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagement.Models;

namespace InventoryManagement.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly ConcurrentDictionary<Guid, Product> _store = new();

        public event Action? OnChange;

        public InventoryService()
        {
            // Seed sample data
            var samples = new[]
            {
                new Product { Name = "Notebook", SKU = "NB-001", Stock = 25, Price = 4.99m, Description = "A5 ruled notebook" },
                new Product { Name = "Pen", SKU = "PN-201", Stock = 100, Price = 0.99m, Description = "Blue ink ballpoint" },
                new Product { Name = "USB Drive 32GB", SKU = "USB-32", Stock = 50, Price = 9.99m, Description = "USB 3.0 flash drive" }
            };

            foreach (var p in samples) _store[p.Id] = p;
        }

        private void Notify() => OnChange?.Invoke();

        public Task AddAsync(Product product)
        {
            product.Id = Guid.NewGuid();
            _store[product.Id] = product;
           // Notify();
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Guid id)
        {
            _store.TryRemove(id, out _);
            Notify();
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            return Task.FromResult(_store.Values.AsEnumerable());
        }

        public Task<Product?> GetByIdAsync(Guid id)
        {
            _store.TryGetValue(id, out var p);
            return Task.FromResult(p);
        }

        public Task UpdateAsync(Product product)
        {
            if (product.Id == Guid.Empty) product.Id = Guid.NewGuid();
            _store[product.Id] = product;
            Notify();
            return Task.CompletedTask;
        }

        public Task AdjustStockAsync(Guid id, int delta)
        {
            if (_store.TryGetValue(id, out var p))
            {
                var newStock = p.Stock + delta;
                if (newStock < 0) newStock = 0;
                p.Stock = newStock;
                _store[id] = p;
                Notify();
            }
            return Task.CompletedTask;
        }
    }
}