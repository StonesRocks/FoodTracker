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
        public void DisplayMenu()
        {
            while (true)
            {

            }
        }
        public void DisplayAndExecuteCommands(List<ICommand> commands)
        {
            DisplayOptions(commands);

            while (true)
            {
                string input = Console.ReadLine().Trim();

                if (input.ToLower() == "exit")
                {
                    return; // User chose to exit
                }

                if (int.TryParse(input, out int choice))
                {
                    if (choice >= 0 && choice < commands.Count)
                    {
                        commands[choice].Execute();
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Please enter a valid option or 'exit' to quit.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter a valid option or 'exit' to quit.");
                }
            }
        }

        private void DisplayOptions(List<ICommand> commands)
        {
            Console.WriteLine("Choose an option:");
            for (int i = 0; i < commands.Count; i++)
            {
                Console.WriteLine($"{i}. {commands[i].ToString()}");
            }
        }

        private bool exit(string input)
        {
            string[] strings = { "exit", "quit", "q" };
            if (strings.Contains(input.ToLower()))
            {
                return true;
            }
            return false;
        }
    }
}
