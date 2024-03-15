using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTracker.Commands;
using FoodTracker.Decorators;
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
            ingredientManager.AddIngredientInput(new IngredientInputManual(this));
            ingredientManager.AddIngredientFactory(new EAN13Factory(this));
            ingredientManager.AddDecorator(new EAN13Decorator());
            ingredientManager.AddDecorator(new ProductNameDecorator());
            ingredientManager.AddDecorator(new GenericNameDecorator());
            ingredientManager.AddDatabase(SaveJson.Instance);

            StorageManager storageManager = new StorageManager(this);
            storageManager.AddDatabase(SaveJson.Instance);

            AddManager(ingredientManager);
            AddManager(storageManager);
            

            Run();
        }


        private void Run()
        {
            while (_running)
            {
                try
                {
                    var userInput = GetChoiceInput(GetMainMenu());
                    // If the user selects the exit option, the program will exit
                    if (userInput == 0)
                    {
                        _running = false;
                        Console.WriteLine("Exiting Program");
                        IDatabase database = SaveJson.Instance;
                        database.Save();
                        continue;
                    }
                    userInput--;
                    var SubOptions = ManagerList[userInput].GetMethods();
                    var subInput = GetChoiceInput(SubOptions);
                    ManagerList[userInput].UseMethod(SubOptions[subInput]);
                }
                catch (AbortOperationException)
                {
                    // Handle abort operation
                    Console.WriteLine("Returning to main menu.");
                    continue; // Continue the loop
                }
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
        public int GetChoiceInput(List<string> options)
        {
            view.DisplayOptions(options);
            return GetChoice(options);
        }
        public string GetInput(string message)
        {
            view.DisplayMessage(message);
            var input = Console.ReadLine();
            if (input == "")
            {
                throw new AbortOperationException();
            }
            return input;
        }

        // Provides a method that takes user input and returns the index of the selected option
        public int GetChoice(List<string> validOptions)
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
                if (userInput == "")
                {
                    throw new AbortOperationException();
                }
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
