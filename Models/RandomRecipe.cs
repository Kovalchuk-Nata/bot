using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types.InputFiles;

namespace jop.Models
{
    public class ExtendedIngredient
    {
        public string Original { get; set; }
    }

    public class Recipe
    {
        public string Title { get; set; }
        public int ReadyInMinutes { get; set; }
        public List<ExtendedIngredient> ExtendedIngredients { get; set; }
        public int Servings { get; set; }
        public string Image { get; set; }
        
        public string Instructions { get; set; }

        public string GetRecipe()
        {
            string rrr = $"{this.Title}" + "\n<b>Ready in minutes:</b>" + $"{this.ReadyInMinutes}" + "\n<b>Ingredients: </b>" + $"{this.ExtendedIngredients}" + "\n<b>Instructions:</b>\n" + $"<i>{this.Instructions}</i>";
            return rrr;
        }

        public string GetPhoto()
        {
            string p = $"{this.Image}";
            
            return p;
        }
    }

    public class RandomRecipe
    {
        public Recipe[] Recipes { get; set; }
        //public string GetRecipe()
        //{
        //    string rrr = $"{this.Recipes}";
        //    return rrr;
        //}
    }

    
}

//public class ExtendedIngredient
//{
//    public string Original { get; set; }
//    public string GetIngredient()
//    {
//        string rrr = $"{this.Original}";
//        return rrr;
//    }
//}