using SchoolBook_Core.Models.ExamModels;
using SchoolBook_Structure.Data;
using SchoolBook_Structure.Entities;

namespace SchoolBook_Core.Services
{
    public class ExamService
    {
        private readonly SchoolBookDb data;
        public ExamService(SchoolBookDb _data)
        {
            data = _data;
        }

        public async Task AddExam(AddExamModel model)
        {
            Exam exam = new Exam()
            {
                Disciplibe = model.Disciplibe,
                ExamDate = model.ExamDate,
                Students = new List<Student>()
           };

            await data.Exams.AddAsync(exam);
            await data.SaveChangesAsync();
        }

        public List<ShowExamModel> AllExams()
        {
            List<ShowExamModel> exams = data
                .Exams
                .Select(x => new ShowExamModel() 
                {
                    Date = x.ExamDate.Date.ToString(),
                    Discimpline = x.Disciplibe
                })
                .ToList();

            return exams;
        }

    }
}
