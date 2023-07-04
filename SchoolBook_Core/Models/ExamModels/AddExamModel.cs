using System.ComponentModel.DataAnnotations;

namespace SchoolBook_Core.Models.ExamModels
{
    public class AddExamModel
    {
        [Display(Name ="Предмет")]
        public string Disciplibe { get; set; } = null!;

        [Display(Name = "Дата")]
        public DateTime ExamDate { get; set; }
    }
}
