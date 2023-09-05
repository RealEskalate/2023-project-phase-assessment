using System;
using System.Collections.Generic;
using System.Linq;
using Backend.Application.Persistence.Contracts;
using Backend.Domain.Entities;
using Backend.Infrastructure.Data;

namespace Backend.Infrastructure.Persistence.Repositories.UserRepo;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = new();
    private readonly ApiDbContext _context;

    public UserRepository(ApiDbContext context)
    {
        _context = context;
    }

    public void AddUser(User user)
    {
        _users.Add(user);
    }

    public User? GetUserByIdentifier(string identifier)
    {
        Console.WriteLine(identifier);
        return _users.FirstOrDefault(u => u.Email == identifier || u.UserName == identifier);
    }

    public User? GetUserByEmail(string email)
    {
        return _users.FirstOrDefault(u => u.Email == email);
    }

    public User? GetUserById(Guid id)
    {
        return _users.FirstOrDefault(u => u.Id == id);
    }

    public User? GetUserByUserName(string userName)
    {
        return _users.FirstOrDefault(u => u.UserName == userName);
    }

    public User EditUser(User user)
    {
        var userToEdit = _users.FirstOrDefault(u => u.Id == user.Id);
        if (userToEdit == null)
            throw new Exception("User not found");
        userToEdit.FirstName = user.FirstName;
        userToEdit.LastName = user.LastName;
        userToEdit.Email = user.Email;
        userToEdit.UserName = user.UserName;
        userToEdit.Bio = user.Bio;
        userToEdit.Picture = user.Picture;
        userToEdit.Password = user.Password;
        
        return userToEdit;
    }

    public List<User> GetAllUsers()
    {
        return _users.ToList();
    }

    public async Task<bool> Exists(Guid id)
    {
        return _users.Any(u => u.Id == id);
    }

    public async Task<bool> SetRole(Guid id, string role)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
        if (user == null)
            return false;
        user.Role = role;
        return true;
    }
}