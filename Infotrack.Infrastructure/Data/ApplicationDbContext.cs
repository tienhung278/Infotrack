using System.Reflection;
using Infotrack.Application.Data;
using Infotrack.Domain.Models;
using Infotrack.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Infotrack.Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : DbContext(options), IApplicationDbContext
{
    public DbSet<SearchEngine> SearchEngines => Set<SearchEngine>();
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        builder.Entity<SearchEngine>().HasData(SearchEngine.Create(SearchEngineId.Of(Guid.NewGuid()), "Google",
            "https://www.google.co.uk/search", "/url?q=(.*?)&sa=U&ved="));
        
        base.OnModelCreating(builder);
    }
}