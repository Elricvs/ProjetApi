using Bunit;
using Xunit;
using ProjetApi.Pages;
using System.Threading.Tasks;

namespace TestHomeRazor
{
    public class JokeIntegrationTest
    {
        [Fact]
        public async Task TestIntegration()
        {
            // Arrange
            // Création d'un contexte de test
            var testContext = new TestContext();

            // Configuration du mode JSInterop sur Loose pour ignorer les appels interopérables non configurés
            testContext.JSInterop.Mode = JSRuntimeMode.Loose;

            // Rendu du composant Home dans le contexte de test
            var cut = testContext.RenderComponent<Home>();

            // Act
            // Simulation du clic sur le bouton dans le composant rendu
            cut.Find("button").Click();

            // Attente de 5 secondes pour permettre au composant de se mettre à jour
            await Task.Delay(5000);

            // Rendu du composant après l'attente pour refléter les mises à jour
            cut.Render();

            // Assert
            // Vérification que le nombre de paragraphes est maintenant supérieur à 0
            var paragraphCountAfterClick = cut.FindAll("p").Count;
            Assert.True(paragraphCountAfterClick > 0);
        }
    }
}
