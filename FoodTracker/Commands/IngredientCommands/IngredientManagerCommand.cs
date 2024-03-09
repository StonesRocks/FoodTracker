using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTracker.Interface;
using FoodTracker.Model;

namespace FoodTracker.Commands.IngredientCommands
{
    public class IngredientManagerCommand : ICommand
    {
        private IngredientManager _ingredientManager;

        public IngredientManagerCommand(IngredientManager ingredientManager)
        {
            _ingredientManager = ingredientManager;
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
