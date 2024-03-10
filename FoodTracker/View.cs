using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTracker.Interface;

namespace FoodTracker
{
    public class View
    {
        private Dictionary<string, dynamic> managersDict = new Dictionary<string, dynamic>();
        public View()
        {

        }

        public void AddManager(string managerName, dynamic manager)
        {
            managersDict.Add(managerName, manager);
        }

        public void DisplayMenu()
        {
            var mainMenu = new List<string>();
            foreach (var manager in managersDict)
            {
                mainMenu.Add(manager.Key);
            }
            mainMenu.Add("Exit");
        }

        private void DisplaySubMenu(string managerName)
        {
            var subMenu = new List<string>();
            var manager = managersDict[managerName];
            var methods = manager.GetType().GetMethods();
            foreach (var method in methods)
            {
                subMenu.Add(method.Name);
            }
            subMenu.Add("Back");
            DisplayList(subMenu);
        }

        private void DisplayList(List<string> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"[{i}]. {list[i]}");
            }
        }
    }
}
