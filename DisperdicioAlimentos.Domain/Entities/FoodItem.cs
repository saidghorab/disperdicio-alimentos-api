using System;

namespace DisperdicioAlimentos.Domain.Entities
{
    public class FoodItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Location { get; set; } // This could be a more complex Value Object later
        public bool IsExpired => DateTime.UtcNow > ExpirationDate;
        public DateTime CreatedAt { get; set; }
        public DateTime? ReusedAt { get; set; } // When the item was reused instead of discarded
    }
}
