using System.ComponentModel.DataAnnotations;

namespace ProductAPIDemo.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(200)]
        public string Address { get; set; } = string.Empty;

        [MaxLength(50)]
        public string ContactNumber { get; set; } = string.Empty;

        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        // Navigation property: One Supplier can have many Products
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
