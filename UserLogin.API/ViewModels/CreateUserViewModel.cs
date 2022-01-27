using System.ComponentModel.DataAnnotations;

namespace UserLogin.API.ViewModels
{
    public class CreateUserViewModel
    {
        [Required]
        [MinLength(3, ErrorMessage = "At least 3 characteres")]
        [MaxLength(50, ErrorMessage = "Maximum of 50 characteres")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "At least 1 characteres")]
        [MaxLength(80, ErrorMessage = "Maximum of 80 characteres")]
        public string LastName { get; set; }
        [Required]
        [MaxLength(80, ErrorMessage = "Maximum of 80 characteres")]
        [EmailAddress(ErrorMessage = "Invalid format")]
        public string Email { get; set; }
        [Required]
        [MinLength(6, ErrorMessage = "At least 6 characteres")]
        [MaxLength(50, ErrorMessage = "Maximum of 50 characteres")]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Not matches")]
        public string ConfirmPassword { get; set; }
    }
}
