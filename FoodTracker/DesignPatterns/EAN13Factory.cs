using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FoodTracker.Decorators;
using FoodTracker.Interface;
using FoodTracker.Model;

namespace FoodTracker.DesignPatterns
{
    public class EAN13Factory : IIngredientFactory
    {
        // This concrete factory will be using the EAN13 barcode to create the product

        private IViewModel viewModel;
        private IIngredientInput inputMethod;
        private Regex EAN13Regex = new Regex(@"^\d{13}$");
        public string name { get; } = "EAN13";
        public string description { get; } = "Please provide an EAN-13 standard barcode (13 digits)";

        public EAN13Factory(IViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public void AddInputMethod(IIngredientInput inputMethod)
        {
            this.inputMethod = inputMethod;
        }

        public IIngredient BuildObject()
        {
            // Creates the ingredient object
            BasicIngredient ingredient = new BasicIngredient();

            // Validates the input
            bool run = true;
            string value = "";
            while (run)
            {
                // Gets the string input using the provided input method
                value = (string)inputMethod.GetInput(this);
                // If the user aborts the operation
                if (value == "")
                {
                    throw new AbortOperationException();
                }
                // Validates the input
                try
                {
                    new EAN13Decorator().Decorate(ingredient, value);
                    run = false;
                }
                catch (ArgumentException e)
                {
                    viewModel.DisplayMessage(e.Message);
                }
            }
            return ingredient;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
