using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTracker.Interface
{
    public interface IDatabase
    {
        // This is the interface that will be used to save and load the model to and from the database
        // Start with JSON and expand to mySQL

        void Save();

        // Storage manager
        List<IIngredient> StorageSearch(string searchTerm);
        void AddToStorage(IIngredient ingredient);
        void RemoveFromStorage(IIngredient ingredient);

        // Ingredient manager
        List<IIngredient> IngredientSearch(string searchTerm);
        void VerifyUnique(IIngredient ingredient);
        void AddIngredientToDatabase(IIngredient ingredient);
        void RemoveIngredientFromDatabase(IIngredient ingredient);



    }
}
