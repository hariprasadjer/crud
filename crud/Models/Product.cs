using System.ComponentModel.DataAnnotations;

namespace crud.Models
{
    // Represents a sellable product
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue)]
        public int Stock { get; set; }

        public ICollection<Order>? Orders { get; set; }
    }
}
