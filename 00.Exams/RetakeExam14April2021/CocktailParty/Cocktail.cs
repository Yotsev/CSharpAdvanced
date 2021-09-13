using System.Collections.Generic;
using System.Linq;
using System;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.MaxAlcoholLevel = maxAlcoholLevel;
            this.Ingredients = new List<Ingredient>();
        }
        public List<Ingredient> Ingredients { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }
        public int CurrentAlcoholLevel
        {
            get
            {
                int current = 0;

                foreach (var item in Ingredients)
                {
                    current += item.Alcohol;
                }

                return current;
            }
        }

        public void Add(Ingredient ingredient)
        {
            if (!Ingredients.Contains(ingredient) && Capacity > Ingredients.Count && MaxAlcoholLevel >= ingredient.Alcohol)
            {
                Ingredients.Add(ingredient);
            }
        }

        public bool Remove(string name)
        {
            Ingredient ingredient = Ingredients.FirstOrDefault(i => i.Name == name);
            return Ingredients.Remove(ingredient);
        }

        public Ingredient FindIngredient(string name)
        {
            return Ingredients.FirstOrDefault(i => i.Name == name);
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            Ingredient ingredient = Ingredients.OrderByDescending(i => i.Alcohol).FirstOrDefault();
            return ingredient;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");
            foreach (var item in Ingredients)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
