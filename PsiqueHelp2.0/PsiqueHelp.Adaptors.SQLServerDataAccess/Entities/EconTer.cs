using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PsiqueHelp.Core.Domain.Models;

namespace PsiqueHelp.Adaptors.SQLServerDataAccess.Entities
{
    public class EconTer : IEntityTypeConfiguration<ConTer>
    {
        public void Configure(EntityTypeBuilder<ConTer> builder)
        {
            builder.ToTable("tb_ConTer");
            builder.HasKey(ct => ct.ConTer_id);

            builder
                .HasMany(ct => ct.mediums)//muchos medios viene de models/conTer
                .WithOne(me => me.contenido)//un contenido viene de models/mediums
               ;

            builder
                .HasMany(ct => ct.psycon)//muchos psicologos viene de models/ConTer
                .WithOne(pd => pd.conterp)//un contenido viene de models/Psy_Da
                ;
        }
        
    }
}
