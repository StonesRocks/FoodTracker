using FoodTracker.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTracker.DesignPatterns;
using static System.Net.Mime.MediaTypeNames;

namespace FoodTracker.Model
{
    public class IngredientManager
    {


        // Database should contain the IIngredients recorded
        // IngredientManager should be able to add, remove, edit and view ingredients

        private IDatabase database;

        private Dictionary<string, Action> functionDict = new Dictionary<string, Action>();

        private IViewModel viewModel;
        private List<IIngredientFactory> ingredientFactories { get; set;} = new List<IIngredientFactory>();
        private List<IIngredientInput> ingredientInputs { get; set; } = new List<IIngredientInput>();

        private List<IDecorator> Decorators { get; set; } = new List<IDecorator>();


        public IngredientManager(IViewModel viewModel)
        {   
            this.viewModel = (ViewModel)viewModel;

            functionDict["Back"] = () => { };
            functionDict["Add Ingredient"] = AddIngredient;
            functionDict["View Ingredient"] = ViewIngredient;

        }

        public List<string> GetMethods()
        {
            return functionDict.Keys.ToList();
        }

        public void AddDatabase(IDatabase database)
        {
            this.database = database;
        }

        public void AddIngredientFactory(IIngredientFactory ingredientFactory)
        {
            this.ingredientFactories.Add(ingredientFactory);
        }

        public void AddIngredientInput(IIngredientInput ingredientInput)
        {
            this.ingredientInputs.Add(ingredientInput);
        }

        public void AddDecorator(IDecorator decorator)
        {
            this.Decorators.Add(decorator);
        }

        public override string ToString()
        {
            return "Ingredient Manager";
        }


        public List<string> GetOptions()
        {
            return functionDict.Keys.ToList();
        }

        public void UseMethod(string methodName)
        {
            functionDict[methodName]();
        }

        public void AddIngredient()
        {
            List<string> factoryList = new List<string>();
            factoryList.Add("Back");
            foreach (var factory in ingredientFactories)
            {
                factoryList.Add(factory.ToString());
            }
            var input = viewModel.GetChoiceInput(factoryList);
            if (input == 0)
            {
                return;
            }
            var chosenFactory = ingredientFactories[input - 1];
            List<string> inputList = new List<string>();
            inputList.Add("Back");
            foreach (var inputMethod in ingredientInputs)
            {
                inputList.Add(inputMethod.ToString());
            }
            var inputMethodChoice = viewModel.GetChoiceInput(inputList);
            if (inputMethodChoice == 0)
            {
                return;
            }
            var chosenInputMethod = ingredientInputs[inputMethodChoice - 1];
            chosenFactory.AddInputMethod(chosenInputMethod);
            var ingredient = chosenFactory.BuildObject();
            // Check if ingredient exist in database
            // If it does, ask if user meant to edit the ingredient instead
            try
            {
                database.VerifyUnique(ingredient);
                // Ingredient is unique
                database.AddIngredientToDatabase(ingredient);
            }
            catch(IngredientNotUniqueException e)
            {
                ingredient = e.matchingIngredient;
                // Matching ingredient found
                viewModel.DisplayMessage("Ingredient already exists in database");
            }

        }
        private void IngredientOperation(IIngredient ingredient)
        {
            List<string> options = new List<string>();
            options.Add("Back");
            options.Add("Edit");
            options.Add("Remove");
            var choice = viewModel.GetChoiceInput(options);
            if (choice == 0)
            {
                return;
            }
            if (choice == 1)
            {
                EditIngredient(ingredient);
            }
            else if (choice == 2)
            {
                RemoveIngredient(ingredient);
            }
        }
        public void RemoveIngredient(IIngredient ingredient)
        {
            database.RemoveIngredientFromDatabase(ingredient);
            database.Save();
        }
        public void EditIngredient(IIngredient ingredient)
        {
            List<string> options = new List<string>();
            options.Add("Back");
            foreach (var decorator in Decorators)
            {
                options.Add(decorator.name);
            }
            viewModel.DisplayMessage("Choose a decorator to edit the ingredient");
            var choice = viewModel.GetChoiceInput(options);
            if (choice == 0)
            {
                return;
            }
            var chosenDecorator = Decorators[choice - 1];
            var value = viewModel.GetInput(chosenDecorator.description);
            chosenDecorator.Decorate(ingredient, value);
            database.Save();
        }
        public void ViewIngredient()
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
                else if(ingredient.GetProperty("GenericName") != null)
                {
                    string genericName = ingredient.GetProperty("GenericName");
                    product += genericName+" (Unnamed product)";
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
            var choice = viewModel.GetChoiceInput(options)-1;
            if (choice == -1)
            {
                return;
            }
            IngredientOperation(foundIngredients[choice]);
        }
    }
}
