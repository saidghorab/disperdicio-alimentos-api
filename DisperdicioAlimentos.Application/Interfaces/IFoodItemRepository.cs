using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DisperdicioAlimentos.Domain.Entities;

namespace DisperdicioAlimentos.Application.Interfaces
{
    public interface IFoodItemRepository
    {
        Task<FoodItem> GetByIdAsync(Guid id);
        Task<IEnumerable<FoodItem>> GetAllAsync();
        Task AddAsync(FoodItem foodItem);
        Task UpdateAsync(FoodItem foodItem);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<FoodItem>> GetExpiringFoodItemsAsync(int daysUntilExpiration);
    }
}
