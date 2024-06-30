using System.Net;
using Infotrack.Application.Data;
using Infotrack.Application.Features.Ranking.Exceptions;
using Infotrack.Application.Features.Ranking.Queries.GetRanking;
using Infotrack.Domain.ValueObjects;
using Moq;
using Moq.Protected;

namespace Infotrack.Test.Features.Ranking.GetRanking;

public class GetRankingHandlerTest
{
    [Fact]
    public async void Get_Ranking_Return_Search_Engine_Not_Found_Exception()
    {
        //Arrange
        var id = Guid.NewGuid();
        var searchEngines = new List<Domain.Models.SearchEngine>
        {
            Domain.Models.SearchEngine.Create(SearchEngineId.Of(id), "Google", "www.infotract.co.uk",
                "test")
        };
        var dbContext =
            DbContextMock.GetMock<Domain.Models.SearchEngine, IApplicationDbContext>(searchEngines,
                c => c.SearchEngines);
        var query = new GetRankingQuery(100, "land registry search", "www.infotrack.co.uk", Guid.NewGuid());
        var handler = new GetRankingHandler(dbContext);
        
        //Act & Assert
        await Assert.ThrowsAsync<SearchEngineNotFoundException>(() => handler.Handle(query, It.IsAny<CancellationToken>()));
    }
    
    [Fact]
    public async void Get_Ranking_Return_Get_Ranking_Query_Result()
    {
        //Arrange
        var id = Guid.NewGuid();
        var searchEngines = new List<Domain.Models.SearchEngine>
        {
            Domain.Models.SearchEngine.Create(SearchEngineId.Of(id), "Google", "https://www.google.co.uk/search?num={0}&q={1}",
                "<div\\s+class=\"BNeawe\\s+UPmit\\s+AP7Wnd\\s+lRVwie\">([^<]*)<\\/div>")
        };
        var dbContext =
            DbContextMock.GetMock<Domain.Models.SearchEngine, IApplicationDbContext>(searchEngines,
                c => c.SearchEngines);
        var query = new GetRankingQuery(100, "land registry search", "www.infotrack.co.uk", id);
        var handler = new GetRankingHandler(dbContext);
        
        //Act
        var result = await handler.Handle(query, It.IsAny<CancellationToken>());
        
        //Assert
        Assert.Single(result.Ranking);
    }
}