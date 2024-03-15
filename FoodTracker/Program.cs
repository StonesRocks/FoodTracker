using FoodTracker.Interface;
using FoodTracker.DesignPatterns;
using FoodTracker.Model;

namespace FoodTracker
{
    internal class Program
    {
        // MVVM
            // The overarching architecture uses the MVVM pattern, this allows us to update the view from console to maybe WPF later on

        // Singleton
            // Our database is currently only a json file manager, therefore we make it a singleton so we can communicate with the database from different places 
        
        // Abstract Factory
            // The factories are able to use different input methods to create the ingredients as well as different decorators to add properties to the ingredients
        
        // Decorator
            // The decorator add properties to the ingredients, this makes it easy to add new properties to the ingredients without changing the ingredient class
            // It also makes it easy to create new properties, such as price, expiration date etc

        // Flyweight
            // Our storage only needs the id of the products because we can reference the rest of the product from the database
            
        // Command
            // I apply the command pattern in my view which allows my program to easily execute UI commands
            // My viewmodel uses these commands to display options and messages

        // Observer
            // The Commands are actually composite of command and observer because they use observer to change the context of the command

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            IDatabase database = SaveJson.Instance;
            IViewModel viewModel = new ViewModel();
        }
    }
}
