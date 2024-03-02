using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTracker.Interface
{
    public interface IIngredientFactory
    {
        // Factory method to create an ingredient
        // Also applies Builder pattern to build the ingredient
        IIngredient BuildIngredient();
    }
}
