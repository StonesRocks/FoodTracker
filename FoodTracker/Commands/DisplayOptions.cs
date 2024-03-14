using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTracker.Interface;

namespace FoodTracker.Commands
{
    public class DisplayOptions : ICommand, IContextObserver
    {
        private List<string> context;

        public DisplayOptions()
        {
            context = new List<string>();
        }

        public void ChangeContext(object newContext)
        {
            context = (List<string>)newContext;
        }

        public void Execute()
        {
            for (int i = 0; i < context.Count; i++)
            {
                Console.WriteLine($"[{i}]. {context[i]}");
            }
        }
    }
}
