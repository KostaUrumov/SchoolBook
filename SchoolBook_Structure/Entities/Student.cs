using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolBook_Structure.Entities
{
    public class Student
    {
        [Key]
        public int studentId { get; set; }

        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;
        [Required]
        public DateTime Birthday { get; set; }

        public string ParentId { get; set; } = null!;

        [ForeignKey(nameof(ParentId))]
        public Parent Parent { get; set; } = null!;

        public List<Exam> Exams { get; set; } = new List<Exam>();

    }
}