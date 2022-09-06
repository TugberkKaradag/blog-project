using System;

namespace BlogProject.Web.Models.DTOs
{
    public class GetCategoryForComponentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ArticleID { get; set; } // Eğer bu yapıdan makalenin tümünü okumak için detay sayfasına gitmek istersek makale id de tutulmalı.

    }
}
