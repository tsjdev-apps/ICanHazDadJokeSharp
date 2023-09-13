using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ICanHazDadJokeSharp
{
    /// <summary>
    ///     A client for fetching a random joke, a specific joke, or searching for jokes in a variety of formats.
    /// </summary>
    public class DadJokeClient : IDadJokeClient
    {
        private const string BaseUrl = "https://icanhazdadjoke.com/";

        private const string RandomJokeUrl = "/";
        private const string JokeUrl = "/j/{0}";
        private const string SearchUrl = "/search?term={0}&page={1}&limit={2}";

        private static HttpClient _httpClient;

        /// <inheritdoc/>
        public string UserAgent { get; private set; }

        /// <summary>
        ///     Initializes a new instance of the DadJokeClient.
        /// </summary>
        public DadJokeClient(string name, string contactDetails)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException();

            if (string.IsNullOrEmpty(contactDetails))
                throw new ArgumentNullException();

            Initialize($"{name} ({contactDetails})");
        }

        /// <inheritdoc/>
        public async Task<DadJoke> GetRandomJokeAsync()
        {
            string response = await _httpClient.GetStringAsync(RandomJokeUrl).ConfigureAwait(false);
            return JsonSerializer.Deserialize<DadJoke>(response);
        }

        /// <inheritdoc/>
        public async Task<DadJoke> GetJokeAsync(string id)
        {
            string response = await _httpClient.GetStringAsync(string.Format(JokeUrl, id)).ConfigureAwait(false);
            return JsonSerializer.Deserialize<DadJoke>(response);
        }

        /// <inheritdoc/>
        public async Task<string> GetJokeAsImageUrlAsync(string id)
        {
            await Task.Yield();
            return $"https://icanhazdadjoke.com/j/{id}.png";
        }

        /// <inheritdoc/>
		public async Task<DadJokeSearchResults> SearchJokesAsync(string term = null, int page = 1, int limit = 20)
        {
            term = string.IsNullOrEmpty(term) ? null : Uri.EscapeUriString(term);

            if (limit < 0)
            {
                limit = 1;
            }
            else if (limit > 30)
            {
                limit = 30;
            }

            string response = await _httpClient.GetStringAsync(string.Format(SearchUrl, term, page, limit)).ConfigureAwait(false);
            return JsonSerializer.Deserialize<DadJokeSearchResults>(response);
        }

        /// <summary>
        ///     Initializes the DadJokeClient with the corresponding User-Agent.
        /// </summary>
        private void Initialize(string userAgent)
        {
            UserAgent = userAgent;

            _httpClient = CreateHttpClient(userAgent);
        }

        /// <summary>
        ///     Creates an instance of an HttpClient by setting the User-Agent and the Accept header.
        /// </summary>
        private HttpClient CreateHttpClient(string userAgent)
        {
            HttpClient httpClient = new HttpClient
            {
                BaseAddress = new Uri(BaseUrl)
            };

            httpClient.DefaultRequestHeaders.UserAgent.TryParseAdd(userAgent);
            httpClient.DefaultRequestHeaders.Accept.TryParseAdd("application/json");

            return httpClient;
        }


    }
}
