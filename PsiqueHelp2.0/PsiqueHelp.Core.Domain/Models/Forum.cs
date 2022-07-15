using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PsiqueHelp.Core.Domain.Models
{
    public class Forum
    {
        public Guid Id_Forum { get; set; }
        public string topic { get; set; }
        public Guid Id_UserDa { get; set; }
        [ForeignKey("Id_UserDa")]
        public UserDa user { get; set; }//llave hacia EuserDa - un usuario
        public Guid Id_User_Psy { get; set; }
        [ForeignKey("Id_User_Psy")]

        public Psy_Da psyda { get; set; }//llave hacia EpsyDa - un psicologo
        public List<comments> Coments { get; set; }//llave que es llamada en Eforum /muchos comentarios

        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }

}
