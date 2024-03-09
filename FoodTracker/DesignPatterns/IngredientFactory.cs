using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTracker.Interface;
using FoodTracker.Model;

namespace FoodTracker.DesignPatterns
{
    public class IngredientFactory : IIngredientFactory
    {
        // We have different methods for different types of inputs when creating ingredients
        // The input type is the key, and the method is the value. we can expand this to include inputs later

        private static IngredientFactory instance;
        private static readonly object padlock = new object();
        public static IngredientFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new IngredientFactory();
                        }
                    }
                }
                return instance;
            }
        }
        private Dictionary<string, IIngredientInput> CreationMethod { get; set;}
        private IngredientFactory()
        {
        }

        public bool AddInputMethod(string name, IIngredientInput input)
        {
            if (CreationMethod.ContainsKey(name))
            {
                return false;
            }
            else
            {
                CreationMethod.Add(name, input);
                return true;
            }
        }

        public IIngredient BuildObject()
        {

            throw new NotImplementedException();
        }

    }
}
