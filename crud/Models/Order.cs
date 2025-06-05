using System.ComponentModel.DataAnnotations;

namespace crud.Models
{
    // Represents a purchase order for a product
    public class Order
    {
        public int OrderId { get; set; }

        [Required]
        public int ProductId { get; set; }
        public Product? Product { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }
    }
}
