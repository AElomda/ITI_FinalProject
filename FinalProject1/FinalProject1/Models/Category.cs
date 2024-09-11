using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FinalProject1.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Category Name is required")]
        [DisplayName("Category Name")]
        public string? Name { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Description Must be between 3 and 50 character.")]
        [Required(ErrorMessage = "Category Name is required")]
        public string? Description { get; set; }
        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
