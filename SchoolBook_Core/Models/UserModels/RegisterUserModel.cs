using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace SchoolBook_Core.Models.UserModels
{
    public class RegisterUserModel
    {
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; } = null!;
        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string RepeatPassword { get; set; } = null!;
        [Required]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; } = null!;
        [Required]
        [Display(Name = "LastName")]
        public string LastName { get; set; } = null!;

        public string Role { get; set; } = null!;
    }
}
