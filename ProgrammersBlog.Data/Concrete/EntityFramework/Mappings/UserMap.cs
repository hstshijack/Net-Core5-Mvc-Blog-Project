﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammersBLog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Data.Concrete.EntityFramework.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
           builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id).ValueGeneratedOnAdd();
            builder.Property(x=>x.Email).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(50);
            builder.HasIndex(x => x.Email).IsUnique();
            builder.Property(x => x.Username).IsRequired();
            builder.Property(x => x.Username).HasMaxLength(20);
            builder.HasIndex(x => x.Username).IsUnique();
            builder.Property(x=>x.PasswordHash).IsRequired();
            builder.Property(x => x.PasswordHash).HasColumnType("VARBINARY(500)");
            builder.Property(x => x.Description).HasMaxLength(500);
            builder.Property(x=>x.FirstName).IsRequired();
            builder.Property(x=>x.FirstName).HasMaxLength(30);
            builder.Property(x => x.LastName).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(30);
            builder.Property(x=>x.Picture).IsRequired();
            builder.Property(x=>x.Picture).HasMaxLength(250);
            builder.HasOne<Role>(x => x.Role).WithMany(r => r.users).HasForeignKey(u=>u.RoleId);
            builder.Property(x => x.CreatedByName).IsRequired();
            builder.Property(x => x.CreatedByName).HasMaxLength(500);
            builder.Property(x => x.ModifiedByName).IsRequired();
            builder.Property(x => x.ModifiedByName).HasMaxLength(50);
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.ModifiedDate).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.Note).HasMaxLength(500);
            builder.ToTable("Users");

            builder.HasData(new User
            {

                Id = 1,
                RoleId = 1,
                FirstName = "Hüseyin",
                LastName = "Cangür",
                Username = "huseyincangur",
                Email = "cangurhuseyin@gmail.com",
                PasswordHash = Encoding.ASCII.GetBytes("0192023a7bbd73250516f069df18b500"),
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedDate = DateTime.Now,
                Description = "İll Admin Kullanıcı",
                Note = "Admin Kullanıcısı",
                Picture= "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcSX4wVGjMQ37PaO4PdUVEAliSLi8-c2gJ1zvQ&usqp=CAU",


            });



        }
    }
}
