using System;

using EF_Example.Models;

using Microsoft.EntityFrameworkCore;

namespace EF_Example;

public sealed class DataBaseContext : DbContext
{
    private readonly string _pathToDb;
    
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }

    public DataBaseContext(string pathToDb) : base()
    {
        if (string.IsNullOrEmpty(pathToDb)) 
            throw new ArgumentNullException(nameof(pathToDb));
        
        _pathToDb = pathToDb;
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={_pathToDb}");
    }
}