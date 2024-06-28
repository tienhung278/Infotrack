using System.Text.RegularExpressions;
using System.Web;
using Infotrack.Application.Data;
using Infotrack.Application.Exceptions;
using Infotrack.Domain.Models;
using MediatR;

namespace Infotrack.Application.Queries.GetRanking;

public class GetRankingHandler(IApplicationDbContext dbContext) : IRequestHandler<GetRankingQuery, GetRankingQueryResult>
{
    public async Task<GetRankingQueryResult> Handle(GetRankingQuery request, CancellationToken cancellationToken)
    {
        var searchEngine = dbContext.SearchEngines.Find(request.SearchEngineId);

        if (searchEngine == null)
        {
            throw new SearchEngineNotFoundException(request.SearchEngineId);
        }
        
        using HttpClient httpClient = new HttpClient();
        var keySearch = request.Keywords.Replace(" ", "+");
        var baseUrl = searchEngine.BaseUrl;
        var searchUrl = baseUrl + keySearch;

        string response = HttpUtility.HtmlDecode(await httpClient.GetStringAsync(searchUrl, cancellationToken));
        var links = ExtractResponse(searchEngine, response);
        var rankingList = links.Where(link => link.Contains(request.WebsiteUrl, StringComparison.OrdinalIgnoreCase))
            .Select(link => links.IndexOf(link) + 1)
            .Distinct()
            .ToList();

        return new GetRankingQueryResult(rankingList);
    }
    
    private List<string> ExtractResponse(SearchEngine searchEngine,string response)
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