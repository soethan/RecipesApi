using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesApp.Api.ViewModels
{
	[ProtoContract]
	public class RecipeStepDto
	{
		[ProtoMember(1)]
		public Guid RecipeStepId { get; set; }
		[ProtoMember(2)]
		public int StepNo { get; set; }
		[ProtoMember(3)]
		public string Instructions { get; set; }
		[ProtoMember(4)]
		public IList<RecipeItemDto> RecipeItems { get; set; }
	}
}
