using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesApp.Api.ViewModels
{
	[ProtoContract]
	public class RecipeItemDto
	{
		[ProtoMember(1)]
		public Guid ItemId { get; set; }
		[ProtoMember(2)]
		public string Name { get; set; }
		[ProtoMember(3)]
		public float Quantity { get; set; }
		[ProtoMember(4)]
		public string MeasurementUnit { get; set; }
	}
}
