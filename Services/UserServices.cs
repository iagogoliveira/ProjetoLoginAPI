using LoginApiProject.Models;
using LoginApiProject.Repositories;

namespace LoginApiProject.Services
{
    public class UserServices
    {
        private readonly IUserRepository _userRepository;

        public UserServices(IUserRepository usuarioRepository)
        {
            _userRepository = usuarioRepository;
        }

        public void CreateUser(User user)
        {
            user.Password = PasswordCriptografyService.GeneratePasswordHash(user.Password);
            user.Id = Guid.NewGuid();

            _userRepository.Add(user);
        }

        public async Task<User?> AuthenticateUserAsync(string userLogin, string userPassword)
        {
            var user = await _userRepository.getLoginAsync(userLogin);

            if (user != null && PasswordCriptografyService.ValidPassword(userPassword, user.Password))
            {
                return user;
            }

            return null;
        }

        public User GetUser(string login)
        {
            return _userRepository.getLoginAsync(login).Result;
        }

    }
}
