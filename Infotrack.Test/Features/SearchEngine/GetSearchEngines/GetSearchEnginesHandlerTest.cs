using Infotrack.Application.Data;
using Infotrack.Application.Features.SearchEngine.Queries.GetSearchEngines;
using Infotrack.Domain.ValueObjects;
using Moq;

namespace Infotrack.Test.Features.SearchEngine.GetSearchEngines;

public class GetSearchEnginesHandlerTest
{
    [Fact]
    public async void Get_Search_Engines_Return_Get_Search_Engines_Result()
    {
        //Arange
        var id = Guid.NewGuid();
        var searchEngines = new List<Domain.Models.SearchEngine>
        {
            Domain.Models.SearchEngine.Create(SearchEngineId.Of(id), "Google", "www.infotract.co.uk",
                "test")
        };
        var dbContext =
            DbContextMock.GetMock<Domain.Models.SearchEngine, IApplicationDbContext>(searchEngines,
                c => c.SearchEngines);
        var handler = new GetSearchEngineHandler(dbContext);
        
        //Act
        var result = await handler.Handle(It.IsAny<GetSearchEngineQuery>(), It.IsAny<CancellationToken>());
        
        //Assert
        Assert.Equal(id, result.SearchEngines.First().Id);
    }
}