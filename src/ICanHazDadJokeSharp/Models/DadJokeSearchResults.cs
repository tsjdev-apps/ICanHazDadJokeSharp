using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ICanHazDadJokeSharp
{
    /// <summary>
    ///     Representation of the search results for dad jokes.
    /// </summary>
    public class DadJokeSearchResults
    {
        /// <summary>
        ///     Gets or Sets the current page number.
        /// </summary>
        [JsonPropertyName("current_page")]
        public int CurrentPage { get; set; }

        /// <summary>
        ///     Gets or Sets a list of jokes.
        /// </summary>
        [JsonPropertyName("results")]
        public List<DadJoke> Jokes { get; set; }

        /// <summary>
        ///     Gets or Sets the limit of the search results.
        /// </summary>
        [JsonPropertyName("limit")]
        public int Limit { get; set; }

        /// <summary>
        ///     Gets or Sets the next page number.
        /// </summary>
        [JsonPropertyName("next_page")]
        public int NextPage { get; set; }

        /// <summary>
        ///     Gets or Sets the previous page number.
        /// </summary>
        [JsonPropertyName("previous_page")]
        public int PreviousPage { get; set; }

        /// <summary>
        ///     Gets or Sets the search term.s
        /// </summary>
        [JsonPropertyName("search_term")]
        public string SearchTerm { get; set; }

        /// <summary>
        ///     Gets or Sets the status of the reponse.
        /// </summary>
        [JsonPropertyName("status")]
        public int Status { get; set; }

        /// <summary>
        ///     Gets or Sets the total number of jokes.
        /// </summary>
        [JsonPropertyName("total_jokes")]
        public int TotalJokes { get; set; }

        /// <summary>
        ///     Gets or Sets the total number of pages.
        /// </summary>
        [JsonPropertyName("total_pages")]
        public int TotalPages { get; set; }
    }
}
