using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FinalProject1.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product Title is required")]
        [DisplayName("Product Title")]
        public string? Title { get; set; }

        [Range(10, 10000, ErrorMessage = "Price must be between 10 and 10000.")]
        [Required(ErrorMessage = "Price is required")]
        [DisplayName("Product Price")]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [MinLength(8, ErrorMessage = "Description must be more than 8 character")]
        [MaxLength(200, ErrorMessage = "Description must be less than 200 character")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity cannot be zero")]
        public int Quantity { get; set; }
        public string? ImagePath { get; set; }
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }
    }
}
