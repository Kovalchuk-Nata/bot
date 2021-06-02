using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace jop.Models
{
    public class ExtendedIngredients
    {
        public string Original { get; set; }
        public string GetIngredients()
        {
            string rrr = $"{this.Original}";
            return rrr;
        }
    }

    public class Steps
    {
        public int Number { get; set; }
        public string Step { get; set; }
    }

    public class AnalyzedInstruction
    {   
        public List<Steps> Steps { get; set; }
        public string GetInstruction()
        {
            string text = " ";

            foreach (var i in Steps)
            {
                    text += i.Number + ") " + i.Step + "\n";
            }
            return text;
        }
    }

    public class Result
    {
        public string Title { get; set; }
        public List<ExtendedIngredients> ExtendedIngredients { get; set; }
        public int ReadyInMinutes { get; set; }
        public int Servings { get; set; }
        public string Image { get; set; }
        public List<AnalyzedInstruction> AnalyzedInstructions { get; set; }
       
        public string GetRecipe()
        {
            string rrr = $"{this.Title}\n" + "\n<b>Ready in minutes: </b>" + $"{this.ReadyInMinutes}\n" + "\n<b>Ingredients: </b>" + $"{this.GetIngredient()}\n" + "\n<b>Instructions:</b>\n" + $"<i>{this.GetInstruction()}</i>";
            string pattern = @"<ol>";
            string target = " ";
            Regex regex = new Regex(pattern);
            string result = regex.Replace(rrr, target);
            return rrr;
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

        public string GetInstruction()
        {
            string text = " ";

            foreach (var i in AnalyzedInstructions)
            {
                text += i.GetInstruction();
            }
            return text;
        }
        public string GetPhoto()
        {
            string p = $"{this.Image}";

            return p;
        }
    }

    public class RecipeByName
    {
        public Result[] Results { get; set; }
    }
}