using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DisperdicioAlimentos.Application.DTOs;

namespace DisperdicioAlimentos.Application.Interfaces
{
    public interface IFoodItemService
    {
        Task<IEnumerable<FoodItemDto>> GetAllFoodItemsAsync();
        Task<FoodItemDto> GetFoodItemByIdAsync(Guid id);
        Task<FoodItemDto> AddFoodItemAsync(FoodItemDto foodItemDto);
        Task UpdateFoodItemAsync(FoodItemDto foodItemDto);
        Task DeleteFoodItemAsync(Guid id);
        Task<IEnumerable<FoodItemDto>> GetExpiringFoodItemsAsync(int daysUntilExpiration);
    }
}
