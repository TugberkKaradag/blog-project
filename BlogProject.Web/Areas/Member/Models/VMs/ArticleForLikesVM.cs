using BlogProject.Model.Entities.Concrete;

namespace BlogProject.Web.Areas.Member.Models.VMs
{
    public class ArticleForLikesVM
    {
        // LİST actionında kullanacağım propları toparlamak amacıyla kullandım.

        public int ArticleID { get; set; }  // actionLinklerde kulllanacğız update-delet-detail vb.

        public string Title { get; set; }

        public string Content { get; set; }

        public string ImagePath { get; set; }

        public string UserFullName { get; set; }  // appUser

        public string CategoryName { get; set; }  // category

        public virtual Like Likes { get; set; }


    }
}
