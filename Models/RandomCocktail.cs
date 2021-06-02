using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace jop.Models
{
    public class ExtendedIngredientsss
    {
        public string Original { get; set; }
    }

    public class Recipes
    {
        public string Title { get; set; }
        public int ReadyInMinutes { get; set; }
        public List<ExtendedIngredientsss> ExtendedIngredients { get; set; }
        public int Servings { get; set; }
        public string Image { get; set; }
        public string Instructions { get; set; }
        public string GetRecipes()
        {
            string rrr = $" {this.Title}\n" + "\nReady in minutes: " + $"{this.ReadyInMinutes}\n" + "\nIngredients:\n" + $"{this.GetIngredient()}" + "\nInstructions:\n" + $"{this.Instructions}";
            string pattern = @"<ol>";
            string target = " ";
            Regex regex = new Regex(pattern);
            string result = regex.Replace(rrr, target);
            return rrr;
        }
        public string GetPhotos()
        {
            string p = $"{this.Image}";

            return p;
        }

        public string GetIngredient()
        {
            string text = " ";

            foreach (var i in ExtendedIngredients)
            {
                text += i.Original + "\n";
            }
            return text;
        }
    }

    public class RandomCocktail
    {
        public Recipes[] Recipes { get; set; }
    }

}
