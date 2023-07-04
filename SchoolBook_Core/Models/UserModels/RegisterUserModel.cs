using Microsoft.Build.Framework;
using SchoolBook_Structure.Entities;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace SchoolBook_Core.Models.UserModels
{
    public class RegisterUserModel
    {
        [Required]
        [Display(Name = "Потребителско име")]
        public string Username { get; set; } = null!;
        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string Password { get; set; } = null!;
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Повтори паролата")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string RepeatPassword { get; set; } = null!;
        [Required]
        [Display(Name = "Име")]
        
        public string FirstName { get; set; } = null!;
        [Required]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; } = null!;

        public string Role { get; set; } = null!;
        public List<Student>? MyKids { get; set; } = new List<Student>();
    }
}
