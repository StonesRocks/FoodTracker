using FoodTracker.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTracker.Model
{
    public class IngredientNotUniqueException : Exception
    {
        public IIngredient matchingIngredient;
        public IngredientNotUniqueException(IIngredient matchingIngredient) : base("Ingredient is not unique")
        {
            this.matchingIngredient = matchingIngredient;
        }
    }
}
