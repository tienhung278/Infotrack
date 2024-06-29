using Infotrack.Application.Data;
using Infotrack.Application.Features.SearchEngine.Extensions;
using MediatR;

namespace Infotrack.Application.Features.SearchEngine.Queries.GetSearchEngines;

public class GetSearchEngineHandler(IApplicationDbContext dbContext) : IRequestHandler<GetSearchEngineQuery, GetSearchEngineResult>
{
    public Task<GetSearchEngineResult> Handle(GetSearchEngineQuery request, CancellationToken cancellationToken)
    {
        var searchEngines = dbContext.SearchEngines.ToArray();
        
        return Task.FromResult(new GetSearchEngineResult(searchEngines.ToSearchEngineDtoList()));
    }
}