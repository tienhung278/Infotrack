using Infotrack.Application.Features.SearchEngine.Dtos;
using MediatR;

namespace Infotrack.Application.Features.SearchEngine.Queries.GetSearchEngines;

public record GetSearchEngineQuery() : IRequest<GetSearchEngineResult>;

public record GetSearchEngineResult(IEnumerable<SearchEngineDto> SearchEngines);