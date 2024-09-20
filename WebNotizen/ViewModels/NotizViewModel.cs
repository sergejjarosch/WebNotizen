using WebNotizen.Models;

namespace WebNotizen.ViewModels
{
    public class NotizViewModel
    {
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
        public Notiz Notiz { get; set; } = new Notiz();
    }
}
