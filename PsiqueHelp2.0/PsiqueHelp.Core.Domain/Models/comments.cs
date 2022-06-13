using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace PsiqueHelp.Core.Domain.Models
{
    public class comments
    {
        public Guid Id_UserDa { get; set; }
        public Guid Id_Forum { get; set; }
        public string title { get; set; }
        public string comment { get; set; }
        public DateTime timedate { get; set; }
        [ForeignKey("Id_UserDa")]
        public UserDa user { get; set; }//llave que va hacia Euser-muchos usuarios

        [ForeignKey("Id_Forum")]
        public Forum CommentsForum { get; set; } //llave que va hacia Eforum-muchos comentarios

    }

}
