using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammersBLog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Data.Concrete.EntityFramework.Mappings
{
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
           builder.HasKey(x => x.Id);
           builder.Property(x => x.Id).ValueGeneratedOnAdd();
           builder.Property(x => x.Title).HasMaxLength(100);
           builder.Property(x=>x.Title).IsRequired();
           builder.Property(x=>x.Content).IsRequired();
           builder.Property(x =>x.Content).HasColumnType("NVARCHAR(MAX)");
           builder.Property(x=>x.Date).IsRequired();
           builder.Property(x =>x.SeoAuthor).IsRequired();
           builder.Property(x =>x.SeoAuthor).HasMaxLength(50);
           builder.Property(x =>x.SeoDescription).HasMaxLength(150);
           builder.Property(x => x.SeoDescription).IsRequired();
           builder.Property(x =>x.SeoTags).IsRequired();
           builder.Property(x => x.SeoTags).HasMaxLength(70);
           builder.Property(x => x.ViewsCount).IsRequired();
           builder.Property(x => x.CommentCount).IsRequired();
           builder.Property(x => x.Thumbnail).IsRequired();
           builder.Property(x => x.Thumbnail).HasMaxLength(250);
           builder.Property(x => x.CreatedByName).IsRequired();
           builder.Property(x => x.CreatedByName).HasMaxLength(50);
           builder.Property(x => x.ModifiedByName).IsRequired();
           builder.Property(x => x.ModifiedByName).HasMaxLength(50);
           builder.Property(x => x.CreatedDate).IsRequired();
           builder.Property(x => x.ModifiedDate).IsRequired();
           builder.Property(x => x.IsActive).IsRequired();
           builder.Property(x => x.IsDeleted).IsRequired();
           builder.Property(x => x.Note).HasMaxLength(500);
           builder.HasOne<Category>(x=>x.category).WithMany(c=>c.articles).HasForeignKey(x=>x.CategoryId);
           builder.HasOne<User>(x => x.users).WithMany(c => c.articles).HasForeignKey(x => x.UserId);
           builder.ToTable("Articles");

            builder.HasData(new Article
            {
                Id = 1,
                CategoryId=1,
                Title ="C# 9.0 ile .Net 5 Yenilikleri",
                Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                Thumbnail="default.jpg",
                SeoDescription= "C# 9.0 ile .Net 5 Yenilikleri",
                SeoTags="C#,C# 9,.Net 5,.Net Core",
                SeoAuthor="Hüseyin Cangür",
                Date=DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedDate = DateTime.Now,
                Note = "C# 9.0 ile .Net 5 Yenilikleri",
                UserId= 1,
                ViewsCount= 100,
                CommentCount=1
               
            },new Article
            {
                Id = 2,
                CategoryId = 2,
                Title = "C++ 11 ve 19 Yenilikleri",
                Content = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).",
                Thumbnail = "default.jpg",
                SeoDescription = "C++ 11 ve 19 Yenilikleri",
                SeoTags = "C#,C# 9,.Net 5,.Net Core",
                SeoAuthor = "Hüseyin Cangür",
                Date = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedDate = DateTime.Now,
                Note = "C++ 11 ve 19 Yenilikleri",
                UserId = 1,
                ViewsCount = 120,
                CommentCount = 1
            },
            new Article
            {
                Id = 3,
                CategoryId = 3,
                Title = "Javascript Es 2019 Yenilikleri",
                Content = "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.",
                Thumbnail = "default.jpg",
                SeoDescription = "Javascript Es 2019 Yenilikleri",
                SeoTags = "Javascript Es 2019 Yenilikleri",
                SeoAuthor = "Hüseyin Cangür",
                Date = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedDate = DateTime.Now,
                Note = "Javascript Es 2019 Yenilikleri",
                UserId = 1,
                ViewsCount = 140,
                CommentCount = 1
            }
            );



        }
    }
}
