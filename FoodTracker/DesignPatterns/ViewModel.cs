using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTracker.Interface;

namespace FoodTracker.DesignPatterns
{
    public class ViewModel : IViewModel
    {

        public void DisplayIngredients()
        {
            // Display ingredients. Allow sorting of ingredients by name, category, expiration date, etc.
            throw new NotImplementedException();
        }

        public void DisplayRecipes()
        {
            // Display recipes. Allow sorting of recipes by name, category, etc.
            // Display available recipes depending on available ingredients
        }


        public void DisplayShoppingList()
        {
            // Display shopping list
            throw new NotImplementedException();
        }


        public void DisplayMealPlan()
        {
            // Display meal plan
            throw new NotImplementedException();
        }


        public void DisplayStatistics()
        {
            // Display statistics
            throw new NotImplementedException();
        }


        public void DisplaySettings()
        {
            // Display settings
            throw new NotImplementedException();
        }

        public void AddIngredient()
        {
            throw new NotImplementedException();
        }
    }
}
