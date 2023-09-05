using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistence.Model;

namespace Persistence;

public class AuthIdentityDbContext : IdentityDbContext<ApplicaionUser> 
{ 
    public AuthIdentityDbContext(DbContextOptions<AuthIdentityDbContext> options) : base(options) 
    { 
         
    } 
 
    protected override void OnModelCreating(ModelBuilder builder){
        base.OnModelCreating(builder);
        
    } 
 
 
}