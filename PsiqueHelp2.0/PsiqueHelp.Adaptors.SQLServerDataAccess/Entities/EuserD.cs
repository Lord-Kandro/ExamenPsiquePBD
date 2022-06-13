using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PsiqueHelp.Core.Domain.Models;

namespace PsiqueHelp.Adaptors.SQLServerDataAccess.Entities
{
    public class EuserD : IEntityTypeConfiguration<UserDa>
    {
        public void Configure(EntityTypeBuilder<UserDa> builder)
        {
            builder.ToTable("tb_UserDa");
            builder.HasKey(ud => ud.Id_UserDa);

            builder
                .HasMany(ud => ud.Comments)//muchos comentarios-viene de models/UserDa
                .WithOne(c => c.user)//un usuario-viene de models/comments
                .HasPrincipalKey(ud => ud.Id_UserDa);
            builder
                .HasMany(ud => ud.forum)//muchos foros -viene de models/UserDa
                .WithOne(f => f.user)//un usuario - viene de Models/Forum
                .HasPrincipalKey(ud => ud.Id_UserDa);
            builder
                .HasMany(ud => ud.notes)//muchas notas -viene de models/UserDa
                .WithOne(n => n.user)//un usuario -viene de models/UserDa
                .HasPrincipalKey(ud => ud.Id_UserDa);
        }
    }
}
