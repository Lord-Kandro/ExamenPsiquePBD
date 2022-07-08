using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PsiqueHelp.Core.Domain.Models
{
    public class Notes
    {
        public Guid id_Note { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public Guid Id_UserDa { get; set; }
        public DateTime date { get; set; }
        [ForeignKey("Id_UserDa")]
        public UserDa user { get; set; }//llave hacia Euser

        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }

}
