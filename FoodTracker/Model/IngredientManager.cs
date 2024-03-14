using FoodTracker.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTracker.DesignPatterns;

namespace FoodTracker.Model
{
    public class IngredientManager
    {


        // Database should contain the IIngredients recorded
        // IngredientManager should be able to add, remove, edit and view ingredients


        private Dictionary<string, Action> functionDict = new Dictionary<string, Action>();

        private Dictionary<int, IIngredient> ingredientDict = new Dictionary<int, IIngredient>();

        private IViewModel viewModel;
        public IIngredientFactory ingredientFactory;


        public IngredientManager(IViewModel viewModel)
        {   
            this.viewModel = (ViewModel)viewModel;

            functionDict["Back"] = () => { };
            functionDict["Add Ingredient"] = AddIngredient;
            functionDict["Remove Ingredient"] = RemoveIngredient;
            functionDict["Edit Ingredient"] = EditIngredient;
            functionDict["View Ingredient"] = ViewIngredient;

        }

        public List<string> GetMethods()
        {
            return functionDict.Keys.ToList();
        }
        public void AddFactoryMethod(IIngredientInput process)
        {
            ingredientFactory.AddInputMethod(process);
        }

        public void AddIngredientFactory(IIngredientFactory ingredientFactory)
        {
            this.ingredientFactory = ingredientFactory;
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

            // We run the Factory and display the options
            viewModel.DisplayOptions(ingredientFactory.GetOptions());
            // We get the input from the user
            var Input = viewModel.GetChoiceInput(ingredientFactory.GetOptions());
            // We use the input method to activate the method to create the ingredient
            var Ingredient = ingredientFactory.UseInputMethod(Input);

            if (Ingredient != null)
            {
                // Add the ingredient to the list
                ingredientDict.Add(int.MinValue, Ingredient);
            }

        }
        public void RemoveIngredient()
        {
            throw new NotImplementedException();
        }
        public void EditIngredient()
        {
            throw new NotImplementedException();
        }
        public void ViewIngredient()
        {
            throw new NotImplementedException();
        }
    }
}
