using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTracker.Interface;

namespace FoodTracker.Commands
{
    public class DisplayMessage : ICommand, IContextObserver
    {
        private string context;

        // Constructor
        public DisplayMessage()
        {
            context = "";
        }

        // Observer pattern method to change the context
        public void ChangeContext(object newContext)
        {

            context = (string)newContext;
        }

        // Execute method to display the message
        public void Execute()
        {
            Console.WriteLine(context);
        }
    }

}
