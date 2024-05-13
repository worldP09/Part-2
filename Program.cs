// See https://aka.ms/new-console-template for more information
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
                    recipeManager.DisplayAllRecipe();
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
                    break;
                }

            }
        }
    }
}

class RecipeManager 
{
    //list to store ricipes
    private List<Recipe> recipes =new List<Recipe>();
    //Store oringinal recipe for resetting quantities 
    private List<Recipe> originalRecipes = new List<Recipe>();

    //method to enter details of a new recipe 
    public void EnterRecipeDetails()
    {
        Recipe recipe = new Recipe();

        //prompt user to enter reccipe name 
        Console.WriteLine("Enter Recipe Name: ");
        recipe.Name = Console.ReadLine();

        //Prompt user to enter number of ingredients
        Console.WriteLine("Enter number of ingredients: ");
        int ingredientCount =int.Parse(Console.ReadLine());
        
        //loop to enter details of each ingredient
        for (int i = 0; i < ingredientCount; i++)
        {
            Ingredient ingredient = new Ingredient();

            //prompt user to enter name of the ingredient 
            Console.WriteLine($"Enter Name of Ingredient {i+1}: ");
            ingredient.Name = Console.ReadLine();

            //prompt user to enter quantity of the ingredient 
            Console.WriteLine($"Enter Quantity of {ingredient.Name}: ");
            ingredient.Quantity = double.Parse(Console.ReadLine()); 

            //Prompt the user to enter unit of measurement for the ingredient
            Console.WriteLine($"Enter unit of measurement for {ingredient.Name}: ");
            ingredient.Unit = Console.ReadLine();

            //Prompt user to enter number of calories for the ingredient
            Console.WriteLine($"Enter number of calories for {ingredient.Name}: ");
            ingredient.Calories = int.Parse(Console.ReadLine());

            // Promt user to enter food group for the ingredient
            Console.WriteLine($"Enter food group for {ingredient.Name}: ");
            ingredient.FoodGroup = Console.ReadLine();

            //add the ingredient to the recipe 
            recipe.Ingredients.Add(ingredient);
        }

            //add the recipe to the list of recipes
            recipes.Add(recipe);
            //store original recipe for resetting quantities 
            originalRecipes.Add(recipe);
            Console.WriteLine("Recipe details added successfully!");

    }

    //method to display all recipes
    public void DisplayAllRecipe()
    {
        Console.WriteLine("\nAll Recipe: ");
        foreach (var recipe in recipes)
        {
            Console.WriteLine(recipe.Name);
        }
    }
  //method to select and display a specific recipe
  public void SelectRecipe()
  { 
        Console.WriteLine("\nSelect a recipe: ");
        DisplayAllRecipe();
        Console.Write("Enter recipe name: ");
        string recipeName = Console.ReadLine();
        //check if the entered recipe exists in the list of recipes
        Recipe selectedRecipe = recipes.Find(r => r.Name == recipeName);
        if (selectedRecipe != null)
        {
            Console.WriteLine($"\nSelected Recipe: {selectedRecipe.Name}");
            Console.WriteLine($"Ingredients: ");

            foreach (var ingredient in selectedRecipe.Ingredients)
            {
            Console.WriteLine($"{ingredient.Name}: {ingredient.Quantity} {ingredient.Unit}");
            }
        
            int totalCalories = CalculateTotalCalories(selectedRecipe);
            Console.WriteLine($"Total Calories: {totalCalories}");

            if (totalCalories > 300)
            {
                RecipeExceedsCalories?.Invoke(selectedRecipe.Name);
            }
        }
        else
        {
        Console.WriteLine("Recipe not found.");
        }
    }

    //Method to scale the recipe by a factor
    public void ScaleRecipe()
    {
        Console.WriteLine("\nEnter scaling factor (0.5, 2 or 3: ");
        double factor = Double.Parse(Console.ReadLine());

        foreach (var recipe in recipes)
        {
            foreach(var ingredient in recipe.Ingredients)
                {
                ingredient.Quantity *= factor;
                }
        }
        Console.WriteLine("Recipe(s) scaled successfully.");

    }

    //Method to reset ingredient quantities to their original values
    public void ResetQuantities()
    {
        //restore original recipe
        
        recipes.Clear();
        Console.WriteLine("Quantities reset to original  values.");
    }
    // Method to clear all entered recipe data to allow entering a new recipe 
    public void ClearAllData()
    {
        recipes.Clear();
        originalRecipes.Clear();
        Console.WriteLine("All data cleared.");
    }

    //method to calculate total calories of a recipe
    public int CalculateTotalCalories(Recipe recipe)
    {
        int totalCalories = 0;
        foreach (var ingredient in recipe.Ingredients)
        {
            totalCalories += ingredient.Calories;
        }
        return totalCalories;
    }
    //Delegate and event to notify when a recipe exceeds 300 calories
    public delegate void RecipeExceedsCaloriesHandler(string recipeName);
    public event RecipeExceedsCaloriesHandler RecipeExceedsCalories;
}
/// <summary>
/// class to represent a recipe
/// </summary>
class Recipe 
{
    public string Name { get; set; }
    public List<Ingredient> Ingredients{get; set; } = new List<Ingredient>(); 
}
//Class to represent an ingredient 
class Ingredient
{
    public string Name { get; set; }
    public double Quantity {get; set;}
    public string Unit {get; set; }
    public int Calories {get; set; }
    public string FoodGroup {get; set; }
};


