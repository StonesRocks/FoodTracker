﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTracker.Interface
{
    public interface IIngredientFactory
    {
        // This factory purpose is to move the Ingredient creation to a factory
        string description { get; }
        string name { get; }

        void AddInputMethod(IIngredientInput inputMethod);
        IIngredient BuildObject();
    }
}
