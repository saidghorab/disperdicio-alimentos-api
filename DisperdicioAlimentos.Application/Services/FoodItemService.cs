using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper; // Add this using statement
using DisperdicioAlimentos.Application.DTOs;
using DisperdicioAlimentos.Application.Interfaces;
using DisperdicioAlimentos.Domain.Entities;

namespace DisperdicioAlimentos.Application.Services
{
    public class FoodItemService : IFoodItemService
    {
        private readonly IFoodItemRepository _foodItemRepository;
        private readonly IMapper _mapper;

        public FoodItemService(IFoodItemRepository foodItemRepository, IMapper mapper)
        {
            _foodItemRepository = foodItemRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FoodItemDto>> GetAllFoodItemsAsync()
        {
            var foodItems = await _foodItemRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<FoodItemDto>>(foodItems);
        }

        public async Task<FoodItemDto> GetFoodItemByIdAsync(Guid id)
        {
            var foodItem = await _foodItemRepository.GetByIdAsync(id);
            return _mapper.Map<FoodItemDto>(foodItem);
        }

        public async Task<FoodItemDto> AddFoodItemAsync(FoodItemDto foodItemDto)
        {
            var foodItem = _mapper.Map<FoodItem>(foodItemDto);
            foodItem.Id = Guid.NewGuid(); // Ensure new ID for new entity
            foodItem.CreatedAt = DateTime.UtcNow;
            await _foodItemRepository.AddAsync(foodItem);
            return _mapper.Map<FoodItemDto>(foodItem);
        }

        public async Task UpdateFoodItemAsync(FoodItemDto foodItemDto)
        {
            var existingFoodItem = await _foodItemRepository.GetByIdAsync(foodItemDto.Id);
            if (existingFoodItem == null) return;

            _mapper.Map(foodItemDto, existingFoodItem); // Map DTO to existing entity
            await _foodItemRepository.UpdateAsync(existingFoodItem);
        }

        public async Task DeleteFoodItemAsync(Guid id)
        {
            await _foodItemRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<FoodItemDto>> GetExpiringFoodItemsAsync(int daysUntilExpiration)
        {
            var foodItems = await _foodItemRepository.GetExpiringFoodItemsAsync(daysUntilExpiration);
            return _mapper.Map<IEnumerable<FoodItemDto>>(foodItems);
        }
    }
}
