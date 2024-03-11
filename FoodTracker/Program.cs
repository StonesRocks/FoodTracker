namespace FoodTracker
{
    internal class Program
    {
        // Singleton
            // Input methods, such as ManualInput, BarcodeInput, and ImageInput
                // There's no need to have multiple instances of these classes, so they are singletons so that the program can access the same instance of the class from anywhere in the program
        
        // Factory
            // Factory for creating ingredients and recipes
            // The IngredientFactory produces fresh, frozen and dry ingredients
                // We have a factory interface and a an ingredient interface
                // We can create a factory for ingredients and expand on it later on
                    // IngredientFactory is the main factory as of now and it procudes fresh, frozen and dry ingredients objects
            // RecipeFactory produces recipes
                // RecipeFactory create objects using IRecipe interface, provides an interface for recipes and enables us to get recipes from the database or manually create them.

        // Decorator
            // Ingredients have a dictionary with property name as key and the value contains the property information
            // We use a the decorator abstract class to create Decorators that manipulate these properties and we can add more decorators later on
                // PriceDecorator takes the ingredient material measurement and price to calculate the price of the ingredient per material

        // Observer
            // 

        // Strategy
            // Merge Sort or Quick Sort
            // We might consider using different sorting algorithms depending on the size. We can use the strategy pattern to switch between different sorting algorithms

        // Plan
        // 


        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            View view = new View();
        }
    }
}
