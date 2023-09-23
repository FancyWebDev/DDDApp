using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database;

public class DataContext : DbContext
{
    private DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder
            .Entity<Customer>()
            .HasKey(entity => entity.Identity);

        builder.Entity<Customer>().Property(entity => entity.Email);
        builder.Entity<Customer>().Property(entity => entity.Name);
        
        builder.Entity<Customer>(entity =>
        {
            entity.Property(e => e.Email)
                .HasConversion(new EmailConverter());
        });
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured) 
            optionsBuilder.UseSqlServer("Data Source=LITTLE-MONSTER;Initial Catalog=DDDApp;Integrated Security=True;Encrypt=False");
    }

    public async ValueTask<IEnumerable<Customer>> GetCustomers() => await Customers.ToListAsync();
   
    public async ValueTask Save() => await SaveChangesAsync();
}