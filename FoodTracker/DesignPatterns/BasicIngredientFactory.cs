using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTracker.Interface;
using FoodTracker.Model;

namespace FoodTracker.DesignPatterns
{
    public class BasicIngredientFactory : IIngredientFactory
    {
        public IIngredient BuildIngredient()
        {
            throw new NotImplementedException();
        }
    }
}
