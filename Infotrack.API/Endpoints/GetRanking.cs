using Carter;
using Infotrack.Application.Features.Ranking.Queries.GetRanking;
using MediatR;

namespace Infotrack.API.Endpoints;

public record RankingRequest(int NumOfResults, string Keyword, string WebsiteUrl, Guid SearchEngineId);

public record RankingResponse(List<int> Ranking);

public class GetRanking : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/ranking", async (RankingRequest request, ISender sender) =>
            {
                var result =
                    await sender.Send(new GetRankingQuery(request.NumOfResults, request.Keyword, request.WebsiteUrl,
                        request.SearchEngineId));

                var response = new RankingResponse(result.Ranking);

                return Results.Ok(response);
            })
            .WithName("GetRanking")
            .Produces<RankingResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Ranking")
            .WithDescription("Get Ranking");
    }
}