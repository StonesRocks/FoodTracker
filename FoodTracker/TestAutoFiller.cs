using FoodTracker.Decorators;
using FoodTracker.Interface;
using FoodTracker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTracker
{
    public class TestAutoFiller
    {
        public TestAutoFiller(IDatabase database)
        {
            // This class is used to fill the database with test data
            // It is not used in the final product
            List<IIngredient> ingredients = new List<IIngredient>()
            {
                {new BasicIngredient()},
                {new BasicIngredient()},
                {new BasicIngredient()},
                {new BasicIngredient()},
                {new BasicIngredient()}
            };
            List<IDecorator> decorators = new List<IDecorator>()
            {
                {new EAN13Decorator()},
                {new ProductNameDecorator()},
            };
            decorators[0].Decorate(ingredients[0], "7312345678901");
            decorators[0].Decorate(ingredients[1], "7321098765432");
            decorators[0].Decorate(ingredients[2], "7350123456789");
            decorators[0].Decorate(ingredients[3], "7398765432101");
            decorators[0].Decorate(ingredients[4], "7345678901234");

            decorators[1].Decorate(ingredients[0], "Ekologiskt havssalt");
            decorators[1].Decorate(ingredients[1], "Kallpressad rapsolja");
            decorators[1].Decorate(ingredients[2], "Ekologiskt fullkornsris");
            decorators[1].Decorate(ingredients[3], "Färsk basilika");
            decorators[1].Decorate(ingredients[4], "Ekologiskt kikärtmjöl");

            foreach (var ingredient in ingredients)
            {
                database.AddIngredientToDatabase(ingredient);
            }

            //database.AddIngredientToDatabase();
        }
    }
}
