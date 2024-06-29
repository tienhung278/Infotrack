using Infotrack.Domain.Models;
using Infotrack.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infotrack.Infrastructure.Data.Configurations;

public class SearchEngineConfiguration: IEntityTypeConfiguration<SearchEngine>
{
    public void Configure(EntityTypeBuilder<SearchEngine> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).HasConversion(
            searchEngineId => searchEngineId.Value,
            dbId => SearchEngineId.Of(dbId));
    }
}