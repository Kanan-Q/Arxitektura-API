using BlogApp.Core.Entites.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDAL.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(x => x.Id).IsUnique();
            builder.HasIndex(x => x.Username).IsUnique();
            builder.HasIndex(x => x.PasswordHash).IsUnique();
            builder.HasIndex(x => x.Email).IsUnique();
            builder.Property(x => x.Username).IsRequired().HasMaxLength(10);
            builder.Property(x => x.PasswordHash).IsRequired().HasMaxLength(10);
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.IsMale).IsRequired();
        }
    }
}
