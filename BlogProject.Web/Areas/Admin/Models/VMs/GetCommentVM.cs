using BlogProject.Model.Enums;

namespace BlogProject.Web.Areas.Admin.Models.VMs
{
    public class GetCommentVM
    {
        // LİST actionında kullanacağım propları toparlamak amacıyla kullandım.

        public int CommentID { get; set; }  // actionLinklerde kulllanacğız update-delet-detail vb.

        public string Text { get; set; }
        public int AppUserId { get; set; }  // appUser

        public int ArticleId { get; set; }  // article
        public string ArticleTitle { get; set; }
        public string UserName { get; set; }

        public Statu statu { get; set; }

    }
}
