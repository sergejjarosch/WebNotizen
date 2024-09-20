using System.ComponentModel.DataAnnotations;

namespace WebNotizen.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required] // <-- Checks if the data is specified
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
    }
}
