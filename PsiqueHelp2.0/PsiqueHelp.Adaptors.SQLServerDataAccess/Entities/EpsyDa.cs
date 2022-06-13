using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PsiqueHelp.Core.Domain.Models;

namespace PsiqueHelp.Adaptors.SQLServerDataAccess.Entities
{
    public class EpsyDa : IEntityTypeConfiguration<Psy_Da>
    {
        public void Configure(EntityTypeBuilder<Psy_Da> builder)
        {
            builder.ToTable("tb_PsyDa");
            builder.HasKey(pd => pd.Id_User_Psy);

            builder
                .HasMany(pd => pd.forum)//muchos foros viene de -models/psyDa
                .WithOne(f => f.psyda)// un psicologo viene de -models/Forum
                .HasPrincipalKey(pd => pd.Id_User_Psy);
        }
    }
}
