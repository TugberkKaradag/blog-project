using BlogProject.Model.Entities.Concrete;
using System;
using System.Collections.Generic;

namespace BlogProject.Web.Models.DTOs
{
    public class GetArticleForNonUserComponentDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string CategoryName { get; set; }
        public DateTime CreatedDate { get; set; }

        public int ConsumeTime { get; set; }
        public string Image { get; set; }
        public string UserFullName { get; set; }

        public int UserId { get; set; } // eğer bu yapıdan yazarı profil sayfasına gitmek istersek id biilgisini tutmalıyız.

        public int ArticleID { get; set; } // Eğer bu yapıdan makalenin tümünü okumak için detay sayfasına gitmek istersek makale id de tutulmalı.

        public List<Comment> Comments { get; set; }

        public List<Like> Likes { get; set; }
        public int LikeCount { get; set; }

        public bool IsLiked { get; set; }
    }
}
