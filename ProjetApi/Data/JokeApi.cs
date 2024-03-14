using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics;
using System.Text.Json;

namespace ProjetApi.Data
{
    public class JokeApi
    {
        // Cette classe représente une API pour récupérer des blagues et gérer les favoris.

        // Représente la blague actuelle récupérée de l'API.
        public Joke CurrentJoke { get; set; }

        // Liste des blagues favorites.
        public List<Joke> Favs { get; set; } = new List<Joke>();

        // Méthode asynchrone pour récupérer une nouvelle blague depuis l'API.
        public async Task GetJoke()
        {
            // Utilisation d'HttpClient pour effectuer une requête HTTP GET à l'API de blagues.
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://v2.jokeapi.dev/joke/Any");

            // Vérification de la réussite de la requête.
            if (response.IsSuccessStatusCode)
            {
                // Création d'une nouvelle instance de la classe Joke pour stocker la blague.
                Joke joke = new Joke();

                // Lecture du contenu de la réponse HTTP.
                string json = await response.Content.ReadAsStringAsync();

                // Analyse du contenu JSON en utilisant System.Text.Json.
                JsonDocument jsondocument = JsonDocument.Parse(json);
                JsonElement root = jsondocument.RootElement;

                // Extraction des parties de la blague à partir du document JSON.
                joke.Setup = root.GetProperty("setup").ToString();
                joke.Delivery = root.GetProperty("delivery").ToString();

                // Assignation de la blague actuelle.
                CurrentJoke = joke;
            }
            else
            {
                // Affichage d'un message d'erreur si la requête échoue.
                Console.WriteLine($"Failed to retrieve joke. Status code: {response.StatusCode}");
            }
        }

        // Méthode pour ajouter la blague actuelle aux favoris.
        public void AddFav()
        {
            // Ajout de la blague actuelle à la liste des favoris.
            Favs.Add(CurrentJoke);

            // Réinitialisation de la blague actuelle à null.
            CurrentJoke = null;
        }
    }
}
