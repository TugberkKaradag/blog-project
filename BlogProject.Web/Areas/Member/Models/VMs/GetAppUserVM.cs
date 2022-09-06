using BlogProject.Model.Entities.Concrete;
using System;
using System.Collections.Generic;

namespace BlogProject.Web.Areas.Member.Models.VMs
{
    public class GetAppUserVM
    {
        // LİST actionında kullanacağım propları toparlamak amacıyla kullandım.

        public List<Article> Articles { get; set; }  // actionLinklerde kulllanacğız update-delet-detail vb.
        public int AppUserId { get; set; }  // appUser
        public string UserName { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ImagePathForAppUser { get; set; }

        public DateTime CreatedDate { get; set; }

        public int ArticleCount { get; set; }


    }
}
