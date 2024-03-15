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
        Dictionary<string, dynamic> Properties { get; set; }
        dynamic GetProperty(string key);
        bool AddProperty(string key, dynamic value);
        bool RemoveProperty(string key);
    }
}
