using BGHub.Models;
using Microsoft.EntityFrameworkCore;

namespace BGHub.BE.Repositories
{
    public interface IUserRepository
    {
        public IEnumerable<User> FindAllUsers();
        public User? FindUserById(int id);
    }
    public class UserRepository : IUserRepository
    {
        private readonly BGHubDbContext _db;
        public UserRepository(BGHubDbContext dbContext)
        {
            _db = dbContext;
        }
        public IEnumerable<User> FindAllUsers()
        {
            return _db.Users;
        }
        public User? FindUserById(int id)
        {
            var user = _db.Users
                .Where(u => u.Id == id)
                .Select(u => new User
                {
                    Id = u.Id,
                    Name = u.Name,
                    BGGUsername = u.BGGUsername,
                    Games = u.Games.Select(g => new Game
                    {
                        Id = g.Id,
                        Name = g.Name,
                        ImageUrl = g.ImageUrl,
                        BGGId = g.BGGId,
                    }).ToList()
                })
                .FirstOrDefault();
            return user;
        }
    }
}
