using BGHub.BE.Repositories;
using BGHub.BE.Services;
using BGHub.Models;
using Moq;

namespace BGHub.BE.Tests.Users.Services
{
    public class Tests
    {
        private IUserService _userService;
        private Mock<IUserRepository> _userRepository;
        private List<User> _users;

        [SetUp]
        public void Setup()
        {
            _userRepository = new Mock<IUserRepository>();
            _userService = new UserService(_userRepository.Object);
            _users = new List<User>
            {
                new User { Id = 1, Name = "John Doe" },
                new User { Id = 2, Name = "Jane Smith" }
            };
        }

        [Test]
        public void FindAllUsers_ReturnsAllUsers()
        {
            _userRepository.Setup(repo => repo.FindAllUsers()).Returns(_users);

            var result = _userService.FindAllUsers();

            Assert.That(result, Is.EquivalentTo(_users));
        }
        [Test]
        public void FindUserById_ValidId_ReturnsUser()
        {
            var user = _users[0];
            _userRepository.Setup(repo => repo.FindUserById(user.Id)).Returns(user);

            var result = _userService.FindUserById(user.Id);

            Assert.That(result, Is.EqualTo(user));
        }
        [Test]
        public void FindUserById_InvalidId_ReturnsNull()
        {
            _userRepository.Setup(repo => repo.FindUserById(It.IsAny<int>())).Returns((User?)null);
            var result = _userService.FindUserById(999);
            Assert.That(result, Is.Null);
        }
    }
}