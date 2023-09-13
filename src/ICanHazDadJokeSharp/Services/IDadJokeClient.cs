using System.Threading.Tasks;

namespace ICanHazDadJokeSharp
{
    /// <summary>
    ///     Client for fetching a random joke, a specific joke, or searching for jokes on ICanHazDadJoke.com.
    /// </summary>
    public interface IDadJokeClient
    {
        /// <summary>
        ///     Gets the current User-Agent string.
        /// </summary>
        string UserAgent { get; }

        /// <summary>
        ///     Gets a specific joke from the API by passing the joke id.
        /// </summary>
        Task<DadJoke> GetJokeAsync(string id);

        /// <summary>
        ///     Gets a random joke from the API.
        /// </summary>
        Task<DadJoke> GetRandomJokeAsync();

        /// <summary>
        ///     Get a specific joke from the API by passing the joke id as an image.
        /// </summary>
        Task<string> GetJokeAsImageUrlAsync(string id);

        /// <summary>
        ///     Searches for jokes.
        /// </summary>
        Task<DadJokeSearchResults> SearchJokesAsync(string term = null, int page = 1, int limit = 20);
    }
}