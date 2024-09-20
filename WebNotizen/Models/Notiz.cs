using System.ComponentModel.DataAnnotations;

namespace WebNotizen.Models
{
    public class Notiz
    {
        public int NotizId { get; set; }

        [Required]
        [Display(Name = "Category")] //Setzt die Anzeige auf Category
        public int? CategoryId { get; set; }

        [Required] // <- Wird ueberprueft
        public string Title { get; set; } = string.Empty;

        [Required] // <- Wird ueberprueft
        public string Text { get; set; } = string.Empty;
        public Category? Category { get; set; }
        public DateTime TimeStamp { get; set; }

    }
}
