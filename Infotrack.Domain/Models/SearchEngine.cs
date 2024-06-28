using Infotrack.Domain.Abstractions;
using Infotrack.Domain.ValueObjects;

namespace Infotrack.Domain.Models;

public class SearchEngine : Entity<SearchEngineId>
{
    public string Name { get; private set; } = default!;
    public string BaseUrl { get; private set; } = default!;
    public string RegEx { get; private set; } = default!;

    public static SearchEngine Create(SearchEngineId id, string name, string baseUrl, string regEx)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(baseUrl);
        ArgumentException.ThrowIfNullOrWhiteSpace(regEx);

        return new SearchEngine
        {
            Id = id,
            Name = name,
            BaseUrl = baseUrl,
            RegEx = regEx
        };
    }
}