using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FoodTracker.Interface;
using FoodTracker.Model;

namespace FoodTracker.DesignPatterns
{
    public class IngredientInputManual : IIngredientInput
    {
        // This implementation allows the user to manually input the barcode
        private IViewModel viewModel;
        private string EAN13 = null;
        Regex EAN13Regex = new Regex(@"^\d{13}$");

        public IngredientInputManual(IViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public IIngredient GetProduct()
        {
            // Get the decorators and use them as options for manual input

            throw new NotImplementedException();
        }

        private void AddEAN13()
        {
            EAN13 = null;
            while (EAN13 == null)
            {
                string barcode = viewModel.GetStringInput("Please input the 13 digit barcode. Enter to cancel");
                if (barcode == "")
                {
                }
                if (EAN13Regex.IsMatch(barcode))
                {
                    EAN13 = barcode;
                }
                else
                {
                    viewModel.DisplayMessage("Invalid barcode");
                }
            }
        }

        public override string ToString()
        {
            return "Manual";
        }
    }
}
