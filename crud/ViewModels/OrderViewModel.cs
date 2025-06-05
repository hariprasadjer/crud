using crud.Models;
using System.ComponentModel.DataAnnotations;

namespace crud.ViewModels
{
    // ViewModel used for Order create/edit forms
    public class OrderViewModel
    {
        public int? OrderId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }

        public IEnumerable<Product>? Products { get; set; }
    }
}
