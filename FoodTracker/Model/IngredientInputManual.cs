using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTracker.Interface;

namespace FoodTracker.Model
{
    public sealed class IngredientInputManual : IIngredientInput
    {
        private static IngredientInputManual instance = null;
        
        public IngredientInputManual()
        {
        }
        public IIngredient GetProduct()
        {
            throw new NotImplementedException();
        }

        public static IngredientInputManual GetInstance()
        {
            if (instance == null)
            {
                instance = new IngredientInputManual();
            }
            return instance;
        }
    }
}
