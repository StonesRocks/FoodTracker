using FoodTracker.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTracker.Model
{
    public class StorageManager
    {
        private IDatabase database;

        private Dictionary<string, Action> functionDict = new Dictionary<string, Action>();

        private IViewModel viewModel;
        public List<IDecorator> Decorators { get; set; } = new List<IDecorator>();

        public StorageManager(IViewModel viewModel)
        {
            this.viewModel = viewModel;

            functionDict["Back"] = () => { };
            functionDict["Add Ingredient"] = AddIngredient;
            functionDict["View Ingredient"] = ViewIngredient;
        }
        public List<string> GetMethods()
        {
            return functionDict.Keys.ToList();
        }
        public void UseMethod(string methodName)
        {
            functionDict[methodName]();
        }

        public void ViewIngredient()
        {
            string input = "";
            var foundIngredients = database.StorageSearch(input);
            List<string> options = new List<string>();
            List<IIngredient> ingredients = new List<IIngredient>();
            options.Add("Back");
            foreach (var ingredient in foundIngredients)
            {
                string product = "Name: ";
                if (ingredient.GetProperty("ProductName") != null)
                {
                    product += ingredient.GetProperty("ProductName");
                }
                else if (ingredient.GetProperty("GenericName") != null)
                {
                    string genericName = ingredient.GetProperty("GenericName");
                    product += genericName + " (Unnamed product)";
                }
                else
                {
                    product += "(Unnamed product)";
                }
                if (ingredient.GetProperty("EAN13") != null)
                {
                    product += " |\tEAN13: " + ingredient.GetProperty("EAN13");
                }
                options.Add(product);
            }
            var choice = viewModel.GetChoiceInput(options) - 1;
            if (choice == -1)
            {
                return;
            }
            IngredientOperation(foundIngredients[choice]);
        }
        private void IngredientOperation(IIngredient ingredient)
        {
            List<string> options = new List<string>();
            options.Add("Back");
            options.Add("Remove");
            var choice = viewModel.GetChoiceInput(options);
            if (choice == 0)
            {
                return;
            }
            if (choice == 1)
            {
                RemoveIngredient(ingredient);
            }
        }

        private void AddIngredient()
        {
            string input = viewModel.GetInput("Enter search term");
            var foundIngredients = database.IngredientSearch(input);
            List<string> options = new List<string>();
            List<IIngredient> ingredients = new List<IIngredient>();
            options.Add("Back");
            foreach (var ingredient in foundIngredients)
            {
                string product = "Name: ";
                if (ingredient.GetProperty("ProductName") != null)
                {
                    product += ingredient.GetProperty("ProductName");
                }
                else if (ingredient.GetProperty("GenericName") != null)
                {
                    string genericName = ingredient.GetProperty("GenericName");
                    product += genericName + " (Unnamed product)";
                }
                else
                {
                    product += "(Unnamed product)";
                }
                if (ingredient.GetProperty("EAN13") != null)
                {
                    product += " |\tEAN13: " + ingredient.GetProperty("EAN13");
                }
                options.Add(product);
            }
            var choice = viewModel.GetChoiceInput(options) - 1;
            if (choice == -1)
            {
                return;
            }
            database.AddToStorage(foundIngredients[choice]);
        }
        public void RemoveIngredient(IIngredient ingredient)
        {
            database.RemoveIngredientFromDatabase(ingredient);
            database.Save();
        }

        public void AddDatabase(IDatabase database)
        {
            this.database = database;
        }

        public void AddDecorator(IDecorator decorator)
        {
            this.Decorators.Add(decorator);
        }

        public override string ToString()
        {
            return "Storage Manager";
        }
    }
}
