using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTracker.Interface;
using FoodTracker.Model;

namespace FoodTracker.Decorators
{
    public class IdDecorator : IDecorator
    {
        public string description { get; } = "Please provide an id for the product";

        public string name { get; } = "Id";

        public void Decorate(IIngredient ingredient, object property)
        {
            if (!(property is string))
            {
                throw new ArgumentException("Property must be a string");
            }
            ingredient.AddProperty("id", property.ToString());
        }
    }
}
