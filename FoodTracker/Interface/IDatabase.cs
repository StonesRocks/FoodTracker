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

        // Nullable parameters allows us to implement either a sophisticated database implemnentation to fetch specific data
        // or a simpler implementation to fetch all data and filter it in the model
        void Save(List<string>? parameters);
        void Load(List<string>? parameters);
    }
}
