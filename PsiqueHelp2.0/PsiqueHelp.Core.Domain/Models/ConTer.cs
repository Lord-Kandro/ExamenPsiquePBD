using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;



namespace PsiqueHelp.Core.Domain.Models
{
    public class ConTer
    {
        public Guid ConTer_id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public List<mediums> mediums { get; set; }//llave que va hacia conTer -muchos medios
        public List<Psy_Da> psycon { get; set; }//llave que va hacia conTer -muchos psicologos

    }


}
