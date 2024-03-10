using FoodTracker.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTracker.DesignPatterns;

namespace FoodTracker.Model
{
    public class IngredientManager
    {
        private static IngredientManager instance = null;
        private static readonly object padlock = new object();

        private Dictionary<string, Action> functionDict = new Dictionary<string, Action>();

        private IIngredientFactory ingredientFactory = IngredientFactory.Instance;

        public IngredientManager Instance
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
            functionDict["Add Ingredient"] = AddIngredient;
            functionDict["Remove Ingredient"] = RemoveIngredient;
            functionDict["Edit Ingredient"] = EditIngredient;
            functionDict["View Ingredient"] = ViewIngredient;
        }


        public List<string> GetMethods()
        {
            return functionDict.Keys.ToList();
        }
        public void AddIngredient()
        {

        }
        public void RemoveIngredient()
        {
            throw new NotImplementedException();
        }
        public void EditIngredient()
        {
            throw new NotImplementedException();
        }
        public void ViewIngredient()
        {
            throw new NotImplementedException();
        }
    }
}
