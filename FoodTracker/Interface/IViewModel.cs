using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTracker.Interface
{
    public interface IViewModel
    {
        void DisplayOptions(List<string> options);

        void DisplayMessage(string message);

        string GetInput(string message);
        int GetChoice(List<string> options);
        int GetChoiceInput(List<string> options);
    }
}
