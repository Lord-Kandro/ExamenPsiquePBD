using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PsiqueHelp.Core.Domain.Models;

namespace PsiqueHelp.Adaptors.SQLServerDataAccess.Entities
{
    public class Eforum : IEntityTypeConfiguration<Forum>
    {
        public void Configure(EntityTypeBuilder<Forum> builder)
        {

            builder.ToTable("tb_Forum");
            builder.HasKey(f => f.Id_Forum);

            builder
                .HasMany(f => f.Coments)//muchos comentarios - viene de models/forum
                .WithOne(c => c.CommentsForum)//un foro - viene de models/comments
                .HasPrincipalKey(f => f.Id_Forum);

        }
    }
}
