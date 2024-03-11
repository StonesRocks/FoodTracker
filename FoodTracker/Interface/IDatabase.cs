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
        void Load();
    }
}
