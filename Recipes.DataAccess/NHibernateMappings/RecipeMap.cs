using FluentNHibernate.Mapping;
using Recipes.Models;

namespace Recipes.DataAccess
{
    public class RecipeMap : ClassMap<Recipe>
    {
        public RecipeMap()
        {
            Id(x => x.RecipeId);
            Map(x => x.Name);
            Map(x => x.Comments);
            Map(x => x.ModifyDate);
            HasMany(x => x.Steps).KeyColumn("RecipeId").Inverse().OrderBy("StepNo Asc");
            Table("Recipes");
        }
    }
}
