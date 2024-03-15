using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTracker.Model
{
    public class AbortOperationException : Exception
    {
        public AbortOperationException() : base("Operation aborted") { }
    }

}
