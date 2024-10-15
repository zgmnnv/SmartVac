using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using SmartVac.Api.Models;

namespace SmartVac.Api.Db;

public class ServiceDbContext : DbContext{
    public ServiceDbContext(DbContextOptions<ServiceDbContext> options) : base(options) { 

    }
    public DbSet<User> Users { get; set; }
    public DbSet<Child> Children { get; set; }
    public DbSet<Manipulation> Manipulations { get; set; }
    public DbSet<Vaccine> Vaccines { get; set; }
}