using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTracker.Interface;
using FoodTracker.Model;

namespace FoodTracker.DesignPatterns
{
    public class IngredientFactory : IIngredientFactory
    {
        // Lets first get the IngredientInputMethod
            // There is a method to add an input method
            // There is a method to use a specified input method

        private IViewModel viewModel;

        // Input dictionary
        private List<IIngredientInput> IngredientInputMethod { get; set; } = new List<IIngredientInput>();
        public IngredientFactory(IViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public List<string> GetOptions()
        {
            List<string> inputMethods = new List<string>();
            foreach (var method in IngredientInputMethod)
            {
                inputMethods.Add(method.ToString());
            }
            return inputMethods;
        }

        // Method to add an input method
        public bool AddInputMethod(IIngredientInput input)
        {
            if (IngredientInputMethod.Contains(input))
            {
                return false;
            }
            else
            {
                IngredientInputMethod.Add(input);
                return true;
            }
        }

        public IIngredient UseInputMethod(int input)
        {
            if (input < IngredientInputMethod.Count)
            {
                return IngredientInputMethod[input].GetProduct();
            }
            else
            {
                return null;
            }
        }

        public List<string> GetMethods()
        {
            List<string> methods = new List<string>();
            foreach (var method in IngredientInputMethod)
            {
                methods.Add(method.ToString());
            }
            return methods;
        }

        public IIngredient BuildObject()
        {
            throw new NotImplementedException();
        }

    }
}
