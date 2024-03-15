using FoodTracker.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTracker.Decorators
{
    public class ProductNameDecorator : IDecorator
    {
        public string description { get; } = "Please provide the name of the product.";

        public string name { get; } = "Product Name";

        public void Decorate(IIngredient ingredient, object property)
        {
            if (!(property is string))
            {
                throw new ArgumentException("Property must be a string");
            }
            ingredient.AddProperty("ProductName", property);
        }
    }
}
