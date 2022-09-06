using System.ComponentModel.DataAnnotations;

namespace BlogProject.Web.Areas.Member.Models.VMs
{
    public class UpdateCommentVM
    {
        public int ID { get; set; }

        // article

        [Required(ErrorMessage = "bu alan boş bırakılamaz")]
        public string Text { get; set; }

        public int ArticleId { get; set; }


        [Required(ErrorMessage = "bu alan boş bırakılamaz")]
        public int AppUserID { get; set; }
    }
}
