using BGHub.BE.Repositories;
using BGHub.Models;

namespace BGHub.BE.Services
{
    public interface IUserService
    {
        public IEnumerable<User> FindAllUsers();
        public User? FindUserById(int id);
    }
    public class UserService : IUserService
    {
        private readonly IUserRepository _db;
        public UserService(IUserRepository dbContext)
        {
            _db = dbContext;
        }
        public IEnumerable<User> FindAllUsers()
        {
            return _db.FindAllUsers();
        }
        public User? FindUserById(int id)
        {
            return _db.FindUserById(id);
        }
    }
}
