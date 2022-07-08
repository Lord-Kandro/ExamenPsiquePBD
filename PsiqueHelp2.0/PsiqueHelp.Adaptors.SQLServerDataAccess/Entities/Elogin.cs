using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PsiqueHelp.Core.Domain.Models;

namespace PsiqueHelp.Adaptors.SQLServerDataAccess.Entities
{
    public class Elogin : IEntityTypeConfiguration<LoginUsers>
    {
        public void Configure(EntityTypeBuilder<LoginUsers> builder)
        {
            builder.ToTable("tb_LoginUsers");
            builder.HasKey(lu => lu.Id_Login);

            builder
                .HasMany(lu => lu.psyLog)//muchos psicologos - viene de models/LoginUsers
                .WithOne(pd => pd.login_users)//un sólo login -viene de models/Psy_Da
                .HasPrincipalKey(lu => lu.Id_Login);
            builder
                .HasMany(lu => lu.userLog)
                .WithOne(ud => ud.login_userId_Login)//un sólo login -viene de models/UserDa
                .HasPrincipalKey(lu => lu.Id_Login);
        }
    }
}
