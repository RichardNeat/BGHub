using BGHub.BE.Controllers;
using BGHub.BE.Services;
using BGHub.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BGHub.BE.Tests.Users.Controllers
{
    public class Tests
    {
        private UsersController _usersController;
        private Mock<IUserService> _userService;
        private List<User> _testUsers;

        [SetUp]
        public void Setup()
        {
            _userService = new Mock<IUserService>();
            _usersController = new UsersController(_userService.Object);
            _testUsers = new List<User>
            {
                new User { Id = 1, Name = "John Doe" },
                new User { Id = 2, Name = "Jane Smith" }
            };
        }

        [Test]
        public void GetAllUsers_Returns_200_With_List_Of_Users()
        {
            _userService.Setup(x => x.FindAllUsers()).Returns(_testUsers);

            var result = _usersController.GetAllUsers();

            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.That(okResult?.Value, Is.EqualTo(_testUsers));
        }
        [Test]
        public void GetUserById_Returns_200_With_User()
        {
            var userId = 1;
            var user = _testUsers.FirstOrDefault(u => u.Id == userId);
            _userService.Setup(x => x.FindUserById(userId)).Returns(user);

            var result = _usersController.GetUserById(userId);

            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.That(okResult?.Value, Is.EqualTo(user));
        }
        [Test]
        public void GetUserById_Returns_404_When_User_Not_Found()
        {
            var userId = 3;
            _userService.Setup(x => x.FindUserById(userId)).Returns((User?)null);

            var result = _usersController.GetUserById(userId);

            Assert.IsInstanceOf<NotFoundObjectResult>(result);
            var notFoundResult = result as NotFoundObjectResult;
            Assert.That(notFoundResult?.Value, Is.EqualTo("User not found"));
        }
    }
}