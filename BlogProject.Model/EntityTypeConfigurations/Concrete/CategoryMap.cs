using BlogProject.Model.Entities.Concrete;
using BlogProject.Model.EntityTypeConfigurations.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogProject.Model.EntityTypeConfigurations.Concrete
{
    public class CategoryMap : BaseMap<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            // defaultta aksi söylenmedikçe not null olur(sınıf içinde tipleri nullable(?)/not null da yapabilrdik. BKZ=> baseEntity removeDate,ModifiedDate)
            builder.Property(a => a.Name).IsRequired(true);
            builder.Property(a => a.Description).IsRequired(true);


            base.Configure(builder);
        }

    }
}
