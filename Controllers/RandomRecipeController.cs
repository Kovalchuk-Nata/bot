using jop.Models;
using kursovaya.Clients;
//using kursovaya.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace jop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RandomRecipeController : ControllerBase
    {


        private readonly ILogger<RandomRecipeController> _logger;
        private readonly RecipeClients _recipeClient;

        public RandomRecipeController(ILogger<RandomRecipeController> logger, RecipeClients recipeClients)
        {
            _logger = logger;
            _recipeClient = recipeClients;
        }

        [HttpGet("random")]
        public async Task<RandomRecipe> GetRandomRecipe()
        {
            var recipe = await _recipeClient.GetRandomRecipe();
            return recipe;
        }

        //[HttpGet("ByName")]
        //public async Task<RecipeByName> GetRecipeByName()
        //{
        //    var recipebyname = await _recipeClient.GetRecipeByName();

        //    return recipebyname;
        //}

    }
}
