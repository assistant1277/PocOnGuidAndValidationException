using GuidExample.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace GuidExample.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}