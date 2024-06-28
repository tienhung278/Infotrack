using Infotrack.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infotrack.Application.Data;

public interface IApplicationDbContext
{
    DbSet<SearchEngine> SearchEngines { get; }
}