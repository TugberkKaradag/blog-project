using BlogProject.Model.Entities.Abstract;
using System.Collections.Generic;

namespace BlogProject.Model.Entities.Concrete
{
    public class Category : BaseEntity
    {
        public Category()
        {
            Articles = new List<Article>();
            UserFollowCategories = new List<UserFollowCategory>();
        }

        public string Name { get; set; }
        public string Description { get; set; }

        // navigation Property

        // 1 kategorinin çokça makalesi olabilir.
        public virtual List<Article> Articles { get; set; }

        // 1 kategori çokça kullanıcı tarafından takip edilebilir.

        public virtual List<UserFollowCategory> UserFollowCategories { get; set; }

    }
}