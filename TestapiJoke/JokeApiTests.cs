using Xunit;
using ProjetApi.Data;

namespace ProjetApi.Tests
{
    public class JokeApiTests
    {
        [Fact]
        public async Task GetJoke_ReturnsJoke_WhenApiResponseIsSuccessful()
        {
            // Arrange
            // Cr�e une instance de votre classe JokeApi.
            var api = new JokeApi();

            // Act
            // Appele la m�thode GetJoke pour r�cup�rer une blague
            await api.GetJoke();

            // Assert
            // V�rifie si la blague actuelle a �t� correctement r�cup�r�e.
            Assert.NotNull(api.CurrentJoke);
        }

        [Fact]
        public void AddFav_AddsCurrentJokeToFavsList_AndSetsCurrentJokeToNull()
        {
            // Arrange
            // Cr�e une instance de votre classe JokeApi.
            var api = new JokeApi();
            // Cr�ez une blague factice.
            var joke = new Joke { Setup = "Test Setup", Delivery = "Test Delivery" };
            // Attribue la blague factice � CurrentJoke
            api.CurrentJoke = joke;

            // Act
            // Appele la m�thode AddFav.
            api.AddFav();

            // Assert
            // V�rifie si la blague actuelle a �t� ajout�e aux favoris.
            Assert.Single(api.Favs);
            // V�rifie si la blague ajout�e aux favoris est la m�me que la blague factice.
            Assert.Equal(joke, api.Favs[0]);
            // V�rifie si CurrentJoke a �t� r�initialis� � null.
            Assert.Null(api.CurrentJoke);
        }
    }
}
