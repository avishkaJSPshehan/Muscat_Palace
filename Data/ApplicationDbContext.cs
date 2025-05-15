using System;
using Microsoft.EntityFrameworkCore;
using Muscat_Palace.Models;

namespace Muscat_Palace.Data;

public class ApplicationDbContext: DbContext 
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

        public DbSet<User> Users { get; set; }
}




