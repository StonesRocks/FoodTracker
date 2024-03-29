﻿using FoodTracker.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTracker.Decorators
{
    public class GenericNameDecorator : IDecorator
    {
        public string description { get; } = "Please provide a genereic name for the product";
        public string name { get; } = "Generic Name";

        public void Decorate(IIngredient ingredient, object property)
        {
            if (!(property is string))
            {
                throw new ArgumentException("Property must be a string");
            }
            ingredient.AddProperty("GenericName", property);
        }
    }
}
