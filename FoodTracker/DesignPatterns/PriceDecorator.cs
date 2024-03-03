using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTracker.Interface;

namespace FoodTracker.DesignPatterns
{
    public abstract class PriceDecorator
    {
        protected readonly IIngredient ingredient;
        public PriceDecorator(IIngredient ingredient)
        {
            this.ingredient = ingredient;
        }

        public abstract double GetPrice();

    }
}
