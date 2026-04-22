using System.ComponentModel.DataAnnotations;

namespace ProductAPIDemo.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        // Navigation property: One Category can have many Products
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
