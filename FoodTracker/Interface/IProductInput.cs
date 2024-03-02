using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTracker.Interface
{
    public interface IProductInput
    {
        // This is the interface that will be used to input the product to the model
        // Lets assume atleast 2 methods, a mock barscanner implementation and a manual input
        IIngredient GetProduct();
    }
}
