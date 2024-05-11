using System;
using System.Collections.Generic;

//main class of the application 
namespace Recipeapp
{
    //main class of the application 
    class Program
    {
        // main method to start the program 
        static void Main(string[] args)
        {
            // create an instance of recipemanager to manage recipes
            RecipeManager recipeManager = new RecipeManager();
            bool exit = false;

            //main menu loop 
            while (!exit)
            {

                // Display menu options to the user 
                Console.WriteLine("1. Enter Recipe Details");
                Console.WriteLine("2. Dispaly All Recipes");
                Console.WriteLine("3. Select Recipe");
                Console.WriteLine("4. Scale Recipe");
                Console.WriteLine("5. Reset Quantities");
                Console.WriteLine("6. Clear All Data");
                Console.WriteLine("7. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                //Switch statement to handle user choice
                switch (choice)
                {
                    case "1":
                    // call method to enter recipe details
                    recipeManager.EnterRecipeDetails();
                    break;
                    case "2":
                    // call method to display all recipes
                    recipeManager.DisplayAllRecipes();
                    break;
                    case "3":
                    // Call method to select and display a specific recipe
                    recipeManager.SelectRecipe();
                    break;
                    case "4":
                    // Call method to scale the recipe
                    recipeManager.ScaleRecipe();

                    break;
                    case "5":
                    // Call method to reset quantities
                    recipeManager.ScaleRecipe();
                    break;
                    case "6":
                    // Call method to clear all data
                    recipeManager.ClearAllData();
                    break;
                    case "7":
                    // Set exit flag to true to exit the loop
                    exit = true;
                    break;
                    default:
                    Console.WriteLine("Invalid Choice! Please try again.");
                    break
                }

            }
        }
    }
}
