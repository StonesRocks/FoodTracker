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
        IIngredient BuildIngredient();
    }
}
