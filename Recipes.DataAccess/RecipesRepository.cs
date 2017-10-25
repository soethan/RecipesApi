using System;
using System.Collections.Generic;
using NHibernate;
using Recipes.Models;
using Recipes.DataAccess.Common;

namespace Recipes.DataAccess
{
	public class RecipesRepository: IRecipesRepository
	{
		ISession _session;

		public RecipesRepository()
		{
			_session = SessionFactory.OpenSession();
		}

		public IList<Recipe> GetAllRecipes()
		{
			try
			{
				return _session.QueryOver<Recipe>().List();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public Recipe GetRecipe(Guid id)
		{
			try
			{
				return _session.Get<Recipe>(id);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public Recipe AddRecipe(Recipe recipe)
		{
			Recipe entity = null;
			using (var transaction = _session.BeginTransaction())
			{
				try
				{
					recipe.RecipeId = Guid.NewGuid();
					recipe.ModifyDate = DateTime.Now;
					entity = _session.Save(recipe) as Recipe;
					transaction.Commit();
				}
				catch (StaleObjectStateException ex)
				{
					try
					{
						entity = _session.Merge(recipe);
						transaction.Commit();
					}
					catch
					{
						transaction.Rollback();
						throw;
					}
				}
				return entity;
			}
		}

		public void UpdateRecipe(Recipe recipe)
		{
			using (var transaction = _session.BeginTransaction())
			{
				try
				{
					_session.Update(recipe);
					transaction.Commit();
				}
				catch (StaleObjectStateException ex)
				{
					try
					{
						_session.Merge(recipe);
						transaction.Commit();
					}
					catch
					{
						transaction.Rollback();
						throw;
					}
				}

			}
		}

		public void DeleteRecipe(Guid id)
		{
			using (var transaction = _session.BeginTransaction())
			{
				var recipe = _session.Get<Recipe>(id);
				if (recipe != null)
				{
					try
					{
						_session.Delete(recipe);
						transaction.Commit();
					}
					catch (StaleObjectStateException ex)
					{
						try
						{
							_session.Merge(recipe);
							transaction.Commit();
						}
						catch
						{
							transaction.Rollback();
							throw;
						}
					}
				}
			}
		}
	}
}

