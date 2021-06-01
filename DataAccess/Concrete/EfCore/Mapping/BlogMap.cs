using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EfCore.Mapping
{
    public class BlogMap:IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Title).HasMaxLength(100).IsRequired();
            builder.Property(x => x.ShortDescription).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Description).HasColumnType("ntext");
            builder.Property(x => x.ImagePath).HasMaxLength(300).IsRequired();

            builder.HasMany(x => x.Comments).WithOne(x => x.Blog).HasForeignKey(x => x.BlogId);
            builder.HasMany(x => x.CategoryBlogs).WithOne(x => x.Blog).HasForeignKey(x => x.BlogId);

        }
    }
}
