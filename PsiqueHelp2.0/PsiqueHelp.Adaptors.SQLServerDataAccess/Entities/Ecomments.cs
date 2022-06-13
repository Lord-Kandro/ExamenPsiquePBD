using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PsiqueHelp.Core.Domain.Models;

namespace PsiqueHelp.Adaptors.SQLServerDataAccess.Entities
{
    class Ecomments : IEntityTypeConfiguration<comments>
    {
        public void Configure(EntityTypeBuilder<comments> builder)
        {
            builder.ToTable("tb_comments");
            builder.HasKey(c => new {c.Id_Forum, c.Id_UserDa});

            builder
                .HasOne(c => c.user)//un usuario viene de -models/comments
                .WithMany(ud => ud.Comments);//muchos comentarios viene de -models/userDa
            builder
                .HasOne(c => c.CommentsForum)//un foro viene de -models/comments
                .WithMany(f => f.Coments);//muchos comentarios viene de -models/forum
        }
                
    }
}
