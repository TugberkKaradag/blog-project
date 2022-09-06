using BlogProject.Model.Entities.Abstract;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogProject.Model.Entities.Concrete
{
    public class Article : BaseEntity
    {
        public Article()
        {
            Comments = new List<Comment>();
            Likes = new List<Like>();
        }
        public string Title { get; set; }

        public string Content { get; set; }

        public string ImagePath { get; set; }  // dosya yolunu tutacak

        [NotMapped]
        public IFormFile Image { get; set; } // dosyayı okuyup,kaydedecek.

        //naviigation Property

        // 1 makalenin 1 oluşturucusu
        public int AppUserId { get; set; }

        public virtual AppUser AppUser { get; set; }

        // 1 makalenin 1 kategorisi
        public List<int> CategoryId { get; set; }
        public virtual List<Category> Category { get; set; }

        // 1 makalenin çokça yorumu
        public virtual List<Comment> Comments { get; set; }

        // 1 makalenin çokça beğenisi
        public virtual List<Like> Likes { get; set; }

    }
}