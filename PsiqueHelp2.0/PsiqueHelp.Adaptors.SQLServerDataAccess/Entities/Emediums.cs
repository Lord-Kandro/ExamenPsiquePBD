using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PsiqueHelp.Core.Domain.Models;

namespace PsiqueHelp.Adaptors.SQLServerDataAccess.Entities
{
    public class Emediums : IEntityTypeConfiguration<mediums>
    {
        public void Configure(EntityTypeBuilder<mediums> builder)
        {
            builder.ToTable("tb_Mediums");
            builder.HasKey(m => m.Id_Medios);
        }
    }
}
