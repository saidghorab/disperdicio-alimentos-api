using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DisperdicioAlimentos.Application.Interfaces;
using DisperdicioAlimentos.Domain.Entities;
using DisperdicioAlimentos.Infrastructure.Data;

namespace DisperdicioAlimentos.Infrastructure.Repositories
{
    public class FoodItemRepository : IFoodItemRepository
    {
        private readonly ApplicationDbContext _context;

        public FoodItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<FoodItem> GetByIdAsync(Guid id)
        {
            return await _context.FoodItems.FindAsync(id);
        }

        public async Task<IEnumerable<FoodItem>> GetAllAsync()
        {
            return await _context.FoodItems.ToListAsync();
        }

        public async Task AddAsync(FoodItem foodItem)
        {
            await _context.FoodItems.AddAsync(foodItem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(FoodItem foodItem)
        {
            _context.Entry(foodItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var foodItem = await _context.FoodItems.FindAsync(id);
            if (foodItem != null)
            {
                _context.FoodItems.Remove(foodItem);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<FoodItem>> GetExpiringFoodItemsAsync(int daysUntilExpiration)
        {
            var expirationThreshold = DateTime.UtcNow.AddDays(daysUntilExpiration);
            return await _context.FoodItems
                .Where(f => f.ExpirationDate <= expirationThreshold && !f.IsExpired)
                .ToListAsync();
        }
    }
}
