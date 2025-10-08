using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DisperdicioAlimentos.Application.DTOs;
using DisperdicioAlimentos.Application.Interfaces;

namespace DisperdicioAlimentos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodItemsController : ControllerBase
    {
        private readonly IFoodItemService _foodItemService;

        public FoodItemsController(IFoodItemService foodItemService)
        {
            _foodItemService = foodItemService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodItemDto>>> GetFoodItems()
        {
            var foodItems = await _foodItemService.GetAllFoodItemsAsync();
            return Ok(foodItems);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FoodItemDto>> GetFoodItem(Guid id)
        {
            var foodItem = await _foodItemService.GetFoodItemByIdAsync(id);
            if (foodItem == null)
            {
                return NotFound();
            }
            return Ok(foodItem);
        }

        [HttpPost]
        public async Task<ActionResult<FoodItemDto>> PostFoodItem(FoodItemDto foodItemDto)
        {
            var createdFoodItem = await _foodItemService.AddFoodItemAsync(foodItemDto);
            return CreatedAtAction(nameof(GetFoodItem), new { id = createdFoodItem.Id }, createdFoodItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFoodItem(Guid id, FoodItemDto foodItemDto)
        {
            if (id != foodItemDto.Id)
            {
                return BadRequest();
            }

            var existingFoodItem = await _foodItemService.GetFoodItemByIdAsync(id);
            if (existingFoodItem == null)
            {
                return NotFound();
            }

            await _foodItemService.UpdateFoodItemAsync(foodItemDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFoodItem(Guid id)
        {
            var existingFoodItem = await _foodItemService.GetFoodItemByIdAsync(id);
            if (existingFoodItem == null)
            {
                return NotFound();
            }

            await _foodItemService.DeleteFoodItemAsync(id);
            return NoContent();
        }

        [HttpGet("expiring/{days}")]
        public async Task<ActionResult<IEnumerable<FoodItemDto>>> GetExpiringFoodItems(int days)
        {
            var expiringFoodItems = await _foodItemService.GetExpiringFoodItemsAsync(days);
            return Ok(expiringFoodItems);
        }
    }
}
