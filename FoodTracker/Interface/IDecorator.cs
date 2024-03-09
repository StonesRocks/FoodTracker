using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTracker.Interface
{
    public interface IDecorator
    {
        // This interface is used to add properties to intredients.
        void Decorate(IIngredient ingredient);
    }
}
