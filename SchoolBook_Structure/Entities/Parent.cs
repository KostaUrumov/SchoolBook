using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SchoolBook_Structure.Entities
{
    public class Parent
    {
        [Required]
        public string Id { get; set; } = null!;

        [ForeignKey(nameof(Id))]
        public User User { get; set; } = null!;
        public List<Student> MyKids { get; set; } = new List<Student>();
    }
}
