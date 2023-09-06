using Application.Contracts;
using AutoMapper;
using Domain.Entites;
using Persistence.Data;

namespace Infrastructure.Persistence.Repositories.UserRepo;

public class UserRepository : IUserRepository
{
    private readonly ApiDbContext _context;
    private readonly IMapper _mapper;

    public UserRepository(ApiDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Task<bool> Exists(Guid id)
    {
        return Task.FromResult(_context.Users.Find(id) != null);
    }

    public Task<User> GetUserByIdentifier(string identifier)
    {
        var user = _context.Users.FirstOrDefault(x => x.Email == identifier || x.UserName == identifier);
        return Task.FromResult(user);
    }

    public Task<User> GetUserById(int id)
    {
        var user = _context.Users.Find(id);
        return Task.FromResult(user);
    }

    public Task<User> GetUserByEmail(string email)
    {
        var user = _context.Users.FirstOrDefault(x => x.Email == email);
        return Task.FromResult(user);
    }

    public Task<User> GetUserByUserName(string userName)
    {
        var user = _context.Users.FirstOrDefault(x => x.UserName == userName);
        return Task.FromResult(user);
    }

    public Task<User> AddUser(User user)
    {
        _context.Users.Add(user);
        if (_context.SaveChanges() <= 0)
        {
            return Task.FromResult<User>(null);
        }
        return Task.FromResult(user);
    }

    public Task<User> UpdateUser(User user)
    {
        _context.Users.Update(user);
        if (_context.SaveChanges() <= 0)
        {
            return Task.FromResult<User>(null);
        }
        return Task.FromResult(user);
    }

    public Task<List<User>> GetAllUsers()
    {
        return Task.FromResult(_context.Users.ToList());
    }

    public Task<User> DeleteUser(User user)
    {
        _context.Users.Remove(user);
        if (_context.SaveChanges() <= 0)
        {
            return Task.FromResult<User>(null);
        }
        return Task.FromResult(user);
    }
}