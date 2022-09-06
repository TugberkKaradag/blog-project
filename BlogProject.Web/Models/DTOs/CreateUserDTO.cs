using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BlogProject.Web.Models.DTOs
{
    public class CreateUserDTO
    {
        [Required(ErrorMessage = "alan boş bırakılamaz")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "alan boş bırakılamaz")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "alan boş bırakılamaz")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "alan boş bırakılamaz")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$")]
        [StringLength(100, ErrorMessage = "{0} en az {2} karakter olmalıdır.", MinimumLength = 6)]
        public string Password { get; set; }

        public string ImagePath { get; set; }

        [Required(ErrorMessage = "alan boş bırakılamaz")]
        public IFormFile Image { get; set; }

        [Required(ErrorMessage = "alan boş bırakılamaz")]
        [DataType(DataType.EmailAddress)]
        public string Mail { get; set; }


    }
}
