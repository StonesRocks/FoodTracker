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
        // We have different methods for different types of inputs when creating ingredients
        // The input type is the key, and the method is the value. we can expand this to include inputs later

        private Dictionary<IIngredientInput, IIngredientCreationMethod> methodDict = null;

        public IngredientFactory(Dictionary<IIngredientInput, IIngredientCreationMethod> _methodDict)
        {
            if (methodDict == null)
            {
                methodDict = _methodDict;
            }
        }

        public IIngredient BuildObject()
        {
            throw new NotImplementedException();
        }

    }
}
