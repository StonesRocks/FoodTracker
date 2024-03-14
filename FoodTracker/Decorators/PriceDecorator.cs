using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTracker.Interface;

namespace FoodTracker.Decorators
{
    public abstract class PriceDecorator : IDecorator
    {
        private IIngredient ingredient;
        public void Decorate(IIngredient ingredient)
        {
            this.ingredient = ingredient;
        }

        public abstract double GetPrice();

    }
}
