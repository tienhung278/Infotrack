using Carter;
using Infotrack.Application.Features.SearchEngine.Dtos;
using Infotrack.Application.Features.SearchEngine.Queries.GetSearchEngines;
using MediatR;

namespace Infotrack.API.Endpoints;

public record GetSearchEnginesResponse(IEnumerable<SearchEngineDto> SearchEngines);

public class GetSearchEngines : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/searchengines", async (ISender sender) =>
            {
                var result = await sender.Send(new GetSearchEngineQuery());

                var response = new GetSearchEnginesResponse(result.SearchEngines);

                return Results.Ok(response);
            })
            .WithName("GetSearchEngines")
            .Produces<GetSearchEnginesResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Get Search Engines")
            .WithDescription("Get Search Engines");
    }
}