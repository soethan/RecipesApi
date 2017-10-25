using Recipes.Models;
using System;
using System.Collections.Generic;

namespace Recipes.DataAccess
{
	public interface IRecipesRepository
    {
		IList<Recipe> GetAllRecipes();
		Recipe GetRecipe(Guid id);
		Recipe AddRecipe(Recipe recipe);
		void UpdateRecipe(Recipe recipe);
		void DeleteRecipe(Guid id);
	}
}
