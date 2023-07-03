using System.ComponentModel.DataAnnotations;

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

       
    }
}