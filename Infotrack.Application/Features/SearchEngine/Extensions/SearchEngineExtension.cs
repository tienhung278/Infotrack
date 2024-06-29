using Infotrack.Application.Features.SearchEngine.Dtos;

namespace Infotrack.Application.Features.SearchEngine.Extensions;

public static class SearchEngineExtension
{
    public static IEnumerable<SearchEngineDto> ToSearchEngineDtoList(this IEnumerable<Domain.Models.SearchEngine> searchEngines)
    {
        return searchEngines.Select(s => new SearchEngineDto(s.Id.Value, s.Name)).ToArray();
    }
}