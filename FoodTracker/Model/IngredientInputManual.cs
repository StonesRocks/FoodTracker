using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTracker.DesignPatterns;
using FoodTracker.Interface;

namespace FoodTracker.Model
{
    public class IngredientInputManual : IIngredientInput
    {
        private static IngredientInputManual instance = null;
        private static readonly object padlock = new object();
        public static IngredientInputManual Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new IngredientInputManual();
                        }
                    }
                }
                return instance;
            }
        }
        
        private IngredientInputManual()
        {
            IIngredientFactory factory = IngredientFactory.Instance;
            factory.AddInputMethod(GetInputType(), this);
        }

        public IIngredient GetProduct()
        {
            throw new NotImplementedException();
        }

        public string GetInputType()
        {
            return "Manual";
        }
    }
}
