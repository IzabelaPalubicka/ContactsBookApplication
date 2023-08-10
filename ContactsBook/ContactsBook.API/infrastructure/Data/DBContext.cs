using ContactsBook.API.domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ContactsBook.API.infrastructure.Data;

/// <summary>
/// Database context.
/// </summary>
public class DBContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DBContext"/> class.
    /// </summary>
    /// <param name="options">DbContext options.</param>
    public DBContext(DbContextOptions<DBContext> options) : base(options) { }

    /// <summary>
    /// Contacts DbSet.
    /// </summary>
    public DbSet<Contact> Contacts { get; set; }

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
