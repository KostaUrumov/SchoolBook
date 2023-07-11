namespace SchoolBook_Core.Models.StudentModels
{
    public class ShowStudentModel
    {
        
        public string FirstName { get; set; } = null!;
        
        public string LastName { get; set; } = null!;

        public string Birthday { get; set; } = null!;

        public int StudentId { get; set; }
        
        public int ExamId { get; set; }

        public double Score { get; set; }
    }
}
