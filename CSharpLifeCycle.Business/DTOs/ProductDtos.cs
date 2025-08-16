using System.ComponentModel.DataAnnotations;

namespace CSharpLifeCycle.DTOs
{
	public class ProductCreateUpdateDto
	{
		[Required][MaxLength(100)] public string Name { get; set; } = string.Empty;
		[Range(0, 100000000)] public decimal Price { get; set; }
		[Range(0, int.MaxValue)] public int Stock { get; set; }
		[MaxLength(500)] public string? Description { get; set; }
	}

	public class ProductResponse
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public decimal Price { get; set; }
		public int Stock { get; set; }
		public string? Description { get; set; }
	}
}