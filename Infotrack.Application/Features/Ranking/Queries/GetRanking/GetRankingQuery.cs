using MediatR;

namespace Infotrack.Application.Features.Ranking.Queries.GetRanking;

public record GetRankingQuery(int NumOfResults, string Keywords, string WebsiteUrl, Guid SearchEngineId)
    : IRequest<GetRankingQueryResult>;

public record GetRankingQueryResult(List<int> Ranking);