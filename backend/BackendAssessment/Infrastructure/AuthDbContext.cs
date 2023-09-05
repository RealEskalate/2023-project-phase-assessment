using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

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