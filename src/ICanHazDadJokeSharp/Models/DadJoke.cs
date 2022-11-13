using System.Text.Json.Serialization;

namespace ICanHazDadJokeSharp
{
    /// <summary>
    ///     Representation of a dad joke.
    /// </summary>
    public class DadJoke
    {
        /// <summary>
        ///     Gets or Sets the ID of the joke.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        ///     Gets or Sets the joke content.
        /// </summary>
        [JsonPropertyName("joke")]
        public string Joke { get; set; }

        /// <summary>
        ///     Gets or Sets the status of the reponse.
        /// </summary>
        [JsonPropertyName("status")]
        public int Status { get; set; }
    }
}
