using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTracker.Interface;

namespace FoodTracker.Model
{
    public sealed class ManualInput : IProductInput
    {
        private static ManualInput instance = null;
        
        private ManualInput()
        {
        }
        public IIngredient GetProduct()
        {
            throw new NotImplementedException();
        }

        public static ManualInput GetInstance()
        {
            if (instance == null)
            {
                instance = new ManualInput();
            }
            return instance;
        }
    }
}
