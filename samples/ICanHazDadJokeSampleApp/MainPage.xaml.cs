using ICanHazDadJokeSharp;

namespace ICanHazDadJokeSampleApp
{
    public partial class MainPage : ContentPage
    {
        private readonly DadJokeClient _client = 
            new("ICanHazDadJokeSampleApp", "https://github.com/tsjdev-apps/ICanHazDadJokeSharp");

        public MainPage()
        {
            InitializeComponent();
        }

        private async void GetRandomJokeButtonOnClicked(object sender, EventArgs e)
        {
            DadJoke joke = await _client.GetRandomJokeAsync();

            await DisplayAlert($"Joke: {joke?.Id}", joke?.Joke, "OK");
        }

        private async void GetSpecificJokeButtonOnClicked(object sender, EventArgs e)
        {
            DadJoke joke = await _client.GetJokeAsync(JokeIdEntry.Text);

            await DisplayAlert($"Joke: {joke?.Id}", joke?.Joke, "OK");
        }

        private async void SearchForAJokeButtonOnClicked(object sender, EventArgs e)
        {
            DadJokeSearchResults searchResults = await _client.SearchJokesAsync(SearchTermEntry.Text);

            DadJoke firstJoke = searchResults.Jokes.FirstOrDefault(); ;

            if (firstJoke is not null)
            {
                await DisplayAlert($"First Joke: {firstJoke.Id}", firstJoke.Joke, "OK");
            }
            else
            {
                await DisplayAlert($"Hint", $"There is no joke for the search term: '{SearchTermEntry.Text}' available.", "OK");
            }            
        }

        private async void GetImageJokeButtonOnClicked(object sender, EventArgs e)
        {
            string jokeImage = await _client.GetJokeAsImageUrlAsync(ImageJokeIdEntry.Text);

            JokeImage.Source = jokeImage;
        }
    }
}