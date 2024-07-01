using System.Text.RegularExpressions;
using System.Web;
using Infotrack.Application.Data;
using Infotrack.Application.Features.Ranking.Exceptions;
using Infotrack.Domain.Models;
using Infotrack.Domain.ValueObjects;
using MediatR;

namespace Infotrack.Application.Features.Ranking.Queries.GetRanking;

public class GetRankingHandler(IApplicationDbContext dbContext) : IRequestHandler<GetRankingQuery, GetRankingQueryResult>
{
    public async Task<GetRankingQueryResult> Handle(GetRankingQuery request, CancellationToken cancellationToken)
    {
        var searchEngines = dbContext.SearchEngines.ToList();
        var searchEngine = searchEngines.FirstOrDefault(s => s.Id.Value == request.SearchEngineId);

        if (searchEngine == null)
        {
            throw new SearchEngineNotFoundException(request.SearchEngineId);
        }
        
        using HttpClient httpClient = new HttpClient();
        var keySearch = request.Keywords.Replace(" ", "+");
        var baseUrl = searchEngine.BaseUrl;
        var searchUrl = string.Format(baseUrl, request.NumOfResults, keySearch);

        string response = HttpUtility.HtmlDecode(await httpClient.GetStringAsync(searchUrl, cancellationToken));
        var links = ExtractResponse(searchEngine, response);
        var rankingList = links.Where(link => link.Contains(request.WebsiteUrl, StringComparison.OrdinalIgnoreCase))
            .Select(link => links.IndexOf(link) + 1)
            .ToList();

        return new GetRankingQueryResult(rankingList);
    }
    
    private List<string> ExtractResponse(Domain.Models.SearchEngine searchEngine,string response)
    {
        List<string> links = new List<string>();
        string pattern = @$"{searchEngine.RegEx}";
        Regex regex = new Regex(pattern);
        MatchCollection matches = regex.Matches(response);
        foreach (Match match in matches)
        {
            string url = match.Groups[1].Value;
            links.Add(Uri.UnescapeDataString(url));
        }

        return links;
    }
}