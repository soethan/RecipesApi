using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Recipes.Models.Configuration;
using Microsoft.Extensions.Options;
using Recipes.DataAccess;
using Recipes.Models;
using AutoMapper;
using RecipesApp.Api.ViewModels;

namespace RecipesApp.Api.Controllers
{
    [Route("api/recipes")]
    public class RecipesController : Controller
    {
		private readonly IOptions<AppSettings> _appSettings;
		private readonly IRecipesRepository _recipesRepository;
		
		public RecipesController(IOptions<AppSettings> appSettings, IRecipesRepository recipesRepository)
		{
			Mapper.Initialize(cfg => {
				cfg.CreateMap<RecipeItem, RecipeItemDto>();
				cfg.CreateMap<RecipeStep, RecipeStepDto>();
				cfg.CreateMap<Recipe, RecipeDto>();
			});
			_appSettings = appSettings;
			_recipesRepository = recipesRepository;
		}

		[HttpGet]
		public IActionResult Get()
		{
			var dest = Mapper.Map<IList<Recipe>, IList<RecipeDto>>(_recipesRepository.GetAllRecipes());
			return Ok(dest);
		}

		//[HttpGet]
		//public IEnumerable<string> Get()
		//{
		//	return new string[] { _appSettings.Value.Database.ConnectionString };
		//}
	}
}