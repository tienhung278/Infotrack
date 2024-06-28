using Infotrack.Domain.Exceptions;

namespace Infotrack.Domain.ValueObjects;

public class SearchEngineId
{
    public Guid Value { get; }
    
    private SearchEngineId(Guid value) => Value = value;
    
    public static SearchEngineId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        
        if (value == Guid.Empty)
        {
            throw new DomainException($"{nameof(SearchEngineId)} cannot be empty.");
        }

        return new SearchEngineId(value);
    }
}