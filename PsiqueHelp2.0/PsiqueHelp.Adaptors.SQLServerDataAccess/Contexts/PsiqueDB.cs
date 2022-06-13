using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PsiqueHelp.Adaptors.SQLServerDataAccess.Entities;
using PsiqueHelp.Adaptors.SQLServerDataAccess.Utils;
using PsiqueHelp.Core.Domain.Models;

namespace PsiqueHelp.Adaptors.SQLServerDataAccess.Contexts
{


    public class PsiqueDB : DbContext
    {
        public DbSet<mediums> mediumS { get; set; }
        public DbSet<ConTer> conteR { get; set; }
        public DbSet<Psy_Da> psYDA { get; set; }
        public DbSet<LoginUsers> loginuSERS { get; set; }
        public DbSet<comments> commeNTS { get; set; }
        public DbSet<UserDa> useRDA { get; set; }
        public DbSet<Forum> forUM { get; set; }
        public DbSet<Notes> notES { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new EuserD());
            builder.ApplyConfiguration(new EpsyDa());
            builder.ApplyConfiguration(new Enotes());
            builder.ApplyConfiguration(new Emediums());
            builder.ApplyConfiguration(new Elogin());
            builder.ApplyConfiguration(new Eforum());
            builder.ApplyConfiguration(new EconTer());
            builder.ApplyConfiguration(new Ecomments());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {


            options.UseSqlServer(GlobalSetting.SqlServerConnectionString);
        }
    }
}

