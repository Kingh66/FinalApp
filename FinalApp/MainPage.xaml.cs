using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace FinalApp
{
    public sealed partial class MainPage : Page
    {
        // List to hold our Recipes
        private List<Recipe> Recipes = new List<Recipe>();
        // A currentRecipe object to handle current recipe in focus
        private Recipe currentRecipe = new Recipe();

        public MainPage()
        {
            this.InitializeComponent();

            // Add items to the ComboBox
            FoodGroupComboBox.Items.Add("Pasta");
            FoodGroupComboBox.Items.Add("Poultry");
            FoodGroupComboBox.Items.Add("Vegetables");
            FoodGroupComboBox.Items.Add("Grains");
            FoodGroupComboBox.Items.Add("Seafood");
            FoodGroupComboBox.Items.Add("Dairy");
            FoodGroupComboBox.Items.Add("Fruits");
            FoodGroupComboBox.Items.Add("Desserts");

            // Create some initial data
            Recipes = new List<Recipe>
            {
                new Recipe
                {
                    Name = "Spaghetti Bolognese",
                    FoodGroup = "Pasta",
                    Steps = new List<string>
                    {
                        "Cook spaghetti according to package instructions.",
                        "In a large pan, cook the minced beef until brown.",
                        "Add the onions and garlic and cook until softened.",
                        "Add the tomato sauce and simmer for 15 minutes.",
                        "Serve the sauce over the cooked spaghetti."
                    },
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient { Name = "Spaghetti", Quantity = "200", Measurement = "g", Calories = 300 },
                        new Ingredient { Name = "Minced beef", Quantity = "400", Measurement = "g", Calories = 1000 },
                        new Ingredient { Name = "Onions", Quantity = "1", Measurement = "large", Calories = 50 },
                        new Ingredient { Name = "Garlic", Quantity = "3", Measurement = "cloves", Calories = 15 },
                        new Ingredient { Name = "Tomato sauce", Quantity = "1", Measurement = "cup", Calories = 100 }
                    }
                },
                new Recipe
                {
                    Name = "Roasted Chicken",
                    FoodGroup = "Poultry",
                    Steps = new List<string>
                    {
                        "Preheat the oven to 425°F (220°C).",
                        "Rub the chicken with olive oil, salt, and pepper.",
                        "Place the chicken in a roasting pan.",
                        "Roast for 1 hour or until the internal temperature reaches 165°F (74°C).",
                        "Let the chicken rest for 10 minutes before serving."
                    },
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient { Name = "Whole chicken", Quantity = "1", Measurement = "", Calories = 1200 },
                        new Ingredient { Name = "Olive oil", Quantity = "2", Measurement = "tbsp", Calories = 240 },
                        new Ingredient { Name = "Salt", Quantity = "1", Measurement = "tsp", Calories = 0 },
                        new Ingredient { Name = "Pepper", Quantity = "1/2", Measurement = "tsp", Calories = 0 }
                    }
                },
                new Recipe
                {
                    Name = "Vegetable Stir-Fry",
                    FoodGroup = "Vegetables",
                    Steps = new List<string>
                    {
                        "Heat oil in a large skillet or wok over medium-high heat.",
                        "Add vegetables and stir-fry for 5-7 minutes until tender-crisp.",
                        "In a small bowl, whisk together soy sauce, ginger, and garlic.",
                        "Pour the sauce over the vegetables and cook for an additional 2 minutes.",
                        "Serve hot with rice or noodles."
                    },
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient { Name = "Broccoli", Quantity = "2", Measurement = "cups", Calories = 60 },
                        new Ingredient { Name = "Carrots", Quantity = "2", Measurement = "large", Calories = 90 },
                        new Ingredient { Name = "Soy sauce", Quantity = "2", Measurement = "tbsp", Calories = 30 },
                        new Ingredient { Name = "Ginger", Quantity = "1", Measurement = "tsp", Calories = 5 },
                        new Ingredient { Name = "Garlic", Quantity = "3", Measurement = "cloves", Calories = 15 }
                    }
                },
                new Recipe
                {
                    Name = "Penne Alfredo",
                    FoodGroup = "Pasta",
                    Steps = new List<string>
                    {
                        "Cook penne pasta according to package instructions.",
                        "In a saucepan, melt butter and sauté garlic.",
                        "Add heavy cream and Parmesan cheese. Stir until the cheese has melted.",
                        "Toss the cooked pasta in the sauce until well coated.",
                        "Serve hot with grated Parmesan cheese on top."
                    },
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient { Name = "Penne pasta", Quantity = "8", Measurement = "oz", Calories = 400 },
                        new Ingredient { Name = "Butter", Quantity = "4", Measurement = "tbsp", Calories = 400 },
                        new Ingredient { Name = "Garlic", Quantity = "2", Measurement = "cloves", Calories = 10 },
                        new Ingredient { Name = "Heavy cream", Quantity = "1", Measurement = "cup", Calories = 800 },
                        new Ingredient { Name = "Parmesan cheese", Quantity = "1/2", Measurement = "cup", Calories = 200 }
                    }
                }
                //... other recipes
            };

            RefreshRecipesList();
        }

        private void AddIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            RecipeStackPanel.Visibility = Visibility.Collapsed;
            IngredientStackPanel.Visibility = Visibility.Visible;
        }

        private void SaveIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            // Save the ingredient logic

            // Clearing the ingredient fields after saving
            IngredientNameTextBox.Text = string.Empty;
            QuantityTextBox.Text = string.Empty;
            MeasurementTextBox.Text = string.Empty;
            CaloriesTextBox.Text = string.Empty;

            // Go back to the recipe creation section
            IngredientStackPanel.Visibility = Visibility.Collapsed;
            RecipeStackPanel.Visibility = Visibility.Visible;
        }

        private void CancelIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            // Clearing the ingredient fields
            IngredientNameTextBox.Text = string.Empty;
            QuantityTextBox.Text = string.Empty;
            MeasurementTextBox.Text = string.Empty;
            CaloriesTextBox.Text = string.Empty;

            // Go back to the recipe creation section
            IngredientStackPanel.Visibility = Visibility.Collapsed;
            RecipeStackPanel.Visibility = Visibility.Visible;
        }
        private void ApplyFiltersButton_Click(object sender, RoutedEventArgs e)
        {
            string ingredientFilter = IngredientFilterTextBox.Text.Trim();
            string foodGroupFilter = (FoodGroupFilterComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            int.TryParse(CaloriesFilterTextBox.Text, out int caloriesFilter);

            // Apply the filters
            var filteredRecipes = Recipes.Where(recipe =>
                (string.IsNullOrEmpty(ingredientFilter) || recipe.Ingredients.Any(ingredient => ingredient.Name.Contains(ingredientFilter))) &&
                (foodGroupFilter == "All" || recipe.FoodGroup == foodGroupFilter) &&
                (caloriesFilter <= 0 || recipe.Ingredients.Sum(ingredient => ingredient.Calories) <= caloriesFilter)
            ).ToList();

            // Update the recipe list
            RecipeListBox.ItemsSource = filteredRecipes;
        }


        private void ClearFiltersButton_Click(object sender, RoutedEventArgs e)
        {
            // Clear the filter controls
            IngredientFilterTextBox.Text = string.Empty;
            FoodGroupFilterComboBox.SelectedIndex = 0;
            CaloriesFilterTextBox.Text = string.Empty;

            // Refresh the recipe list
            RefreshRecipesList();
        }



        private void SaveRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            Recipe recipe = new Recipe();
            recipe.Name = RecipeNameTextBox.Text;
            recipe.FoodGroup = FoodGroupComboBox.SelectedValue.ToString();
            recipe.Steps.AddRange(StepsTextBox.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries));

            // Create a new ingredient and add it to the recipe
            Ingredient ingredient = new Ingredient
            {
                Name = IngredientNameTextBox.Text,
                Quantity = QuantityTextBox.Text,
                Measurement = MeasurementTextBox.Text
            };

            int calories;
            if (int.TryParse(CaloriesTextBox.Text, out calories))
            {
                ingredient.Calories = calories;
            }
            else
            {
                // Set a default value or handle the error case
                ingredient.Calories = 0;
            }

            recipe.Ingredients.Add(ingredient);

            // Add the recipe to the Recipes list
            Recipes.Add(recipe);

            // Clear the input fields
            RecipeNameTextBox.Text = string.Empty;
            FoodGroupComboBox.SelectedIndex = -1;
            StepsTextBox.Text = string.Empty;
            IngredientNameTextBox.Text = string.Empty;
            QuantityTextBox.Text = string.Empty;
            MeasurementTextBox.Text = string.Empty;
            CaloriesTextBox.Text = string.Empty;

            // Refresh the recipe list in the ListBox
            RefreshRecipesList();
        }







        private void RefreshRecipesButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshRecipesList();

        }

        private void RecipeListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedRecipe = RecipeListBox.SelectedItem as Recipe;
            if (selectedRecipe != null)
            {
                RecipeDetailsStackPanel.DataContext = selectedRecipe;
                IngredientList.ItemsSource = selectedRecipe.Ingredients.Select(i =>
                    $"{i.Name}, {i.Quantity} {i.Measurement}, {i.Calories} calories"
                );
                StepList.ItemsSource = selectedRecipe.Steps;
                RecipeDetailsStackPanel.Visibility = Visibility.Visible;
            }
            else
            {
                RecipeDetailsStackPanel.Visibility = Visibility.Collapsed;
            }
        }

        // Method to refresh the recipes in the ListBox
        private void RefreshRecipesList()
        {
            RecipeListBox.ItemsSource = null;
            RecipeListBox.ItemsSource = Recipes.OrderBy(recipe => recipe.Name);
        }
    }

    public class Ingredient
    {
        public string Name { get; set; }
        public string Quantity { get; set; }
        public string Measurement { get; set; }
        public int Calories { get; set; }
    }

    public class Recipe
    {
        public string Name { get; set; }
        public string FoodGroup { get; set; }
        public List<string> Steps { get; set; }
        public List<Ingredient> Ingredients { get; set; }

        public Recipe()
        {
            Steps = new List<string>();
            Ingredients = new List<Ingredient>();
        }
    }
}
