using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTracker.Interface
{
    public interface IIngredient
    {
        // key is a string for the property and the value can be a string or a list of strings
        Dictionary<string, List<string>> Properties { get; set; }

        bool AddProperty(string key, string value);
        bool AddProperty(string key, List<string> values);
        bool RemoveProperty(string key);

        Object GetProperty(string key);
    }
}
