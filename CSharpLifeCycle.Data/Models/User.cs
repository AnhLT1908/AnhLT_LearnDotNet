using System.ComponentModel.DataAnnotations;

namespace CSharpLifeCycle.Models
{
	public class User
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(50)]
		public string Username { get; set; } = string.Empty;

		[Required]
		[MaxLength(200)]
		public string Password { get; set; } = string.Empty;

		[MaxLength(100)]
		public string? FullName { get; set; }

		[MaxLength(20)]
		public string Role { get; set; } = "User";
	}
}