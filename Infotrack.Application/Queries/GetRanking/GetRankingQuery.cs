using MediatR;

namespace Infotrack.Application.Queries.GetRanking;

public record GetRankingQuery(string Keywords, string WebsiteUrl, Guid SearchEngineId) : IRequest<GetRankingQueryResult>;

public record GetRankingQueryResult(List<int> Ranking);