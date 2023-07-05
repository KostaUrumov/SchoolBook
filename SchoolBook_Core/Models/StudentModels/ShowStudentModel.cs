using System.ComponentModel.DataAnnotations;

namespace SchoolBook_Core.Models.StudentModels
{
    public class ShowStudentModel
    {
        
        public string FirstName { get; set; } = null!;
        
        public string LastName { get; set; } = null!;

        public string Birthday { get; set; } = null!;

        public int Id { get; set; }
    }
}
