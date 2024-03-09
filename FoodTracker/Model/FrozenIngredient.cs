using FoodTracker.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTracker.Model
{
    public class FrozenIngredient : IIngredient
    {
        // Dictionary with properties of the ingredient
        private Dictionary<string, dynamic> properties = null;
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

        public bool AddProperty(string key, List<string> values)
        {
            if (Properties.ContainsKey(key))
            {
                List<string> existingValues = Properties[key];

                foreach (string value in values)
                {
                    if (!existingValues.Contains(value))
                    {
                        existingValues.Add(value.ToLower());
                    }
                }

                return true;
            }
            else
            {
                List<string> lowerStrings = new List<string>();
                foreach (string value in values)
                {
                    lowerStrings.Add(value.ToLower());
                }
                Properties.Add(key, lowerStrings);
                return true;
            }
            return false;
        }

        public bool AddProperty(string key, string value)
        {
            if (Properties.ContainsKey(key))
            {
                if (!Properties[key].Contains(value.ToLower()))
                {
                    Properties[key].Add(value.ToLower());
                }
                return true;
            }
            else
            {
                List<string> values = new List<string>();
                values.Add(value.ToLower());
                Properties.Add(key, values);
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
