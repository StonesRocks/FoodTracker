using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTracker.Model
{
    public class IngredientManager
    {
        private static IngredientManager instance = null;
        private static readonly object padlock = new object();

        public static IngredientManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new IngredientManager();
                        }
                    }
                }
                return instance;
            }
        }

        public IngredientManager()
        {

        }


    }
}
