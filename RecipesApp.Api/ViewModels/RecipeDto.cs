using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesApp.Api.ViewModels
{
	[ProtoContract]
	public class RecipeDto
	{
		[ProtoMember(1)]
		public Guid RecipeId { get; set; }
		[ProtoMember(2)]
		public string Name { get; set; }
		[ProtoMember(3)]
		public string Comments { get; set; }
		[ProtoMember(4)]
		public DateTime ModifyDate { get; set; }
		[ProtoMember(5)]
		public IList<RecipeStepDto> Steps { get; set; }

	}
}
