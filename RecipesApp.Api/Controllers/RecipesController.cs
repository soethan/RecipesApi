using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Recipes.Models.Configuration;
using Microsoft.Extensions.Options;
using Recipes.DataAccess;
using Recipes.Models;

namespace RecipesApp.Api.Controllers
{
    [Route("api/recipes")]
    public class RecipesController : Controller
    {
		private readonly IOptions<AppSettings> _appSettings;
		private readonly IRecipesRepository _recipesRepository;
		
		public RecipesController(IOptions<AppSettings> appSettings, IRecipesRepository recipesRepository)
		{
			_appSettings = appSettings;
			_recipesRepository = recipesRepository;
		}

		[HttpGet]
		public IEnumerable<Recipe> Get()
		{
			return _recipesRepository.GetAllRecipes();
		}

		//[HttpGet]
		//public IEnumerable<string> Get()
		//{
		//	return new string[] { _appSettings.Value.Database.ConnectionString };
		//}
	}
}