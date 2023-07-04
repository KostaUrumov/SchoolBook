using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SchoolBook_Core.Models.StudentModels
{
    public class AddStudentModel
    {
        [Required]
        [Display(Name = "Име")]
        public string FirstName { get; set; } = null!;

        [Required]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; } = null!;
        [Required]
        [Display( Name = "Дата на раждане")]
        public DateTime Birthday { get; set; }
    }
}
