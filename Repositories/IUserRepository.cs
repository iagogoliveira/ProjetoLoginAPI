using LoginApiProject.Models;

namespace LoginApiProject.Repositories
{
    public interface IUserRepository
    {
        void Add(User user);

        Task<User> getLoginAsync(string login);
    }
}
