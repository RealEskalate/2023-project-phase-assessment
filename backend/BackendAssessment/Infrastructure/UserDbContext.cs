using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistence.Model;

namespace Persistence;

public class UserDbContext : IdentityDbContext<ApplicaionUser> 
{ 
    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) 
    { 
         
    } 
 
    protected override void OnModelCreating(ModelBuilder builder){
        base.OnModelCreating(builder);
        
    } 
 
 
}