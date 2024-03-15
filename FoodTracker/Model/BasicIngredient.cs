using FoodTracker.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTracker.Model
{
    public class BasicIngredient : IIngredient
    {
        // Dictionary with properties of the ingredient
        private Dictionary<string, dynamic> properties = null;

        public BasicIngredient()
        {

        }

        public Dictionary<string, dynamic> Properties
        {
            get
            {
                if (properties == null)
                {
                    properties = new Dictionary<string, dynamic>();
                }
                return properties;
            }
            set { properties = value; }
        }

        public bool AddProperty(string key, dynamic value)
        {
            if (!Properties.ContainsKey(key))
            {
                Properties.Add(key, value);
                return true;
            }
            return false;
        }
        public object GetProperty(string key)
        {
            if (Properties.ContainsKey(key))
            {
                return Properties[key];
            }
            else
            {
                return null;
            }
        }
        public bool RemoveProperty(string key)
        {
            if (Properties.ContainsKey(key))
            {
                Properties.Remove(key);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
