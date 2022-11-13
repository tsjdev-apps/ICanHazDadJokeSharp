using ICanHazDadJokeSharp;

namespace ICanHazDadJokeSampleApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void GetRandomJokeButtonOnClicked(object sender, EventArgs e)
        {
            var client = new DadJokeClient("ICanHazDadJokeSampleApp", "https://github.com/tsjdev-apps/ICanHazDadJokeSharp");
            var joke = await client.GetRandomJokeAsync();

            await DisplayAlert($"Joke: {joke?.Id}", joke?.Joke, "OK");
        }

        private async void GetSpecificJokeButtonOnClicked(object sender, EventArgs e)
        {
            var client = new DadJokeClient("ICanHazDadJokeSampleApp", "https://github.com/tsjdev-apps/ICanHazDadJokeSharp");
            var joke = await client.GetJokeAsync(JokeIdEntry.Text);

            await DisplayAlert($"Joke: {joke?.Id}", joke?.Joke, "OK");
        }

        private async void SearchForAJokeButtonOnClicked(object sender, EventArgs e)
        {
            var client = new DadJokeClient("ICanHazDadJokeSampleApp", "https://github.com/tsjdev-apps/ICanHazDadJokeSharp");
            var searchResults = await client.SearchJokesAsync(SearchTermEntry.Text);

            var firstJoke = searchResults.Jokes.FirstOrDefault(); ;

            if (firstJoke is not null)
            {
                await DisplayAlert($"First Joke: {firstJoke.Id}", firstJoke.Joke, "OK");
            }
            else
            {
                await DisplayAlert($"Hint", $"There is no joke for the search term: '{SearchTermEntry.Text}' available.", "OK");
            }            
        }
    }
}