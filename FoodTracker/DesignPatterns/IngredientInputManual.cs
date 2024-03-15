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
        // This Input method means the user manually inserts the information

        private IViewModel viewModel;

        public IngredientInputManual(IViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public object GetInput(IIngredientFactory factory)
        {
            return viewModel.GetInput(factory.description);
        }

        public override string ToString()
        {
            return "Manual";
        }
    }
}
