using BlogProject.Model.Enums;
using System.ComponentModel.DataAnnotations;

namespace BlogProject.Web.Areas.Admin.Models.DTOs
{
    public class UpdateAppUserDTO
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Bu alan bş bırakılamaz!")]
        [MinLength(2), MaxLength(100)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Bu alan bş bırakılamaz!")]
        [MinLength(2), MaxLength(100)]

        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Mail { get; set; }
        private Statu _status = Statu.Active;
        public Statu Statu
        {
            get { return _status; }
            set { _status = value; }
        }

    }
}
