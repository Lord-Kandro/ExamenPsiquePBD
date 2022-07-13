using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PsiqueHelp.Core.Domain.Models
{
    public class mediums
    {
        public Guid Id_Medios { get; set; }
        public string video { get; set; }
        public string music { get; set; }
        public string image { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }

        [ForeignKey("ConTer_id")]
        public ConTer contenido { get; set; }

    }

}
