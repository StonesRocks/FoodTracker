using FoodTracker.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTracker.DesignPatterns;

namespace FoodTracker.Model
{
    public class RecipeManager
    {
        private static RecipeManager instance = null;
        private static readonly object padlock = new object();

        private Dictionary<string, Action> functionDict = new Dictionary<string, Action>();

        public static RecipeManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new RecipeManager();
                        }
                    }
                }
                return instance;
            }
        }

        private RecipeManager()
        {
            functionDict["Add Ingredient"] = AddRecipe;
            functionDict["Remove Ingredient"] = RemoveRecipe;
            functionDict["Edit Ingredient"] = EditRecipe;
            functionDict["View Ingredient"] = ViewRecipe;
        }


        public List<string> GetMethods()
        {
            return functionDict.Keys.ToList();
        }
        public void AddRecipe()
        {

        }
        public void RemoveRecipe()
        {
            throw new NotImplementedException();
        }
        public void EditRecipe()
        {
            throw new NotImplementedException();
        }
        public void ViewRecipe()
        {
            throw new NotImplementedException();
        }
    }
}
