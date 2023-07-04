using System.ComponentModel.DataAnnotations;

namespace SchoolBook_Core.Models.UserModels
{
    public class LogInViewModel
    {
        [Required]
        [Display(Name = "Потребителско име")]
        public string Username { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string Password { get; set; } = null!;
    }
}
