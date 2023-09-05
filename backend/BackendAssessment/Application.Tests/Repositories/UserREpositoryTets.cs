using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts;
using Application.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace Application.Test.Repositories
{
    public class UserRepositoryTests
    {
        [Fact]
        public async Task GetUserAsync_Returns_User_When_Exists()
        {
            // Arrange
            var userId = 1;
            var users = new List<User>
            {
                new User
                {
                    UserId = 1,
                    Username = "User 1",
                    Email = "user1@example.com",
                    Password = "password1",
                    Products = new List<Product>()
                },
                new User
                {
                    UserId = 2,
                    Username = "User 2",
                    Email = "user2@example.com",
                    Password = "password2",
                    Products = new List<Product>()
                }
            }.AsQueryable();

            var mockContext = new Mock<ProductHubDbContext>();
            mockContext.Setup(c => c.Users).ReturnsDbSet(users);

            var userRepository = new UserRepository(mockContext.Object);

            // Act
            var user = await userRepository.GetUserAsync(userId);

            // Assert
            Assert.NotNull(user);
            Assert.Equal(userId, user.UserId);
            Assert.Equal("User 1", user.Username);
            Assert.Equal("user1@example.com", user.Email);
            Assert.Equal("password1", user.Password);
            Assert.NotNull(user.Products);
        }


    }
}
