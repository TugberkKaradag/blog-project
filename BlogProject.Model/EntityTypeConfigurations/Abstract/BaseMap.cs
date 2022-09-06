using BlogProject.Model.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogProject.Model.EntityTypeConfigurations.Abstract
{
    public abstract class BaseMap<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        // virtual işaretledik ki kalıtım alanlar istediği g,bi şekillendirebilsin
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(a => a.ID);  // primary key
            builder.Property(a => a.CreatedDate).IsRequired(true);
            builder.Property(a => a.ModifiedDate).IsRequired(false);
            builder.Property(a => a.RemovedDate).IsRequired(false);   // nullable
            builder.Property(a => a.Statu).IsRequired(true).HasDefaultValue(Enums.Statu.Passive);          // not null 
        }
    }
}
