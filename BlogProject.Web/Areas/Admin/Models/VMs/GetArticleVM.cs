using BlogProject.Model.Entities.Concrete;
using BlogProject.Model.Enums;
using System.Collections.Generic;

namespace BlogProject.Web.Areas.Admin.Models.VMs
{
    public class GetArticleVM
    {
        // LİST actionında kullanacağım propları toparlamak amacıyla kullandım.

        public int ArticleID { get; set; }  // actionLinklerde kulllanacğız update-delet-detail vb.

        public string Title { get; set; }

        public string Content { get; set; }

        public string ImagePath { get; set; }

        public string UserFullName { get; set; }  // appUser

        public string CategoryName { get; set; }  // category
        public int LikeCount { get; set; }
        public Statu Statu { get; set; }
        public bool IsLiked { get; set; }
        public List<Like> Likes { get; set; }

    }
}
