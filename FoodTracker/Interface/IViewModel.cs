using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTracker.Interface
{
    public interface IViewModel
    {
        // This is the interface that will be used to display the model to the view
            // We start with a console view and expand to a GUI
        

        // Display ingredients. Allow sorting of ingredients by name, category, expiration date, etc.
        public void DisplayIngredients();

        // Display recipes. Allow sorting of recipes by name, category, etc.
            // Display available recipes depending on available ingredients
        public void DisplayRecipes();

        // Display shopping list
        public void DisplayShoppingList();

        // Display meal plan
        public void DisplayMealPlan();

        // Display statistics
        public void DisplayStatistics();

        // Display settings
        public void DisplaySettings();

        public void AddIngredient();
    }
}
