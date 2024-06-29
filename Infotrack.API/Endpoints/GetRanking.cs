using Carter;
using Infotrack.Application.Dtos;
using Infotrack.Application.Queries.GetRanking;
using MediatR;

namespace Infotrack.API.Endpoints;

public record GetRankingRequest(RankingDto Ranking);

public record GetRankingResponse(List<int> Ranking);

public class GetRanking : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/ranking", async (GetRankingRequest request, ISender sender) =>
            {
                var result =
                    await sender.Send(new GetRankingQuery(request.Ranking.Keyword, request.Ranking.WebsiteUrl,
                        request.Ranking.SearchEngineId));

            var response = new GetRankingResponse(result.Ranking);

            return Results.Ok(response);
        })
        .WithName("GetRanking")
        .Produces<GetRankingResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Ranking")
        .WithDescription("Get Ranking");
    }
}