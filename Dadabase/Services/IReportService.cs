namespace Dadabase.Services;

public interface IReportService<T>
{
    Task<IEnumerable<Joke>> GetJokesByTag(int categoryId);
    Task<IEnumerable<Joke>> GetJokesToldToAudience(int audienceId);
    Task<IEnumerable<Joke>> GetRankedJokesByScore();
    Task<IEnumerable<Joke>> GetRankedJokesByScoreForTag(int jokeCategoryId);
    Task<IEnumerable<Joke>> GetRankedJokesByScoreForAudience(int audienceId);
}
