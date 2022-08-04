﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Web.Models.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage ="bu alan boş olamaz.")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "bu alan boş olamaz.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
