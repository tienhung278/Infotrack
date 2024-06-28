using Infotrack.Domain.Models;

namespace Infotrack.Application.Exceptions;

public class SearchEngineNotFoundException(Guid id) : Exception($"Entity {nameof(SearchEngine)} ({id}) was not found.");