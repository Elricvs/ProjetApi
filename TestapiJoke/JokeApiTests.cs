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
            // Crée une instance de votre classe JokeApi.
            var api = new JokeApi();

            // Act
            // Appele la méthode GetJoke pour récupérer une blague
            await api.GetJoke();

            // Assert
            // Vérifie si la blague actuelle a été correctement récupérée.
            Assert.NotNull(api.CurrentJoke);
        }

        [Fact]
        public void AddFav_AddsCurrentJokeToFavsList_AndSetsCurrentJokeToNull()
        {
            // Arrange
            // Crée une instance de votre classe JokeApi.
            var api = new JokeApi();
            // Créez une blague factice.
            var joke = new Joke { Setup = "Test Setup", Delivery = "Test Delivery" };
            // Attribue la blague factice à CurrentJoke
            api.CurrentJoke = joke;

            // Act
            // Appele la méthode AddFav.
            api.AddFav();

            // Assert
            // Vérifie si la blague actuelle a été ajoutée aux favoris.
            Assert.Single(api.Favs);
            // Vérifie si la blague ajoutée aux favoris est la même que la blague factice.
            Assert.Equal(joke, api.Favs[0]);
            // Vérifie si CurrentJoke a été réinitialisé à null.
            Assert.Null(api.CurrentJoke);
        }
    }
}
