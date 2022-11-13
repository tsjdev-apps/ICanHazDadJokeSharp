namespace ICanHazDadJokeSharp.Tests
{
    public class DadJokeClientTests
    {
        public const string Name = "ICanHazDadJokeSharp";
        public const string ContactDetails = "https://github.com/tsjdev-apps/ICanHazDadJokeSharp";

        public const string TestJokeId = "lyPZgVn3Le";
        public const string TestJokeJoke = "What did the ocean say to the shore? Nothing, it just waved.";


        [Test]
        public async Task GetRandomJokeAsyncTest()
        {
            // arrange
            var client = new DadJokeClient(Name, ContactDetails);

            // act
            var joke = await client.GetRandomJokeAsync();

            // assert            
            Assert.Multiple(() =>
            {
                Assert.That(joke, Is.Not.Null);
                Assert.That(joke.Id, Is.Not.Null);
                Assert.That(joke.Joke, Is.Not.Null);
                Assert.That(joke.Status, Is.EqualTo(200));
            });
        }

        [Test]
        public async Task GetJokeAsyncTest()
        {
            // arrange
            var client = new DadJokeClient(Name, ContactDetails);

            // act
            var joke = await client.GetJokeAsync(TestJokeId);

            // assert
            Assert.Multiple(() =>
            {
                Assert.That(joke, Is.Not.Null);
                Assert.That(joke.Id, Is.EqualTo(TestJokeId));
                Assert.That(joke.Joke, Is.EqualTo(TestJokeJoke));
                Assert.That(joke.Status, Is.EqualTo(200));
            });
        }

        [Test]
        public async Task SearchJokesAsyncTest()
        {
            // arrange
            var client = new DadJokeClient(Name, ContactDetails);

            // act
            var results = await client.SearchJokesAsync(TestJokeJoke);

            // assert
            Assert.Multiple(() =>
            {
                Assert.That(results, Is.Not.Null);
                Assert.That(results.CurrentPage, Is.EqualTo(1));
                Assert.That(results.Limit, Is.EqualTo(20));
                Assert.That(results.NextPage, Is.EqualTo(2));
                Assert.That(results.PreviousPage, Is.EqualTo(1));
                Assert.That(results.Jokes, Is.Not.Null);
                Assert.That(results.Jokes.Count, Is.GreaterThan(0));
                Assert.That(results.Jokes.First().Id, Is.EqualTo(TestJokeId));
                Assert.That(results.Jokes.First().Joke, Is.EqualTo(TestJokeJoke));
                Assert.That(results.SearchTerm, Is.EqualTo(TestJokeJoke));
                Assert.That(results.TotalJokes, Is.GreaterThan(0));
                Assert.That(results.TotalPages, Is.GreaterThan(0));
            });
        }

        [Test]
        public async Task SearchJokesAsyncWithNullTest()
        {
            // arrange
            var client = new DadJokeClient(Name, ContactDetails);

            // act
            var results = await client.SearchJokesAsync();

            // assert
            Assert.Multiple(() =>
            {
                Assert.That(results, Is.Not.Null);
                Assert.That(results.CurrentPage, Is.EqualTo(1));
                Assert.That(results.Limit, Is.EqualTo(20));
                Assert.That(results.NextPage, Is.EqualTo(2));
                Assert.That(results.PreviousPage, Is.EqualTo(1));
                Assert.That(results.Jokes, Is.Not.Null);
                Assert.That(results.TotalJokes, Is.GreaterThan(0));
                Assert.That(results.TotalPages, Is.GreaterThan(0));
            });
        }
    }
}