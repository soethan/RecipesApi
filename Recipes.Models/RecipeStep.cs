using System;
using System.Collections.Generic;

namespace Recipes.Models
{
    public class RecipeStep
    {
        public virtual Guid RecipeStepId { get; set; }
        public virtual int StepNo { get; set; }
        public virtual string Instructions { get; set; }
        public virtual IList<RecipeItem> RecipeItems { get; set; }
    }
}
