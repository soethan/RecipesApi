using FluentNHibernate.Mapping;
using Recipes.Models;

namespace Recipes.DataAccess
{
    public class RecipeStepMap : ClassMap<RecipeStep>
    {
        public RecipeStepMap()
        {
            Id(x => x.RecipeStepId);

            Map(x => x.StepNo);
            Map(x => x.Instructions);
            HasMany(x => x.RecipeItems).KeyColumn("RecipeStepId").Inverse();
            Table("RecipeSteps");
        }
    }
}
