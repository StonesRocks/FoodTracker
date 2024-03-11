using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTracker.Interface;
using FoodTracker.Model;

namespace FoodTracker
{
    public class View
    {
        private Dictionary<string, dynamic> managersDict = new Dictionary<string, dynamic>();

        //Testing with ICommand
        private Dictionary<string, ICommand> availableCommands = new Dictionary<string, ICommand>();

        private bool _running = true;
        public View()
        {
            //Initialize the managers
            AddManager("IngredientManager", IngredientManager.Instance);


            while(_running)
            {
                var MainMenu = GetMainMenu();
                DisplayList(MainMenu);

                var input = GetInput(MainMenu);
                if(input == MainMenu[MainMenu.Count - 1]) { _running = false;}
                else
                {
                    var SubMenu = GetSubMenu(input);
                    if (SubMenu.Count > 1)
                    {
                        DisplayList(SubMenu);
                        var subInput = GetInput(SubMenu);
                        if(subInput == SubMenu[SubMenu.Count - 1]) { continue; }
                        else
                        {
                            var manager = managersDict[input];
                            manager.UseMethod(subInput);
                        }
                    }
                }
            }
        }

        public void AddManager(string managerName, dynamic manager)
        {
            managersDict.Add(managerName, manager);
        }

        public List<string> GetMainMenu()
        {
            var mainMenu = new List<string>();
            foreach (var manager in managersDict)
            {
                mainMenu.Add(manager.Key);
            }
            mainMenu.Add("Exit");
            return mainMenu;  
        }

        private List<string> GetSubMenu(string managerName)
        {
            var subMenu = new List<string>();
            var manager = managersDict[managerName];
            subMenu = manager.GetMethods();
            subMenu.Add("Back");
            return subMenu;
        }

        private void DisplayList(List<string> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"[{i}]. {list[i]}");
            }
        }

        private string GetInput(List<string> Choices)
        {
            while (true)
            {
                var userInput = Console.ReadLine();
                if(int.TryParse(userInput, out int input))
                {
                    if(input >= 0 && input < Choices.Count)
                    {
                        return Choices[input];
                    }
                }

                if (managersDict.ContainsKey(userInput))
                {
                    return userInput;
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }
        }
    }
}
