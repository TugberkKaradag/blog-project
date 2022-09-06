using BlogProject.Model.Entities.Concrete;
using System.Collections.Generic;

namespace BlogProject.Web.Areas.Member.Models.DTOs
{
    public class GetCategoryForFollowsDTO
    {
        // her bir kategori için o kategoriye ait yalnızca id ve isim bilgiisnin taşınması için bu dto yu oluşturmayı tercih ettik.

        public int ID { get; set; }  // categoryID

        public string Name { get; set; } // categoryName

        public List<UserFollowCategory> UserFollowCategories { get; set; }

        public bool IsFollowing { get; set; }

        public int AppuserId { get; set; }
    }
}
