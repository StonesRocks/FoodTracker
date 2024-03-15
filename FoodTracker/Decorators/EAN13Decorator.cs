using FoodTracker.DesignPatterns;
using FoodTracker.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FoodTracker.Decorators
{
    public class EAN13Decorator : IDecorator
    {
        Regex EAN13Regex = new Regex(@"^\d{13}$");
        public string name { get; } = "EAN13";
        public string description { get; } = "Please provide an EAN-13 standard barcode";
        public void Decorate(IIngredient ingredient, object property)
        {
            if (!(property is string))
            {
                throw new ArgumentException("Property must be a string");
            }
            if (!EAN13Regex.IsMatch((string)property))
            {
                throw new ArgumentException("Invalid EAN13 barcode, try again");
            }
            ingredient.AddProperty("EAN13", property);
        }
    }
}
