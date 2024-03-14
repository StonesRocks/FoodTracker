using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTracker.Interface
{
    public interface IIngredientFactory
    {
        // This factory purpose is to move the Ingredient creation to a factory

        List<string> GetOptions();
        IIngredient BuildObject();
        bool AddInputMethod(IIngredientInput input);
        IIngredient UseInputMethod(int input);
    }
}
