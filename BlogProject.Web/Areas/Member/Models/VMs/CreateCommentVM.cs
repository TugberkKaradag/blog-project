using System.ComponentModel.DataAnnotations;

namespace BlogProject.Web.Areas.Member.Models.VMs
{
    public class CreateCommentVM
    {
        // article

        [Required(ErrorMessage = "bu alan boş bırakılamaz")]
        [MaxLength(60)]
        public string Text { get; set; }

        // category

        [Required(ErrorMessage = "bu alan boş bırakılamaz")]
        public int ArticleID { get; set; }

        // USER

        [Required(ErrorMessage = "bu alan boş bırakılamaz")]
        public int AppUserID { get; set; }
        [Required(ErrorMessage = "bu alan boş bırakılamaz")]
        public string ArticleTitle { get; set; }

    }
}
