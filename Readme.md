1)instructions for how to compile and run the software

-Recipe App
This recipe app allows you to create, filter, and view recipes with their ingredients and steps.

-Features
Add new recipes with a name, food group, ingredients, and steps.
Filter recipes based on ingredient name, food group, and total calories.
View recipe details including ingredients and steps.
Refresh the recipe list to see the latest changes.

-Getting Started

To use the app, follow these steps:

Clone the repository to your local machine.
Open the project in Visual Studio or any other compatible IDE.
Build the project to restore dependencies and compile the code.
Run the application on a compatible device or simulator.

-Adding a New Recipe

Launch the app.
In the "Add New Recipe" section, enter the recipe name in the "Recipe Name" textbox.
Select the food group from the "Food Group" dropdown.
Click the "Add Ingredient" button to add ingredients to the recipe.
Enter the ingredient name, quantity, measurement, and calories in the respective textboxes.
Click the "Save Ingredient" button to save the ingredient and add it to the recipe.
Enter the steps for the recipe in the "Steps" textbox, one step per line.
Click the "Save Recipe" button to save the recipe.
The recipe will appear in the recipe list.

-Filtering Recipes

In the "Filter Recipes" section, enter an ingredient name in the "Enter ingredient name" textbox to filter recipes that contain that ingredient.
Select a food group from the "Select food group" dropdown to filter recipes belonging to that food group.
Enter a value in the "Enter total calories" textbox to filter recipes with a total calorie count lower than or equal to that value.
Click the "Apply Filters" button to apply the filters.
The recipe list will display the filtered recipes.

-Viewing Recipe Details

In the recipe list, click on a recipe name to view its details.
The recipe details will expand, showing the recipe name, ingredients, and steps.
The ingredients will be listed with their name, quantity, measurement, and calories.
The steps will be listed one after the other.
Scroll down to view all the steps if necessary.

-Refreshing the Recipe List

To see the latest changes or reset the filters, click the "Refresh Recipes" button.
The recipe list will be updated, showing all the recipes.

2) a link to your GitHub repository

https://github.com/Kingh66?tab=repositories

3)a brief description (100 to 200 words) of what i have changed

Background Image: A background image was added to the main page using the ImageBrush class. This provides a visually appealing background for the app.

Recipe Creation: The recipe creation section now includes a scroll viewer to allow easy navigation when creating lengthy recipes. The steps textbox also includes a placeholder and accepts the "Enter" key after each step for better usability.

Recipe Detail Display: The recipe detail section now displays the recipe name, ingredients, and steps in an organized manner. The ingredient and step lists are bound to their respective data sources, making it easy to dynamically update the details based on the selected recipe.

Ingredient Addition: The ingredient addition section now includes a cancel button, allowing users to discard the input and go back to the recipe creation section. This improves the user experience and provides more flexibility when adding ingredients.

Filtering and Refreshing: The filtering functionality allows users to filter recipes based on ingredient name, food group, and total calories. Applying the filters updates the recipe list accordingly. Additionally, a refresh button was added to reset the filters and display all recipes.
