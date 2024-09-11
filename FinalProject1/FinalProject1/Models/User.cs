using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FinalProject1.Models
{
    public class User
    {
        public int Id { get; set; }


        [StringLength(12, MinimumLength = 3, ErrorMessage = "Name Must be between 3 and 12 character.")]
        [Required(ErrorMessage = "Name is Required.")]
        [DisplayName("User FirstName")]
        public string? FirstName { get; set; }

        [StringLength(12, MinimumLength = 3, ErrorMessage = "Name Must be between 3 and 12 character.")]
        [Required(ErrorMessage = "Name is Required.")]
        [DisplayName("User LastName")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Password is Required, must contain at least  8 characters  and numbers.")]
        [DisplayName("User Password")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Email is Required.")]
        [EmailAddress]
        [DisplayName("User Email")]
        public string? Email { get; set; }
    }
}
