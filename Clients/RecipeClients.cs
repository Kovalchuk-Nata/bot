using jop.Models;
//using kursovaya.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace kursovaya.Clients
{
    //
    public class RecipeClients
    {
        private HttpClient client;
        private static string adress;

        public RecipeClients()
        {
            adress = Const.adress;
            client = new HttpClient();
            client.BaseAddress = new Uri(adress);
        }

        public async Task<RandomRecipe> GetRandomRecipe()
        {
            var response = await client.GetAsync("random");
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;

            var result = JsonConvert.DeserializeObject<RandomRecipe>(content);
            
            return result;
        }

        public async Task<RecipeByName> GetRecipeByName(string title)
        {
            var response = await client.GetAsync($"ByName?title={title}");
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;

            var result = JsonConvert.DeserializeObject<RecipeByName>(content);
            return result;
        }

        public async Task<RandomCocktail> GetRandomCocktail()
        {
            var response = await client.GetAsync("RandomCocktails"); ;
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;

            var result = JsonConvert.DeserializeObject<RandomCocktail>(content);

            return result;
        }

        //public async Task<RecipeByIngredient> GetRecipeByIngredient(string ingredient)
        //{
        //    var response = await client.GetAsync($"ByIngredient?ingredient={ingredient}");
        //    response.EnsureSuccessStatusCode();
        //    var content = response.Content.ReadAsStringAsync().Result;

        //    var result = JsonConvert.DeserializeObject<RecipeByName>(content);
        //    return result;
        //} 
        //public async Task<RandomCocktail> GetRandomCocktail(int offset)
        //{
        //    var response = await client.GetAsync("RandomCocktail?offset={offset}"); ;
        //    response.EnsureSuccessStatusCode();
        //    var content = response.Content.ReadAsStringAsync().Result;

        //    var result = JsonConvert.DeserializeObject<RandomCocktail>(content);

        //    return result;
        //}
    }
}
