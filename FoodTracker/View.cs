using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTracker.Interface;
using FoodTracker.Model;
using FoodTracker.Commands;

namespace FoodTracker
{
    public class View
    {
        // This class is caught lacking because this implementation of the view is a console application
        // I will implement the command pattern with commands to display options and messages

        // This dictionary contains the available commands
        private Dictionary<string, ICommand> availableCommands = new Dictionary<string, ICommand>();

        public View()
        {
            // Initialize the commands and adds them to the dictionary
            availableCommands.Add("DisplayOptions", new DisplayOptions());
            availableCommands.Add("DisplayMessage", new DisplayMessage());
        }
        public void DisplayOptions(List<string> options)
        {
            IContextObserver command = (IContextObserver)availableCommands["DisplayOptions"];
            command.ChangeContext(options);
            ICommand displayOptions = availableCommands["DisplayOptions"];
            displayOptions.Execute();
        }

        public void DisplayMessage(string message)
        {
            IContextObserver command = (IContextObserver)availableCommands["DisplayMessage"];
            command.ChangeContext(message);
            ICommand displayMessage = availableCommands["DisplayMessage"];
            displayMessage.Execute();
        }

    }
}
