using BlogProject.Model.Entities.Concrete;
using System.Collections.Generic;

namespace BlogProject.Web.Areas.Member.Models.VMs
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
        public int appUserId { get; set; }
        public int LikeCount { get; set; }

        public bool IsLiked { get; set; }

        public List<Like> Likes { get; set; }

        public List<Comment> Comments { get; set; }

    }
}
