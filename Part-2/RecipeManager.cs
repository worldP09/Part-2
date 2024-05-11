class RecipeManager 
{
    //list to store ricipes
    private list<Recipe> recipes =new list<Recipe>();
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
            Console.WriteLine($"Enter Quantity of {ingredient.name}: ");
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
            originalRecipes.add(recipe);
            Console.WriteLine("Recipe details added successfully!");

    }

    //method to display all recipes
    public void DisplayAllRecipe()
    {
        Console.WriteLine("\nAll Recipe: ");
        foreach (var recipe in recipes)
        {
            Console.WriteLine(recipe.Name)
        }
    }
  //method to select and display a specific recipe
  public void SelectRecipe()
  { Console.WriteLine("\nSelect a recipe: ");
  DisplayAllRecipe();
  Console.Write("Enter recipe name: ");
  string recipeName = Console.ReadLine();

  RecipeManager selectedRecipe = recipeName.Find(r => r.Name == recipeName);
  if (selectedRecipe != null)
  {
    Console.WriteLine($"\nSelected Recipe: {selectedRecipe.Name}");
    Console.WriteLine($"Ingredients: ");

    foreach (var ingredient in selectedRecipe.Ingredients)
    {Console.WriteLine($"{ingredient.Name}: {ingredient.Quantity} {ingredient.Unit}")}
  }
  int totalCalories = CalculateTotalCalories(selectedRecipe);
  Console.WriteLine($"Total Calories: {totalCalories}");

  if (totalCalories > 300)
  {
    RRecipeExceedsCalories?.Invoke(selectedRecipe.Name);
    
     }
  }
    else
    {
        Console.WriteLine("Recipe not found.");
    }


//Method to scale the recipe by a factor
    public void ScaleRecipe()
    {
        Console.WriteLine("\nEnter scaling factor (0.5, 2 or 3: ");
        double factor = Double.Parse(Console.ReadLine());

        foreach (var recipe in recipe)
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
        RecipeManager.Clear();
        recipes.AddRange(originalRecipe);
        Console.WriteLine("Quantities reset to original  values.");
    }
    // Method to clear all entered recipe data to allow entering a new recipe 
    public void ClearAllData()
    {
        Recipes.Clear();
        originalReccipe.Clear();
        Console.WriteLine("All data cleared.");
    }

    //
}