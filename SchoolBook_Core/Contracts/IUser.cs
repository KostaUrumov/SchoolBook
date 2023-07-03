using SchoolBook_Core.Models.UserModels;

namespace SchoolBook_Core.Contracts
{
    public interface IUser
    {
        public Task AddUser(RegisterUserModel model);
    }
}
