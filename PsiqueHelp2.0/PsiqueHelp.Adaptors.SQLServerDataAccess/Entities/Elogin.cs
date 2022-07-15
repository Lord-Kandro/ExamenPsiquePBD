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

           
            
        }
    }
}
