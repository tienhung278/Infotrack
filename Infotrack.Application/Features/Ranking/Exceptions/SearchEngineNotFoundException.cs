using Infotrack.Domain.Models;

namespace Infotrack.Application.Features.Ranking.Exceptions;

public class SearchEngineNotFoundException(Guid id) : Exception($"Entity {nameof(SearchEngine)} ({id}) was not found.");