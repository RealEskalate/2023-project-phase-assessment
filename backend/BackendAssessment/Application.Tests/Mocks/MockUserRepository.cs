using Application.Contracts.Persistence;
using Domain.Entities;
using Infrastructure.PasswordService;
using Moq;

namespace Application.Tests.Mocks;

public class MockUserRepository
{
    public static Mock<IUserRepository> GetMockUserRepository()
    {
        var _passwordHasher = new PasswordHasher();
        var users = new List<User>
        {
            new User
            {
                Email = "User1@gmail.com",
                Username = "User1",
                Password = _passwordHasher.HashPassword("User1password"),
                Id = 1
            },
        };

        var userRepository = new Mock<IUserRepository>();

        userRepository
            .Setup(repo => repo.GetAsync(It.IsAny<int>()))
            .ReturnsAsync((int id) => users.FirstOrDefault(u => u.Id == id));

        userRepository.Setup(repo => repo.GetAsync()).ReturnsAsync(users);

        userRepository
            .Setup(repo => repo.AddAsync(It.IsAny<User>()))
            // Add the user to the list and return the user with the new Id
            .ReturnsAsync(
                (User user) =>
                {
                    user.Id = users.Count + 1;
                    users.Add(user);
                    return user;
                }
            );

        userRepository
            .Setup(repo => repo.UpdateAsync(It.IsAny<int>(), It.IsAny<User>()))
            .Callback(
                (int id, User user) =>
                {
                    var index = users.FindIndex(u => u.Id == user.Id);
                    if (index >= 0)
                    {
                        users[index] = user;
                    }
                }
            );

        userRepository
            .Setup(repo => repo.DeleteAsync(It.IsAny<int>()))
            .Callback(
                (int id) =>
                {
                    var index = users.FindIndex(u => u.Id == id);
                    if (index >= 0)
                    {
                        users.RemoveAt(index);
                    }
                }
            );

        userRepository
            .Setup(repo => repo.UsernameExists(It.IsAny<string>()))
            .ReturnsAsync((string username) => users.Any(u => u.Username == username));

        userRepository
            .Setup(repo => repo.EmailExists(It.IsAny<string>()))
            .ReturnsAsync((string email) => users.Any(u => u.Email == email));

        userRepository
            .Setup(repo => repo.GetByUsername(It.IsAny<string>()))
            .ReturnsAsync((string username) => users.FirstOrDefault(u => u.Username == username)!);

        return userRepository;
    }
}
