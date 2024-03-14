using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTracker.Commands;
using FoodTracker.Interface;
using FoodTracker.Model;

namespace FoodTracker.DesignPatterns
{
    public class ViewModel : IViewModel
    {
        private View view = new View();
        private List<dynamic> ManagerList = new List<dynamic>();

        private bool _running = true;

        public ViewModel()
        {
            // Initialize the managers and adds them to the dictionary
            var ingredientManager = new IngredientManager(this);
            ingredientManager.AddIngredientFactory(new IngredientFactory(this));
            ingredientManager.AddFactoryMethod(new IngredientInputManual(this));
            AddManager(ingredientManager);

            Run();
        }

        public int RequestUserInput(List<string> options)
        {
            view.DisplayOptions(options);
            return GetChoiceInput(options);
        }

        private void Run()
        {
            while (_running)
            {
                view.DisplayOptions(GetMainMenu());
                var userInput = GetChoiceInput(GetMainMenu());
                if (userInput == 0)
                {
                    _running = false;
                    Console.WriteLine("Exiting Program");
                    continue;
                }
                userInput--;
                var SubOptions = ManagerList[userInput].GetMethods();
                view.DisplayOptions(SubOptions);
                var subInput = GetChoiceInput(SubOptions);
                if (subInput == SubOptions.Count - 1)
                {
                    continue;
                }
                ManagerList[userInput].UseMethod(SubOptions[subInput]);
            }
        }

        public void DisplayOptions(List<string> options)
        {
            view.DisplayOptions(options);
        }
        public void DisplayMessage(string message)
        {
            view.DisplayMessage(message);
        }

        public string GetStringInput(string message)
        {
            view.DisplayMessage(message);
            return Console.ReadLine();
        }

        // Provides a method that takes user input and returns the index of the selected option
        public int GetChoiceInput(List<string> validOptions)
        {
            int answer = 0;
            bool run = true;
            if (validOptions.Count == 0)
            {
                return answer;
            }
            while (run)
            {
                var userInput = Console.ReadLine();
                if (int.TryParse(userInput, out int result))
                {
                    if (result >= 0 && result < validOptions.Count)
                    {
                        answer = result;
                        run = false;
                        continue;
                    }
                }
                else if (validOptions.Contains(userInput.ToLower()))
                {
                    answer = validOptions.IndexOf(userInput);
                    run = false;
                    continue;
                }
                view.DisplayMessage("Invalid input. Please try again.");
            }
            return answer;
        }

        // Allows the system to dynamically add additional managers for future functionality
        public void AddManager(dynamic manager)
        {
            ManagerList.Add(manager);
        }

        // Function that gets the main menu for this view
        private List<string> GetMainMenu()
        {
            var mainMenu = new List<string>() { "Exit" };
            foreach (var manager in ManagerList)
            {
                mainMenu.Add(manager.ToString());
            }

            return mainMenu;
        }

        
    }
}
