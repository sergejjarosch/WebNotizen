using System.Data;

namespace WebNotizen.Models
{
    public class NotizenRepository
    {
        private static List<Notiz> _notizen = new List<Notiz>()
        {
            new Notiz { NotizId = 1, CategoryId = 1, Title = "Project Init", TimeStamp = DateTime.Now, Text ="Project was created. The structure is still being worked on." },
            new Notiz { NotizId = 2, CategoryId = 1, Title = "Create DB",TimeStamp = DateTime.Now, Text ="The database design still needs to be created. Before that, we should talk about the customer's requirements."},
            new Notiz { NotizId = 3, CategoryId = 2, Title = "Design Wishes", TimeStamp = DateTime.Now, Text ="The customer's wishes have been taken into account and the design is currently being developed"},
            new Notiz { NotizId = 4, CategoryId = 2, Title = "Design Concept", TimeStamp = DateTime.Now, Text = "The design has been adapted and can be assessed by Frontender to see if it is feasible." }
        };

        public static void AddNotiz(Notiz product)
        {
            var maxId = _notizen.Max(x => x.NotizId);
            product.NotizId = maxId + 1;
            product.TimeStamp = DateTime.Now;
            _notizen.Add(product);
        }

        public static List<Notiz> GetNotiz(bool loadCategory = false)
        {
            if (!loadCategory)
            {
                return _notizen;
            }
            else
            {
                if (_notizen != null && _notizen.Count > 0)
                {
                    _notizen.ForEach(x =>
                    {
                        if (x.CategoryId.HasValue)
                            x.Category = CategoriesRepository.GetCategoryById(x.CategoryId.Value);
                    });
                }
                return _notizen ?? new List<Notiz>();
            }
        }

        public static Notiz? GetNotizById(int notizId, bool loadCategory = false)
        {
            var notiz = _notizen.FirstOrDefault(x => x.NotizId == notizId);
            if (notiz != null)
            {
                var prod = new Notiz
                {
                    NotizId = notiz.NotizId,
                    Title = notiz.Title,
                    Text = notiz.Text,
                    CategoryId = notiz.CategoryId,
                    TimeStamp = notiz.TimeStamp,
                };

                if (loadCategory && prod.CategoryId.HasValue)
                {
                    prod.Category = CategoriesRepository.GetCategoryById(prod.CategoryId.Value);
                }
                return prod;
            }
            return null;
        }

        public static void UpdateNotiz(int notizId, Notiz notiz)
        {
            if (notizId != notiz.NotizId) return;

            var notizToUpdate = _notizen.FirstOrDefault(x => x.NotizId == notizId);
            if (notizToUpdate != null)
            {
                notizToUpdate.Title = notiz.Title;
                notizToUpdate.Text = notiz.Text;
                notizToUpdate.CategoryId = notiz.CategoryId;
            }
        }

        public static void DeleteNotiz(int notizId)
        {
            var notiz = _notizen.FirstOrDefault(x => x.NotizId == notizId);
            if (notiz != null)
            {
                _notizen.Remove(notiz);
            }
        }

        public static List<Notiz> GetNotizByCategoryId(int categoryId)
        {
            var notiz = _notizen.Where(x => x.CategoryId == categoryId);
            if (notiz != null)
                return notiz.ToList();
            else
                return new List<Notiz>();
        }

    }
}
