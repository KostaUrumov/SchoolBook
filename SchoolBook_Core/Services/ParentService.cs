using SchoolBook_Core.Models.Teacher;
using SchoolBook_Structure.Data;

namespace SchoolBook_Core.Services
{
    public class ParentService
    {
        private readonly SchoolBookDb data;

        public ParentService(SchoolBookDb _data)
        {
            data = _data;
        }

        public List<ParentViewModel> GetAllParents()
        {
            List<ParentViewModel> models = data
                .Parents
                .Select(p => new ParentViewModel
                {
                    FirstName = p.User.FirstName,
                    LastName = p.User.LastName
                })
                .ToList();
            return models;
        }
    }
}
