namespace BlogProject.Model.Entities.Concrete
{
    public class UserFollowCategory
    {
        // composite key => primary key + foreign key
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public int AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }

    }
}