using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FoodTracker.Interface
{
    public interface IDecorator
    {
        // This interface is used to add properties to intredients.
        string description { get; }
        string name { get; }
        void Decorate(IIngredient ingredient, object property);
    }
}
