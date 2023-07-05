using Microsoft.AspNetCore.Mvc.ModelBinding;
using SchoolBook_Core.Models.StudentModels;
using SchoolBook_Structure.Data;
using SchoolBook_Structure.Entities;

namespace SchoolBook_Core.Services
{
    public class StudentService
    {
        private readonly SchoolBookDb data;

        public StudentService(SchoolBookDb _data)
        {
            data = _data;
        }

        public async Task AddStudent(AddStudentModel model, string userId)
        {
            Parent us = data.Parents.Find(userId);
            
            Student student = new Student()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Birthday = model.Birthday
            };

            us.MyKids.Add(student);
            await data.AddAsync(student);
            await data.SaveChangesAsync();
        }

        public List<ShowStudentModel> AllStudents()
        {
            List<ShowStudentModel> studs = data
                .Students
                .Select(s => new ShowStudentModel
                {
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Birthday = s.Birthday.Date.ToShortDateString(),
                    Id = s.studentId
                })
                .ToList();
            return studs;
        }

    }
}
