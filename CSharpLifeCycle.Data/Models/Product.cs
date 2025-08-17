using System.ComponentModel.DataAnnotations;

namespace CSharpLifeCycle.Data.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [Range(0, 100000000)]
        public decimal Price { get; set; }
        [Range(0, int.MaxValue)]
        public int Stock { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
    }
}